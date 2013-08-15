using System;
using System.Collections.Generic;
using System.Text;
using TaxApp.InterfacesAndConstants;
using System.IO;
using log4net;
using NUnit.Framework;
using TaxBuilder.GraphicObjects;
using TaxBuilder.GraphicObjects.TaxAppRuntime;
using System.Reflection;
using System.Drawing;
using TaxApp.IntrinsicFunctions;
using System.Diagnostics;

namespace TaxAppClient.BusinessObjects
{
    /// <summary>
    /// Client side Application Information getter.  This should connect to the WCFServices to download information about the applications - storing it locally (cache).
    /// </summary>
    public class TaxAppInfo : ITaxAppInfo
    {
        private static readonly ILog theLogger = LogManager.GetLogger("TaxAppInfo");

        private UserConfigurationItems myUserConfigOptions;
        private Dictionary<string, Dictionary<int, List<NavigationNodeRecord>>> myParentIDToChildrenNodesDictionaryByAppName;  //this is used for both trees, since parent node indexes won't cross trees.
        private Dictionary<string, int> myTaxAppRootNodeIDByAppName;
        private Dictionary<string, int> myPrintRootNodeIDByAppName;
        private Dictionary<string, PageAndGraphicBinaryFileIndex> myPrintPageAndGraphicBinaryFileIndexByAppName;
        private Dictionary<string, PageAndGraphicBinaryFileIndex> myTaxAppPageAndGraphicBinaryFileIndexByAppName;
        private Dictionary<string, Dictionary<int, Dictionary<int, PageAndGraphicRecord>>> myPrintPageAndGraphicRecordByIndexLookupByAppName;
        private Dictionary<string, Dictionary<int, Dictionary<int, PageAndGraphicRecord>>> myTaxAppPageAndGraphicRecordByIndexLookupByAppName;
        private Dictionary<string, Dictionary<int, int>> myPrintPageIndexToBinaryFileIndexLookupByAppName;
        private Dictionary<string, Dictionary<int, int>> myTaxAppPageIndexToBinaryFileIndexLookupByAppName;
        private Dictionary<string, Dictionary<int, Dictionary<int, List<GraphicDataLinkRecord>>>> myGraphicDataLinksPageLookupByAppName;
        private Dictionary<int, ValueListRecord> myValueListsByID;

        #region ITaxAppInfo Members
        public void Initialize(UserConfigurationItems userConfigurationItems)
        {
            myUserConfigOptions = userConfigurationItems;
        }
        /// <summary>
        /// Get applications currently available.  Needs to include ClientID so licensing can be checked.
        /// </summary>
        /// <returns></returns>
        public List<string> GetApplicationNamesCurrentlyAvailable()
        {
            List<string> appNames = new List<string>();

            //we should probably download the list everytime - just in case there's some sort of "new purchase" but 
            //honestly the best way would be to open this up for a Refresh parm.

            //also check to see if the cache should be refreshed - do on a seperate thread
            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            try
            {
                string[] appNameStrings = myTACWCFService.GetListOfStrings("RequestApplicationNames");
                foreach (string s in appNameStrings)
                {
                    appNames.Add(s);
                }
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error communicating with WCFService during GetApplicationNamesCurrentlyAvailable call.");
                theLogger.Error("Error: ", ex);
            }
            finally 
            {
                myTACWCFService.Close();
            }
            
            return appNames;
        }

        public RunTimeNode GetApplicationRootRunTimeNode(string ApplicationName, AppTypeEnum TreeType, short Year)
        {
            theLogger.Debug("GetApplicationRootRunTimeNode.  ApplicationName: " + ApplicationName + " TreeType: " + TreeType.ToString());

            //we need to interogate the cache and see if the application information has already been downloaded
            CheckForAndDownloadNavigationInfo(ApplicationName, TreeType, Year);

            //there also should be some version checking on a "versioning" WCF service call that will drive this class.
            //then once down - de-serialize it
            LoadNavigationTree(ApplicationName, TreeType, Year);

            NavigationNodeRecord rootNodeNNR = new NavigationNodeRecord();
            int IDToLookFor = 0;
            if (TreeType == AppTypeEnum.TaxApp)
            {
                IDToLookFor = myTaxAppRootNodeIDByAppName[ApplicationName];
            }
            else if (TreeType == AppTypeEnum.Print)
            {
                IDToLookFor = myPrintRootNodeIDByAppName[ApplicationName];
            }
            //both root nodes should be in the dictionary entry for parentID = 0
            if (myParentIDToChildrenNodesDictionaryByAppName[ApplicationName].ContainsKey(0))
            {
                foreach (NavigationNodeRecord nnr in myParentIDToChildrenNodesDictionaryByAppName[ApplicationName][0])
                {
                    if (nnr.NodeID == IDToLookFor)
                    {
                        rootNodeNNR = nnr;
                    }
                }
            }

            RunTimeNode rtn = new RunTimeNode();
            rtn.ApplicationName = ApplicationName;
            rtn.AppType = TreeType;
            rtn.ProductYear = Year;
            ConvertNavigationNodeRecordIntoRunTimeNode(rtn, rootNodeNNR, ApplicationName);
            return rtn;
        }
        private void CheckForAndDownloadNavigationInfo(string ApplicationName, AppTypeEnum TreeType, short Year)
        {

            string filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), GetVariousFileNameMethods.GetApplicationInfoNavigationFileName(ApplicationName, TreeType, Year));
            FileInfo fi = new FileInfo(filepath);

