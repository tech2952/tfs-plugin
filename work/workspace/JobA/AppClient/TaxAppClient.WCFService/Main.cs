using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;
using System.Runtime.Serialization;
using TaxApp.InterfacesAndConstants;
using NUnit.Framework;
using TestHarness.BusinessObjects;
using log4net;
using System.Configuration;
using TaxBuilder.GraphicObjects.TaxAppRuntime;
using TaxBuilder.GraphicObjects;
using System.Drawing;
using SD.LLBLGen.Pro.ORMSupportClasses;
using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.CollectionClasses;
using TestHarness.DataObjects.FactoryClasses;
using TestHarness.DataObjects;
using TaxApp.CalcEngine;
using TaxApp.IntrinsicFunctions;
using System.Threading;

namespace TaxAppClient.WCFService
{
    /// <summary>
    /// If the method signatures are changed, or new methods added, then fire up the WCFService and run the following commands against it - it will generate new files - make sure to check out the corresponding files first
    /// cd C:\TaxBuilder\Development\TestHarness\Thomson.TTA.TAC.BOs
    /// svcutil.exe http://localhost:8080/TaxAppClientWCFService?wsdl /out:TaxAppClient.WCFServiceClient
    /// svcutil.exe http://localhost:8080/TaxAppClientWCFServiceMTOM?wsdl /out:TaxAppClient.WCFServiceClientMTOM /config:outputMTOM.config
    /// also make sure to checkout the two output.config files (output.config & outputMTOM.config)
    /// then make sure to check the namespaces on the two generated files - the brackets are sometimes messed up.
    /// </summary>
    [ServiceContract()]
    public interface ITaxAppClientService
    {
        /// <summary>
        /// Used by ITaxAppClientData to retrieve the clients and locators for the logged in user.
        /// </summary>
        [OperationContract]
        List<CliInfo> GetClientAndLocatorInfo();
        [OperationContract]
        List<string> GetListOfStrings(string messageType);
        [OperationContract]
        int RunMethodByMessageTypeReturnInt(string messageType, string parameters);       
        /// <summary>
        /// Get a set of Records by LocID, Year, RecordLineage, PageID and GraphicID.  If GraphicID = 0, then all records for the page are retrieved.
        /// </summary>
        /// <param name="locatorID">Locator ID</param>
        /// <param name="year">Year</param>
        /// <param name="recordLineage">Rec Lineage</param>
        /// <param name="pageID">PageID</param>
        /// <param name="graphicID">GraphicID</param>
        /// <returns></returns>
        [OperationContract]
        List<LORecord> GetRecords(int locatorID, short year, int recordLineage, int pageID, int graphicID, int parentGraphicID);
        [OperationContract]
        List<LORecord> SetRecords(List<LORecord> records);
        [OperationContract]
        bool DeleteRecords(List<LORecord> records);
    }
    [ServiceContract()]
    public interface ITaxAppClientServiceMTOM
    {
        [OperationContract]
        byte[] RequestBinary(string appName, string fileName);
    }


    public class TaxAppClientService : ITaxAppClientService
    {
        private static readonly ILog theLogger = LogManager.GetLogger("TaxAppClientService");
        private static Dictionary<int, Locator> myLocators;                                     //TODO: Make this thread safe
        private static Dictionary<int, bool> myLocatorIsCalcReady;
        private static Dictionary<int, DateTime> myLastSetTimeByLocator = new Dictionary<int,DateTime>();

