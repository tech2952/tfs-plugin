using System;
using System.Collections.Generic;
using System.Text;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.GraphicObjects;
using System.Data;
using TaxApp.IntrinsicFunctions;
using log4net;
using TaxBuilder.GraphicObjects.TaxAppRuntime;
using System.IO;
using TaxAppClient.WCFService;
using NUnit.Framework;
using System.Diagnostics;
using System.ServiceModel;
using System.Configuration;

namespace TaxAppClient.BusinessObjects
{
    public class TaxAppData : ITaxAppData
    {
        private static readonly ILog theLogger = LogManager.GetLogger("TaxAppData");
        #region ITaxAppData Members

        private string myLocatorName;
        private int myLocatorID;
        private short myYear;
        private UserConfigurationItems myUserconfigurationItems;
        private Dictionary<string, Dictionary<int, Dictionary<int, GraphicInfoItem>>> myGraphicMatrixByAppNamePageIDGraphicID;
        private Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int>>>> myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix;
        private Dictionary<int, LORecord> myRecordIDToLORecordDictionary;

        public event PageUpdatedEventHandler PageUpdatedEvent;

        public int LocatorID
        {
            get { return myLocatorID; }
        }
        public short Year
        {
            get { return myYear; }
        }
        public string LocatorName
        {
            get { return myLocatorName; }
        }
        public void Initialize(string LocatorName, int LocatorID, short Year, UserConfigurationItems configItems)
        {
            myLocatorName = LocatorName;
            myLocatorID = LocatorID;
            myYear = Year;
            myUserconfigurationItems = configItems;
            myGraphicMatrixByAppNamePageIDGraphicID = new Dictionary<string, Dictionary<int, Dictionary<int, GraphicInfoItem>>>();
            myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix = new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int>>>>();
            myRecordIDToLORecordDictionary = new Dictionary<int, LORecord>();
            //init the calc engine
            LoadCalcEngine();
            


        }