            //TODO:  This will refresh every time - this is where the version checking system needs to come into play and obviously not download if already down - 
            //also needs to use any version in cache if the request doesn't work.
            if (fi.Exists)
                fi.Delete();
            string fileName = GetVariousFileNameMethods.GetApplicationInfoNavigationFileName(ApplicationName, TreeType, Year);
            DownLoadBinaryFiles(ApplicationName, fileName);

        }
        private void DownLoadBinaryFiles(string appName, string fileName)
        {
            byte[] filebytes = null;

            TaxAppClientServiceMTOMClient c = new TaxAppClientServiceMTOMClient();
            try
            {
                filebytes = c.RequestBinary(appName, fileName);
            }
            catch (Exception ex)
            {
                theLogger.Error("Error connecting to WCF binary file download service.", ex);
            }
            finally
            {
                c.Close();
            }

            if (filebytes == null)
            {
                return;
            }

            theLogger.Debug("File received.  Length: " + filebytes.Length);

            string filepath = string.Empty;
            if (appName == "Images")
            {
                string imageCacheDir = Path.Combine(StaticHelperMethods.GetCacheDirectory(), "Images");
                DirectoryInfo di = new DirectoryInfo(imageCacheDir);
                if (!di.Exists)
                    di.Create();
                filepath = Path.Combine(imageCacheDir, fileName);
                filepath = filepath + ".wmf";
            }
            else
            {
                filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), fileName);
            }

            theLogger.Debug("File writing to: " + filepath);
            using (FileStream sf = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                sf.Write(filebytes, 0, filebytes.Length);
            }
        }
        private void LoadNavigationTree(string ApplicationName, AppTypeEnum appType, short Year)
        {
            string fileName = Path.Combine(StaticHelperMethods.GetCacheDirectory(), GetVariousFileNameMethods.GetApplicationInfoNavigationFileName(ApplicationName, appType, Year));
            Dictionary<int, List<NavigationNodeRecord>> tempDictionary = new Dictionary<int, List<NavigationNodeRecord>>();
            if (appType == AppTypeEnum.TaxApp)
            {
                if (myTaxAppRootNodeIDByAppName == null)
                    myTaxAppRootNodeIDByAppName = new Dictionary<string, int>();
                int rootNodeID = 0;
                tempDictionary = NavigationNodeRecord.LoadNavigationTreeFromBINFile(fileName, out rootNodeID);
                if (!myTaxAppRootNodeIDByAppName.ContainsKey(ApplicationName))
                    myTaxAppRootNodeIDByAppName.Add(ApplicationName, rootNodeID);
            }
            else
            {
                if (myPrintRootNodeIDByAppName == null)
                    myPrintRootNodeIDByAppName = new Dictionary<string, int>();
                int rootNodeID2 = 0;
                tempDictionary = NavigationNodeRecord.LoadNavigationTreeFromBINFile(fileName, out rootNodeID2);
                if (!myPrintRootNodeIDByAppName.ContainsKey(ApplicationName))
                    myPrintRootNodeIDByAppName.Add(ApplicationName, rootNodeID2);
            }
            if (myParentIDToChildrenNodesDictionaryByAppName == null)
            {
                myParentIDToChildrenNodesDictionaryByAppName = new Dictionary<string, Dictionary<int, List<NavigationNodeRecord>>>();
            }

            if (!myParentIDToChildrenNodesDictionaryByAppName.ContainsKey(ApplicationName))
            {
                myParentIDToChildrenNodesDictionaryByAppName.Add(ApplicationName, tempDictionary);
            }
            else
            {
                foreach (KeyValuePair<int, List<NavigationNodeRecord>> kvp in tempDictionary)
                {
                    if (myParentIDToChildrenNodesDictionaryByAppName[ApplicationName].ContainsKey(kvp.Key))
                    {
                        //this should only happen on the two root nodes
                        foreach (NavigationNodeRecord nnr in kvp.Value)
                        {
                            myParentIDToChildrenNodesDictionaryByAppName[ApplicationName][kvp.Key].Add(nnr);
                        }
                    }
                    else
                        myParentIDToChildrenNodesDictionaryByAppName[ApplicationName].Add(kvp.Key, kvp.Value);
                }
            }
            theLogger.Debug("Navigation tree loaded from file.  Total records in ParentNode dictionary: " + myParentIDToChildrenNodesDictionaryByAppName[ApplicationName].Count);
            
        }
        private void ConvertNavigationNodeRecordIntoRunTimeNode(RunTimeNode newRuntimeNode, NavigationNodeRecord nnr, string applicationName)
        {
            newRuntimeNode.Name = nnr.NodeName;
            newRuntimeNode.NodeID = nnr.NodeID;
            newRuntimeNode.NodeType = (NavigationNodeTypeEnum)nnr.NodeType;
            newRuntimeNode.PageID = nnr.PageID;
            newRuntimeNode.ChildrenAlreadyLoaded = false;
            newRuntimeNode.HasChildren = myParentIDToChildrenNodesDictionaryByAppName[applicationName].ContainsKey(nnr.NodeID) ? true : false;
            newRuntimeNode.ImageIndex = GetImageIndexByNodeType(newRuntimeNode.NodeType, newRuntimeNode.Name);
            newRuntimeNode.HasConstraint = nnr.HasConstraint;
            newRuntimeNode.LoopRuntimePageID = nnr.LoopPageID;
            newRuntimeNode.LoopRuntimeGraphicID = nnr.LoopGraphicID;
            newRuntimeNode.AlternateActionNodeID = nnr.AlternateActionNodeID;
            newRuntimeNode.ShortcutNodeID = nnr.ShortcutNodeID;
        }
        private int GetImageIndexByNodeType(NavigationNodeTypeEnum nodeType, string nodeName)
        {
            switch (nodeType)
            {
                case NavigationNodeTypeEnum.DesignAttachmentNode:
                case NavigationNodeTypeEnum.DesignDiagnosticGroupNode:
                case NavigationNodeTypeEnum.DesignDiagnosticPageNode:
                case NavigationNodeTypeEnum.DesignFolderNode:
                case NavigationNodeTypeEnum.DesignHeaderNode:
                case NavigationNodeTypeEnum.DesignOrganizerGroupNode:
                case NavigationNodeTypeEnum.DesignOrganizerHeaderNode:
                case NavigationNodeTypeEnum.DesignOrganizerNode:
                case NavigationNodeTypeEnum.DesignPageNode:
                case NavigationNodeTypeEnum.DesignProjectGroupNode:
                case NavigationNodeTypeEnum.DesignProjectNode:
                case NavigationNodeTypeEnum.DesignTaxAppLivingTemplateNode:
                case NavigationNodeTypeEnum.DesignTaxAppTemplateNode:
                case NavigationNodeTypeEnum.DesignTaxFormGroupNode:
                case NavigationNodeTypeEnum.DesignTaxFormLivingTemplateNode:
                case NavigationNodeTypeEnum.DesignTaxFormTemplateNode:
                case NavigationNodeTypeEnum.DesignTemplateGroupNode:
                case NavigationNodeTypeEnum.DesignWorkpaperGroupNode:
                case NavigationNodeTypeEnum.DesignWorkpaperHeaderNode:
                case NavigationNodeTypeEnum.DesignWorkpaperNode:
                    return 0;  //this might be replaced with a red X or maybe a zero with a slash thru it to indicate that it is an error
                
                case NavigationNodeTypeEnum.PRTAlternateNode:
                    return 16;
                case NavigationNodeTypeEnum.PRTAttachmentNode:
                    return 5;
                case NavigationNodeTypeEnum.PRTAvailableFormsIndexNode:
                    return 7;
                case NavigationNodeTypeEnum.PRTDiagnosticsNode:
                    return 11;
                case NavigationNodeTypeEnum.PRTHeaderNode:
                    return 3;
                case NavigationNodeTypeEnum.PRTOrganizerOverrideNode:
                    return 12;
                case NavigationNodeTypeEnum.PRTOverrideNode:
                    return 12;
                case NavigationNodeTypeEnum.PRTPageNode:
                    return 4;
                case NavigationNodeTypeEnum.PRTRootNode:
                    return 2;
                case NavigationNodeTypeEnum.PRTShortcutNode:
                    return 13;
                case NavigationNodeTypeEnum.PRTUnavailableFormsIndexNode:
                    return 8;
                
                case NavigationNodeTypeEnum.TAAlternateNode:
                    return 16;
                case NavigationNodeTypeEnum.TAHeaderNode:
                    if (nodeName == "Organizer") return 18;
                    if (nodeName == "Workpaper") return 17;
                    return 3;
                case NavigationNodeTypeEnum.TAOrganizerNode:
                    return 21;
                case NavigationNodeTypeEnum.TARootNode:
                    return 2;
                case NavigationNodeTypeEnum.TATabbedPageNode:
                    return 7;
                case NavigationNodeTypeEnum.TAWorkpaperNode:
                    return 20;
                default:
                    break;
            }
            return 0;
        }

        public SortedList<int, RunTimeNode> GetRunTimeNodesChildren(RunTimeNode runTimeNode)
        {
            theLogger.Debug("GetRunTimeNodesChildren called. ");
            SortedList<int, RunTimeNode> children = new SortedList<int, RunTimeNode>();
            if (myParentIDToChildrenNodesDictionaryByAppName.ContainsKey(runTimeNode.ApplicationName))
            {
                if (myParentIDToChildrenNodesDictionaryByAppName[runTimeNode.ApplicationName].ContainsKey(runTimeNode.NodeID))
                {
                    int count = 1;
                    foreach (NavigationNodeRecord nnr in myParentIDToChildrenNodesDictionaryByAppName[runTimeNode.ApplicationName][runTimeNode.NodeID])
                    {
                        RunTimeNode childRTN = new RunTimeNode();
                        childRTN.ApplicationName = runTimeNode.ApplicationName;
                        childRTN.AppType = runTimeNode.AppType;
                        childRTN.ProductYear = runTimeNode.ProductYear;
                        ConvertNavigationNodeRecordIntoRunTimeNode(childRTN, nnr, runTimeNode.ApplicationName);
                        children.Add(count, childRTN);
                        count++;
                    }
                }
            }
            theLogger.Debug("Returning child count: " + children.Count);
            return children;
        }

        public RunTimePage GetPage(RunTimeNode runTimeNode)
        {
            RunTimePage RTPage = new RunTimePage();

            //check for the PageandGraphicBinary file index binary
            if (myPrintPageAndGraphicBinaryFileIndexByAppName == null)
            {
                myPrintPageAndGraphicBinaryFileIndexByAppName = new Dictionary<string, PageAndGraphicBinaryFileIndex>();
                myTaxAppPageAndGraphicBinaryFileIndexByAppName = new Dictionary<string, PageAndGraphicBinaryFileIndex>();
            }

            if (!myPrintPageAndGraphicBinaryFileIndexByAppName.ContainsKey(runTimeNode.ApplicationName))
            {
                CheckForDownloadAndParsePageIndexFile(runTimeNode.ApplicationName, runTimeNode.ProductYear);
            }

            PageAndGraphicRecord pgr = null;
            if (runTimeNode.AppType == AppTypeEnum.TaxApp)
            {
                if (myTaxAppPageIndexToBinaryFileIndexLookupByAppName[runTimeNode.ApplicationName].ContainsKey(runTimeNode.PageID))
                {
                    int fileIndex = myTaxAppPageIndexToBinaryFileIndexLookupByAppName[runTimeNode.ApplicationName][runTimeNode.PageID];
                    if (myTaxAppPageAndGraphicRecordByIndexLookupByAppName == null)
                        myTaxAppPageAndGraphicRecordByIndexLookupByAppName = new Dictionary<string, Dictionary<int, Dictionary<int, PageAndGraphicRecord>>>();
                    if (!myTaxAppPageAndGraphicRecordByIndexLookupByAppName.ContainsKey(runTimeNode.ApplicationName))
                    {
                        myTaxAppPageAndGraphicRecordByIndexLookupByAppName.Add(runTimeNode.ApplicationName, new Dictionary<int, Dictionary<int, PageAndGraphicRecord>>());
                    }
                    if (!myTaxAppPageAndGraphicRecordByIndexLookupByAppName[runTimeNode.ApplicationName].ContainsKey(fileIndex))
                    {
                        CheckForDownloadAndParsePageAndGraphicBinaryFile(fileIndex, runTimeNode.AppType, runTimeNode.ApplicationName);
                    }

                    pgr = myTaxAppPageAndGraphicRecordByIndexLookupByAppName[runTimeNode.ApplicationName][fileIndex][runTimeNode.PageID];
                }
            }
            else
            {
                if (myPrintPageIndexToBinaryFileIndexLookupByAppName[runTimeNode.ApplicationName].ContainsKey(runTimeNode.PageID))
                {
                    int fileIndex = myPrintPageIndexToBinaryFileIndexLookupByAppName[runTimeNode.ApplicationName][runTimeNode.PageID];
                    if (myPrintPageAndGraphicRecordByIndexLookupByAppName == null)
                        myPrintPageAndGraphicRecordByIndexLookupByAppName = new Dictionary<string, Dictionary<int, Dictionary<int, PageAndGraphicRecord>>>();
                    if (!myPrintPageAndGraphicRecordByIndexLookupByAppName.ContainsKey(runTimeNode.ApplicationName))
                    {
                        myPrintPageAndGraphicRecordByIndexLookupByAppName.Add(runTimeNode.ApplicationName, new Dictionary<int, Dictionary<int, PageAndGraphicRecord>>());
                    }
                    if (!myPrintPageAndGraphicRecordByIndexLookupByAppName[runTimeNode.ApplicationName].ContainsKey(fileIndex))
                    {
                        CheckForDownloadAndParsePageAndGraphicBinaryFile(fileIndex, runTimeNode.AppType, runTimeNode.ApplicationName);
                    }

                    pgr = myPrintPageAndGraphicRecordByIndexLookupByAppName[runTimeNode.ApplicationName][fileIndex][runTimeNode.PageID];
                }

            }
            if (pgr != null)
            {
                RTPage = ConvertPageAndGraphicRecordToRunTimePage(pgr);
                RTPage.RecordLineage = runTimeNode.RecordLineage;
                RTPage.BackGroundImage = GetImage(RTPage.PageProperties.ImageInfoID);
                RTPage.DataLinks = GetDataLinks(runTimeNode.ApplicationName, RTPage.PageID, runTimeNode.ProductYear);
                BindValueLists(RTPage, runTimeNode.ApplicationName, runTimeNode.ProductYear);
            }
            else
            {
                //make the RTPage say something like page not found in binary.
            }

            return RTPage;
        }
        private RunTimePage ConvertPageAndGraphicRecordToRunTimePage(PageAndGraphicRecord pgr)
        {
            RunTimePage rtPage = new RunTimePage();
            rtPage.PageID = pgr.PageID;
            rtPage.PageType = (PageTypeEnum)pgr.PageType;
            rtPage.PageProperties = PageAndGraphicRecord.GetPagePropertiesObjectFromPageRecordAdditionalProperties(pgr.PageType, pgr.AdditionalProperties);
            foreach (IGraphicsObject graphic in GraphicRecord.GetGraphicCollectionFromGraphicRecords(pgr.GraphicRecords))
            {
                rtPage.GraphicsCollection.Add(graphic);
            }
            
            return rtPage;
        }
        private void BindValueLists(RunTimePage rtPage, string appName, short year)
        {
            if (myValueListsByID == null)
            {
                            
                string filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), GetVariousFileNameMethods.GetValueListFileName(year.ToString()));
                FileInfo fi = new FileInfo(filepath);

                if (fi.Exists)
                    fi.Delete();
                string fileName = GetVariousFileNameMethods.GetValueListFileName(year.ToString());
                DownLoadBinaryFiles(appName, fileName);

                myValueListsByID = ValueListRecord.LoadValueListFromBINFile(filepath);
            }
            foreach (GraphicObject g in rtPage.GraphicsCollection)
            { 
                if (g.GetType() == typeof(DropDownListGraphic))
                {
                    if (myValueListsByID.ContainsKey(((DropDownListGraphic)g).BoundToValueListID))
                    {
                        ValueListRecord vlr = myValueListsByID[((DropDownListGraphic)g).BoundToValueListID];
                        ((DropDownListGraphic)g).ValueListItems.Add("(none)");
                        foreach (KeyValuePair<string, string> vals in vlr.ValueListItems)
                        {
                            ((DropDownListGraphic)g).ValueListItems.Add(vals.Key);
                        }
                    }
                }
                if (g.GraphicCollection.Count > 0)
                {
                    BindValueListsHelper(g);
                }
            }
        }
        private void BindValueListsHelper(GraphicObject graphic)
        {
            foreach (GraphicObject g in graphic.GraphicCollection)
            {
                if (g.GetType() == typeof(DropDownListGraphic))
                {
                    if (myValueListsByID.ContainsKey(((DropDownListGraphic)g).BoundToValueListID))
                    {
                        ValueListRecord vlr = myValueListsByID[((DropDownListGraphic)g).BoundToValueListID];
                        ((DropDownListGraphic)g).ValueListItems.Add("(none)");
                        foreach (KeyValuePair<string, string> vals in vlr.ValueListItems)
                        {
                            ((DropDownListGraphic)g).ValueListItems.Add(vals.Key);
                        }
                    }
                }
                if (g.GraphicCollection.Count > 0)
                {
                    BindValueListsHelper(g);
                }
            }

        }
        private Dictionary<int, Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>> GetDataLinks(string appName, int pageID, short year)
        {
            Dictionary<int, Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>> graphicDataLinksByGraphicID = new Dictionary<int,Dictionary<KeyValuePair<int, int>,GraphicDataLinkRecord>>();
            try
            {
                if (myGraphicDataLinksPageLookupByAppName == null)
                    myGraphicDataLinksPageLookupByAppName = new Dictionary<string, Dictionary<int, Dictionary<int, List<GraphicDataLinkRecord>>>>();
                if (!myGraphicDataLinksPageLookupByAppName.ContainsKey(appName))
                { 
                    CheckForDownloadAndParseGraphicDataLinksBinaryFile(appName, year);

                }
                if (myGraphicDataLinksPageLookupByAppName[appName].ContainsKey(pageID))
                { 
                    //now to process them into what the CAB expects
                    foreach (KeyValuePair<int, List<GraphicDataLinkRecord>> graphicsDLsByGraphicID in myGraphicDataLinksPageLookupByAppName[appName][pageID])
                    {
                        Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord> links = new Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>();
                        foreach (GraphicDataLinkRecord glinks in graphicsDLsByGraphicID.Value)
                        {
                            links.Add(new KeyValuePair<int, int>(glinks.GraphicIDKey, glinks.PageIDKey), glinks);
                        }
                        graphicDataLinksByGraphicID.Add(graphicsDLsByGraphicID.Key, links);
                    }
                }
                //if it doesn't then there are no data links from or to this page.
            }
            catch (Exception ex)
            {
                theLogger.Error("Error retrieving data links for page: " + pageID, ex);
            }
            return graphicDataLinksByGraphicID;
        }
        private void CheckForDownloadAndParseGraphicDataLinksBinaryFile(string appName, short year)
        {
            string fileName = GetVariousFileNameMethods.GetDataLinkFileName(appName, year.ToString());
            string filePath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), fileName);
            File.Delete(filePath);

            DownLoadBinaryFiles(appName, fileName);

            myGraphicDataLinksPageLookupByAppName.Add(appName, GraphicDataLinkPageRecord.LoadGraphicDataLinkRecordsFromBINFileByPageByGraphic(filePath));
        }

        private void CheckForDownloadAndParsePageAndGraphicBinaryFile(int fileIndex, AppTypeEnum appType, string applicationName)
        {
            try
            {
                string fileName = string.Empty;
                string filepath = string.Empty;
                if (appType == AppTypeEnum.TaxApp)
                {
                    fileName = myTaxAppPageAndGraphicBinaryFileIndexByAppName[applicationName].ListOfFileIndexAndFileNames[fileIndex];
                    filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), fileName);
                }
                else
                {
                    fileName = myPrintPageAndGraphicBinaryFileIndexByAppName[applicationName].ListOfFileIndexAndFileNames[fileIndex];
                    filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), fileName);
                }
                FileInfo fi = new FileInfo(filepath);

                //TODO:  This will refresh every time - this is where the version checking system needs to come into play and obviously not download if already down - 
                //also needs to use any version in cache if the request doesn't work.
                if (fi.Exists)
                    fi.Delete();

                DownLoadBinaryFiles(applicationName, fileName);

                if (appType == AppTypeEnum.TaxApp)
                {
                    myTaxAppPageAndGraphicRecordByIndexLookupByAppName[applicationName].Add(fileIndex, PageAndGraphicRecord.LoadPageAndGraphicFromBINFile(filepath));
                }
                else
                {
                    myPrintPageAndGraphicRecordByIndexLookupByAppName[applicationName].Add(fileIndex, PageAndGraphicRecord.LoadPageAndGraphicFromBINFile(filepath));
                }
                
                
            }
            catch (Exception ex)
            {
                theLogger.Error("Error checking cache and downloading page and graphic file.  ", ex);
            }
        }
        private void CheckForDownloadAndParsePageIndexFile(string applicationName, short year)
        {
            try
            {
                string fileName = GetVariousFileNameMethods.GetApplicationInfoPageIndexFileName(applicationName, AppTypeEnum.Print, year);
                string fileName2 = GetVariousFileNameMethods.GetApplicationInfoPageIndexFileName(applicationName, AppTypeEnum.TaxApp, year);

                string filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), fileName);
                string filepath2 = Path.Combine(StaticHelperMethods.GetCacheDirectory(), fileName2);
                
                FileInfo fi = new FileInfo(filepath);
                FileInfo fi2 = new FileInfo(filepath2);

                //TODO:  This will refresh every time - this is where the version checking system needs to come into play and obviously not download if already down - 
                //also needs to use any version in cache if the request doesn't work.
                if (fi.Exists)
                    fi.Delete();
                if (fi2.Exists)
                    fi2.Delete();

                DownLoadBinaryFiles(applicationName, fileName);
                DownLoadBinaryFiles(applicationName, fileName2);

                myPrintPageAndGraphicBinaryFileIndexByAppName.Add(applicationName, PageAndGraphicBinaryFileIndex.LoadPageAndGraphicBinaryFileIndexFromBINFile(filepath));
                myTaxAppPageAndGraphicBinaryFileIndexByAppName.Add(applicationName, PageAndGraphicBinaryFileIndex.LoadPageAndGraphicBinaryFileIndexFromBINFile(filepath2));

                if (myPrintPageIndexToBinaryFileIndexLookupByAppName == null)
                {
                    myPrintPageIndexToBinaryFileIndexLookupByAppName = new Dictionary<string, Dictionary<int, int>>();
                    myTaxAppPageIndexToBinaryFileIndexLookupByAppName = new Dictionary<string, Dictionary<int, int>>();
                }

                Dictionary<int, int> tempPrintPageIndexToBinaryFileIndexLookup = new Dictionary<int, int>();
                Dictionary<int, int> tempTaxAppPageIndexToBinaryFileIndexLookup = new Dictionary<int, int>();
                
                foreach (KeyValuePair<int, string> kvp in myPrintPageAndGraphicBinaryFileIndexByAppName[applicationName].ListOfFileIndexAndFileNames)
                {
                    int fileIndex = kvp.Key;
                    foreach (int i in myPrintPageAndGraphicBinaryFileIndexByAppName[applicationName].ForFileIndexListOfPageIDs[fileIndex])
                    {
                        tempPrintPageIndexToBinaryFileIndexLookup.Add(i, fileIndex);
                    }
                }
                myPrintPageIndexToBinaryFileIndexLookupByAppName.Add(applicationName, tempPrintPageIndexToBinaryFileIndexLookup);

                foreach (KeyValuePair<int, string> kvp in myTaxAppPageAndGraphicBinaryFileIndexByAppName[applicationName].ListOfFileIndexAndFileNames)
                {
                    int fileIndex = kvp.Key;
                    foreach (int i in myTaxAppPageAndGraphicBinaryFileIndexByAppName[applicationName].ForFileIndexListOfPageIDs[fileIndex])
                    {
                        tempTaxAppPageIndexToBinaryFileIndexLookup.Add(i, fileIndex);
                    }
                }
                myTaxAppPageIndexToBinaryFileIndexLookupByAppName.Add(applicationName, tempTaxAppPageIndexToBinaryFileIndexLookup);
            }
            catch (Exception ex)
            {
                theLogger.Error("Error checking cache and downloading page and graphic index file.  ", ex);
            }
        }

        public System.Drawing.Image GetImage(int ImageID)
        {
            if (ImageID == 0)
                return null;
            //this'll call the web service
            System.Drawing.Image i = null;
            string filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), "Images");
            filepath = Path.Combine(filepath, ImageID.ToString());
            FileInfo fi = new FileInfo(filepath);
            if (!fi.Exists)
            {
                DownLoadBinaryFiles("Images", ImageID.ToString());    
            }
            //TODO: make an update to not have to write an ext to the file.
            filepath = filepath + ".wmf";
            theLogger.Debug("Loading image ID: " + ImageID + " from file: " + filepath);
            i = Image.FromFile(filepath);
            

            return i;
        }
        
        #endregion
        public Stack<int> GetParentNodeChainForPageID(int PageID)
        {
            

            //TODO: implement this 
            return new Stack<int>();
        }

    }
    namespace Tests
    {
        [TestFixture] public class TaxAppInfoTests
        {
            private Process WCFprocess = null;
            [TestFixtureSetUp]
            public void Setup()
            {
                //these are to exercise the exception handling of not being able to communicate with the WCF service
                TaxAppInfo o = new TaxAppInfo();
                UserConfigurationItems uCon = new UserConfigurationItems();
                o.Initialize(uCon);
                o.GetApplicationNamesCurrentlyAvailable();
                o.GetApplicationRootRunTimeNode("TestApplication", AppTypeEnum.TaxApp, uCon.Year);


                string WCFEXEName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\TaxAppClient.WCFServiceHost\\bin\\Debug\\TaxAppClient.WCFServiceHost.exe");
                Console.WriteLine("Loading WCF Service.  WCFEXEName: " + WCFEXEName);
                WCFprocess = System.Diagnostics.Process.Start(WCFEXEName);
            }

            [TestFixtureTearDown]
            public void TearDown()
            {
                if (WCFprocess != null)
                    WCFprocess.Kill();

            }

            /// <summary>
            ///in order to run these tests, the GraphicObjects.TaxAppRuntime.Tests.BuildSampleApplication.Build method needs to be ran.
            ///also the WCFServiceHost's app.config setting needs to point at the outputdirectory of those tests (bin\debug\RunTimebinaries) of where the unit tests are ran.
            ///TaxBuilder.GraphicObjects.TaxAppRuntime.Tests.BuildSampleApplication.Build();
            /// </summary>
            [Test]
            public void InitializeTest()
            {
                TaxAppInfo o = new TaxAppInfo();
                UserConfigurationItems ucon = new UserConfigurationItems();
                o.Initialize(ucon);

                
                List<string> apps = o.GetApplicationNamesCurrentlyAvailable();
                Assert.IsNotNull(apps);
                bool found = false;
                foreach (string s in apps)
                {
                    Console.WriteLine("Application found: " + s);
                    if (s == "TestApplication")
                        found = true;

                }
                Assert.IsTrue(found);

                RunTimeNode root = o.GetApplicationRootRunTimeNode("TestApplication", AppTypeEnum.TaxApp, ucon.Year);
                Assert.IsNotNull(root);
                SortedList<int, RunTimeNode> rootNodes = o.GetRunTimeNodesChildren(root);
                Assert.IsNotNull(rootNodes);

                RunTimeNode rootTestApp = o.GetApplicationRootRunTimeNode("TestApplication", AppTypeEnum.TaxApp, ucon.Year);
                RunTimeNode rootTestPrint = o.GetApplicationRootRunTimeNode("TestApplication", AppTypeEnum.Print, ucon.Year);
                Assert.IsNotNull(rootTestApp);
                Assert.IsNotNull(rootTestPrint);

                SortedList<int, RunTimeNode> rootTestAppNodes = o.GetRunTimeNodesChildren(rootTestApp);
                SortedList<int, RunTimeNode> rootTestPrintNodes = o.GetRunTimeNodesChildren(rootTestPrint);
                Assert.IsNotNull(rootTestAppNodes);
                Assert.IsNotNull(rootTestPrintNodes);

                List<RunTimeNode> rtnWithPages = new List<RunTimeNode>();
                List<RunTimeNode> rtnWithPagesPrint = new List<RunTimeNode>();
                int pageID = 0;
                int pageIDprint = 0;
                foreach (KeyValuePair<int, RunTimeNode> kvp in rootTestAppNodes)
                {
                    if (kvp.Value.PageID > 0)
                    {
                        pageID = kvp.Value.PageID;
                        rtnWithPages.Add(kvp.Value);
                    }

                    SortedList<int, RunTimeNode> secondLevelNodes = o.GetRunTimeNodesChildren(kvp.Value);
                    foreach (KeyValuePair<int, RunTimeNode> kvp2 in secondLevelNodes)
                    {
                        if (kvp2.Value.PageID > 0)
                        {
                            pageID = kvp2.Value.PageID;
                            rtnWithPages.Add(kvp2.Value);
                        }
                    }
                }
                foreach (KeyValuePair<int, RunTimeNode> kvp in rootTestPrintNodes)
                {
                    if (kvp.Value.PageID > 0)
                    {
                        pageIDprint = kvp.Value.PageID;
                        rtnWithPagesPrint.Add(kvp.Value);
                    }
                    SortedList<int, RunTimeNode> secondLevelNodes = o.GetRunTimeNodesChildren(kvp.Value);
                    foreach (KeyValuePair<int, RunTimeNode> kvp2 in secondLevelNodes)
                    {
                        if (kvp2.Value.PageID > 0)
                        {
                            pageIDprint = kvp2.Value.PageID;
                            rtnWithPagesPrint.Add(kvp2.Value);
                        }
                    }
                }

                Assert.AreNotEqual(0, pageID);
                Assert.AreNotEqual(0, pageIDprint);

                List<RunTimePage> rtpagesTest = new List<RunTimePage>();
                foreach (RunTimeNode rtnPage in rtnWithPages)
                {
                    rtpagesTest.Add(o.GetPage(rtnPage));
                }
                Assert.IsNotNull(rtpagesTest[0]);

                List<RunTimePage> rtpTestPrint = new List<RunTimePage>();
                foreach (RunTimeNode rtnPrint in rtnWithPagesPrint)
                {
                    rtpTestPrint.Add(o.GetPage(rtnPrint));
                }
                Assert.IsNotNull(rtpTestPrint[0]);

            }
        }
    }
}