        /// <summary>
        /// This returns the current Clients and Locators - this is currently using the testharness
        /// business objects - why do we have to use a different object?  If we use the ClientIDAndNameWithLocatorDictionary
        /// we get a problem with interference between the namespaces...  
        /// //TODO: We'll need to add parms here - in the form of security tokens...
        /// </summary>
        /// <returns></returns>
        public List<CliInfo> GetClientAndLocatorInfo()
        {
            theLogger.Debug("Runtime Database Info: " + ConfigurationManager.AppSettings["Main.ConnectionString"]);
            theLogger.Debug("GetClientAndLocatorInfo called");
            List<CliInfo> cliLocators = new List<CliInfo>();

            ClientImpl cli = new ClientImpl();
            List<ClientIDAndNameWithLocatorDictionary> clientsAndLocators = cli.GetAllClientNames();

            //convert them to CliInfos
            foreach (ClientIDAndNameWithLocatorDictionary cliIDAndName in clientsAndLocators)
            {
                CliInfo ci = new CliInfo(cliIDAndName.ClientID, cliIDAndName.ClientName);
                foreach (LocatorInfo li in cliIDAndName.Locators)
                {
                    ci.Locators.Add(new LocInfo(li.LocatorID, li.Name, li.Year));
                }
                cliLocators.Add(ci);

            }

            return cliLocators;
        }
        /// <summary>
        /// Generic method to fire a method that returns an int, sometimes an ID, sometime and error code.
        /// </summary>
        /// <param name="messageType">message type "RequestClientID", "RequestAddNewLocatorToListForClient", "DeleteLocator" </param>
        /// <param name="parameters">key value pairs of form parmName="value";parmName="value" - depends on the message type</param>
        /// <returns>-10 (ConstantsWCFService.PassedInParmsError), sometimes the ID, sometimes 0 for successful (ITCO Delete)</returns>
        public int RunMethodByMessageTypeReturnInt(string messageType, string parameters)
        {
            theLogger.Debug("RunMethodByMessageTypeReturnInt called.  MessageType: " + messageType.ToString() + " parameters: " + parameters);
            int returnInt = 0;
            Dictionary<string, string> parametersParsed = ParseParameters(parameters);
            try
            {
                switch (messageType)
                {
                    //PARMS:  ClientName, Year
                    case "RequestClientID":
                        returnInt = MethodRequestClientID(parametersParsed);
                        break;

                    //PARMS: ClientID, LocatorName, Year
                    case "RequestAddNewLocatorToListForClient":
                        returnInt = MethodRequestAddNewLocatorToListForClient(parametersParsed);
                        break;

                    //PARMS: LocatorID, Year
                    case "DeleteLocator":
                        returnInt = MethodDeleteLocator(parametersParsed);
                        break;

                    //PARMS: LocatorID, ApplicationName
                    case "StartCalcEngineApplication":
                        returnInt = MethodStartCalcEngineApplicationByLocator(parametersParsed);
                        break;

                    //PARMS: LocatorID, Year
                    case "StartCalcEngineLocator":
                        returnInt = MethodStartCalcEngineForLocator(parametersParsed);
                        break;

                    case "Initialize":
                        returnInt = Initialize();
                        break;

                    default:
                        theLogger.Info("Unknown messageType passed to GetInteger.  MessageType: " + messageType.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                theLogger.Debug("RunMethodByMessageTypeReturnInt error.", ex);
            }

            return returnInt;
        }
        /// <summary>
        /// To run - RunMethodByMessageTypeReturnInt("Initialize", string.empty);
        /// </summary>
        /// <returns></returns>
        private int Initialize()
        {
            if (null == myLastSetTimeByLocator)
            {
                myLastSetTimeByLocator = new Dictionary<int, DateTime>();
            }
            if (DatabaseInitializer.CheckEnterpriseTableAndEnums())
                return 1;
            else
                return 0;
        }
        private int MethodRequestClientID(Dictionary<string, string> parametersParsed)
        {
            ClientImpl ci = new ClientImpl();
            if (!parametersParsed.ContainsKey("ClientName") || !parametersParsed.ContainsKey("Year"))
                return ConstantsWCFService.PassedInParametersError;

            return ci.GetClientByNameAddIfNew(parametersParsed["ClientName"], Convert.ToInt16(parametersParsed["Year"]));
        }
        private int MethodRequestAddNewLocatorToListForClient(Dictionary<string, string> parametersParsed)
        {
            ClientImpl ci2 = new ClientImpl();
            if (!parametersParsed.ContainsKey("ClientID") || !parametersParsed.ContainsKey("LocatorName") || !parametersParsed.ContainsKey("Year"))
                return ConstantsWCFService.PassedInParametersError;
            return ci2.AddNewLocatorToListForClient(Convert.ToInt32(parametersParsed["ClientID"]), parametersParsed["LocatorName"], Convert.ToInt16(parametersParsed["Year"]));
        }
        private int MethodDeleteLocator(Dictionary<string, string> parametersParsed)
        {
            if (!parametersParsed.ContainsKey("LocatorID") || !parametersParsed.ContainsKey("Year"))
                return ConstantsWCFService.PassedInParametersError;
            
            //delete - if it works return 0, else return -1?
            int locID = Convert.ToInt32(parametersParsed["LocatorID"]);
            int year = Convert.ToInt32(parametersParsed["Year"]);
            ClientImpl ci3 = new ClientImpl();
            ci3.DeleteLocator(locID, year);
            LocatorEntity le = new LocatorEntity(Convert.ToInt16(year), locID);
            if (le.IsNew)
                return 0;
            else
                return -1;
        }
        
        
        /// <summary>
        /// PARMS: LocatorID, Year
        /// Method Name: "StartCalcEngineLocator":
        /// </summary>
        /// <param name="parametersParsed"></param>
        /// <returns></returns>
        private int MethodStartCalcEngineForLocator(Dictionary<string, string> parametersParsed)
        {
            if (!parametersParsed.ContainsKey("LocatorID") || !parametersParsed.ContainsKey("Year"))
                return ConstantsWCFService.PassedInParametersError;

            theLogger.Debug("Opening Locator.  LocID: " + parametersParsed["LocatorID"] + "  Year: " + parametersParsed["Year"]);

            IDataSource dataSource = null;
            if (parametersParsed.ContainsKey("UseMockDataSource"))
            {
                dataSource = new MockDataSource(string.Empty);
            }
            else
            {
                string ConnectionstringForLocatorDatabase = ConfigurationManager.AppSettings["Main.ConnectionString"];
                dataSource = new SqlDataSource(ConnectionstringForLocatorDatabase);
            }

            if (myLocators == null)
            {
                myLocators = new Dictionary<int, Locator>();
                myLocatorIsCalcReady = new Dictionary<int, bool>();
            }
            int locID = Convert.ToInt32(parametersParsed["LocatorID"]);
            if (!myLocators.ContainsKey(locID))
            {
                int year = Convert.ToInt32(parametersParsed["Year"]);
                myLocators.Add(locID, Locator.Open(locID, year, dataSource));
                myLocatorIsCalcReady.Add(locID, true);
                theLogger.Debug(string.Format("Locator Opened.  LocID: {0}  Year: {1}", locID, year));
            }

            return 0;
        }


        /// <summary>
        /// PARMS: LocatorID, ApplicationName    "StartCalcEngineApplication":
        /// </summary>
        /// <param name="parametersParsed"></param>
        /// <returns></returns>
        private int MethodStartCalcEngineApplicationByLocator(Dictionary<string, string> parametersParsed)
        {
            if (!parametersParsed.ContainsKey("ApplicationName") || !parametersParsed.ContainsKey("LocatorID"))
                return ConstantsWCFService.PassedInParametersError;

            int locID = Convert.ToInt32(parametersParsed["LocatorID"]);
            string appName = parametersParsed["ApplicationName"];
            theLogger.Debug("Opening Application. ApplicationName: " + appName + " LocID: " + locID);

            ////for now just maintain the calc engine, in process
            if (myLocators.ContainsKey(locID))
            {
                if (!myLastSetTimeByLocator.ContainsKey(locID))
                    myLastSetTimeByLocator.Add(locID, DateTime.Now);
                string binaryDirectory = Path.Combine(ConfigurationManager.AppSettings["ApplicationBinaryDirectory"], appName);
                myLocators[locID].LocatorIsReady += new Locator.LocatorIsReadyEventHandler(TaxAppClientService_LocatorIsReady);
                myLocators[locID].ComputeIsDone += new Locator.ComputeIsDoneEventHandler(this.ComputeFinished);

                myLocators[locID].OpenApplication(binaryDirectory, appName);

            }
            else
            {
                theLogger.Error("Locator not open in CalcEngine.  LocID: " + locID.ToString());
            }
            
            return 0;
        }
        

        void TaxAppClientService_LocatorIsReady(int LocatorID)
        {
            theLogger.Debug("LocatorIsReady event fired.");

            //if (myLocatorIsCalcReady.ContainsKey(LocatorID))
            //{
            //    myLocatorIsCalcReady[LocatorID] = true;
            //    TaxAppClientAsyncService.SendUpdatePagesCall(new List<int>());
            //}
        }

        private void ComputeFinished(int LocatorID, List<int> computedPages)
        {
            theLogger.Debug("ComputeFinished Event from calc engine.  Number of computed pages: " + computedPages.Count);
            TimeSpan ts = DateTime.Now - myLastSetTimeByLocator[LocatorID];
            theLogger.Debug("Time from last SetData: " + ts.TotalSeconds);
            TaxAppClientAsyncService.SendUpdatePagesCall(computedPages);
            
        }


        /// <summary>
        /// Parse the key value pairs into a dictionary
        /// </summary>
        /// <param name="parameters">string of kvp of form parmName="value";parmName="value"</param>
        /// <returns>dictionary</returns>
        public Dictionary<string, string> ParseParameters(string parameters)
        {
            Dictionary<string, string> parsedParms = new Dictionary<string, string>();
            if (parameters == string.Empty)
                return parsedParms;
            try
            {
                string[] s = parameters.Split(new char[2] { Convert.ToChar("="), Convert.ToChar(";")});
                for (int i = 0; i < s.Length; i = i + 2)
                {
                    parsedParms.Add(s[i].Replace("\"", string.Empty), s[i + 1].Replace("\"", string.Empty));
                }
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error encountered parsing the passed in parameters." + parameters);
                theLogger.Error("Error: ", ex);
            }
            return parsedParms;
        }
        /// <summary>
        /// Generic method to get a list of strings
        /// </summary>
        /// <param name="messageType">string enum:  "RequestApplicationNames"</param>
        /// <returns>list of strings</string></returns>
        public List<string> GetListOfStrings(string messageType)
        {
            theLogger.Debug("GetListOfStrings called.");
            List<string> ss = new List<string>();
            switch (messageType)
            { 
                case "RequestApplicationNames":
                    //Get the list of applications that this customer is qualified to access.
                    //not only will they have different applications to access, but this process should make sure that it
                    //has access to the binary files that make up the application.

                    //Another way might be to just get the list from the binaries on disk - could be a switch in the config.
                    ss.Add("Sample_Application");
                    
                    string binaryDirectory = ConfigurationManager.AppSettings["ApplicationBinaryDirectory"];
                    DirectoryInfo di = new DirectoryInfo(binaryDirectory);
                    if (di.Exists)
                    {
                        ss.Clear();
                        foreach (DirectoryInfo diSub in di.GetDirectories())
                        {
                            ss.Add(diSub.Name);
                        }
                    }

                    break;
                default:
                    theLogger.Info("Unknown messageType passed to GetListOfStrings.  MessageType: " + messageType.ToString());
                    break;
            }
            return ss;
        }

        public bool DeleteRecords(List<LORecord> records)
        {
            //could return List<LORecords> with thier RecordIDs = -1 if it is successful...
            bool deleteSuccessful = false;
            PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
            //list of records to delete
            foreach (LORecord lorecord in records)
            {
                LocatorObjectRecordEntity lore = new LocatorObjectRecordEntity(lorecord.RecordID, prefetch);
                if (!lore.IsNew)
                {
                    lore.LocatorObjectValue.DeleteMulti();
                    deleteSuccessful = lore.Delete();
                }
            }
            //also tell the calc engine to delete
            foreach (LORecord lorecordTBD in records)
            {
                if (myLocators.ContainsKey(lorecordTBD.LocatorID))
                {
                    myLocators[lorecordTBD.LocatorID].DeleteRow(lorecordTBD.ParentGraphicID, GetRowLineageFromRecordLineage(lorecordTBD.RecordLineage), lorecordTBD.RowDisplayOrder);
                }
                else
                {
                    theLogger.Warn("CalcEngine Locator not found.");
                }
            }

            return deleteSuccessful;
        }

        #region GetRecords
        /// <summary>
        /// Method to get Locator records from a locator.  To get all graphics on a page, set GraphicID = 0.  Pages with shortcuts will want to get the page graphics and then group the shortcut calls by their page also
        /// </summary>
        /// <param name="locatorID">locatorID</param>
        /// <param name="year">year</param>
        /// <param name="recordLineage">recordLineage</param>
        /// <param name="pageID">pageID</param>
        /// <param name="graphicID">graphicID</param>
        /// <param name="parentGraphicID">ID of grid graphic in the case of columns</param>
        /// <returns>a List of LORecords</returns>
        public List<LORecord> GetRecords(int locatorID, short year, int recordLineage, int pageID, int graphicID, int parentGraphicID)
        {
            //for now we are going to the database and the calc engine.  The calc engine doesn't know about recordLineage
            List<LORecord> records = new List<LORecord>();
            LocatorObjectRecordCollection lorc = GetLocatorObjectRecordCollection(locatorID, year, recordLineage, pageID, graphicID);
            if (lorc.Count > 0)
            {
                foreach (LocatorObjectRecordEntity lor in lorc)
                {
                    LORecord lorecord = new LORecord();
                    lorecord.LocatorID = locatorID;
                    lorecord.ProductYear = year;
                    lorecord.PageID = pageID;
                    lorecord.GraphicObjectID = graphicID;
                    lorecord.RecordID = lor.Record_ID;
                    lorecord.ParentGraphicID = parentGraphicID;
                    lorecord.DataType = lor.DataType_EnumValue;
                    lorecord.RowDisplayOrder = Convert.ToInt16(lor.Row_DisplayOrder);
                    lorecord.RecordLineage = recordLineage;
                    lorecord.DataSourceUsed = lor.DatasourceUsed;
                    foreach (LocatorObjectValueEntity lov in lor.LocatorObjectValue)
                    {
                        LOValue lovalue = new LOValue();
                        lovalue.DataSource = lov.DataSource_EnumValue;
                        lovalue.BooleanValue = lov.BooleanValue;
                        lovalue.StringValue = lov.StringValue;
                        lovalue.NumericValue = Convert.ToDecimal(lov.NumericValue);
                        lovalue.DateTimeValue = lov.DateLastSaved;
                        lovalue.FractionValue = lov.FractionValue;
                        //TODO: Hookup image type- maybe LOValue has byte array.
                        lovalue.DateLastSaved = lov.DateLastSaved;
                        //TODO: history be included in this call?
                        lorecord.Values.Add(lovalue);
                    }
                    records.Add(lorecord);
                }
            }

            if (myLocators.ContainsKey(locatorID))
            {
                //figure out rowLineage from RecordLineage
                RowLineageKey rowLineage = GetRowLineageFromRecordLineage(recordLineage);
                

                try
                {
                    //this should represent the "calced" value - or a dataentry one for zero-level taxFields
                    IBaseType t = myLocators[locatorID].GetData(graphicID, pageID, rowLineage);
                    if (t == null)
                    {
                        theLogger.Debug(string.Format("CalcEngine GetData: PID: {0}   GraphicID: {1}   rowLineage: {2}.  Returned NULL", pageID , graphicID, rowLineage.ToString()));
                    }
                    else
                    {
                        string valueString = ConstructValueString(t);
                        theLogger.Debug(string.Format("CalcEngine GetData: PID: {0}   GraphicID: {1}   rowLineage: {2}.  Returned value: {3}", pageID, graphicID, rowLineage.ToString(), valueString));
                        AddCalcedBaseValesToLORecordSet(t, records, locatorID, pageID, graphicID, year, rowLineage, recordLineage, parentGraphicID);
                        int row = t.Rows;
                        if (!myLocators[locatorID].IsComputedGrid(parentGraphicID))
                        {
                            UpdateLocatorGridRow(locatorID, pageID, parentGraphicID, recordLineage, year, row);
                        }
                    }
                }
                catch (Exception ex)
                {
                    theLogger.Warn(String.Format("The Calc Engine returned an error for the GetData: GID: {0}, PID: {1}, RowLineage: {2}", graphicID, pageID, rowLineage));
                    throw ex;
                }
            }
            return records;
        }

        private string ConstructValueString(IBaseType t)
        {
            string val = string.Empty;
            for (int i = 1; i <= t.Rows; i++)
            {
                t.ActiveRow = i;
                val = val + "Row: " + i + "  Value: " + t.Value.ToString() + "  ";

            }
            return val;
        }
        public RowLineageKey GetRowLineageFromRecordLineage(int recordLineage)
        {
            RowLineageKey rowLineageKey = new RowLineageKey();
            if (recordLineage == 0)
                return rowLineageKey;

            LocatorObjectRecordEntity lore = new LocatorObjectRecordEntity(recordLineage);

            Stack<int> keys = new Stack<int>();
            keys.Push(lore.Row_DisplayOrder);
            int parentID = lore.Record_Lineage;

            if (parentID != 0)
            {
                do
                {
                    lore = new LocatorObjectRecordEntity(parentID);
                    keys.Push(lore.Row_DisplayOrder);
                    parentID = lore.Record_Lineage;

                } while (parentID != 0);
            }
            List<int> rowLineages = new List<int>();
            rowLineageKey = new RowLineageKey(keys.ToArray());
            return rowLineageKey;
        }
        
        private void AddCalcedBaseValesToLORecordSet(IBaseType calcBaseType, List<LORecord> recordsFromDB, int locatorID, int pageID, int graphicID, short year, RowLineageKey rowLineage, int recordLineage, int parentGraphicID)
        {
            if (recordsFromDB.Count == 0)
            {
                for (int i = 1; i < calcBaseType.Rows + 1; i++)
                {
                    //For each one, add it to the recordsFromDB (which is ultimately what is returned), and save it to the database.

                    calcBaseType.ActiveRow = i;
                    object value = calcBaseType.Value;

                    LORecord lorecord = new LORecord();
                    lorecord.LocatorID = locatorID;
                    lorecord.ProductYear = year;
                    lorecord.PageID = pageID;
                    lorecord.GraphicObjectID = graphicID;
                    lorecord.ParentGraphicID = parentGraphicID;
                    lorecord.IsComputedField = calcBaseType.IsComputed;
                    lorecord.RecordID = -1;  //these are records from the calc engine - no - not yet...
                    lorecord.DataType = (byte)calcBaseType.DataTypeEnum;
                    lorecord.RowDisplayOrder = Convert.ToInt16(i);  // Convert.ToInt16(lor.Row_DisplayOrder);
                    lorecord.RecordLineage = recordLineage;
                    
                    //if this is a new record (ie the database doesn't know about it - save it - get a record ID)
                    LocatorObjectRecordEntity loreNew = new LocatorObjectRecordEntity();
                    loreNew.Product_Year = year;
                    loreNew.Locator_ID = locatorID;
                    loreNew.Page_ID = pageID;
                    loreNew.GraphicObject_ID = graphicID;
                    loreNew.DataType_EnumValue = (byte)calcBaseType.DataTypeEnum;
                    loreNew.Row_DisplayOrder = i;
                    loreNew.Record_Lineage = recordLineage;
                    if (calcBaseType.IsComputed)
                    {
                        loreNew.DatasourceUsed = (byte)DataSourceEnum.Compute;
                        lorecord.DataSourceUsed = (byte)DataSourceEnum.Compute;
                    }
                    else
                    {
                        loreNew.DatasourceUsed = (byte)DataSourceEnum.DataEntry;
                        lorecord.DataSourceUsed = (byte)DataSourceEnum.DataEntry;
                    }
                    loreNew.Save();
                                        

                    lorecord.RecordID = loreNew.Record_ID;

                    LOValue lovalue = new LOValue();
                    lovalue.DataSource = lorecord.DataSourceUsed;
                    LocatorObjectValueEntity lovNew = new LocatorObjectValueEntity();
                    lovNew.DataSource_EnumValue = loreNew.DatasourceUsed;

                    switch (calcBaseType.DataTypeEnum)
                    {
                        case EnumKeyDataType.Boolean:
                            lovalue.BooleanValue = (bool)((BOOL)calcBaseType);
                            lovNew.BooleanValue = lovalue.BooleanValue;
                            break;
                        case EnumKeyDataType.Integer:
                        case EnumKeyDataType.Money:
                            lovalue.NumericValue = (int)((INTEGER)calcBaseType);
                            lovNew.NumericValue = lovalue.NumericValue;
                            break;
                        case EnumKeyDataType.String:
                            lovalue.StringValue = (string)((STRING)calcBaseType);
                            lovNew.StringValue = lovalue.StringValue;
                            break;
                        case EnumKeyDataType.DateTime: //datetime
                            lovalue.DateTimeValue = (DateTime)((DATE)calcBaseType);
                            lovNew.DateValue = lovalue.DateTimeValue;
                            break;
                        case EnumKeyDataType.Ratio: //ratio
                            lovalue.FractionValue = Convert.ToDecimal((double)((RATIO)calcBaseType)); //TODO: figure out why I'm using decimal on the client side instead of doubles
                            lovNew.FractionValue = lovalue.FractionValue;
                            break;
                        case EnumKeyDataType.DataTable: //datatable
                            //shouldn't get any of these - data tables are the collections of these rows / values
                            break;
                        case EnumKeyDataType.Image: //image
                            //shouldn't get any of these (but might get these eventually)
                            //TODO: seriously think about hooking this up.
                            break;
                        default:
                            break;
                    }
                    lovalue.DateLastSaved = DateTime.Now;
                    lorecord.Values.Add(lovalue);
                    lovNew.DateLastSaved = lovalue.DateLastSaved;
                    loreNew.LocatorObjectValue.Add(lovNew);
                    loreNew.Save(true);
                    lorecord.RecordID = loreNew.Record_ID;
                    recordsFromDB.Add(lorecord);

                }
            }
            else 
            { 
                //for each row in the basetype, it is possible that we already have the records from the database.
                foreach (LORecord lor in recordsFromDB)
                {
                    if (lor.RowDisplayOrder <= calcBaseType.Rows)
                    {
                        calcBaseType.ActiveRow = lor.RowDisplayOrder;
                        LOValue calcValue = null;
                        LocatorObjectValueEntity lovNew = null;
                        if (calcBaseType.IsComputed)
                        {
                            //make sure the db's record is pointing at the dataSource = calc'd value
                            LocatorObjectRecordEntity loreInDB = new LocatorObjectRecordEntity(lor.RecordID);
                            loreInDB.DatasourceUsed = (byte)DataSourceEnum.Compute;
                            loreInDB.Save();

                            //update the values in the db
                            foreach (LOValue lov in lor.Values)
                            {
                                //On the Set of computed values, need to set the datasource to override
                                if (lov.DataSource == (byte)DataSourceEnum.Compute)
                                {
                                    calcValue = lov;
                                    break;
                                }
                            }
                            if (calcValue == null)
                            {
                                calcValue = new LOValue();
                                calcValue.DataSource = (byte)DataSourceEnum.Compute;
                                calcValue.DateLastSaved = DateTime.Now;
                                lor.Values.Add(calcValue);

                                lovNew = new LocatorObjectValueEntity();
                                lovNew.DataSource_EnumValue = (byte)DataSourceEnum.Compute;
                                lovNew.DateLastSaved = DateTime.Now;
                                SetLocatorObjectValueFromBaseType(lovNew, calcBaseType);
                                lovNew.Record_ID = lor.RecordID;
                                lovNew.Save();
                                
                            }
                            //set the datasource to be from Compute
                            calcValue.DataSource = (byte)DataSourceEnum.Compute;
                            lor.DataSourceUsed = (byte)DataSourceEnum.Compute;
                        }
                        else
                        {
                            foreach (LOValue lov in lor.Values)
                            {
                                if (lov.DataSource == (byte)DataSourceEnum.DataEntry)
                                {
                                    calcValue = lov;
                                    break;
                                }
                            }
                            if (calcValue == null)
                            { 

                            }
                        }

                        SetLORecordValueFromBaseType(calcValue, calcBaseType);
                    }
                }
                if (calcBaseType.Rows > recordsFromDB.Count)
                {
                    //there are rows in calc that are not in the database - save them
                    for (int i = recordsFromDB.Count + 1; i < calcBaseType.Rows + 1; i++)
                    {
                        calcBaseType.ActiveRow = i;
                        object value = calcBaseType.Value;

                        LORecord lorecord2 = new LORecord();
                        lorecord2.LocatorID = locatorID;
                        lorecord2.ProductYear = year;
                        lorecord2.PageID = pageID;
                        lorecord2.GraphicObjectID = graphicID;
                        lorecord2.ParentGraphicID = parentGraphicID;
                        lorecord2.RecordID = -1;  //these are records from the calc engine - do we know the recordID - not yet, but we will...
                        lorecord2.DataType = (byte)calcBaseType.DataTypeEnum;
                        lorecord2.RowDisplayOrder = Convert.ToInt16(i);  // Convert.ToInt16(lor.Row_DisplayOrder);
                        lorecord2.RecordLineage = recordLineage;

                        LocatorObjectRecordEntity loreNew2 = new LocatorObjectRecordEntity();
                        loreNew2.Product_Year = year;
                        loreNew2.Locator_ID = locatorID;
                        loreNew2.Page_ID = pageID;
                        loreNew2.GraphicObject_ID = graphicID;
                        loreNew2.DataType_EnumValue = (byte)calcBaseType.DataTypeEnum;
                        loreNew2.Row_DisplayOrder = i;
                        loreNew2.Record_Lineage = recordLineage;

                        LOValue lovalue2 = new LOValue();
                        LocatorObjectValueEntity lovNew2 = new LocatorObjectValueEntity();
                        loreNew2.LocatorObjectValue.Add(lovNew2);
                        if (calcBaseType.IsComputed)
                        {
                            lovalue2.DataSource = (byte)DataSourceEnum.Compute;
                        }
                        else
                        {
                            lorecord2.DataSourceUsed = (byte)DataSourceEnum.DataEntry;
                        }
                        lorecord2.DataSourceUsed = lovalue2.DataSource;
                        loreNew2.DatasourceUsed = lovalue2.DataSource;
                        lovNew2.DataSource_EnumValue = lovalue2.DataSource;

                        SetLocatorObjectValueFromBaseType(lovNew2, calcBaseType);
                        SetLORecordValueFromBaseType(lovalue2, calcBaseType);

                        
                        lovalue2.DateLastSaved = DateTime.Now;
                        lovNew2.DateLastSaved = lovalue2.DateLastSaved;

                        loreNew2.Save(true);
                        lorecord2.RecordID = loreNew2.Record_ID;
                        lorecord2.Values.Add(lovalue2);
                        recordsFromDB.Add(lorecord2);

                    }

                }

            }
        }
        private void SetLORecordValueFromBaseType(LOValue lovalue, IBaseType value)
        {
            switch (value.DataTypeEnum)
            {
                case EnumKeyDataType.Boolean: //bool
                    lovalue.BooleanValue = (bool)((BOOL)value);
                    break;
                case EnumKeyDataType.Money:
                    lovalue.NumericValue = Convert.ToDecimal((double)((MONEY)value));
                    break;
                case EnumKeyDataType.Integer: //Int
                    lovalue.NumericValue = (int)((INTEGER)value);
                    break;
                case EnumKeyDataType.String: //string
                    lovalue.StringValue = (string)((STRING)value);
                    break;
                case EnumKeyDataType.DateTime: //datetime
                    lovalue.DateTimeValue = (DateTime)((DATE)value);
                    break;
                case EnumKeyDataType.Ratio: //ratio
                    lovalue.FractionValue = Convert.ToDecimal((double)((RATIO)value));
                    break;
                case EnumKeyDataType.DataTable: //datatable
                    //shouldn't get any of these
                    break;
                case EnumKeyDataType.Image: //image
                    //shouldn't get any of these (but might get these eventually)
                    break;
                default:
                    break;
            }
        }
        private void SetLocatorObjectValueFromBaseType(LocatorObjectValueEntity lovEntity, IBaseType value)
        {
            switch (value.DataTypeEnum)
            {
                case EnumKeyDataType.Boolean: //bool
                    lovEntity.BooleanValue = (bool)((BOOL)value);
                    break;
                case EnumKeyDataType.Integer:
                    lovEntity.NumericValue = (int)((INTEGER)value);
                    break;
                case EnumKeyDataType.Money: //money
                    lovEntity.NumericValue = Convert.ToDecimal((double)((MONEY)value));
                    break;
                case EnumKeyDataType.String: //string
                    lovEntity.StringValue = (string)((STRING)value);
                    break;
                case EnumKeyDataType.DateTime: //datetime
                    lovEntity.DateValue = (DateTime)((DATE)value);
                    break;
                case EnumKeyDataType.Ratio: //ratio
                    lovEntity.FractionValue = Convert.ToDecimal((double)((RATIO)value));
                    break;
                case EnumKeyDataType.DataTable: //datatable
                    //shouldn't get any of these
                    break;
                case EnumKeyDataType.Image: //image
                    //shouldn't get any of these (but might get these eventually)
                    break;
                default:
                    break;
            }

        }

        private LocatorObjectRecordCollection GetLocatorObjectRecordCollection(int locatorID, short year, int recordLineage, int pageID, int graphicID)
        {
            LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            //prefetch
            PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
            //filter
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, locatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, year));
            if (graphicID != 0)
            {
                filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, graphicID));
            }
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, pageID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, recordLineage));
            //sourt
            ISortExpression sortClause = new SortExpression(SortClauseFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder, SortOperator.Ascending));
            //get 'em
            lorc.GetMulti(filter, 0, sortClause, null, prefetch);
            return lorc;
        }
        #endregion

        #region Set Records
        /// <summary>
        /// the interface on TaxappData is: SetValue(int PageID, int RuntimeGraphicID, object value, DataSourceEnum dataSource, int RecordLineage)
        /// for grids, the value is a datatable - this is deconstructed into LOrecords
        /// </summary>
        /// <param name="records">List of Records for a page with same locatorID, year, pageID, and recordLineage</param>
        /// <returns></returns>
        public List<LORecord> SetRecords(List<LORecord> records)
        {
            if (records.Count == 0)
                return records;

            Dictionary<LocatorObjectRecordKey, Dictionary<int, LORecord>> keyRecordColl = CleanUpDuplicatesSeperateIntoRows(records);

            int recordCount = keyRecordColl.Values.Count;

            //This is breaking it down into a set (by LocatorID/Year/PageID/GraphicID/RecordLineage) having a row dictionary of LORecords
            foreach (KeyValuePair<LocatorObjectRecordKey, Dictionary<int, LORecord>> kvp in keyRecordColl) 
            {
                ProcessSaveForRowDictionaryOfLORecords(kvp);
            }

            //also set them in the CalcEngine
            foreach (LORecord rec in records)
            {
                if (myLocatorIsCalcReady.ContainsKey(rec.LocatorID) && myLocatorIsCalcReady[rec.LocatorID])
                {
                    if (myLocators.ContainsKey(rec.LocatorID))
                    {
                        object value = null;
                        foreach (LOValue lov in rec.Values)
                        {
                            if (lov.DataSource == rec.DataSourceUsed)
                            {
                                switch (rec.DataType)
                                {
                                    case 0: //bool
                                        value = lov.BooleanValue;
                                        break;
                                    case 1: //Int
                                        value = Convert.ToInt32(lov.NumericValue);
                                        break;
                                    case 8: //money
                                        value = Convert.ToDouble(lov.NumericValue);
                                        break;
                                    case 2: //string
                                        value = lov.StringValue;
                                        break;
                                    case 3: //datetime
                                        value = lov.DateTimeValue;
                                        break;
                                    case 7: //ratio
                                        value = Convert.ToDouble(lov.FractionValue);
                                        break;
                                    case 9: //datatable
                                        //shouldn't get any of these - completely bail
                                        theLogger.Debug("DataTable type sent in SetRecords - error");
                                        return records;
                                    case 10: //image
                                        theLogger.Debug("Image type sent in SetRecords");
                                        return records;
                                    default:
                                        break;
                                }
                                break;
                            }
                        }
                        //TODO: remove this and use the calc engines
                        RowLineageKey rowLineage = GetRowLineageFromRecordLineage(rec.RecordLineage);

                        if (rec.RecordWasAdded)
                        {
                            if (theLogger.IsDebugEnabled)
                                theLogger.Debug(string.Format("Calling InsertRow: ParentGraphicID: {0}   RowLineageKey: {1}   RowDisplayOrder:  {2}", rec.ParentGraphicID, rowLineage, rec.RowDisplayOrder));
                            myLocators[rec.LocatorID].InsertRow(rec.ParentGraphicID, rowLineage, rec.RowDisplayOrder);
                        }
                        
                        if (theLogger.IsDebugEnabled)
                        {
                            theLogger.Debug(String.Format("Calling SetData on Locator.  LocatorID: {0}   PageID: {1}  GraphicID: {2}   RowLineageToString: {3}    RowDisplayOrder: {4}   Value: {5}",
                                    rec.LocatorID, rec.PageID, rec.GraphicObjectID, rowLineage.ToString(), rec.RowDisplayOrder, value.ToString()));
                            if (myLastSetTimeByLocator.ContainsKey(rec.LocatorID))
                                myLastSetTimeByLocator[rec.LocatorID] = DateTime.Now;
                            else
                            {
                                myLastSetTimeByLocator.Add(rec.LocatorID, DateTime.Now);
                            }
                        }
                        myLocators[rec.LocatorID].SetData(rec.GraphicObjectID, rec.PageID, rowLineage, rec.RowDisplayOrder, value);
                        
                    }

                }
            }
            return records;
        }

        private void ProcessSaveForRowDictionaryOfLORecords(KeyValuePair<LocatorObjectRecordKey, Dictionary<int, LORecord>> kvp)
        {
            //this is getting by graphic - could group by page if we wanted to
            LocatorObjectRecordCollection lorcExisting = GetLocatorObjectRecordCollection(kvp.Key.LocatorID, kvp.Key.Year, kvp.Key.RecordLineage, kvp.Key.PageID, kvp.Key.GraphicID);

            int maxRow = 0;
            foreach (int i in kvp.Value.Keys)
            {
                if (i > maxRow)
                {
                    maxRow = i;
                }
            }


            foreach (KeyValuePair<int, LORecord> kvpRecord in kvp.Value)
            {
                
                LocatorObjectRecordEntity loreExisting = null;
                if (kvpRecord.Value.RecordID == -1)
                {
                    //it thinks it is a new value
                    foreach (LocatorObjectRecordEntity lore in lorcExisting)
                    {
                        if (lore.Row_DisplayOrder == kvpRecord.Value.RowDisplayOrder)
                        {
                            //there is an entry for this displayorder in the database.  
                            kvpRecord.Value.RecordID = lore.Record_ID;
                            kvpRecord.Value.RecordWasAdded = false;
                            loreExisting = lore;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (LocatorObjectRecordEntity lore in lorcExisting)
                    {
                        if (lore.Record_ID == kvpRecord.Value.RecordID)
                        {
                            kvpRecord.Value.RecordWasAdded = false;
                            loreExisting = lore;
                            break;
                        }
                    }
                }

                if (kvpRecord.Value.RecordID == -1)
                {
                    //it is a new record - save it
                    //find out if the locatorgridrow is already incremented.
                    int rowCount = GetLocatorGridRowCount(kvpRecord.Value.LocatorID, kvpRecord.Value.PageID, kvpRecord.Value.ParentGraphicID, kvpRecord.Value.RecordLineage, kvpRecord.Value.ProductYear);
                    if (rowCount < maxRow)
                    {
                        kvpRecord.Value.RecordWasAdded = true;
                    }
                    SaveNewLORecordIntoDatabaseObject(kvpRecord.Value);
                }
                else
                {
                    int returnInt = SaveLORecordIntoExistingDatabaseObject(loreExisting, kvpRecord.Value);
                    if (returnInt == -1)
                    {
                        kvpRecord.Value.RecordID = -2;
                    }
                }

            }

            //if it is a grid, make sure to update the LocatorGridRow
            if (kvp.Key.ParentGraphicID != 0)
            {
                
                UpdateLocatorGridRow(kvp.Key.LocatorID, kvp.Key.PageID, kvp.Key.ParentGraphicID, kvp.Key.RecordLineage, kvp.Key.Year, maxRow);

            }
        }

        private int GetLocatorGridRowCount(int locatorID, int pageID, int gridID, int recordLineage, short year)
        {

            LocatorGridRowCollection lgrc = new LocatorGridRowCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Locator_ID, ComparisonOperator.Equal, locatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Page_ID, ComparisonOperator.Equal, pageID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, gridID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Record_Lineage, ComparisonOperator.Equal, recordLineage));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Product_Year, ComparisonOperator.Equal, year));

            lgrc.GetMulti(filter);

            if (lgrc.Count == 1)
                return lgrc[0].Row_Count;
            else
                return 0;

        }
        private void UpdateLocatorGridRow(int locatorID, int pageID, int gridID, int recordLineage, short year, int maxRow)
        {
            if (gridID == 0)
            {
                theLogger.Warn("GridID = 0 in UpdateLocatorGridRow.  Returning.");
                return;
            }

            LocatorGridRowCollection lgrc = new LocatorGridRowCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Locator_ID, ComparisonOperator.Equal, locatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Page_ID, ComparisonOperator.Equal, pageID));
            //the parent graphic id will be the grid.
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, gridID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Record_Lineage, ComparisonOperator.Equal, recordLineage));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Product_Year, ComparisonOperator.Equal, year));

            lgrc.GetMulti(filter);

            theLogger.Debug("Updating LocatorGridRow.  LocatorGridRowCollection.Count: " + lgrc.Count + "  RowCount: " + maxRow);

            if (lgrc.Count == 1)
            {
                lgrc[0].Row_Count = maxRow;
                lgrc[0].Save();
            }
            else if (lgrc.Count == 0)
            {
                LocatorGridRowEntity lgre = new LocatorGridRowEntity();
                lgre.Page_ID = pageID;
                lgre.Locator_ID = locatorID;
                lgre.GraphicObject_ID = gridID;
                lgre.Record_Lineage = recordLineage;
                lgre.Product_Year = year;
                lgre.Row_Count = maxRow;
                lgre.Save();
            }
            else
            {
                theLogger.Warn(string.Format("Multiple entries in Locator Grid Row table for LocatorID: {0}  PageID: {1}  GridID: {2}  RecordLineage: {3}  Year: {4}", 
                        locatorID, pageID, gridID, recordLineage, year));
            }
        }

        private Dictionary<LocatorObjectRecordKey, Dictionary<int, LORecord>> CleanUpDuplicatesSeperateIntoRows(List<LORecord> records)
        {
            Dictionary<LocatorObjectRecordKey, Dictionary<int, LORecord>> keyRecordColl = new Dictionary<LocatorObjectRecordKey, Dictionary<int, LORecord>>();
            List<LORecord> recordsToBeRemoved = new List<LORecord>();
            foreach (LORecord lorecord in records)
            {
                if (keyRecordColl.ContainsKey(lorecord.NonRecordIDKey))
                {
                    if (keyRecordColl[lorecord.NonRecordIDKey].ContainsKey(lorecord.RowDisplayOrder))
                    {
                        //duplicate record!
                        recordsToBeRemoved.Add(lorecord);
                    }
                    else
                    {
                        keyRecordColl[lorecord.NonRecordIDKey].Add(lorecord.RowDisplayOrder, lorecord);
                    }
                }
                else
                {
                    Dictionary<int, LORecord> recordsNew = new Dictionary<int, LORecord>();
                    recordsNew.Add(lorecord.RowDisplayOrder, lorecord);
                    keyRecordColl.Add(lorecord.NonRecordIDKey, recordsNew);
                }
            }
            foreach (LORecord recordTBR in recordsToBeRemoved)
            {
                records.Remove(recordTBR);
            }
            return keyRecordColl;
        }

        private void SaveNewLORecordIntoDatabaseObject(LORecord lor)
        {
            LocatorObjectRecordEntity lorNew = new LocatorObjectRecordEntity();
            lorNew.Product_Year = Convert.ToInt16(lor.ProductYear);
            lorNew.Locator_ID = lor.LocatorID;
            lorNew.Page_ID = lor.PageID;
            lorNew.GraphicObject_ID = lor.GraphicObjectID;
            lorNew.DataType_EnumValue = lor.DataType;
            lorNew.Row_DisplayOrder = lor.RowDisplayOrder;
            lorNew.DatasourceUsed = lor.DataSourceUsed;
            lorNew.Record_Lineage = lor.RecordLineage;
            foreach (LOValue lov in lor.Values)
            {
                LocatorObjectValueEntity lovNew = new LocatorObjectValueEntity();
                lovNew.DataSource_EnumValue = lov.DataSource;
                switch (lor.DataType)
                {
                    case 0:  //bool
                        lovNew.BooleanValue = lov.BooleanValue;
                        break;
                    case 1:  //int
                    case 8: //money
                        lovNew.NumericValue = lov.NumericValue;
                        break;
                    case 2: //string
                        lovNew.StringValue = lov.StringValue;
                        break;
                    case 3:  //DateTime
                        lovNew.DateValue = lov.DateTimeValue;
                        break;
                    case 7:  //ratio
                        lovNew.FractionValue = lov.FractionValue;
                        break;
                    default:
                        break;

                }
                lovNew.Save_History = "created: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                lovNew.DateLastSaved = DateTime.Now;
                lorNew.LocatorObjectValue.Add(lovNew);
            }
            if (!lorNew.Save(true))
            {
                theLogger.Warn("Error saving.");
                return;
            }
            lor.RecordID = lorNew.Record_ID;
        }
        private int SaveLORecordIntoExistingDatabaseObject(LocatorObjectRecordEntity lorEntity, LORecord loRecord)
        {
            bool updated = false;
            if (lorEntity.DataType_EnumValue != loRecord.DataType)
            {
                theLogger.Warn("DataTypeEnum mismatch.  Invalid RecordID matchup.  Not saving.  RecordID: " + loRecord.RecordID);
                return -1;
            }
            if (lorEntity.Row_DisplayOrder != loRecord.RowDisplayOrder)
            {
                if (theLogger.IsDebugEnabled)
                    theLogger.Debug("Updating RowDisplayOrder in RecordID: " + loRecord.RecordID + " to value: " + loRecord.RowDisplayOrder);
                lorEntity.Row_DisplayOrder = loRecord.RowDisplayOrder;
                updated = true;
            }

            if (lorEntity.DatasourceUsed != loRecord.DataSourceUsed)
            {
                if (theLogger.IsDebugEnabled)
                    theLogger.Debug("Updating DataSourceUsed in RecordID: " + loRecord.RecordID + " to value: " + loRecord.DataSourceUsed);
                lorEntity.DatasourceUsed = loRecord.DataSourceUsed;
                updated = true;
            }

            
            foreach (LOValue lov in loRecord.Values)
            {
                bool found = false;
                foreach (LocatorObjectValueEntity love in lorEntity.LocatorObjectValue)
                {
                    
                    if (love.DataSource_EnumValue == lov.DataSource)
                    {
                        switch (loRecord.DataType)
                        {
                            //TODO: remove this switch somehow
                            case 0:  //bool
                                love.BooleanValue = lov.BooleanValue;
                                break;
                            case 1:  //int
                            case 8: //money
                                love.NumericValue = lov.NumericValue;
                                break;
                            case 2: //string
                                love.StringValue = lov.StringValue;
                                break;
                            case 3:  //DateTime
                                love.DateValue = lov.DateTimeValue;
                                break;
                            case 7:  //ratio
                                love.FractionValue = lov.FractionValue;
                                break;
                            default:
                                break;

                        }
                        found = true;
                        if (love.IsDirty)
                        {
                            updated = true;
                            love.DateLastSaved = DateTime.Now;
                        }
                        break;
                    }

                }
                if (!found)
                {
                    LocatorObjectValueEntity lovNew = new LocatorObjectValueEntity();
                    lovNew.DataSource_EnumValue = lov.DataSource;
                    switch (loRecord.DataType)
                    {
                            //TODO: remove this switch somehow
                        case 0:  //bool
                            lovNew.BooleanValue = lov.BooleanValue;
                            break;
                        case 1:  //int
                        case 8: //money
                            lovNew.NumericValue = lov.NumericValue;
                            break;
                        case 2: //string
                            lovNew.StringValue = lov.StringValue;
                            break;
                        case 3:  //DateTime
                            lovNew.DateValue = lov.DateTimeValue;
                            break;
                        case 7:  //ratio
                            lovNew.FractionValue = lov.FractionValue;
                            break;
                        default:
                            break;

                    }
                    updated = true;
                    lorEntity.LocatorObjectValue.Add(lovNew);
                }
            }
            bool entitySaveIsGood = lorEntity.Save(true);
            if (!entitySaveIsGood)
            {
                theLogger.Error("Error saving LocatorObjectRecordEntity.");
                updated = false;
            }
            if (updated)
                return 1;
            else
                return 0;
        }
        #endregion
    }

    public class TaxAppClientServiceMTOM : ITaxAppClientServiceMTOM
    {
        private static readonly ILog theLogger = LogManager.GetLogger("TaxAppClientServiceMTOM");
        /// <summary>
        /// Request a binary file be downloaded to the calling client via WCF using the MTOM compression routines
        /// </summary>
        /// <param name="binaryFileEnum"></param>
        /// <param name="AppName"></param>
        /// <returns></returns>
        public byte[] RequestBinary(string appName, string fileName)
        {
            theLogger.Debug("RequestBinary called.");
            byte[] file = null;
            if (appName == "Images")
            {
                //this functionality needs to be moved from here - the image library for the application
                //should be downloaded and used locally by TestHarness
                ApplicationInfoRetrieverFromTaxBuilderDesignDB appinfo = new ApplicationInfoRetrieverFromTaxBuilderDesignDB();
                appinfo.Initialize(new UserConfigurationItems());
                file = appinfo.GetImageBytes(Convert.ToInt32(fileName));

                theLogger.Debug("Image retrieved from database.  Byte size: " + file.Length);
            }
            else
            {
                string binaryDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, appName);
                try
                {
                    binaryDirectory = Path.Combine(ConfigurationManager.AppSettings["ApplicationBinaryDirectory"], appName);
                }
                catch (Exception)
                {
                    theLogger.Warn("ApplicationBinaryDirectory Key not found.  Using base directory.");
                }

                fileName = Path.Combine(binaryDirectory, fileName);
                
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                {
                    int l = Convert.ToInt32(fi.Length);
                    theLogger.Debug("Getting file: " + fileName + " which is length: " + fi.Length);
                    file = new byte[fi.Length];
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        fs.Read(file, 0, l);
                    }
                }
                else
                {
                    theLogger.Warn("Requested binary file: " + fileName + " Not found.");
                }
                fi = null;
            }
            return file;
        }
    }

    public class LocatorObjectRecordKey
    {
        private int myLocatorID;
        private short myYear;
        private int myRecordLineage;
        private int myPageID;
        private int myGraphicID;
        private int myParentGraphicID;

        public int LocatorID
        {
            get { return myLocatorID; }
            set { myLocatorID = value; }
        }
        public short Year
        {
            get { return myYear; }
            set { myYear = value; }
        }
        public int RecordLineage
        {
            get { return myRecordLineage; }
            set { myRecordLineage = value; }
        }
        public int PageID
        {
            get { return myPageID; }
            set { myPageID = value; }
        }
        public int GraphicID
        {
            get { return myGraphicID; }
            set { myGraphicID = value; }
        }
        public int ParentGraphicID
        {
            get { return myParentGraphicID; }
            set { myParentGraphicID = value; }
        }

        public LocatorObjectRecordKey()
        {

        }
        public LocatorObjectRecordKey(LORecord lorecord)
        {
            myLocatorID = lorecord.LocatorID;
            myPageID = lorecord.PageID;
            myYear = lorecord.ProductYear;
            myRecordLineage = lorecord.RecordLineage;
            myGraphicID = lorecord.GraphicObjectID;
            myParentGraphicID = lorecord.ParentGraphicID;
        }
        public override bool Equals(object obj)
        {
            return (((LocatorObjectRecordKey)obj).LocatorID.Equals(myLocatorID) &&
                     ((LocatorObjectRecordKey)obj).Year.Equals(myYear) &&
                     ((LocatorObjectRecordKey)obj).PageID.Equals(myPageID) &&
                     ((LocatorObjectRecordKey)obj).GraphicID.Equals(myGraphicID) &&
                     ((LocatorObjectRecordKey)obj).RecordLineage.Equals(myRecordLineage));
        }
        public override int GetHashCode()
        {
            //TODO: this probably isn't the best way to do this - but this will make it unique.  Need to research most efficient hashing function.
            string s = myLocatorID.ToString() + "." + myYear.ToString() + "." + myPageID.ToString() + "." + myRecordLineage.ToString() + "." + myGraphicID.ToString();
            //return s.GetHashCode();
            return TaxApp.IntrinsicFunctions.HashUtil.GetHashCode32(s);
        }
    }

    namespace Tests
    {
        [TestFixture]
        public class TaxAppClientServiceTests
        {
            UserConfigurationItems uCon = new UserConfigurationItems();
            [Test]
            public void ObjectCD()
            {
                TaxAppClientService o = new TaxAppClientService();
                Assert.IsNotNull(o);
                TaxAppClientServiceMTOM o2 = new TaxAppClientServiceMTOM();
                Assert.IsNotNull(o2);
            }
            [Test]
            public void LocatorObjectRecordKeyObjectCD()
            {
                LocatorObjectRecordKey o = new LocatorObjectRecordKey();
                o.LocatorID = 5;
                o.Year = uCon.Year;
                o.RecordLineage = 7;
                o.PageID = 6;
                o.GraphicID = 8;
                o.ParentGraphicID = 55;
                int hashcode1 = o.GetHashCode();
                Assert.AreEqual(5, o.LocatorID);
                Assert.AreEqual(uCon.Year, o.Year);
                Assert.AreEqual(7, o.RecordLineage);
                Assert.AreEqual(6, o.PageID);
                Assert.AreEqual(8, o.GraphicID);
                Assert.AreEqual(55, o.ParentGraphicID);

                LORecord lor = new LORecord();
                lor.LocatorID = 5;
                lor.PageID = 6;
                lor.ProductYear = uCon.Year;
                lor.RecordLineage = 7;
                lor.GraphicObjectID = 8;
                

                LocatorObjectRecordKey o2 = new LocatorObjectRecordKey(lor);
                Assert.AreEqual(o, o2);
                int hashcode2 = o2.GetHashCode();
                Assert.AreEqual(hashcode1, hashcode2);
                o2.GraphicID = 17;
                Assert.AreNotEqual(o, o2);

            }
            [Test]
            public void GetClientAndLocatorInfoTest()
            {
                CheckForAndAddLocatorReturnID();
                TaxAppClientService t = new TaxAppClientService();
                List<CliInfo> clis = t.GetClientAndLocatorInfo();
                foreach (CliInfo cli in clis)
                {
                    Console.WriteLine(cli.ClientName +  " : " + cli.ClientID);
                    foreach (LocInfo li in cli.Locators)
                    {
                        Console.WriteLine("\t" +li.Name);
                    }
                }
            }
            [Test]
            public void GetListOfStringsTests()
            { 
                TaxAppClientService o = new TaxAppClientService();
                List<String> ss = o.GetListOfStrings("RequestApplicationNames");
                Assert.IsNotNull(ss);

                List<string> ss2 = o.GetListOfStrings("RequestClientID");
                Assert.IsNotNull(ss2);
                Assert.AreEqual(0, ss2.Count);

            }
            //[Test]
            public void RequestBinaryTest()
            {
                //first make sure there is a file in the running base directory
                string binaryDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                binaryDirectory = Path.Combine(ConfigurationManager.AppSettings["ApplicationBinaryDirectory"], "Sample_Application");
                string filename = Path.Combine(binaryDirectory, GetVariousFileNameMethods.GetApplicationInfoNavigationFileName("Sample_Application", AppTypeEnum.TaxApp, uCon.Year));
                string filename2 = Path.Combine(binaryDirectory, GetVariousFileNameMethods.GetApplicationInfoNavigationFileName("Sample_Application", AppTypeEnum.Print, uCon.Year));
                File.Delete(filename);
                File.Delete(filename2);
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                FileStream fs2 = new FileStream(filename2, FileMode.OpenOrCreate, FileAccess.Write);
                Console.WriteLine("filename: " + filename);
                Console.WriteLine("filename2: " + filename2);
                byte[] file = new byte[5];
                file[0] = Convert.ToByte(1);
                file[1] = Convert.ToByte(2);
                file[2] = Convert.ToByte(3);
                file[3] = Convert.ToByte(4);
                file[4] = Convert.ToByte(5);
                fs.Write(file, 0, 5);
                fs.Flush();
                fs.Close();
                fs.Dispose();

                fs2.Write(file, 0, 5);
                fs2.Flush();
                fs2.Close();
                fs2.Dispose();

                TaxAppClientServiceMTOM t = new TaxAppClientServiceMTOM();
                Assert.IsNotNull(t);
                byte[] b = t.RequestBinary("Sample_Application", filename);
                byte[] b2 = t.RequestBinary("Sample_Application", filename2);
                Assert.IsNotNull(b);
                Assert.AreEqual(b, file);
                Assert.IsNotNull(b2);
                Assert.AreEqual(b2, file);
                Assert.AreEqual(b2, b);
            }
            [Test]
            public void RunMethodByMessageTypeReturnIntTest()
            {
                TaxAppClientService o = new TaxAppClientService();
                int i = o.RunMethodByMessageTypeReturnInt("RequestClientID", "ClientName=\"NAME\";Year=\"" + uCon.Year + "\"");
                Assert.IsNotNull(i);
                Assert.AreNotEqual(0, i);

                int clientID = i;

                
                ////PARMS: ClientID, LocatorName, Year
                int locID = o.RunMethodByMessageTypeReturnInt("RequestAddNewLocatorToListForClient", "ClientID=\""+ clientID +"\";Year=\"" + uCon.Year + "\";LocatorName=\"NewLocName\"");
                Assert.IsTrue(locID > 0);


                //ClientID, LocatorName, Year
                int successInt = o.RunMethodByMessageTypeReturnInt("DeleteLocator", "LocatorID=\"" + locID + "\";Year=\"" + uCon.Year + "\"");
                Assert.AreEqual(0, successInt);


                o.RunMethodByMessageTypeReturnInt("Test", string.Empty);

            }
            [Test]
            public void ParseParametersTest()
            {
                TaxAppClientService o = new TaxAppClientService();
                string parms = "ClientName=\"Client\";Year=\"" + uCon.Year + "\"";
                Dictionary<string, string> dic = o.ParseParameters(parms);
                Assert.AreEqual(2, dic.Count);
                Assert.AreEqual("Client", dic["ClientName"]);
                Assert.AreEqual(uCon.Year.ToString(), dic["Year"]);

            }
            private int CheckForAndAddLocatorReturnID()
            {
                DatabaseInitializer.CheckEnterpriseTableAndEnums();
                int locID = 0;
                LocatorCollection lc = new LocatorCollection();
                lc.GetMulti(null, 1);
                if (lc.Count == 0)
                {
                    LocatorEntity le = new LocatorEntity();
                    le.Product_Year = uCon.Year;
                    le.Locator_Name = "NUnit Loc";
                    le.Save();
                    locID = le.Locator_ID;

                    int clientID = 0;

                    ClientEntity ce = new ClientEntity();
                    ce.Client_Name = "NAME";
                    ce.Product_Year = uCon.Year;
                    ce.Product_License = "LICENSE";
                    ce.Firm_Code = "FIRM";
                    ce.Account_Code = "ACCOUNT";
                    ce.Save();
                    clientID = ce.Client_ID;

                    Assert.IsTrue(clientID > 0);
                    ClientLocatorEntity cle = new ClientLocatorEntity();
                    cle.Product_Year = uCon.Year;
                    cle.Client_ID = clientID;
                    cle.Locator_ID = locID;
                    cle.Save();

                }
                else
                {
                    locID = lc[0].Locator_ID;
                }
                return locID;
            }
            [Test]
            public void GetAndSetTestToDBAndCalcEngine()
            {
                int locID = CheckForAndAddLocatorReturnID();
                Console.WriteLine("LocID: " + locID);

                //clean up any old values.
                LocatorObjectRecordCollection lorcDele = new LocatorObjectRecordCollection();
                PredicateExpression filter = new PredicateExpression();
                filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, 5));
                filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, locID));
                filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, uCon.Year));
                lorcDele.GetMulti(filter);
                foreach (LocatorObjectRecordEntity lorDel in lorcDele)
                {
                    lorDel.LocatorObjectValue.DeleteMulti();
                }
                lorcDele.DeleteMulti();
                Assert.AreEqual(0, lorcDele.GetDbCount(filter));


                //signal the WCF service to load up the calc engine for this locator and the sample-application app
                TaxAppClientService o = new TaxAppClientService();
                string parmsCalcLoc = "LocatorID=\"1\";Year=\"" + uCon.Year.ToString() + "\";UseMockDataSource=\"true\"";
                o.RunMethodByMessageTypeReturnInt("StartCalcEngineLocator", parmsCalcLoc );
                o.RunMethodByMessageTypeReturnInt("StartCalcEngineApplication", "ApplicationName=\"Sample_Application\"");

                List<LORecord> recs = new List<LORecord>();

                //a set records with an empty list of LORecords doesn't do anything...
                List<LORecord> recEmpty = o.SetRecords(recs);
                Assert.AreEqual(0, recEmpty.Count);


                LORecord r = new LORecord();
                r.PageID = 5;
                r.LocatorID = locID;
                r.GraphicObjectID = 101;
                r.ProductYear = uCon.Year;
                r.RecordID = -1;
                r.RecordLineage = 0;
                r.RowDisplayOrder = 1;
                r.DataSourceUsed = 0;
                r.DataType = 0;  //boolean
                LOValue v = new LOValue();
                v.DataSource = 0;
                v.BooleanValue = true;
                r.Values = new List<LOValue>();
                r.Values.Add(v);

                recs.Add(r);


                List<LORecord> retI = o.SetRecords(recs);
                Assert.AreEqual(1, retI.Count);
                Assert.IsTrue(retI[0].RecordID != 0);
                int recID = retI[0].RecordID;

                retI[0].RecordID = -1;
                List<LORecord> retRecsThinksItIsNewButIsnt = o.SetRecords(retI);
                Assert.AreEqual(recID, retRecsThinksItIsNewButIsnt[0].RecordID);

                List<LORecord> retII = o.SetRecords(recs);
                Assert.AreEqual(1, retII.Count);

                LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
                PredicateExpression filter2 = new PredicateExpression();
                filter2.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, 101));
                filter2.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, 5));
                filter2.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, locID));
                Assert.AreEqual(1, lorc.GetDbCount(filter2));

                List<LORecord> rs = o.GetRecords(locID, uCon.Year, 0, 5, 101, 0);
                Assert.AreEqual(1, rs.Count);
                Assert.AreEqual(1, rs[0].RowDisplayOrder);
                Assert.AreEqual(101, rs[0].GraphicObjectID);
                Assert.AreEqual(locID, rs[0].LocatorID);
                Assert.AreEqual(5, rs[0].PageID);
                Assert.AreEqual(1, rs[0].Values.Count);
                Assert.AreEqual(0, rs[0].DataSourceUsed);

                rs[0].DataSourceUsed = 1;
                LOValue v2 = new LOValue();
                v2.DataSource = 1;
                v2.BooleanValue = false;
                rs[0].Values.Add(v2);

                List<LORecord> retIII = o.SetRecords(rs);
                Assert.AreEqual(1, retIII.Count);

                List<LORecord> retIV = o.SetRecords(rs);
                Assert.AreEqual(1, retIV.Count);

                rs = o.GetRecords(locID, uCon.Year, 0, 5, 101, 0);
                Assert.AreEqual(2, rs[0].Values.Count);
                Assert.AreEqual(1, rs[0].DataSourceUsed);
                foreach (LOValue lov1 in rs[0].Values)
                {
                    if (lov1.DataSource == 0)
                        Assert.AreEqual(true, lov1.BooleanValue);
                    if (lov1.DataSource == 1)
                        Assert.AreEqual(false, lov1.BooleanValue);
                }

                //add in an extra record with the same display_row - make sure the set straightens it out...
                LORecord r2 = new LORecord();
                r2.PageID = 5;
                r2.LocatorID = locID;
                r2.GraphicObjectID = 101;  //same graphic, same row display order
                r2.ProductYear = uCon.Year;
                r2.RecordID = -1;
                r2.RecordLineage = 0;
                r2.RowDisplayOrder = 1;
                r2.DataSourceUsed = 0;
                r2.DataType = 0;  //boolean
                r2.RecordWasDeleted = true;  //it still should sort it out, but this needs to be included so that we can tell the calc engine
                LOValue v3 = new LOValue();
                v3.DataSource = 0;
                v3.BooleanValue = false;
                r2.Values = new List<LOValue>();
                r2.Values.Add(v3);

                rs.Add(r2);
                List<LORecord> retV = o.SetRecords(rs);

                Assert.AreEqual(1, retV.Count);

                LORecord r11 = new LORecord();
                r11.PageID = 5;
                r11.LocatorID = locID;
                r11.GraphicObjectID = 111;
                r11.ProductYear = uCon.Year;
                r11.RecordID = -1;
                r11.RecordLineage = 0;
                r11.RowDisplayOrder = 1;
                r11.DataSourceUsed = 0;
                r11.DataType = 2;  //string
                LOValue v11 = new LOValue();
                v11.DataSource = 0;
                v11.StringValue = "StringValue";
                r11.Values = new List<LOValue>();
                r11.Values.Add(v11);
                rs.Add(r11);

                LORecord r12 = new LORecord();
                r12.PageID = 5;
                r12.LocatorID = locID;
                r12.GraphicObjectID = 112;
                r12.ProductYear = uCon.Year;
                r12.RecordID = -1;
                r12.RecordLineage = 0;
                r12.RowDisplayOrder = 1;
                r12.DataSourceUsed = 0;
                r12.DataType = 3;  //datetime
                LOValue v12 = new LOValue();
                v12.DataSource = 0;
                v12.DateTimeValue = new DateTime(2007, 3, 15);
                r12.Values = new List<LOValue>();
                r12.Values.Add(v12);
                rs.Add(r12);

                LORecord r13 = new LORecord();
                r13.PageID = 5;
                r13.LocatorID = locID;
                r13.GraphicObjectID = 113;
                r13.ProductYear = uCon.Year;
                r13.RecordID = -1;
                r13.RecordLineage = 0;
                r13.RowDisplayOrder = 1;
                r13.DataSourceUsed = 0;
                r13.DataType = 8;  //money
                LOValue v13 = new LOValue();
                v13.DataSource = 0;
                v13.FractionValue = 35.6M;
                r13.Values = new List<LOValue>();
                r13.Values.Add(v13);
                rs.Add(r13);

                List<LORecord> retV2 = o.SetRecords(rs);
                Assert.AreEqual(4, retV2.Count);
                retV2 = o.SetRecords(rs);



                //there should be one graphic, but the values count should still be 2 as we won't remove values' of different datasources
                List<LORecord> rs2 = o.GetRecords(locID, uCon.Year, 0, 5, 101, 0);
                Assert.AreEqual(1, rs2.Count);
                Assert.AreEqual(1, rs2[0].RowDisplayOrder);
                Assert.AreEqual(101, rs2[0].GraphicObjectID);
                Assert.AreEqual(locID, rs2[0].LocatorID);
                Assert.AreEqual(5, rs2[0].PageID);
                Assert.AreEqual(1, rs2[0].DataSourceUsed);
                Assert.AreEqual(2, rs2[0].Values.Count);

                Assert.AreEqual(4, lorcDele.GetDbCount(filter));

                for (int i = 0; i < 10; i++)
                {
                    LORecord r3 = new LORecord();
                    r3.PageID = 5;
                    r3.LocatorID = locID;
                    r3.GraphicObjectID = 102;  //1 graphic, multiple rows
                    r3.ProductYear = uCon.Year;
                    r3.RecordID = -1;
                    r3.RecordLineage = 0;
                    r3.RowDisplayOrder = Convert.ToInt16(i + 1);
                    r3.DataSourceUsed = 0;
                    r3.DataType = 1;  //int
                    LOValue v4 = new LOValue();
                    v4.DataSource = 0;
                    v4.NumericValue = 100 + i;
                    r3.Values = new List<LOValue>();
                    r3.Values.Add(v4);
                    rs2.Add(r3);
                }
                List<LORecord> ret6 = o.SetRecords(rs2);
                Assert.AreEqual(11, ret6.Count);

                List<LORecord> rs3 = o.GetRecords(locID, uCon.Year, 0, 5, 101, 0);
                List<LORecord> rs4 = o.GetRecords(locID, uCon.Year, 0, 5, 102, 0);
                Assert.AreEqual(1, rs3.Count);
                Assert.AreEqual(1, rs3[0].RowDisplayOrder);
                Assert.AreEqual(101, rs3[0].GraphicObjectID);
                Assert.AreEqual(locID, rs3[0].LocatorID);
                Assert.AreEqual(5, rs3[0].PageID);
                Assert.AreEqual(1, rs3[0].DataSourceUsed);
                Assert.AreEqual(2, rs3[0].Values.Count);

                Assert.AreEqual(10, rs4.Count);
                Assert.AreEqual(1, rs4[0].RowDisplayOrder);
                Assert.AreEqual(2, rs4[1].RowDisplayOrder);
                Assert.AreEqual(102, rs4[0].GraphicObjectID);
                Assert.AreEqual(locID, rs4[0].LocatorID);
                Assert.AreEqual(5, rs4[0].PageID);
                Assert.AreEqual(0, rs4[0].DataSourceUsed);
                Assert.AreEqual(1, rs4[0].Values.Count);
                Assert.AreEqual(109, rs4[9].Values[0].NumericValue);

                Assert.AreEqual(14, lorcDele.GetDbCount(filter));

                Assert.Greater(rs4[0].RecordID, 0);

                //update a single row
                rs4[5].Values[0].NumericValue = 33;
                rs4 = o.SetRecords(rs4);
                List<LORecord> ret10 = o.GetRecords(locID, uCon.Year, 0, 5, 102, 0);
                Assert.AreEqual(33, ret10[5].Values[0].NumericValue);

                rs4[6].RowDisplayOrder = 99;
                rs4 = o.SetRecords(rs4);

                rs4[1].DataType = 9;
                rs4 = o.SetRecords(rs4);
                Assert.AreEqual(-2, rs4[1].RecordID);

                Assert.IsTrue(o.DeleteRecords(ret10));
                //make sure they are gone
                LocatorObjectRecordCollection lorc6 = new LocatorObjectRecordCollection();
                PredicateExpression filter6 = new PredicateExpression();
                List<int> recIDS = new List<int>();
                foreach (LORecord lor in ret10)
                {
                    recIDS.Add(lor.RecordID);
                }
                filter6.Add(PredicateFactory.CompareRange(LocatorObjectRecordFieldIndex.Record_ID, recIDS));
                Assert.AreEqual(0, lorc.GetDbCount(filter6));


            }
            //[Test]
            public void TestLoadUpCalcEngine()
            {
                DatabaseInitializer.ClearDatabaseCompletely();
                int locID = CheckForAndAddLocatorReturnID();

                TaxAppClientService o = new TaxAppClientService();
                string parms = "LocatorID=\"" + locID + "\";Year=\"2007\";UseMockDataSource=\"true\"";
                Assert.AreNotEqual(-10, o.RunMethodByMessageTypeReturnInt("StartCalcEngineLocator", parms));
                string parms2 = "LocatorID=\"" + locID + "\";ApplicationName=\"Sample_Application\"";
                Assert.AreNotEqual(-10, o.RunMethodByMessageTypeReturnInt("StartCalcEngineApplication", parms2));


                //the sample_application 
                List<LORecord> grid1CountryNames = o.GetRecords(locID, 2007, 0, 3, 32, 0);
                Assert.AreEqual(3, grid1CountryNames.Count);

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(grid1CountryNames[i].Values[0].StringValue);
                }
                Assert.IsTrue(grid1CountryNames[0].RecordID > 0);
                Assert.IsTrue(grid1CountryNames[1].RecordID > 0);
                Assert.IsTrue(grid1CountryNames[2].RecordID > 0);

                List<LORecord> grid2USACityNames = o.GetRecords(locID, 2007, grid1CountryNames[0].RecordID, 4, 40, 0);
                Assert.AreEqual(3, grid2USACityNames.Count);
                Assert.AreEqual("Dallas", grid2USACityNames[0].Values[0].StringValue);

                List<LORecord> grid3DallasBuildings = o.GetRecords(locID, 2007, grid2USACityNames[0].RecordID, 5, 44, 0);
                Assert.AreEqual(3, grid3DallasBuildings.Count);
                Assert.AreEqual("DallasLoc1", grid3DallasBuildings[0].Values[0].StringValue);

                int thirdLevelRecID = grid3DallasBuildings[0].RecordID;
                Console.WriteLine("Third Level Rec ID: " + thirdLevelRecID);
                List<LORecord> grid4Floor1 = o.GetRecords(locID, 2007, thirdLevelRecID, 7, 52, 0);
                Assert.AreEqual(2, grid4Floor1.Count);
                Assert.AreEqual(2, grid4Floor1[0].Values[0].NumericValue);
                Assert.IsTrue(grid4Floor1[0].RecordID > 0);

                List<LORecord> recs = new List<LORecord>();
                LORecord rec1 = new LORecord();
                rec1.DataSourceUsed = Convert.ToByte(DataSourceEnum.DataEntry);
                rec1.DataType = 1;
                rec1.GraphicObjectID = 52;
                rec1.IsComputedField = false;
                rec1.LocatorID = locID;
                rec1.PageID = 7;
                rec1.ProductYear = uCon.Year;
                rec1.RecordID = -1;
                rec1.RecordLineage = thirdLevelRecID;
                rec1.RowDisplayOrder = 1;
                rec1.Values = new List<LOValue>();
                LOValue lov1 = new LOValue();
                lov1.DataSource = Convert.ToByte(DataSourceEnum.DataEntry);
                lov1.NumericValue = 15;
                rec1.Values.Add(lov1);

                recs.Add(rec1);

                List<LORecord> grid4Floor1LightBulbs1 = o.SetRecords(recs);
                List<LORecord> grid4Floor1Test = o.GetRecords(locID, 2007, thirdLevelRecID, 7, 52, 0);
                Assert.AreEqual(2, grid4Floor1Test.Count);
                Assert.AreEqual(15, grid4Floor1Test[0].Values[0].NumericValue);

                List<LORecord> grid4Floor1Calced = o.GetRecords(locID, 2007, thirdLevelRecID, 7, 50, 0);
                Assert.AreEqual(18, grid4Floor1Calced[0].Values[0].NumericValue);

                grid4Floor1Test[0].Values[0].NumericValue = 25;
                o.SetRecords(grid4Floor1Test);
                grid4Floor1Calced = o.GetRecords(locID, 2007, thirdLevelRecID, 7, 50, 0);
                Assert.AreEqual(28, grid4Floor1Calced[0].Values[0].NumericValue);

            }
            [Test]
            public void GetRowLineageFromRecordLineageTests()
            { 
                TaxAppClientService o = new TaxAppClientService();
                int locID = CheckForAndAddLocatorReturnID();

                LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
                PredicateExpression filter = new PredicateExpression();
                filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, 6000));
                lorc.DeleteMulti(filter);

                LocatorObjectRecordEntity lore = new LocatorObjectRecordEntity();
                lore.Product_Year = uCon.Year;
                lore.Locator_ID = locID;
                lore.Page_ID = 6000;
                lore.GraphicObject_ID = 6000;
                lore.DataType_EnumValue = (byte)EnumKeyDataType.String;
                lore.Row_DisplayOrder = 1;
                lore.Record_Lineage = 0;
                lore.DatasourceUsed = 0;
                lore.Save();
                
                int recID = lore.Record_ID;

                Assert.IsNotNull(o.GetRowLineageFromRecordLineage(0));
                RowLineageKey key1 = new RowLineageKey(new int[1]{1});
                Assert.AreEqual(key1, o.GetRowLineageFromRecordLineage(recID));

                LocatorObjectRecordEntity lore2 = new LocatorObjectRecordEntity();
                lore2.Product_Year = uCon.Year;
                lore2.Locator_ID = locID;
                lore2.Page_ID = 6000;
                lore2.GraphicObject_ID = 6001;
                lore2.DataType_EnumValue = (byte)EnumKeyDataType.String;
                lore2.Row_DisplayOrder = 2;
                lore2.Record_Lineage = recID;
                lore2.DatasourceUsed = 0;
                lore2.Save();

                int recID2 = lore2.Record_ID;
                RowLineageKey key2 = new RowLineageKey(new int[2]{1, 2});
                Assert.AreEqual(key2, o.GetRowLineageFromRecordLineage(recID2));
                foreach (int i in key2)
                {
                    Console.WriteLine(i);
                }
                Assert.AreEqual(2, key2.Count);

                LocatorObjectRecordEntity lore3 = new LocatorObjectRecordEntity();
                lore3.Product_Year = uCon.Year;
                lore3.Locator_ID = locID;
                lore3.Page_ID = 6000;
                lore3.GraphicObject_ID = 6002;
                lore3.DataType_EnumValue = (byte)EnumKeyDataType.String;
                lore3.Row_DisplayOrder = 3;
                lore3.Record_Lineage = recID2;
                lore3.DatasourceUsed = 0;
                lore3.Save();


                RowLineageKey key3 = new RowLineageKey(new int[3] { 1, 2, 3 });
                Assert.AreEqual(key3, o.GetRowLineageFromRecordLineage(lore3.Record_ID));
                foreach (int i in key3)
                {
                    Console.WriteLine(i);
                }
                Assert.AreEqual(3, key3.Count);

            }
            //[Test]
            public void CalcEngineTest1()
            { 
                DatabaseInitializer.ClearDatabaseCompletely();
                int locID = CheckForAndAddLocatorReturnID();

                //not using the mock data for this
                TaxAppClientService o = new TaxAppClientService();
                o.RunMethodByMessageTypeReturnInt("Initialize", string.Empty);
                string parms = "LocatorID=\"" + locID + "\";Year=\"2007\"";
                Assert.AreEqual(0, o.RunMethodByMessageTypeReturnInt("StartCalcEngineLocator", parms));
                string parms2 = "LocatorID=\"" + locID + "\";ApplicationName=\"Sample_Application\"";
                Assert.AreEqual(0, o.RunMethodByMessageTypeReturnInt("StartCalcEngineApplication", parms2));

                //the sample_application 
                Console.WriteLine("GetRecord Start Blank");
                List<LORecord> grid1CountryNames = o.GetRecords(locID, 2007, 0, 3, 32, 31);
                Assert.AreEqual(0, grid1CountryNames.Count);

                LORecord newLor = new LORecord();
                newLor.RecordID = -1;               //it is a new row
                newLor.ProductYear = uCon.Year;
                newLor.LocatorID = locID;
                newLor.PageID = 3;
                newLor.GraphicObjectID = 32;
                newLor.ParentGraphicID = 31;
                newLor.DataType = (byte)EnumKeyDataType.String;
                newLor.RowDisplayOrder = 1;
                newLor.RecordLineage = 0;
                newLor.DataSourceUsed = 0;
                LOValue newLov = new LOValue();
                newLov.DataSource = 0;
                newLov.StringValue = "Country1";
                newLor.Values.Add(newLov);
                
                grid1CountryNames.Add(newLor);

                Console.WriteLine("SetRecords 1 new record");
                grid1CountryNames = o.SetRecords(grid1CountryNames);
                Assert.AreEqual(1, grid1CountryNames.Count);
                Assert.AreNotEqual(0, grid1CountryNames[0].RecordID);

                //check the LocatorGridRow & LocatorObjectRecord & LocatorObjectValue
                LocatorGridRowCollection lgrc = new LocatorGridRowCollection();
                PredicateExpression filter = new PredicateExpression();
                filter.Add(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Locator_ID, ComparisonOperator.Equal, locID));
                lgrc.GetMulti(filter);
                Assert.AreEqual(1, lgrc.Count);
                Assert.AreEqual(1, lgrc[0].Row_Count);

                LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
                PredicateExpression filter2 = new PredicateExpression();
                filter2.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, locID));
                lorc.GetMulti(filter2);
                Assert.AreEqual(1, lorc.Count);
                int recID = lorc[0].Record_ID;

                LocatorObjectValueCollection lovc = new LocatorObjectValueCollection();
                lovc.GetMulti(null);
                Assert.AreEqual(1, lovc.Count);

                //update the value
                grid1CountryNames[0].Values[0].StringValue = "CountryNameChanged";
                Console.WriteLine("SetRecords 1 changed record");
                grid1CountryNames = o.SetRecords(grid1CountryNames);

                Assert.AreEqual(1, lgrc.GetDbCount(filter));
                Assert.AreEqual(1, lorc.GetDbCount(filter2));
                Assert.AreEqual(1, lovc.GetDbCount());
                Console.WriteLine("GetRecords confirm only 1 still exists");
                List<LORecord> recConfirm1 = o.GetRecords(locID, uCon.Year, 0, 3, 32, 31);
                Assert.AreEqual(1, recConfirm1.Count);

                //assume it is all good - go ahead and add Cities, Buildings, and Bld Detail - check calc'd results all the way back up
                LORecord newLorCity = new LORecord();
                newLorCity.RecordID = -1;               //it is a new row
                newLorCity.ProductYear = uCon.Year;
                newLorCity.LocatorID = locID;
                newLorCity.PageID = 4;
                newLorCity.GraphicObjectID = 40;
                newLorCity.ParentGraphicID = 39;
                newLorCity.DataType = (byte)EnumKeyDataType.String;
                newLorCity.RowDisplayOrder = 1;
                newLorCity.RecordLineage = recID;
                newLorCity.DataSourceUsed = 0;
                LOValue newLovCity = new LOValue();
                newLovCity.DataSource = 0;
                newLovCity.StringValue = "City1";
                newLorCity.Values.Add(newLovCity);

                Console.WriteLine("GetRecords for City Column");
                List<LORecord> cityRecords = o.GetRecords(locID, uCon.Year, recID, 4, 40, 39);
                Assert.AreEqual(0, cityRecords.Count);
                cityRecords.Add(newLorCity);
                Console.WriteLine("SetRecords for new City value");
                cityRecords = o.SetRecords(cityRecords);
                Assert.AreEqual(1, cityRecords.Count);
                int cityRecID = cityRecords[0].RecordID;
                Assert.AreNotEqual(0, cityRecID);

                //each of these should have 2 values now
                Assert.AreEqual(2, lgrc.GetDbCount(filter));
                Assert.AreEqual(2, lorc.GetDbCount(filter2));
                Assert.AreEqual(2, lovc.GetDbCount());

                Console.WriteLine("Getting blank Building Summary records");
                List<LORecord> buildingRecords = o.GetRecords(locID, uCon.Year, cityRecID, 5, 44, 43);
                Assert.AreEqual(0, buildingRecords.Count);

                LORecord newLorBuilding = new LORecord();
                newLorBuilding.RecordID = -1;               //it is a new row
                newLorBuilding.ProductYear = uCon.Year;
                newLorBuilding.LocatorID = locID;
                newLorBuilding.PageID = 5;
                newLorBuilding.GraphicObjectID = 44;
                newLorBuilding.ParentGraphicID = 43;
                newLorBuilding.DataType = (byte)EnumKeyDataType.String;
                newLorBuilding.RowDisplayOrder = 1;
                newLorBuilding.RecordLineage = cityRecID;
                newLorBuilding.DataSourceUsed = 0;
                LOValue newLovBuilding = new LOValue();
                newLovBuilding.DataSource = 0;
                newLovBuilding.StringValue = "Building1";
                newLorBuilding.Values.Add(newLovBuilding);

                buildingRecords.Add(newLorBuilding);
                Console.WriteLine("SetRecords - new building summary record");
                buildingRecords = o.SetRecords(buildingRecords);
                Assert.AreEqual(1, buildingRecords.Count);
                int buildRecID = buildingRecords[0].RecordID;
                Assert.AreNotEqual(0, buildRecID);

                Assert.AreEqual(3, lgrc.GetDbCount(filter));
                Assert.AreEqual(3, lorc.GetDbCount(filter2));
                Assert.AreEqual(3, lovc.GetDbCount());

                List<LORecord> buildingDetailRecords = o.GetRecords(locID, uCon.Year, buildRecID, 7, 49, 48);
                Assert.AreEqual(0, buildingDetailRecords.Count);

                LORecord newLorBuildingDetail = new LORecord();
                newLorBuildingDetail.RecordID = -1;               //it is a new row
                newLorBuildingDetail.ProductYear = uCon.Year;
                newLorBuildingDetail.LocatorID = locID;
                newLorBuildingDetail.PageID = 7;
                newLorBuildingDetail.GraphicObjectID = 49;
                newLorBuildingDetail.ParentGraphicID = 48;
                newLorBuildingDetail.DataType = (byte)EnumKeyDataType.String;
                newLorBuildingDetail.RowDisplayOrder = 1;
                newLorBuildingDetail.RecordLineage = buildRecID;
                newLorBuildingDetail.DataSourceUsed = 0;
                LOValue newLovBuildingDetail = new LOValue();
                newLovBuildingDetail.DataSource = 0;
                newLovBuildingDetail.StringValue = "Floor1";
                newLorBuildingDetail.Values.Add(newLovBuildingDetail);

                buildingDetailRecords.Add(newLorBuildingDetail);
                buildingDetailRecords = o.SetRecords(buildingDetailRecords);
                Assert.AreEqual(1, buildingDetailRecords.Count);

                Assert.AreEqual(4, lgrc.GetDbCount(filter));
                Assert.AreEqual(4, lorc.GetDbCount(filter2));
                Assert.AreEqual(4, lovc.GetDbCount());

                Console.WriteLine("GetRecords to other detail columns");  //this should get back a row in each column and should up the db to 7 recs
                List<LORecord> buildingDetailRecordsColumn1 = o.GetRecords(locID, uCon.Year, buildRecID, 7, 52, 48);  //incandescent
                List<LORecord> buildingDetailRecordsColumn2 = o.GetRecords(locID, uCon.Year, buildRecID, 7, 53, 48);  //flourescent
                List<LORecord> buildingDetailRecordsColumn3 = o.GetRecords(locID, uCon.Year, buildRecID, 7, 50, 48);  //total

                Assert.AreEqual(4, lgrc.GetDbCount(filter));  //grid rows shouldn't change
                Assert.AreEqual(7, lorc.GetDbCount(filter2));
                Assert.AreEqual(7, lovc.GetDbCount());

                Assert.AreEqual(1, buildingDetailRecordsColumn1.Count);
                Assert.AreEqual(1, buildingDetailRecordsColumn2.Count);
                Assert.AreEqual(1, buildingDetailRecordsColumn3.Count);

                Assert.AreNotEqual(0, buildingDetailRecordsColumn1[0].RecordLineage);

                Assert.AreEqual(0, buildingDetailRecordsColumn1[0].Values[0].NumericValue);
                Assert.AreEqual(0, buildingDetailRecordsColumn2[0].Values[0].NumericValue);
                Assert.AreEqual(0, buildingDetailRecordsColumn3[0].Values[0].NumericValue);

                buildingDetailRecordsColumn1[0].Values[0].NumericValue = 1;

                Console.WriteLine("Saving updated column1 value");
                buildingDetailRecordsColumn1 = o.SetRecords(buildingDetailRecordsColumn1);
                Assert.AreEqual(1, buildingDetailRecordsColumn1.Count);
                Assert.AreEqual(1, buildingDetailRecordsColumn1[0].Values[0].NumericValue);

                buildingDetailRecordsColumn3 = o.GetRecords(locID, uCon.Year, buildRecID, 7, 50, 48);  //total

                //it is possible at this point to have 2 values for the computed column.
                Assert.AreEqual((byte)DataSourceEnum.Compute, buildingDetailRecordsColumn3[0].DataSourceUsed);
                bool found = false;
                foreach (LOValue lov in buildingDetailRecordsColumn3[0].Values)
                {
                    if (lov.DataSource == (byte)DataSourceEnum.Compute)
                    {
                        found = true;
                        Assert.AreEqual(1,lov.NumericValue);
                    }
                }
                Assert.IsTrue(found);
                

                buildingDetailRecordsColumn2[0].Values[0].NumericValue = 2;
                buildingDetailRecordsColumn2 = o.SetRecords(buildingDetailRecordsColumn2);
                Assert.AreEqual(1, buildingDetailRecordsColumn2.Count);

                Thread.Sleep(1500);

                buildingDetailRecordsColumn3 = o.GetRecords(locID, uCon.Year, buildRecID, 7, 50, 48);  //total
                Assert.AreEqual((byte)DataSourceEnum.Compute, buildingDetailRecordsColumn3[0].DataSourceUsed);
                found = false;
                foreach (LOValue lov in buildingDetailRecordsColumn3[0].Values)
                {
                    if (lov.DataSource == (byte)DataSourceEnum.Compute)
                    {
                        found = true;
                        Assert.AreEqual(3, lov.NumericValue);
                    }
                }
                Assert.IsTrue(found);

                

            }

        }
    }
}
