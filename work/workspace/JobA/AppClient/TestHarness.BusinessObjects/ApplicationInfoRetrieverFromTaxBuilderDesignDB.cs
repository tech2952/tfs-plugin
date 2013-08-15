using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Text;
using log4net;
using NUnit.Framework;
using TaxApp.IntrinsicFunctions;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.BusinessObjects;
using TaxBuilder.DataObjects;
using TaxBuilder.GraphicObjects;
using Infragistics.Win.UltraWinTree;
using System.Reflection;
using TaxBuilder.DataObjects.CollectionClasses;
using TaxBuilder.DataObjects.EntityClasses;
using TaxBuilder.DataObjects.FactoryClasses;
using TaxBuilder.DataObjects.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using TaxBuilder.GraphicObjects.TaxAppRuntime;

namespace TestHarness.BusinessObjects
{
    public class ApplicationInfoRetrieverFromTaxBuilderDesignDB : ITaxAppInfo 
    {
        private static readonly ILog theLogger = LogManager.GetLogger("ApplicationInfoRetriever");
        
        private UserConfigurationItems myUserConfigurationItems;

        public ApplicationInfoRetrieverFromTaxBuilderDesignDB(){}

        #region IRetrieveApplicationInformation Members
        public void Initialize(UserConfigurationItems userConfigurationItems) 
        {
            myUserConfigurationItems = userConfigurationItems;
            SetConnectionPropertiesInConfiguration();
            string ServerName = myUserConfigurationItems.DatabaseAndBinaryPathSettings.DesignDatabaseServerName;
            string DatabaseName = myUserConfigurationItems.DatabaseAndBinaryPathSettings.DesignDatabaseName;
            theLogger.Debug("Application Retriever Initializing...");
            DesignDatabaseConnectionSwitcher.SetServerAndDatabase(ServerName, DatabaseName);
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            TaxBuilder.BusinessObjects.DatabaseInitializer di = TaxBuilder.BusinessObjects.DatabaseInitializer.GetInstance();
            if (di.DatabaseInitialized)
            {
                theLogger.Info("Connection to Design Database established and verified");
                theLogger.Info("Database Server: " + ServerName);
                theLogger.Info("       Database: " + DatabaseName);
            }
            else 
            {
                theLogger.Error("Connection to Design Database not verified");
            }
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
        }

        private void SetConnectionPropertiesInConfiguration()
        {
            //set up the database settings in the configuration file
            AppSettingsReader asr = new AppSettingsReader();
            string MainConnString = asr.GetValue("Main.ConnectionString", typeof(string)).ToString();
            string DesignConnString = asr.GetValue("Main.ConnectionStringForDesignDatabase", typeof(string)).ToString();
            string[] MainConnStringSplit = MainConnString.Split(new char[1] { Convert.ToChar(";") });
            string[] DesignConnStringSplit = DesignConnString.Split(new char[1] { Convert.ToChar(";") });

            if (MainConnStringSplit.Length > 2)
            {
                if (MainConnStringSplit[0].ToLower().StartsWith("data source="))
                {
                    myUserConfigurationItems.DatabaseAndBinaryPathSettings.LocatorDatabaseServerName = MainConnStringSplit[0].Substring(12);
                }
                if (MainConnStringSplit[1].ToLower().StartsWith("initial catalog="))
                {
                    myUserConfigurationItems.DatabaseAndBinaryPathSettings.LocatorDatabaseName = MainConnStringSplit[1].Substring(16);
                }
            }
            if (DesignConnStringSplit.Length > 2)
            {
                if (DesignConnStringSplit[0].ToLower().StartsWith("data source="))
                {
                    myUserConfigurationItems.DatabaseAndBinaryPathSettings.DesignDatabaseServerName = DesignConnStringSplit[0].Substring(12);
                }
                if (DesignConnStringSplit[1].ToLower().StartsWith("initial catalog="))
                {
                    myUserConfigurationItems.DatabaseAndBinaryPathSettings.DesignDatabaseName = DesignConnStringSplit[1].Substring(16);
                }
            }
        }