        //public for unit tests - used internally otherwise
        public void LoadGraphicMatrix(string appName, string year)
        {
            CheckForAndDownloadGraphicMatrix(appName, year);
            string filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), GetVariousFileNameMethods.GetGraphicInfoItemFileName(appName, year));
            myGraphicMatrixByAppNamePageIDGraphicID.Add(appName, GraphicInfoItem.LoadGraphicInfoItemsFromBINFile(filepath));

        }
        private void LoadCalcEngine()
        {
            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            string parmsString = "LocatorID=\"" + LocatorID.ToString() + "\";Year=\"" + Year.ToString() + "\"";
            try
            {
                int ReturnID = myTACWCFService.RunMethodByMessageTypeReturnInt("StartCalcEngineLocator", parmsString);
                if (ReturnID == -10) //bad parms
                {
                    throw new ArgumentException("parmsString: " + parmsString);
                }
            }
            catch (Exception ex)
            {
                theLogger.Debug("Error with LoadCalcEngine call. ParmString: " + parmsString, ex);
            }
            finally 
            {
                myTACWCFService.Close();
            }

            //hook up to the async service
            HookUpAsyncClient();
        }

        private void HookUpAsyncClient()
        {
            try
            {
                string endPointAddy = ConfigurationManager.AppSettings["AsyncServerAddress"];

                EndpointAddress serverAddress = new EndpointAddress(endPointAddy);
                theLogger.Debug("Connecting to server: " + serverAddress);
                string clientName = Environment.MachineName;
                TACCallBack.Instance = new TACCallBack();
                TACCallBack.Instance.pageUpdateEvent += new TACCallBack.PageUpdateEvent(Instance_pageUpdateEvent);
                TaxAppClientAsyncServiceClient.Instance = new TaxAppClientAsyncServiceClient
                                                        (
                                                            clientName,
                                                            new InstanceContext(TACCallBack.Instance),
                                                            "ClientTcpBinding",
                                                            serverAddress
                                                         );
                TaxAppClientAsyncServiceClient.Instance.Open();
                theLogger.Debug("Calling Join on TaxAppClientAsyncServiceClient");
                TaxAppClientAsyncServiceClient.Instance.Join(clientName);
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error hooking into server async client.", ex);
            }

        }

        void Instance_pageUpdateEvent(List<int> pageIDs)
        {
            //if this TaxAppData has asked for the pages sent back, then 
            //propogate the event up - the UI should just reget all the pages it currently has open
            theLogger.Debug("Page Update event in TaxAppData firing");
            if (PageUpdatedEvent != null)
            {
                PageUpdatedEvent(this, pageIDs);
            }

        }



        private void LoadCalcEngineApplication(string appName)
        {
            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            string parmsString = "ApplicationName=\"" + appName + "\";LocatorID=\"" + myLocatorID + "\"";
            try
            {
                int ReturnID = myTACWCFService.RunMethodByMessageTypeReturnInt("StartCalcEngineApplication", parmsString);
                if (ReturnID == -10) //bad parms
                {
                    throw new ArgumentException("parmsString: " + parmsString);
                }
            }
            catch (Exception ex)
            {
                theLogger.Debug("Error with LoadCalcEngineApplication call. ParmString: " + parmsString, ex);
            }
            finally
            {
                myTACWCFService.Close();
            }

        }
        private void CheckForAndDownloadGraphicMatrix(string appName, string year)
        {
            string filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), GetVariousFileNameMethods.GetGraphicInfoItemFileName(appName, year));
            FileInfo fi = new FileInfo(filepath);

            //TODO:  This will refresh every time - this is where the version checking system needs to come into play and obviously not download if already down - 
            //also needs to use any version in cache if the request doesn't work.
            if (fi.Exists)
                fi.Delete();
            string fileName = GetVariousFileNameMethods.GetGraphicInfoItemFileName(appName, year);
            DownLoadBinaryFiles(appName, fileName);

        }
        private void DownLoadBinaryFiles(string appName, string fileName)
        {
            byte[] filebytes = null;

            try
            {
                TaxAppClientServiceMTOMClient c = new TaxAppClientServiceMTOMClient();
                filebytes = c.RequestBinary(appName, fileName);
                c.Close();
            }
            catch (Exception ex)
            {
                theLogger.Error("Error connecting to WCF binary file download service.", ex);
            }

            theLogger.Debug("File received.  Length: " + filebytes.Length);

            string filepath = string.Empty;
            filepath = Path.Combine(StaticHelperMethods.GetCacheDirectory(), fileName);

            theLogger.Debug("File writing to: " + filepath);
            using (FileStream sf = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                sf.Write(filebytes, 0, filebytes.Length);
            }
        }
        private GraphicInfoItem GetGraphicInfo(int PageID, int GraphicID)
        {
            //is this really the best way to keep getting GIIs where I don't know the app?
            GraphicInfoItem graphicInfo = null;
            foreach (KeyValuePair<string, Dictionary<int, Dictionary<int, GraphicInfoItem>>> kvp in myGraphicMatrixByAppNamePageIDGraphicID)
            {
                if (kvp.Value.ContainsKey(PageID))
                {
                    graphicInfo = kvp.Value[PageID][GraphicID];
                    break;
                }
            }
            return graphicInfo;
        }

        public SortedList<int, RunTimeNode> ProcessRunTimeNodeCollection(RunTimeNode parentNode, SortedList<int, RunTimeNode> rtns)
        {
            if (!myGraphicMatrixByAppNamePageIDGraphicID.ContainsKey(parentNode.ApplicationName))
            {
                LoadGraphicMatrix(parentNode.ApplicationName, parentNode.ProductYear.ToString());
                LoadCalcEngineApplication(parentNode.ApplicationName);
            }

            SortedList<int, RunTimeNode> nodesProcessedForLooping = new SortedList<int, RunTimeNode>();

            int count = 1;
            foreach (RunTimeNode rtn in rtns.Values)
            {
                if (rtn.LoopRuntimePageID != 0)
                {
                    if (theLogger.IsDebugEnabled)
                    {
                        theLogger.Info(string.Format("Processing Group Loop.  NodeID.NodeRowLineage: [{0} - {1}]     LoopingPage/Graphic: [{2} - {3}]", rtn.NodeID, rtn.RowLineage, rtn.LoopRuntimePageID, rtn.LoopRuntimeGraphicID));
                        theLogger.Info(string.Format("Parent NodeID.RowLineage: {0}.{1} - Loop Record ID: {2} ", parentNode.NodeID, parentNode.RowLineage, parentNode.LoopRecordID));
                    }
                    GraphicInfoItem thisGraphicItem = myGraphicMatrixByAppNamePageIDGraphicID[rtn.ApplicationName][rtn.LoopRuntimePageID][rtn.LoopRuntimeGraphicID];
                    //the grid should also be there
                    int columnsGridID = 0;
                    foreach (KeyValuePair<int, GraphicInfoItem> kvp in myGraphicMatrixByAppNamePageIDGraphicID[rtn.ApplicationName][rtn.LoopRuntimePageID])
                    {
                        if (kvp.Value.DataType == (byte)EnumKeyDataType.DataTable)
                        {
                            foreach (GraphicInfoItem giiColumn in kvp.Value.Columns)
                            {
                                if (giiColumn.GraphicID == rtn.LoopRuntimeGraphicID)
                                {
                                    columnsGridID = kvp.Value.GraphicID;
                                }
                            }
                        }
                    }

                    TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
                    LORecord[] records = null;
                    if (rtn.RecordLineage == 0 && parentNode.LoopRecordID != 0)
                    {
                        records = myTACWCFService.GetRecords(myLocatorID, myYear, parentNode.LoopRecordID, rtn.LoopRuntimePageID, rtn.LoopRuntimeGraphicID, columnsGridID);
                    }
                    else
                    {
                        records = myTACWCFService.GetRecords(myLocatorID, myYear, rtn.RecordLineage, rtn.LoopRuntimePageID, rtn.LoopRuntimeGraphicID, columnsGridID);
                    }

                    if (records.Length > 0)
                    {
                        for (int i = 0; i < records.Length; i++)
                        {
                            LORecord lor = records[i];
                            RunTimeNode rtnNew = rtn.Copy();
                            rtnNew.LoopRecordID = lor.RecordID;
                            if (parentNode.RowLineage == string.Empty)
                            {
                                rtnNew.RowLineage = lor.RowDisplayOrder.ToString();
                            }
                            else
                            {
                                rtnNew.RowLineage = parentNode.RowLineage.ToString() + "." + lor.RowDisplayOrder.ToString();
                            }
                            //this handles when the node is under a looping node
                            if (parentNode.LoopRecordID > 0)
                            {
                                rtnNew.RecordLineage = parentNode.LoopRecordID;
                                
                            }
                            else if (parentNode.RecordLineage > 0)
                            {
                                rtnNew.RecordLineage = parentNode.RecordLineage;
                            }
                            List<ValueWithDataSources> otherValues = new List<ValueWithDataSources>();
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, lor.DataSourceUsed, out otherValues, false);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.ConvertDefaultValueToDataType();
                            if (dataSourceVal == null)
                            {
                                //it still is null, then there is a problem with the data type and the binary default value (persisted as string);
                                theLogger.Warn("Error retrieving DefaultValue for the bound graphic.  PID/GraphicID: " + thisGraphicItem.PageID + "/" + thisGraphicItem.GraphicID);
                                theLogger.Warn("Graphic DataTypeByte: " + thisGraphicItem.DataType + " DefaultValueString: " + thisGraphicItem.DefaultValue);
                            }
                            else
                            {
                                rtnNew.Name = rtn.Name + " " + dataSourceVal.ToString();
                            }
                            nodesProcessedForLooping.Add(count, rtnNew);
                            count++;
                        }
                    }
                    else
                    {
                        //there is no value for this looping graphic
                        rtn.Name = rtn.Name + " *No Value on looping graphic* LoopRecordID: " + rtn.LoopRecordID.ToString();
                        if (parentNode.LoopRecordID > 0)
                        {
                            rtn.RecordLineage = parentNode.LoopRecordID;
                        }
                        else if (parentNode.RecordLineage > 0)
                        {
                            rtn.RecordLineage = parentNode.RecordLineage;
                        }
                        rtn.Enabled = false;
                        nodesProcessedForLooping.Add(count, rtn);
                        count++;
                    }
                }
                else
                {
                    //this handles when the node is under a looping node
                    rtn.RowLineage = parentNode.RowLineage;
                    if (parentNode.LoopRecordID > 0)
                    {
                        rtn.RecordLineage = parentNode.LoopRecordID;
                    }
                    else if (parentNode.RecordLineage > 0)
                    {
                        rtn.RecordLineage = parentNode.RecordLineage;
                    }

                    nodesProcessedForLooping.Add(count, rtn);
                    count++;
                }

            }

            return nodesProcessedForLooping;
        }

    
        public ValueWithDataSources GetSingleValue(int PageID, int RuntimeGraphicID, int RecordLineage)
        {
            ValueWithDataSources valueWDS = null;
            GraphicInfoItem graphicInfo = GetGraphicInfo(PageID, RuntimeGraphicID);

            if (graphicInfo == null)
            {
                theLogger.Warn("Get: GraphicInfoItem not found. PID/GID: " + PageID + "/" + RuntimeGraphicID);
                return null;
            }
            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            LORecord[] records = null;
            if (!graphicInfo.IsShortcut)
            {
                records = myTACWCFService.GetRecords(myLocatorID, myYear, RecordLineage, PageID, RuntimeGraphicID, 0);
            }
            else
            {
                records = myTACWCFService.GetRecords(myLocatorID, myYear, RecordLineage, graphicInfo.LinkedPageID, graphicInfo.LinkedGraphicID, 0);
            }

            if (records.Length > 1)
            {
                if (!graphicInfo.IsShortcut)
                {
                    theLogger.Warn("Get: Multiple records found for a GetSingleValue call.  PID/GID/RL: " + PageID + "/" + RuntimeGraphicID + "/" + RecordLineage);
                    theLogger.Warn("Get: Returning First one.");
                }
                else
                {
                    theLogger.Warn("Get: Multiple records found for a GetSingleValue call (shortcut).  PID/GID/RL: " + graphicInfo.LinkedPageID + "/" + graphicInfo.LinkedGraphicID + "/" + RecordLineage);
                    theLogger.Warn("Get: Returning First one.");
                }
            }

            if (records.Length > 0)
            {
                LORecord lor = records[0];
                valueWDS = new ValueWithDataSources();
                valueWDS.DataSource = (DataSourceEnum)lor.DataSourceUsed;
                List<ValueWithDataSources> otherVals = new List<ValueWithDataSources>();
                valueWDS.Value = GetValueFromThisLocatorObjectRecordByDataSource(lor, lor.DataSourceUsed, out otherVals, true);
                valueWDS.OtherDataSources = otherVals;
                SetRecord(lor.PageID, lor.GraphicObjectID, RecordLineage, lor.RowDisplayOrder, lor.RecordID);
                if (theLogger.IsDebugEnabled)
                {
                    theLogger.Debug(string.Format("Get: PID {0}    GID {1}    RL {2}   RecID {3}    Value {4}", PageID, RuntimeGraphicID, RecordLineage, lor.RecordID, valueWDS.Value.ToString()));
                }
            }
            else
            {
                //none - make the single return the default value.
                if (graphicInfo != null)
                {
                    object defValue = null;
                    GraphicInfoItem shortcutGraphicInfo = null;
                    if (graphicInfo.IsShortcut)
                    {
                        shortcutGraphicInfo = GetGraphicInfo(graphicInfo.LinkedPageID, graphicInfo.LinkedGraphicID);
                        if (shortcutGraphicInfo == null)
                        {
                            theLogger.Warn("Get: Shortcut Origination GraphicInfoItem not found.  Shortcutted object's originating graphic's page must be included in the tree.  Shortcut PID/GID: " + graphicInfo.LinkedPageID + "/" + graphicInfo.LinkedGraphicID);
                            //not sure what to do here...
                            //this error should only happen in testing - return this graphicInfo's default value
                            defValue = graphicInfo.ConvertDefaultValueToDataType();
                        }
                        else
                        {
                            defValue = shortcutGraphicInfo.ConvertDefaultValueToDataType();
                        }
                    }
                    else
                    {
                        defValue = graphicInfo.ConvertDefaultValueToDataType();
                    }
                    if (defValue == null)
                    {
                        if (graphicInfo.IsShortcut)
                        {
                            theLogger.Debug("Get: Default value for Shortcut returns NULL.  PID/GID/DefValue/DataType: " + graphicInfo.LinkedPageID + "/" + graphicInfo.LinkedGraphicID + "/" + shortcutGraphicInfo.DefaultValue.ToString() + "/" + shortcutGraphicInfo.DataType);
                        }
                        else
                        {
                            theLogger.Debug("Get: Default value returns NULL.  PID/GID/DefValue/DataType: " + PageID + "/" + RuntimeGraphicID + "/" + graphicInfo.DefaultValue.ToString() + "/" + graphicInfo.DataType);
                        }
                    }
                    valueWDS = new ValueWithDataSources(defValue , TaxBuilder.GraphicObjects.DataSourceEnum.SystemDefault, null);
                }
            }
            
            return valueWDS;
        }
        private void SetRecord(int pageID, int graphicID, int recordLineage, int displayOrder, int RecordID)
        {
            if (!myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix.ContainsKey(pageID))
            {
                myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix.Add(pageID, new Dictionary<int, Dictionary<int, Dictionary<int, int>>>());
            }
            if (!myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[pageID].ContainsKey(graphicID))
            {
                myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[pageID].Add(graphicID, new Dictionary<int, Dictionary<int, int>>());
            }
            if (!myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[pageID][graphicID].ContainsKey(recordLineage))
            {
                myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[pageID][graphicID].Add(recordLineage, new Dictionary<int,int>());
            }
            if (!myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[pageID][graphicID][recordLineage].ContainsKey(displayOrder))
            {
                myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[pageID][graphicID][recordLineage].Add(displayOrder, RecordID);
            }
            else
            {
                myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[pageID][graphicID][recordLineage][displayOrder] = RecordID;
            }
        }
        public DataTable GetGridDataTable(int PageID, int RuntimeGraphicID, int RecordLineage)
        {
            GraphicInfoItem gii = GetGraphicInfo(PageID, RuntimeGraphicID);
            if (gii.DataType == Convert.ToByte(EnumKeyDataType.DataTable))
            {
                return ProcessDataTable(gii, RecordLineage);
            }
            else
                return null;
        }
        private DataTable ProcessDataTable(GraphicInfoItem GridGraphicInfoItem, int RecordLineage)
        {
            if (theLogger.IsDebugEnabled)
                theLogger.Debug("Get: Processing Grid DataTable...  GridID/RecordLineage: " + GridGraphicInfoItem.GraphicID + "/" + RecordLineage.ToString());

            DataTable Table = GetDataTable(GridGraphicInfoItem);

            //load in the sets of data for each column
            int maxnumberRecords = 0;

            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            Dictionary<int, Dictionary<int, LORecord>> recordsByGraphicIDByDisplayOrder = new Dictionary<int, Dictionary<int, LORecord>>();

            for (int i = 0; i < GridGraphicInfoItem.Columns.Count; i++)
            {
                int graphicID = GridGraphicInfoItem.Columns[i].GraphicID;
                LORecord[] records = myTACWCFService.GetRecords(myLocatorID, myYear, RecordLineage, GridGraphicInfoItem.Columns[i].PageID, GridGraphicInfoItem.Columns[i].GraphicID, GridGraphicInfoItem.GraphicID);
                for (int j = 0; j < records.Length; j++)
                {
                    if (!recordsByGraphicIDByDisplayOrder.ContainsKey(GridGraphicInfoItem.Columns[i].GraphicID))
                    {
                        recordsByGraphicIDByDisplayOrder.Add(GridGraphicInfoItem.Columns[i].GraphicID, new Dictionary<int, LORecord>());
                    }
                    //this shouldn't ever have problems - let it fail if it does for now...
                    if (recordsByGraphicIDByDisplayOrder[GridGraphicInfoItem.Columns[i].GraphicID].ContainsKey(records[j].RowDisplayOrder))
                    { 
                        //duplicate displayOrders in the database.  Thus invalid data.
                        theLogger.Warn("Duplicate Display Rows in database for PID/GID/RL: " + GridGraphicInfoItem.PageID + "/" + GridGraphicInfoItem.GraphicID + "/" + RecordLineage);

                    }
                    else
                    {
                        recordsByGraphicIDByDisplayOrder[GridGraphicInfoItem.Columns[i].GraphicID].Add(records[j].RowDisplayOrder, records[j]);
                    }
                    //figure out the greatest display order
                    if (maxnumberRecords < records[j].RowDisplayOrder)
                        maxnumberRecords = records[j].RowDisplayOrder;
                }
            }
            PropertyCollection tableProps = Table.ExtendedProperties;
            //the rowcolumnRecordIndex starts row = 1 to maxnumberrow, and is empty if there are entries in the dictionary
            Dictionary<RowColumnKey, int> RowColumnRecordIndex = GetRowColumnRecordIndex(maxnumberRecords, GridGraphicInfoItem);
            tableProps.Add("RecordIDS", RowColumnRecordIndex);

            if (maxnumberRecords > 0)
            {
                //now loop thru and set each columns data
                int rowInd = 1;
                while (rowInd < maxnumberRecords + 1)
                {
                    DataRow row = Table.NewRow();
                    foreach (GraphicInfoItem column in GridGraphicInfoItem.Columns)
                    {
                        if (recordsByGraphicIDByDisplayOrder.ContainsKey(column.GraphicID))
                        {
                            if (recordsByGraphicIDByDisplayOrder[column.GraphicID].ContainsKey(rowInd))
                            {
                                LORecord lor = (LORecord)recordsByGraphicIDByDisplayOrder[column.GraphicID][rowInd];
                                RowColumnKey rck = new RowColumnKey(rowInd, column.GraphicID);
                                RowColumnRecordIndex[rck] = lor.RecordID;

                                //set the value of the row[index by graphicID] = ValueWithDataSource object...
                                DataSourceEnum datasource = (DataSourceEnum)lor.DataSourceUsed;
                                List<ValueWithDataSources> otherDatasources = new List<ValueWithDataSources>();
                                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, (byte)datasource, out otherDatasources, true);
                                if (dataSourceVal == null)
                                    dataSourceVal = column.DefaultValue;
                                ValueWithDataSources valueDataSource = new ValueWithDataSources(dataSourceVal, datasource, otherDatasources);
                                row[column.GraphicID.ToString()] = valueDataSource;
                            }
                        }
                    }
                    Table.Rows.Add(row);
                    rowInd++;
                }
            }
            else
            {
                //empty - add one
                DataRow row = Table.NewRow();
                foreach (GraphicInfoItem column in GridGraphicInfoItem.Columns)
                {
                    //this is where default values and system values come into play
                    //TODO: hook up getting user Defaults...
                    //user defaults should be handled at a database level - these systems should never realize what user defaults are or how they change.
                    object val = column.ConvertDefaultValueToDataType();
                    ValueWithDataSources valueDataSource = new ValueWithDataSources(val, DataSourceEnum.SystemDefault, new List<ValueWithDataSources>());
                    row[column.GraphicID.ToString()] = valueDataSource;
                }
                Table.Rows.Add(row);
            }
            Table.AcceptChanges();
            return Table;
        }
 
        private DataTable GetDataTable(GraphicInfoItem GridGraphicInfoItem)
        {
            DataTable Table = new DataTable(GridGraphicInfoItem.GraphicName);
            //setup the DataTable Schema
            if (theLogger.IsDebugEnabled)
                theLogger.Debug("Get: Adding Columns to datatable.  Column count: " + GridGraphicInfoItem.Columns.Count);
            for (int i = 0; i < GridGraphicInfoItem.Columns.Count; i++)
            {
                foreach (GraphicInfoItem gii in GridGraphicInfoItem.Columns)
                {
                    if ((int)gii.ColumnDisplayOrder == i + 1)
                    {
                        DataColumn column = new DataColumn(gii.GraphicID.ToString(), typeof(ValueWithDataSources));
                        Table.Columns.Add(column);
                        break;
                    }

                }
            }
            return Table;
        }
        private Dictionary<RowColumnKey, int> GetRowColumnRecordIndex(int maxnumberRecords, GraphicInfoItem GridGraphicInfoItem)
        {
            Dictionary<RowColumnKey, int> RowColumnRecordIndex = new Dictionary<RowColumnKey, int>();

            //initialize all the row columnGID keys to -1
            foreach (GraphicInfoItem column in GridGraphicInfoItem.Columns)
            { 
                for (int rowIndex = 1; rowIndex < maxnumberRecords + 1; rowIndex++)
                {
                    RowColumnRecordIndex.Add(new RowColumnKey(rowIndex, column.GraphicID), -1);
                }
            }
            return RowColumnRecordIndex;
        }
        
        
        public bool SetValue(int PageID, int RuntimeGraphicID, object value, TaxBuilder.GraphicObjects.DataSourceEnum dataSource, int RecordLineage)
        {
            if (value == null)
            {
                theLogger.Warn("Set: value == null");
                return false;
            }

            if (theLogger.IsDebugEnabled)
            {
                theLogger.Debug(string.Format("Set: PID {0}    GID {1}    RL {2}   Value {3}", PageID, RuntimeGraphicID, RecordLineage, value.ToString()));
            } 
            GraphicInfoItem graphicInfo = GetGraphicInfo(PageID, RuntimeGraphicID);
            if (graphicInfo == null)
            {
                theLogger.Warn("Set: Unable to find Graphic Info during SetValue.  PID/GID: " + PageID + "/" + RuntimeGraphicID);
                return false;
            }

            LORecord[] lors = null;
            if (graphicInfo.DataType == Convert.ToByte(EnumKeyDataType.DataTable))
            {
                List<LORecord> recordsToBeDeleted = null;
                lors = ProcessDataTableSetValue(graphicInfo, value, dataSource, RecordLineage, out recordsToBeDeleted);

                if (recordsToBeDeleted.Count > 0)
                {
                    TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
                    myTACWCFService.DeleteRecords(recordsToBeDeleted.ToArray());
                }
                
            }
            else
            {
                lors = ProcessSingleSetValue(graphicInfo, value, dataSource, RecordLineage);
            }

            if (lors != null)
            {
                TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
                lors = myTACWCFService.SetRecords(lors);
                if (graphicInfo.DataType == Convert.ToByte(EnumKeyDataType.DataTable))
                {
                    ProcessDataTableReturnedValue((DataTable)value, lors);
                }
                //TODO: do more with the returnvalue
            }

            return true;
        }
        private void ProcessDataTableReturnedValue(DataTable dataTable, LORecord[] lors)
        {
            Dictionary<RowColumnKey, int> rowColumnMatrix = (Dictionary<RowColumnKey, int>)dataTable.ExtendedProperties["RecordIDS"];
            for (int i = 0; i < lors.Length; i++)
            {
                LORecord lorec = lors[i];
                RowColumnKey rck = new RowColumnKey(lorec.RowDisplayOrder, lorec.GraphicObjectID);
                rowColumnMatrix[rck] = lorec.RecordID;
            }

        }
        private LORecord[] ProcessDataTableSetValue(GraphicInfoItem graphicInfoItem, object value, DataSourceEnum dataSource, int recordLineage, out List<LORecord> recordsToBeDeleted)
        { 
            //the value is a datatable - break it down into columns, and then each column each row a LORecord 
            LORecord[] lors = null;
            recordsToBeDeleted = new List<LORecord>();
            //the value should just be a datatable.  With an attached RecordIDs property
            DataTable Table = value as DataTable;
            if (Table == null)
            {
                theLogger.Warn("The passed in value for setting value of a grid graphic not a DataTable");
                return null;
            }
            Dictionary<RowColumnKey, int> RowColumnRecordIndex = Table.ExtendedProperties["RecordIDS"] as Dictionary<RowColumnKey, int>;
            if (RowColumnRecordIndex == null)
            {
                theLogger.Warn("The passed in DataTable doesn't have the associated RecordIDS extended properties.");
                return null;
            }
            int currentRowIndexInTable = 0;
            int currentDisplayRowIndex = 1;
            List<LORecord> LORecords = new List<LORecord>();
            
            foreach (DataRow row in Table.Rows)
            {
                switch (row.RowState)
                { 
                    case DataRowState.Unchanged:
                        currentDisplayRowIndex++;
                        currentRowIndexInTable++;
                        continue;
                    case DataRowState.Deleted:
                        //there has to be a way to tell the Set routine that a LORecord has been deleted.
                        //or should the set routine, just be smart enough to notice that in a returned multi-row LORecord set, that a record is updated?
                        //nah, because that would mean you'd have to send back all the rows in a set, when we really just want to update the rows
                        //that need it.
                        
                        //TODO: write the delete code - need to change LORecord to include a NeedsToBeDeleted flag.

                        //currentRowIndexInTable++;
                        //continue;
                    case DataRowState.Added:
                    case DataRowState.Modified:
                        //create a new LORecord / add it to the records to be processed...
                        foreach (GraphicInfoItem column in graphicInfoItem.Columns)
                        {
                            if (row[column.GraphicID.ToString()] == DBNull.Value)
                                continue;
                            ValueWithDataSources columnsValueWDS = (ValueWithDataSources)row[column.GraphicID.ToString()];
                            if (columnsValueWDS.HasChanged)
                            {
                                LORecord lorAdd = new LORecord();
                                lorAdd.DataSourceUsed = Convert.ToByte(dataSource);
                                lorAdd.DataType = column.DataType;
                                //TODO:  check on shortcuts of columns - I think shortcutted columns always are the original..
                                lorAdd.GraphicObjectID = column.GraphicID;
                                lorAdd.PageID = column.PageID;
                                lorAdd.LocatorID = myLocatorID;
                                lorAdd.ProductYear = myYear;
                                lorAdd.RecordLineage = recordLineage;
                                lorAdd.RowDisplayOrder = Convert.ToInt16(currentDisplayRowIndex);  //check to make sure reordering the data 
                                lorAdd.ParentGraphicID = graphicInfoItem.GraphicID;  //put in the grid id - for updating the LocatorGridRow table

                                if (row.RowState == DataRowState.Added)
                                {
                                    lorAdd.RecordWasAdded = true;
                                }
                                if (row.RowState == DataRowState.Deleted)
                                {
                                    recordsToBeDeleted.Add(lorAdd);
                                    
                                    continue;
                                }


                                //(sorting etc) will not affect the display order - or maybe it does and it can be saved that way?
                                RowColumnKey rcri = new RowColumnKey(currentDisplayRowIndex, column.GraphicID);
                                if (RowColumnRecordIndex.ContainsKey(rcri))
                                {
                                    lorAdd.RecordID = RowColumnRecordIndex[rcri];
                                }
                                else
                                {
                                    lorAdd.RecordID = -1;
                                }
                                lorAdd.Values = new LOValue[1];
                                lorAdd.Values[0] = new LOValue();
                                lorAdd.Values[0].DataSource = Convert.ToByte(dataSource);
                                EnumKeyDataType dataType = (EnumKeyDataType)column.DataType;
                                switch (dataType)
                                {
                                    case EnumKeyDataType.Boolean:  //boolean
                                        lorAdd.Values[0].BooleanValue = Convert.ToBoolean(columnsValueWDS.Value);
                                        break;
                                    case EnumKeyDataType.Integer:  //int
                                    case EnumKeyDataType.Money:
                                        lorAdd.Values[0].NumericValue = Convert.ToDecimal(columnsValueWDS.Value);
                                        break;
                                    case EnumKeyDataType.String: //string
                                        lorAdd.Values[0].StringValue = Convert.ToString(columnsValueWDS.Value);
                                        break;
                                    case EnumKeyDataType.DateTime://datetime
                                        lorAdd.Values[0].DateTimeValue = Convert.ToDateTime(columnsValueWDS.Value);
                                        break;
                                    case EnumKeyDataType.Ratio: //RATIO
                                        lorAdd.Values[0].FractionValue = Convert.ToDecimal(columnsValueWDS.Value);
                                        break;
                                }

                                LORecords.Add(lorAdd);
                                continue;


                            }
                        }
                        if (row.RowState != DataRowState.Deleted)
                        {
                            currentDisplayRowIndex++;
                        }
                        
                        currentRowIndexInTable++;
                        continue;
                }
            }

            if (LORecords.Count > 0)
            {
                lors = new LORecord[LORecords.Count];
                int i = 0;
                foreach (LORecord l in LORecords)
                {
                    lors[i] = l;
                    i++;
                }
            }

            Table.AcceptChanges();
            
            
            return lors;
        }
        private LORecord[] ProcessSingleSetValue(GraphicInfoItem graphicInfoItem, object value, DataSourceEnum dataSource, int recordLineage)
        {
            LORecord[] lors = null;
            //the value should just be a value (int32, string, etc)
            if (value != null)
            {
                lors = new LORecord[1];
                lors[0] = new LORecord();
                //this means that shortcut fields are overridable from their location
                if (!graphicInfoItem.IsShortcut)
                {
                    lors[0].GraphicObjectID = graphicInfoItem.GraphicID;
                    lors[0].PageID = graphicInfoItem.PageID;
                }
                else
                {
                    lors[0].GraphicObjectID = graphicInfoItem.LinkedGraphicID;
                    lors[0].PageID = graphicInfoItem.LinkedPageID;
                }
                
                lors[0].ProductYear = myYear;
                lors[0].LocatorID = myLocatorID;

                lors[0].RecordID = GetRecordIDForThisGraphicByDisplayOrder(graphicInfoItem.PageID, graphicInfoItem.GraphicID, recordLineage, 1);
                lors[0].DataSourceUsed = Convert.ToByte(dataSource);
                lors[0].RecordLineage = recordLineage;
                lors[0].RowDisplayOrder = 1;
                lors[0].DataType = graphicInfoItem.DataType;
                lors[0].Values = new LOValue[1];
                lors[0].Values[0] = new LOValue();
                lors[0].Values[0].DataSource = Convert.ToByte(dataSource);
                EnumKeyDataType dataType = (EnumKeyDataType)graphicInfoItem.DataType;
                switch(dataType)
                {
                    case EnumKeyDataType.Boolean:  //boolean
                        lors[0].Values[0].BooleanValue = Convert.ToBoolean(value);
                        break;
                    case EnumKeyDataType.Integer:  //int & money go into the same column
                    case EnumKeyDataType.Money:  //money - the SQL Column is numeric(22,2)
                        lors[0].Values[0].NumericValue = Convert.ToDecimal(value);
                        break;
                    case EnumKeyDataType.String: //string
                        lors[0].Values[0].StringValue = Convert.ToString(value);
                        break;
                    case EnumKeyDataType.DateTime://datetime
                        lors[0].Values[0].DateTimeValue = Convert.ToDateTime(value);
                        break;
                    case EnumKeyDataType.Ratio: //RATIO - the SQL column is: numeric(20,9)
                        lors[0].Values[0].FractionValue = Convert.ToDecimal(value);
                        break;
                }
            }
            return lors;
        }

        // not implemented yet...
        public IBaseType GetValueAsBaseType(int PageID, int RuntimeGraphicID, int RecordLineage)
        {
            INTEGER i = 1;
            return i;

            //GraphicInfoItem thisGraphicItem = GetGraphicInfoItem(PageID, RuntimeGraphicID);

            //PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            //prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);

            //LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            //PredicateExpression filter = new PredicateExpression();
            //filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
            //filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
            //filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, RuntimeGraphicID));
            //filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, PageID));
            //if (RecordLineage != 0)
            //{
            //    filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, RecordLineage));
            //}

            //ISortExpression sortClause = new SortExpression(SortClauseFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder, SortOperator.Ascending));
            //lorc.GetMulti(filter, 0, sortClause, null, prefetch);

            ////at this point we have a collection of LORs - extract out TheValues from each one and create an array of objects to pass into the ctor of the BaseType
            ////this should return an INTEGER / DOUBLE / STRING / (one of the codescriptdata types)
            ////if we have no LORs then we need to create a default value
            //if (lorc.Count > 0)
            //{
            //    int i = 0;
            //    //this really could become problematic - once a string, always a string kind of thing
            //    //if they want to change datatypes after an application has shipped - it'll need to be in a codescript - setting one field to another
            //    EnumKeyDataType dataTypeK = (EnumKeyDataType)thisGraphicItem.DataType;
            //    switch (dataTypeK)
            //    {
            //        case EnumKeyDataType.Integer:
            //            int[] o = new int[lorc.Count];
            //            i = 0;
            //            foreach (LocatorObjectRecordEntity lor in lorc)
            //            {
            //                DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
            //                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
            //                if (dataSourceVal == null)
            //                    dataSourceVal = thisGraphicItem.DefaultValue;
            //                o[i] = Convert.ToInt32(dataSourceVal);
            //                i++;
            //            }
            //            INTEGER I = o;
            //            return I;

            //        case EnumKeyDataType.Money:
            //            double[] d = new double[lorc.Count];
            //            i = 0;
            //            foreach (LocatorObjectRecordEntity lor in lorc)
            //            {
            //                DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
            //                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
            //                if (dataSourceVal == null)
            //                    dataSourceVal = thisGraphicItem.DefaultValue;
            //                d[i] = Convert.ToDouble(dataSourceVal);
            //                i++;
            //            }
            //            MONEY M = d;
            //            return M;

            //        case EnumKeyDataType.Boolean:
            //            bool[] b = new bool[lorc.Count];
            //            i = 0;
            //            foreach (LocatorObjectRecordEntity lor in lorc)
            //            {
            //                DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
            //                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
            //                if (dataSourceVal == null)
            //                    dataSourceVal = thisGraphicItem.DefaultValue;
            //                b[i] = Convert.ToBoolean(dataSourceVal);
            //                i++;
            //            }
            //            BOOL B = b;
            //            return B;

            //        case EnumKeyDataType.DateTime:
            //            DateTime[] dt = new DateTime[lorc.Count];
            //            i = 0;
            //            foreach (LocatorObjectRecordEntity lor in lorc)
            //            {
            //                DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
            //                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
            //                if (dataSourceVal == null)
            //                    dataSourceVal = thisGraphicItem.DefaultValue;
            //                dt[i] = DateTime.Parse(dataSourceVal.ToString());
            //                i++;
            //            }
            //            DATE D = dt;
            //            return D;

            //        case EnumKeyDataType.Ratio:
            //            Double[] dd = new Double[lorc.Count];
            //            i = 0;
            //            foreach (LocatorObjectRecordEntity lor in lorc)
            //            {
            //                DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
            //                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
            //                if (dataSourceVal == null)
            //                    dataSourceVal = thisGraphicItem.DefaultValue;

            //                dd[i] = Convert.ToDouble(dataSourceVal);
            //                i++;
            //            }
            //            RATIO R = dd;
            //            return R;

            //        default:
            //            string[] s = new string[lorc.Count];
            //            i = 0;
            //            foreach (LocatorObjectRecordEntity lor in lorc)
            //            {
            //                DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
            //                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
            //                if (dataSourceVal == null)
            //                    dataSourceVal = thisGraphicItem.DefaultValue;
            //                s[i] = dataSourceVal.ToString();
            //                i++;
            //            }
            //            STRING S = s;
            //            return S;
            //    }
            //}
            //else
            //{
            //    //there is no value for this GraphicInfoItem in the database - return the defaultvalue properly casted
            //    EnumKeyDataType dataType = (EnumKeyDataType)thisGraphicItem.DataType;
            //    switch (dataType)
            //    {
            //        case EnumKeyDataType.DataTable:
            //            return null;
            //        case EnumKeyDataType.Boolean:
            //            BOOL bdefault = Convert.ToBoolean(thisGraphicItem.DefaultValue);
            //            return bdefault;
            //        case EnumKeyDataType.DateTime:
            //            //TODO: fix the default date
            //            //DATE ddefault = DateTime.Parse(thisGraphicItem.DefaultValue.ToString());
            //            DATE ddefault = Convert.ToDateTime(Constants.MinimumDateValue);
            //            return ddefault;
            //        case EnumKeyDataType.Ratio:
            //            RATIO rdefault = Convert.ToDouble(thisGraphicItem.DefaultValue);
            //            return rdefault;
            //        case EnumKeyDataType.Image:
            //            theLogger.Info("Image type cannot be a basetype - yet");
            //            return null;
            //        case EnumKeyDataType.Integer:
            //            INTEGER idefault = Convert.todecimal(thisGraphicItem.DefaultValue);
            //            return idefault;
            //        case EnumKeyDataType.Money:
            //            MONEY mdefault = Convert.ToDouble(thisGraphicItem.DefaultValue);
            //            return mdefault;
            //        case EnumKeyDataType.String:
            //            STRING sdefault = thisGraphicItem.DefaultValue.ToString();
            //            return sdefault;
            //        default:
            //            return null;
            //    }
            //}











        }
        public void SetBasetypeValue(int PageID, int RuntimeGraphicID, TaxApp.IntrinsicFunctions.IBaseType value, TaxBuilder.GraphicObjects.DataSourceEnum dataSource, int RecordLineage)
        {

        }
        public bool GetNodeConstraintIsThisNodeIDEnabled(int NavigationNodeID)
        {
            return true;
        }
        public void SetValueFromConstraint(int NavigationNodeID, bool value)
        {

        }
        public int GetRecordLineageForThisRecordID(int RecordID)
        {
            return 1;
        }
        public IDictionary<int, string> GetSetofRecordIDandValueForSameGraphicAndLineage(int RecordID)
        {
            Dictionary<int, string> parentID = new Dictionary<int, string>();
            return parentID;
        }
        public int GetRecordIDForThisGraphicByDisplayOrder(int PageID, int GraphicID, int RecordLineage, int DisplayOrder)
        {
            if (myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix.ContainsKey(PageID))
            {
                if (myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[PageID].ContainsKey(GraphicID))
                {
                    if (myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[PageID][GraphicID].ContainsKey(RecordLineage))
                    {
                        if (myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[PageID][GraphicID][RecordLineage].ContainsKey(DisplayOrder))
                        {
                            return myPageToGraphicToRecordLineageToDisplayRowRecordIDMatrix[PageID][GraphicID][RecordLineage][DisplayOrder];
                        }
                    }
                }
            }
            return -1;
        }
        
        
        
        public void UpdateValue(int RecordID, object value, TaxBuilder.GraphicObjects.DataSourceEnum datasource)
        {

        }
        public void SelectDataSource(bool bClearOverride, int PageID, int RuntimeGraphicID, TaxBuilder.GraphicObjects.DataSourceEnum dataSource, int RecordLineage, int RowInd)
        {

        }
        public void PerformFullCompute()
        {

        }

        #endregion



        public static object GetValueFromThisLocatorObjectRecordByDataSource(LORecord lorecord, byte requestedDataSource, out List<ValueWithDataSources> otherValues, bool parseOtherValues)
        {
            object value = null;
            otherValues = null;
            if (lorecord != null)
            {
                if (parseOtherValues)
                    otherValues = new List<ValueWithDataSources>();
                if (lorecord.Values != null)
                {
                    foreach (LOValue lov in lorecord.Values)
                    {
                        if (lov.DataSource == requestedDataSource)
                        {
                            value = GetValueFromLOV(lov, lorecord.DataType);
                            if (!parseOtherValues)
                                return value;
                        }
                        else if (parseOtherValues)
                        {
                            object otherValue = TaxAppData.GetValueFromLOV(lov, lorecord.DataType);
                            ValueWithDataSources other = new ValueWithDataSources(otherValue, (DataSourceEnum)lov.DataSource, null);
                            otherValues.Add(other);
                        }
                    }
                }
            }
            return value;
        }
        public static object GetValueFromLOV(LOValue lov, byte typeByte)
        {
            EnumKeyDataType type = (EnumKeyDataType)typeByte;
            switch (type)
            {
                case EnumKeyDataType.Boolean:
                    return lov.BooleanValue;

                case EnumKeyDataType.String:
                    return lov.StringValue;

                case EnumKeyDataType.Money:
                case EnumKeyDataType.Integer:
                    return lov.NumericValue;

                case EnumKeyDataType.DateTime:
                    return lov.DateTimeValue;

                case EnumKeyDataType.Ratio:
                    return lov.FractionValue;

                //case EnumKeyDataType.Image:
                //    return lov.LocatorImage;

                default:
                    return null;
            }
        }


}
    //internal class
    class RowColumnKey
    {
        private int myRow = 0;
        private int myColumn = 0;
        public RowColumnKey(int DisplayRow, int ColumnRuntimeIDKey)
        {
            myRow = DisplayRow;
            myColumn = ColumnRuntimeIDKey;
        }
        public override bool Equals(object obj)
        {
            return ((((RowColumnKey)obj).myColumn == myColumn && ((RowColumnKey)obj).myRow == myRow));
        }
        public override int GetHashCode()
        {
            return myColumn.GetHashCode() + myRow.GetHashCode();
        }
        public int Row
        {
            get { return myRow; }
            set { myRow = value; }
        }
        public int Column
        {
            get { return myColumn; }
            set { myColumn = value; }
        }

    }
    namespace Tests
    {
        [TestFixture]public class TaxAppDataTests
        {
            private Process WCFprocess = null;
            private UserConfigurationItems uCon = new UserConfigurationItems();
            [TestFixtureSetUp]
            public void SetupWCFService()
            { 
                string WCFEXEName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\TaxAppClient.WCFServiceHost\\bin\\Debug\\TaxAppClient.WCFServiceHost.exe");
                Console.WriteLine("Loading WCF Service.  WCFEXEName: " + WCFEXEName);
                WCFprocess = System.Diagnostics.Process.Start(WCFEXEName);

            }
            [TestFixtureTearDown]
            public void TearDownWCFService()
            {
                if (WCFprocess != null)
                    WCFprocess.Kill();
            }
            [Test]
            public void RowColumnKeyObjectCD()
            {
                RowColumnKey o = new RowColumnKey(1, 2);
                Assert.AreEqual(1, o.Row);
                Assert.AreEqual(2, o.Column);
                o.Row = 3;
                o.Column = 4;
                Assert.AreEqual(3, o.Row);
                Assert.AreEqual(4, o.Column);

                RowColumnKey o2 = new RowColumnKey(3, 4);
                Assert.IsTrue(o.Equals(o2));
                int hash = o2.GetHashCode();
                int hash2 = o.GetHashCode();
                Assert.AreEqual(hash, hash2);


            }
            [Test] public void ObjectCd()
            {
                TaxAppData o = new TaxAppData();
                Assert.IsNotNull(o);

                TaxAppClientData o2 = new TaxAppClientData();
                o2.Initialize(uCon);
                int clientID = o2.GetClientByNameAddIfNew("unit test Client", uCon.Year);
                List<ClientIDAndNameWithLocatorDictionary> cliLocs = o2.GetAllClientNames();
                int locID = 0;
                int year = uCon.Year;
                foreach (ClientIDAndNameWithLocatorDictionary cliloc in cliLocs)
                {
                    if (cliloc.ClientID == clientID)
                    {
                        foreach (LocatorInfo loc in cliloc.Locators)
                        {
                            if (loc.Name == "TestLocator" && loc.Year == year)
                            {
                                locID = loc.LocatorID;
                                break;
                            }
                        }
                    }
                }
                if (locID == 0)
                {
                    locID = o2.AddNewLocatorToListForClient(clientID, "TestLocator", uCon.Year);
                    year = uCon.Year;
                }

                o.Initialize("TestLocator", locID, uCon.Year, uCon);
                o.LoadGraphicMatrix("TestApplication", uCon.Year.ToString());

                ValueWithDataSources v = o.GetSingleValue(500001, 5, 0);
                if (v.Value.ToString() != "test1")
                {
                    bool saved = o.SetValue(500001, 5, "test1", DataSourceEnum.DataEntry, 0);
                }
                ValueWithDataSources v2 = o.GetSingleValue(500001, 5, 0);
                Assert.AreEqual("test1", v2.Value.ToString());

                DataTable dt = o.GetGridDataTable(500001, 9, 0);
                Assert.IsNotNull(dt);
                Assert.AreEqual(2, dt.Columns.Count);
                Assert.AreEqual(1, dt.Rows.Count);
                Random r = new Random();
                string stringTestX = "stringtest" + r.NextDouble().ToString();
                dt.Rows[0]["10"] = new ValueWithDataSources(stringTestX, DataSourceEnum.DataEntry, null);
                ((ValueWithDataSources)dt.Rows[0]["10"]).HasChanged = true;
                dt.Rows[0]["11"] = new ValueWithDataSources("key1", DataSourceEnum.DataEntry, null);
                ((ValueWithDataSources)dt.Rows[0]["11"]).HasChanged = true;

                Assert.IsTrue(o.SetValue(500001, 9, dt, DataSourceEnum.DataEntry, 0));
                DataTable dt2 = o.GetGridDataTable(500001, 9, 0);
                Assert.AreEqual(2, dt2.Columns.Count);
                Assert.AreEqual(2, dt2.Columns.Count); //there should always be at least one blank / new one?
                Assert.AreEqual(stringTestX, dt2.Rows[0]["10"].ToString());
                Assert.AreEqual("key1", dt2.Rows[0]["11"].ToString());
                Dictionary<RowColumnKey, int> RowColumnRecordIndex = (Dictionary<RowColumnKey, int>) dt2.ExtendedProperties["RecordIDS"];
                Assert.AreEqual(2, RowColumnRecordIndex.Count);


                



                //string parms = "LocatorID=\"1\";Year=\"2007\";UseMockDataSource=\"true\"";
                //Assert.AreNotEqual(-10, o.RunMethodByMessageTypeReturnInt("StartCalcEngineLocator", parms));
                //string parms2 = "LocatorID=\"1\";ApplicationName=\"Sample_Application\"";
                //Assert.AreNotEqual(-10, o.RunMethodByMessageTypeReturnInt("StartCalcEngineApplication", parms2));


            }
            [Test] public void GetValueTest()
            {
                List<ValueWithDataSources> otherValues = new List<ValueWithDataSources>();
                GraphicInfoItem gii = new GraphicInfoItem(1, 1, "IntTestBox", 1, false, "3", false, 0, 0, 1);

                LORecord l = new LORecord();
                l.GraphicObjectID = 1;
                l.PageID = 1;
                l.ProductYear = uCon.Year;
                l.RecordID = 100;
                l.RecordLineage = 0;
                l.RowDisplayOrder = 1;
                l.DataSourceUsed = 1;
                l.DataType = 1;
                l.LocatorID = 1;

                object o = TaxAppData.GetValueFromThisLocatorObjectRecordByDataSource(l, 0, out otherValues, true);

                l.Values = new LOValue[2];
                l.Values[0] = new LOValue();
                l.Values[0].DataSource = 0;
                l.Values[0].NumericValue = 5;

                l.Values[1] = new LOValue();
                l.Values[1].DataSource = 1;
                l.Values[1].NumericValue = 6;

                Assert.AreEqual(5, TaxAppData.GetValueFromLOV(l.Values[0], 1));
                Assert.AreEqual(6, TaxAppData.GetValueFromLOV(l.Values[1], 1));

                
                o = TaxAppData.GetValueFromThisLocatorObjectRecordByDataSource(l, 0, out otherValues, true);
                Assert.AreEqual(5, o);

            }
            [Test]
            public void TestProcessNodes()
            { 
                //use the mock data source

            }
            [Test]
            public void TestAsyncCallback()
            { 

            }
        }
    }

}