        public List<string> GetApplicationNamesCurrentlyAvailable()
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();

            NavigationCollectionImpl nci = new NavigationCollectionImpl();
            List<string> al = new List<string>();
            foreach (string s in nci.CurrentApps)
            {
                al.Add(s);
            }
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();

            return al;
        }
        private NavigationImpl myNavImpl;

        public RunTimeNode GetApplicationRootRunTimeNode(string ApplicationName, AppTypeEnum treeType, short Year)
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();

            UltraTree tree = new UltraTree();
            if (myNavImpl == null)
            {
                myNavImpl = new NavigationImpl(ApplicationName);
            }
            switch (treeType)
            {
                case AppTypeEnum.Print:
                    myNavImpl.LoadPrintRunTimeTree(tree, ApplicationName, true);
                    break;
                case AppTypeEnum.TaxApp:
                    myNavImpl.LoadTaxAppTree(tree, ApplicationName);
                    break;
                default:
                    break;
            }
            RunTimeNode rootNode = ConvertBaseNodeImplIntoRunTimeNode((BaseNodeImpl)tree.Nodes[1].Tag);
            rootNode.ApplicationName = ApplicationName;
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return rootNode;
        }
        private UltraTreeNode ConvertRunTimeNodeIntoUltraTreeNodeWithBaseNodeImplInTag(RunTimeNode runtimeNode)
        {
            string BusinessObjectNamespace = "TaxBuilder.BusinessObjects";
            TaxBuilder.DataObjects.EntityClasses.NavigationNodeEntity nodeEntity = new TaxBuilder.DataObjects.EntityClasses.NavigationNodeEntity(runtimeNode.NodeID);
            string strTempNodeImpl = BusinessObjectNamespace + "." + runtimeNode.NodeType.ToString() + "Impl";
            Assembly boAssembly = Assembly.Load(BusinessObjectNamespace);
            BaseNodeImpl nodeImpl = ((BaseNodeImpl)boAssembly.CreateInstance(strTempNodeImpl));
            return nodeImpl.GetNode(nodeEntity, null);            
        }
        private RunTimeNode ConvertBaseNodeImplIntoRunTimeNode(BaseNodeImpl basenodeImpl)
        {
            RunTimeNode rtn = new RunTimeNode();
            rtn.PageID = basenodeImpl.PageID;
            rtn.NodeID = basenodeImpl.NavNode.Navigation_Node_ID;
            rtn.Name = basenodeImpl.NodeSetablePropertiesObject.NodeName;
            rtn.NodeType = basenodeImpl.NodeType;
            rtn.ImageIndex = (int) basenodeImpl.ImageType;
            rtn.HasChildren = basenodeImpl.HasChildren;
            rtn.ChildrenAlreadyLoaded = basenodeImpl.ChildrenAlreadyLoaded;

            int assignmentID = ((ICanHaveAConstraintScriptAssignment)basenodeImpl.NodeSetablePropertiesObject).ConstraintAssignmentID;
            
            if (assignmentID != 0)
            {
                rtn.HasConstraint = true;
            }
            if (basenodeImpl.NodeSetablePropertiesObject.GetType().GetInterface("ICanHaveAGraphicIDAssignedToMe") != null)
            {
                rtn.LoopRuntimeGraphicID = ((ICanHaveAGraphicIDAssignedToMe)basenodeImpl.NodeSetablePropertiesObject).GraphicID;
                rtn.LoopRuntimePageID = ((ICanHaveAGraphicIDAssignedToMe)basenodeImpl.NodeSetablePropertiesObject).PageID;
            }
            return rtn;

        }

        public SortedList<int, RunTimeNode> GetRunTimeNodesChildren(RunTimeNode RunTimeNode)
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();

            UltraTree tree = new UltraTree();
            UltraTreeNode utn = ConvertRunTimeNodeIntoUltraTreeNodeWithBaseNodeImplInTag(RunTimeNode);
            myNavImpl.SetName(RunTimeNode.ApplicationName);
            myNavImpl.LoadApplicationNode(utn, true);
            //the node comes back with children with dummy nodes as their children if they have them.
            SortedList<int, RunTimeNode> sl = new SortedList<int, RunTimeNode>();

            int i = 0;
            foreach (UltraTreeNode utnchildren in utn.Nodes)
            {
                RunTimeNode rtn = ConvertBaseNodeImplIntoRunTimeNode((BaseNodeImpl)utnchildren.Tag);
                rtn.ApplicationName = RunTimeNode.ApplicationName;
                sl.Add(i, rtn);
                i++;
            }

            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return sl;
        }

        public RunTimePage GetPage(RunTimeNode RunTimeNode)
        {
            if (RunTimeNode.NodeType == NavigationNodeTypeEnum.TATabbedPageNode)
            {
                theLogger.Debug("Tabbed page selected");
            }
            if (RunTimeNode.ShowTaxFormSurface)
            {
                DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
                PageImpl pi = new PageImpl(RunTimeNode.PageID, RunTimeNode.NodeType);
                pi.GetPageGraphics();
                
                RunTimePage rtp = ConvertPageImplToRunTimePage(pi, RunTimeNode);
                if (RunTimeNode.LoopRecordID != 0)
                {
                    rtp.RecordLineage = RunTimeNode.LoopRecordID;
                }
                else
                {
                    if (rtp.PageLevel > 0)
                    {

                        if (theLogger.IsDebugEnabled)
                            theLogger.Debug("Setting Record_Lineage on Page: " + RunTimeNode.PageID + " to: " + RunTimeNode.RecordLineage);
                        rtp.RecordLineage = RunTimeNode.RecordLineage;
                    }
                }
                //GetDataLinks for this page
                Dictionary<int, List<DataLink>> links = DataLinkImpl.GetDataLinksByGraphicIDForPage(RunTimeNode.PageID);
                rtp.DataLinks.Clear();
                foreach (KeyValuePair<int, List<DataLink>> keypair in links)
                {
                    Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord> giiString = new Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>();
                    foreach (DataLink dl in keypair.Value)
                    {
                        if (dl.SourcePageID == RunTimeNode.PageID)
                        {
                            GraphicDataLinkRecord gDataLink = new GraphicDataLinkRecord();
                            gDataLink.DisplayPageName = dl.PageName;
                            gDataLink.DisplayGraphicName = dl.GraphicObjectName;
                            gDataLink.DataLinkType = dl.DataLinkType;
                            gDataLink.IsDefault = dl.IsDefault;
                            gDataLink.GraphicIDKey = dl.TargetGraphicID;
                            gDataLink.PageIDKey = dl.TargetPageID;
                            gDataLink.DirectionIsForward = true;
                            gDataLink.BindingColumnGraphicID = dl.LoopingColumnID;
                            giiString.Add(new KeyValuePair<int, int>(dl.TargetPageID, dl.TargetGraphicID), gDataLink);
                        }
                        else
                        {
                            GraphicDataLinkRecord gDataLinkReturning = new GraphicDataLinkRecord();
                            gDataLinkReturning.DisplayPageName = dl.PageName;
                            gDataLinkReturning.DisplayGraphicName = dl.GraphicObjectName;
                            gDataLinkReturning.DataLinkType = dl.DataLinkType;
                            gDataLinkReturning.IsDefault = dl.IsDefault;
                            gDataLinkReturning.GraphicIDKey = dl.SourceGraphicID;
                            gDataLinkReturning.PageIDKey = dl.SourcePageID;
                            gDataLinkReturning.DirectionIsForward = false;
                            gDataLinkReturning.BindingColumnGraphicID = dl.LoopingColumnID;
                            giiString.Add(new KeyValuePair<int, int>(dl.SourcePageID, dl.SourceGraphicID), gDataLinkReturning);
                        }
                    }
                    rtp.DataLinks.Add(keypair.Key, giiString);
                }

                DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
                return rtp;
            }
            else
            {
                return null;
            }
        }
        private void ProcessPagePropertyImageSettings(RunTimePage runTimePage)
        {
            if (runTimePage != null)
            {
                try
                {
                    if (runTimePage.PageProperties.ImageInfoID > 0)
                    {
                        ImageImpl ii = new ImageImpl(runTimePage.PageProperties.ImageInfoID);
                        const float PAPER_WIDTH = 8.5f;
                        const float LETTER_HEIGHT = 11f;
                        const float LEGAL_HEIGHT = 14f;
                        if (ii.ImageObj.Width < ii.ImageObj.Height)
                        {
                            runTimePage.PageProperties.SetOrientation(PaperOrientationEnum.Portrait);
                            if (ii.ImageObj.Width == ii.ImageObj.HorizontalResolution * PAPER_WIDTH &&
                                ii.ImageObj.Height == ii.ImageObj.VerticalResolution * LETTER_HEIGHT)
                            {
                                runTimePage.PageProperties.PaperSize = PaperSizeEnum.Letter;
                                runTimePage.BackGroundImage = ii.ImageObj;
                                return;
                            }
                            if (ii.ImageObj.Width == ii.ImageObj.HorizontalResolution * PAPER_WIDTH &&
                                ii.ImageObj.Height == ii.ImageObj.VerticalResolution * LEGAL_HEIGHT)
                            {
                                runTimePage.PageProperties.PaperSize = PaperSizeEnum.Legal;
                                runTimePage.BackGroundImage = ii.ImageObj;
                                return;
                            }
                        }
                        else
                        {
                            runTimePage.PageProperties.SetOrientation(PaperOrientationEnum.Landscape);
                            if (ii.ImageObj.Height == ii.ImageObj.VerticalResolution * PAPER_WIDTH &&
                                ii.ImageObj.Width == ii.ImageObj.HorizontalResolution * LETTER_HEIGHT)
                            {
                                runTimePage.PageProperties.PaperSize = PaperSizeEnum.Letter;
                                runTimePage.BackGroundImage = ii.ImageObj;
                                return;
                            }
                            if (ii.ImageObj.Height == ii.ImageObj.VerticalResolution * PAPER_WIDTH &&
                                ii.ImageObj.Width == ii.ImageObj.HorizontalResolution * LEGAL_HEIGHT)
                            {
                                runTimePage.PageProperties.PaperSize = PaperSizeEnum.Legal;
                                runTimePage.BackGroundImage = ii.ImageObj;
                                return;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    theLogger.Error("Error in Processing Page Property Image Settings: ", ex);
                }
                return;
            }
        }

        private RunTimePage ConvertPageImplToRunTimePage(PageImpl pi, RunTimeNode nodeOnTreeThatLaunchedThisPage)
        {
            RunTimePage rtp = new RunTimePage();
            rtp.PageID = pi.PageID;
            rtp.PageProperties = pi.PagePropertyObj;
            ProcessPagePropertyImageSettings(rtp);

            foreach (DataObjectGraphicObjectImpl dogoi in pi.DataObjectGraphicImplColl)
            {
                IGraphicsObject g = dogoi.GetGraphicObject();
                rtp.GraphicsCollection.Add(g);
            }
            rtp.PageType = nodeOnTreeThatLaunchedThisPage.GetPageTypeBasedOnNodeType();
            rtp.PageLevel = DataLinkImpl.GetPageDetailLevel(pi.PageID);
         
            foreach (DataObjectGraphicObjectImpl g in pi.DataObjectGraphicImplColl)
            { 
                if (g.GetGraphicObject().GetType() == typeof(DropDownListGraphic))
                {
                    foreach(string s in GetValueListByID(((DropDownListGraphic)g.GetGraphicObject()).BoundToValueListID))
                    {
                        ((DropDownListGraphic)g.GetGraphicObject()).ValueListItems.Add(s);
                    }
                }
                if (g.GraphicCollection.Count > 0)
                {
                    BindValueListsHelper(g);
                }
            }
         
            return rtp;
        }

           
        
        private void BindValueListsHelper(DataObjectGraphicObjectImpl graphic)
        {
            foreach (DataObjectGraphicObjectImpl g in graphic.GraphicCollection)
            {

                if (g.GetGraphicObject().GetType() == typeof(DropDownListGraphic))
                {
                    foreach (string s in GetValueListByID(((DropDownListGraphic)g.GetGraphicObject()).BoundToValueListID))
                    {
                        ((DropDownListGraphic)g.GetGraphicObject()).ValueListItems.Add(s);
                    }
                }
                if (g.GraphicCollection.Count > 0)
                {
                    BindValueListsHelper(g);
                }
            }

        }


        /// <summary>
        /// used by the TAC BOs to get an image byte array from the design database - this should be done thru some other mechanism eventually.
        /// </summary>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public byte[] GetImageBytes(int ImageID)
        {
            if (ImageID == 0) return null;
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            byte[] imageBytes = ImageImpl.GetImageByteArray(ImageID);
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return imageBytes;
        }

        public System.Drawing.Image GetImage(int ImageID)
        {
            if (ImageID == 0) return null;
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            ImageImpl ii = new ImageImpl(ImageID);
            System.Drawing.Image i = ii.ImageObj;
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return i;
        }


        public Stack<int> GetParentNodeChainForPageID(int PageID)
        { 
            //find all nodes that have this PageID  - should filter by application?
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            NavigationNodeCollection nnc = new NavigationNodeCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(NavigationNodeFieldIndex.Page_ID, ComparisonOperator.Equal, PageID));
            filter.AddWithAnd(PredicateFactory.CompareValue(NavigationFieldIndex.NavigationType_EnumValue, ComparisonOperator.Equal, NavigationTypeEnum.PrintDesign, true));
            RelationCollection relations = new RelationCollection();
            relations.Add(NavigationNodeEntity.Relations.NavigationEntityUsingNavigation_ID);
            nnc.GetMulti(filter, relations);
            Stack<int> stackList = new Stack<int>();
            foreach (NavigationNodeEntity nne in nnc)  //for now just going to do one of these - increase to have multiple return chains - because pages can show up multiple times in various trees...
            {
                //find chain for each of these - to the root
                stackList.Push(nne.Navigation_Node_ID);
                NavigationNodeEntity nneparent = new NavigationNodeEntity(nne.Parent_Node_ID);
                do
                {
                    stackList.Push(nneparent.Navigation_Node_ID);
                    if (nneparent.Parent_Node_ID == 0)
                        break;
                    nneparent = new NavigationNodeEntity(nneparent.Parent_Node_ID);                    
                } while (nneparent != null);
                
                break;
            }


            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return stackList;
        }
        
        private List<String> GetValueListByID(int ValueListID)
        {

            ValueListEntity vle = new ValueListEntity(ValueListID);
            if (vle.IsNew)
                throw new ArgumentException("ValueListID: " + ValueListID + " not found");
            List<string> items = new List<string>();
            items.Add("(none)");
            foreach (ValueListItemEntity vli in vle.ValueListItem)
            {
                items.Add(vli.ValueListItem_Name);
            }

            return items;
        }

        #endregion

      
    }
    namespace Tests
    {
        [TestFixture]
        public class ApplicationInfoRetrieverFromTaxBuilderDesignDBTests
        {
            [Test]
            public void ObjectCD()
            {
                ApplicationInfoRetrieverFromTaxBuilderDesignDB a = new ApplicationInfoRetrieverFromTaxBuilderDesignDB();
                List<string> s = a.GetApplicationNamesCurrentlyAvailable();
                Assert.IsNotNull(s);
                foreach (string s1 in s)
                {
                    Console.WriteLine("Currently Available Application in design database: " + s1);
                    RunTimeNode rtn = a.GetApplicationRootRunTimeNode(s1, AppTypeEnum.Print, 2007);
                    Console.WriteLine("Root node loaded: " + rtn.Name + " Has Children: " + rtn.HasChildren );
                    SortedList<int, RunTimeNode> rtns = a.GetRunTimeNodesChildren(rtn);
                    foreach (RunTimeNode r in rtns.Values)
                    {
                        Console.WriteLine("ChildNode: " + r.Name);
                    }
                }
            }
            [Test]
            public void TestGetPage()
            { 
                //TODO:!!!write this!!!
            }

        }
    }
}
