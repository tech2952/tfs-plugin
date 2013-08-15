using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using NUnit.Framework;
using TestHarness.DataObjects;
using TestHarness.DataObjects.CollectionClasses;
using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.FactoryClasses;
using TaxBuilder.GraphicObjects;
using TaxApp.IntrinsicFunctions;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Security.Principal;
using System.Configuration;
using TaxApp.InterfacesAndConstants;
using log4net;
using TaxApp.WinformRuntimeGraphics;
using TaxApp.CalcEngine;
using TaxBuilder.BusinessObjects;
using TaxBuilder.DataObjects.EntityClasses;
using TaxBuilder.GraphicObjects.TaxAppRuntime;

namespace TestHarness.BusinessObjects
{
	/// <summary>
	/// LocatorImpl should provide functionality to get & put information into a particular locator
	/// </summary>
	public class LocatorImpl : ITaxAppData
	{
		private static readonly ILog theLogger = LogManager.GetLogger("LocatorImpl");
		private short myYear;
		private int myLocatorID;
        private string myLocatorName;
        private UserConfigurationItems myUserconfig;
        private ScriptLibrary myScriptLibrary;
        private DatabaseAndBinaryPathSettings myDatabaseAndBinaryPathSettings;
        private Dictionary<KeyValuePair<int, int>, GraphicInfoItem> myGraphicMatrix;
        public event PageUpdatedEventHandler PageUpdatedEvent;

		public LocatorImpl(){}
        public void Initialize(string LocatorName, int LocatorID, short Year, UserConfigurationItems configItems)
		{
            myYear = Year;
            myLocatorName = LocatorName;
            myLocatorID = LocatorID;
            myUserconfig = configItems;
            myDatabaseAndBinaryPathSettings = configItems.DatabaseAndBinaryPathSettings;

            //this might be the first time this database is used.
            if (!DatabaseInitializer.CheckEnterpriseTableAndEnums())
            {
                theLogger.Error("Error checking PatrickHenry Database.");
                theLogger.Error("Server Name: " + myDatabaseAndBinaryPathSettings.LocatorDatabaseServerName);
                theLogger.Error("   Database: " + myDatabaseAndBinaryPathSettings.LocatorDatabaseName);
            }

            LocatorEntity myLocatorEntity = new LocatorEntity(myYear, myLocatorID);
			if (myLocatorEntity.IsNew)
			{
                theLogger.Error("Unable to find LocatorID / Year: " + LocatorID + "/" + Year);
				//throw new NullReferenceException("Unable to Find locator");
			}

            SetScriptLibraryAndMappingInfo();

            LoadGraphicMatrix();

		}

        public short Year { get { return myYear; } }
		public int LocatorID { get { return myLocatorID; } }
        public string LocatorName { get { return myLocatorName; } }

        #region GraphicMatrix
        /// <summary>
        /// This is purely a unit test function.  It loads in a graphic matrix that the nunit tests use to perform their work against this ITaxAppData implementation
        /// It uses the graphic matrix that is used in the test ITaxAppData implementation.
        /// </summary>
        public void LoadGraphicMatrix()
        {
            //used by the nunit tests
            TILocatorDatabase t = new TILocatorDatabase();
            t.Initialize(LocatorName, LocatorID, Year, myUserconfig);
            myGraphicMatrix = t.GraphicMatrix;
        }
        private void LoadGraphicsForPage(int PageID, bool refresh)
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();

            PageEntity pe = new PageEntity(PageID);
            NavigationNodeTypeEnum nodeType = NavigationNodeTypeEnum.PRTPageNode; //default?
            PageTypeEnum pte = (PageTypeEnum)Enum.Parse(typeof(PageTypeEnum), pe.PageType_EnumValue.ToString());
            switch (pte)
            {
                case PageTypeEnum.Attachment:
                    nodeType = NavigationNodeTypeEnum.PRTAttachmentNode;
                    break;
                case PageTypeEnum.Form:
                    nodeType = NavigationNodeTypeEnum.PRTPageNode;
                    break;
                case PageTypeEnum.Organizer:
                    nodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                    break;
                case PageTypeEnum.Workpaper:
                    nodeType = NavigationNodeTypeEnum.TAWorkpaperNode;
                    break;
                case PageTypeEnum.TaxAppLivingTemplate:
                case PageTypeEnum.TaxFormLivingTemplate:
                case PageTypeEnum.TaxFormTemplate:
                case PageTypeEnum.TaxAppTemplate:
                    throw new ArgumentException("Invalid PageID - Template pages cannot be used in tax applications");

                default:
                    throw new ArgumentException("unknown page type");
            }
            PageImpl pi = new PageImpl(PageID, nodeType);
            pi.GetPageGraphics();
            foreach (DataObjectGraphicObjectImpl dogoi in pi.DataObjectGraphicImplColl)
            {
                AddDogoiToGraphicMatrix(PageID, dogoi, refresh);
            }
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
        }
        public GraphicInfoItem GetGraphicInfoItem(int PageID, int RunTimeGraphicID)
        {
            if (myGraphicMatrix == null)
            {
                myGraphicMatrix = new Dictionary<KeyValuePair<int, int>, GraphicInfoItem>();
            }
            KeyValuePair<int, int> key = new KeyValuePair<int, int>(PageID, RunTimeGraphicID);
            if (myGraphicMatrix.ContainsKey(key))
            {
                if (myGraphicMatrix[key].IsShortcut)
                    return GetGraphicInfoItem(myGraphicMatrix[key].LinkedPageID, myGraphicMatrix[key].LinkedGraphicID);
                else
                    return myGraphicMatrix[key];
            }
            else
            {
                LoadGraphicsForPage(PageID, true);
                if (myGraphicMatrix.ContainsKey(key))
                {
                    if (myGraphicMatrix[key].IsShortcut)
                        return GetGraphicInfoItem(myGraphicMatrix[key].LinkedPageID, myGraphicMatrix[key].LinkedGraphicID);
                    else
                        return myGraphicMatrix[key];
                }
                else
                {
                    theLogger.Error("Runtime Graphic ID not found: PageID / RuntimeGraphicID: " + PageID.ToString() + " / " + RunTimeGraphicID.ToString());
                    return null;
                }
            }
        }
        private GraphicInfoItem GetGIIFromDOGOI(int PageID, DataObjectGraphicObjectImpl dogoi)
        {
            int runtimeID = dogoi.GraphicOid;
            string name = dogoi.GetGraphicObject().Name;
            EnumKeyDataType datatype = (EnumKeyDataType)dogoi.GetGraphicObject().GetRunTimeDataType((GraphicObjectTypeEnum)dogoi.graphicObjectType);
            object defaultvalue = string.Empty;
            switch (datatype)
            {
                case EnumKeyDataType.Boolean:
                    defaultvalue = false;
                    break;
                case EnumKeyDataType.DateTime:
                    defaultvalue = Constants.MinimumDateValue;
                    break;
                case EnumKeyDataType.Ratio:
                case EnumKeyDataType.Integer:
                case EnumKeyDataType.Money:
                    defaultvalue = 0;
                    break;
                case EnumKeyDataType.String:
                    defaultvalue = string.Empty;
                    break;
                case EnumKeyDataType.Image:
                    break;
                default:
                    break;
            }
            int valuelistID = 0;
            switch (dogoi.graphicObjectType)
            {
                case GraphicObjectTypeEnum.Textbox:
                    if (((TextBoxGraphic)dogoi.GetGraphicObject()).NeedMaskControl())
                    {
                        string saveText = ((TextBoxGraphic)dogoi.GetGraphicObject()).Text;
                        ((TextBoxGraphic)dogoi.GetGraphicObject()).Text = ((TextBoxGraphic)dogoi.GetGraphicObject()).DefaultValue;
                        defaultvalue = ((TextBoxGraphic)dogoi.GetGraphicObject()).FormattedText;
                        ((TextBoxGraphic)dogoi.GetGraphicObject()).Text = saveText;
                    }
                    else
                        defaultvalue = ((TextBoxGraphic)dogoi.GetGraphicObject()).DefaultValue;
                    break;
                case GraphicObjectTypeEnum.CheckBox:
                    defaultvalue = ((CheckBoxGraphic)dogoi.GetGraphicObject()).Checked;
                    break;
                case GraphicObjectTypeEnum.DropDownList:
                    valuelistID = ((DropDownListGraphic)dogoi.GetGraphicObject()).BoundToValueListID;
                    if (valuelistID != 0)
                        defaultvalue = ((DropDownListGraphic)dogoi.GetGraphicObject()).DefaultValue;
                    else
                        defaultvalue = string.Empty;
                    break;
                case GraphicObjectTypeEnum.OptionGroup:
                    {
                        foreach (DataObjectGraphicObjectImpl button in dogoi.GraphicCollection)
                        {
                            if (((OptionButtonGraphic)button.GetGraphicObject()).Checked)
                            {
                                defaultvalue = ((OptionButtonGraphic)button.GetGraphicObject()).Text;
                                break;
                            }
                        }
                    }
                    break;
                case GraphicObjectTypeEnum.OptionButton:
                    defaultvalue = ((OptionButtonGraphic)dogoi.GetGraphicObject()).Checked;
                    break;
                default:
                    break;
            }
            bool isComputed = false;
            if (null != dogoi.GetGraphicObject().GetType().GetInterface("ICanHaveAComputeScriptAssignment"))
            {
                if (((ICanHaveAComputeScriptAssignment)dogoi.GetGraphicObject()).ComputeAssignmentID > 0)
                    isComputed = true;
            }
            GraphicInfoItem gii = new GraphicInfoItem(PageID, runtimeID, name, Convert.ToByte(datatype), isComputed, defaultvalue.ToString(), dogoi.GetGraphicObject().IsShortCut, dogoi.LinkedGraphicID, dogoi.LinkedPageID, Convert.ToByte(dogoi.GetGraphicObject().DisplayOrder));
            return gii;
        }

        private void AddDogoiToGraphicMatrix(int PageID, DataObjectGraphicObjectImpl dogoi, bool refresh)
        {
            KeyValuePair<int, int> key = new KeyValuePair<int, int>(PageID, dogoi.GraphicOid);
            if (myGraphicMatrix.ContainsKey(key))
            {
                if (!refresh)
                {
                    return;
                }
                else
                {
                    myGraphicMatrix.Remove(key);
                }

            }
            GraphicInfoItem gii = GetGIIFromDOGOI(PageID, dogoi);
            if (gii.DataType == 9)
            {
                foreach (DataObjectGraphicObjectImpl dogoiColumn in dogoi.GraphicCollection)
                {
                    GraphicInfoItem giiCol = GetGIIFromDOGOI(PageID, dogoiColumn);
                    giiCol.ColumnDisplayOrder = Convert.ToByte(dogoiColumn.GetGraphicObject().DisplayOrder);
                    gii.Columns.Add(giiCol);
                    //also add them to the overall collection - for easy retrieval of types there
                    KeyValuePair<int, int> gridKey = new KeyValuePair<int, int>(PageID, giiCol.GraphicID);
                    if (!myGraphicMatrix.ContainsKey(gridKey))
                    {
                        this.myGraphicMatrix.Add(gridKey, giiCol);
                        if (theLogger.IsDebugEnabled)
                            theLogger.Debug(string.Format("GIIColumn added : PageID/GID/Name/DataType/DF : {0}/{1}/{2}/{3}/{4}", PageID, giiCol.GraphicID, giiCol.GraphicName, giiCol.DataType.ToString(), giiCol.DefaultValue.ToString()));
                    }
                }
            }
            this.myGraphicMatrix.Add(key, gii);
            foreach (DataObjectGraphicObjectImpl dogoiChild in dogoi.GraphicCollection)
            {
                AddDogoiToGraphicMatrix(PageID, dogoiChild, true);
            }
            if (theLogger.IsDebugEnabled)
                theLogger.Debug(string.Format("GII added : PageID/GID/Name/DataType/DF : {0}/{1}/{2}/{3}/{4}", PageID, gii.GraphicID, gii.GraphicName, gii.DataType.ToString(), gii.DefaultValue.ToString()));
        }

        public IDictionary<KeyValuePair<int, int>, GraphicInfoItem> GetGraphicInfoItems(ICollection<KeyValuePair<int, int>> pageIDGraphicIDs)
        {
            Dictionary<KeyValuePair<int, int>, GraphicInfoItem> list = new Dictionary<KeyValuePair<int, int>, GraphicInfoItem>();
            foreach (KeyValuePair<int, int> i in pageIDGraphicIDs)
            {
                list.Add(i, GetGraphicInfoItem(i.Key, i.Value));
            }
            return list;
        }
        #endregion GraphicMatrix

        public SortedList<int, RunTimeNode> ProcessRunTimeNodeCollection(RunTimeNode parentNode, SortedList<int, RunTimeNode> rtnsCollectionFromApplicationInfoProvider)
        { 
            int overallCount = 0;
            SortedList<int, RunTimeNode> rtnsProcessed = new SortedList<int, RunTimeNode>();
            foreach (RunTimeNode rtn in rtnsCollectionFromApplicationInfoProvider.Values)
            {
                if (rtn.LoopRuntimeGraphicID > 0)
                {
                    if (theLogger.IsDebugEnabled)
                        theLogger.Info(string.Format("Processing Group Loop.  NodeID.NodeRecordLineage: [{0} - {1}]     LoopingPage/Graphic: [{2} - {3}]",
                            rtn.NodeID, rtn.RecordLineage, rtn.LoopRuntimePageID, rtn.LoopRuntimeGraphicID));
                    if (theLogger.IsDebugEnabled)
                        theLogger.Info(string.Format("Parent NodeID.RecordLineage: {0}.{1} - Loop Record ID: {2} ", parentNode.NodeID, parentNode.RecordLineage, parentNode.LoopRecordID));
                    GraphicInfoItem thisGraphicItem = GetGraphicInfoItem(rtn.LoopRuntimePageID, rtn.LoopRuntimeGraphicID);
                    PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
                    prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);

                    LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
                    PredicateExpression filter = new PredicateExpression();
                    filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
                    filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
                    filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, rtn.LoopRuntimeGraphicID));
                    filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, rtn.LoopRuntimePageID));
                    filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, parentNode.LoopRecordID.ToString()));

                    ISortExpression sortClause = new SortExpression(SortClauseFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder, SortOperator.Ascending));
                    lorc.GetMulti(filter, 0, sortClause, null, prefetch);
                    theLogger.Debug("Processing " + lorc.Count.ToString() + " LORs.");
                    //at this point we have a collection of LORs - extract out TheValues from each one and create a RunTimeNode foreach one
                    string Value = string.Empty;
                    if (lorc.Count > 0)
                    {
                        foreach(LocatorObjectRecordEntity lor in lorc)
                        {
                            RunTimeNode rtnNew = rtn.Copy();
                            rtnNew.LoopRecordID = lor.Record_ID;
                            if (parentNode.LoopRecordID > 0)
                            {
                                rtnNew.RecordLineage = parentNode.LoopRecordID;
                            }
                            else if (parentNode.RecordLineage > 0)
                            {
                                rtnNew.RecordLineage = parentNode.RecordLineage;
                            }
                            DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.DefaultValue;
                            rtnNew.Name = rtn.Name + " " + dataSourceVal.ToString();
                            rtnsProcessed.Add(overallCount, rtnNew);
                            overallCount++;
                        }
                    }
                    else
                    { 
                        //there is no value for this looping graphic
                        rtn.Name = rtn.Name + " *No Value on looping graphic* LoopRecordID: " + rtn.LoopRecordID.ToString();
                        rtn.Enabled = false;
                        rtnsProcessed.Add(overallCount, rtn);
                        overallCount++;
                    }
                }
                else
                {
                    //just add the incoming one to the other return collection
                    if (parentNode.LoopRecordID > 0)
                    {
                        rtn.RecordLineage = parentNode.LoopRecordID;
                    }
                    else if (parentNode.RecordLineage > 0)
                    {
                        rtn.RecordLineage = parentNode.RecordLineage;
                    }
                    rtnsProcessed.Add(overallCount, rtn);
                    overallCount ++;
                }
               
            }
            
            return rtnsProcessed;
        }
        public bool SaveGraphicObjectData(int PageID, int RuntimeGraphicID, ref int RecordID, int RecordLineage,  object value, DataSourceEnum dataSource, bool newValue, int RowDisplayOrder, bool bKeepDataSourceUsed)
		{
            if (theLogger.IsDebugEnabled)
                theLogger.Debug(string.Format("SaveGraphicobjectData called: PageID/GraphicID/RecordID/RL/value/datasource/IsNew/displayOrder:: " +
                    " {0}/{1}/{2}/{3}/{4}/{5}/{6}/{7} ", PageID.ToString(), RuntimeGraphicID.ToString(), RecordID.ToString(), RecordLineage.ToString(), value.ToString(), dataSource.ToString(), newValue.ToString(), RowDisplayOrder.ToString()));
            //get the graphic first - if it is a textbox of numeric value and is saving a string.empty - bail
            GraphicInfoItem gii = GetGraphicInfoItem(PageID, RuntimeGraphicID);
            if (gii.DataType != 2 && value.ToString() == string.Empty)
                return false;

			//return true if the specified datasource value changes
			bool TheValueChanged = true;  //this means that the record's datasource is updated
			PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
			prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
            LocatorObjectRecordEntity lor = null;
            if (RecordID != 0)
            {
                lor = new LocatorObjectRecordEntity(RecordID, prefetch);
            }
            else 
            {
                int recID = GetRecordIDForSingleValue(PageID, RuntimeGraphicID, RowDisplayOrder, RecordLineage);
                if (recID != 0)
                {
                    lor = new LocatorObjectRecordEntity(recID, prefetch);
                }
                else
                {
                    lor = new LocatorObjectRecordEntity();
                }
            }

            EnumKeyDataType dataType = (EnumKeyDataType)gii.DataType;

			if (!lor.IsNew)
			{
                if (lor.Row_DisplayOrder != RowDisplayOrder)
                {
                    lor.Row_DisplayOrder = RowDisplayOrder;
                    theLogger.Warn("DisplayOrder reset on Record: " + lor.Record_ID);
                }
                if (!bKeepDataSourceUsed)
                    lor.DatasourceUsed = Convert.ToByte(dataSource);
				bool foundOneOfDataSourceSent = false;
				//sure if there is one for the datasource passed.
				foreach (LocatorObjectValueEntity lov in lor.LocatorObjectValue )
				{
					if (lov.DataSource_EnumValue == Convert.ToByte(dataSource))
					{
                        TheValueChanged = SetValueInLocatorObjectValue(lov, value, dataType);
						lov.Save();
                        if (lor.IsDirty)
                        {
                            lor.Save();
                            //ALso need to run the proc that will update the row record lineage - is this correct here?  doesn't seem to have to be done.
                            //int outputError = 0;
                            //TestHarness.DataObjects.StoredProcedureCallerClasses.ActionProcedures.SpManageRowLineage(myLocatorID, myYear, lor.Record_ID, ref outputError);
                        }
						foundOneOfDataSourceSent = true;
					}
				}
				if (!foundOneOfDataSourceSent)
				{
					//if it got here then there is a record, but not of the datasource type being set.
					LocatorObjectValueEntity newlov = new LocatorObjectValueEntity();
					newlov.DataSource_EnumValue = Convert.ToByte(dataSource);
					newlov.Record_ID = lor.Record_ID;

					lor.LocatorObjectValue.Add(newlov);
                    SetValueInLocatorObjectValue(newlov, value, dataType);  //ignore return value - it changed...
					lor.Save(true);
                    //ALso need to run the proc that will update the row record lineage
                    //int outputError = 0;
                    //TestHarness.DataObjects.StoredProcedureCallerClasses.ActionProcedures.SpManageRowLineage(myLocatorID, myYear, lor.Record_ID, ref outputError);

				}
			}
			else
			{
				lor.GraphicObject_ID = RuntimeGraphicID;
                lor.Page_ID = PageID;
				lor.Product_Year = myYear;
				lor.Locator_ID = myLocatorID;
				lor.DataType_EnumValue = Convert.ToByte(dataType);
                lor.Record_Lineage = RecordLineage;
                lor.Row_DisplayOrder = RowDisplayOrder;
                lor.DatasourceUsed = Convert.ToByte(dataSource);

				LocatorObjectValueEntity lov = new LocatorObjectValueEntity();
                lov.DataSource_EnumValue = Convert.ToByte(dataSource);

				lor.LocatorObjectValue.Add(lov);
                SetValueInLocatorObjectValue(lov, value, dataType); //ignore return value - it changed...
				lor.Save(true);
                RecordID = lor.Record_ID;
                //ALso need to run the proc that will update the row record lineage
                //int outputError = 0;
                //TestHarness.DataObjects.StoredProcedureCallerClasses.ActionProcedures.SpManageRowLineage(myLocatorID, myYear, lor.Record_ID, ref outputError);

			}
			return TheValueChanged;
		}
        public IDictionary<int, string> GetSetofRecordIDandValueForSameGraphicAndLineage(int RecordID)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            LocatorObjectRecordEntity lor = new LocatorObjectRecordEntity(RecordID);
            GraphicInfoItem thisgraphic = GetGraphicInfoItem(lor.Page_ID, lor.GraphicObject_ID);

            PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);

            LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, lor.GraphicObject_ID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, lor.Page_ID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, lor.Record_Lineage));

            ISortExpression sortClause = new SortExpression(SortClauseFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder, SortOperator.Ascending));
            lorc.GetMulti(filter, 0, sortClause, null, prefetch);
            foreach (LocatorObjectRecordEntity lori in lorc)
            {
                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lori, thisgraphic, (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lori.DatasourceUsed.ToString()));
                if (dataSourceVal == null)
                    dataSourceVal = thisgraphic.DefaultValue;
                list.Add(lori.Record_ID, dataSourceVal.ToString());
            }
            
            return list;
        }
        public ValueWithDataSources GetSingleValue(int PageID, int RuntimeGraphicID, int RecordLineage)
		{
            GraphicInfoItem gii = GetGraphicInfoItem(PageID, RuntimeGraphicID);
            if (gii.DataType == Convert.ToByte(EnumKeyDataType.DataTable))
            {
                //this shouldn't happen - as the called should be able to differentiate between a datagrid and all other Runtimegraphics
                return null;
            }
            else
            {
                int RecordID = GetRecordIDForSingleValue(gii.PageID, gii.GraphicID, 1, RecordLineage);


                if (RecordID != 0)
                {
                    PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
                    prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
                    LocatorObjectRecordEntity lor = new LocatorObjectRecordEntity(RecordID, prefetch);
                    DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                    object value = GetValueFromThisLocatorObjectRecordByDataSource(lor, gii, datasource);
                    List<ValueWithDataSources> otherdatasources = GetOtherDataSources(lor, datasource);
                    ValueWithDataSources valueDataSource = null;
                    if (value != null)
                        valueDataSource = new ValueWithDataSources(value, datasource, otherdatasources);
                    else
                        valueDataSource = new ValueWithDataSources(value, DataSourceEnum.SystemDefault, otherdatasources);
                    return valueDataSource;
                }
                else
                {
                    //TODO: this is where I need to get any UserDefaults 
                    //TODO: add attribute to GII to indicate if that GII has UserDefaults or not? (Definitely whether it can be updated...)
                    ValueWithDataSources vds = new ValueWithDataSources(gii.DefaultValue, DataSourceEnum.SystemDefault, null);
                    return vds;
                }
            }
		}
        public DataTable GetGridDataTable(int PageID, int RuntimeGraphicID, int RecordLineage)
        {
            GraphicInfoItem gii = GetGraphicInfoItem(PageID, RuntimeGraphicID);
            if (gii.DataType == Convert.ToByte(EnumKeyDataType.DataTable))
            {
                return ProcessDataTable(gii, RecordLineage);
            }
            else
                return null;
        }

   		public IBaseType GetValueAsBaseType(int PageID, int RuntimeGraphicID, int RecordLineage)
		{
            GraphicInfoItem thisGraphicItem = GetGraphicInfoItem(PageID, RuntimeGraphicID);
            PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);

            LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, RuntimeGraphicID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, PageID));
            if (RecordLineage != 0)
            {
                filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, RecordLineage));
            }

            ISortExpression sortClause = new SortExpression(SortClauseFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder, SortOperator.Ascending));
            lorc.GetMulti(filter, 0, sortClause, null, prefetch);

            //at this point we have a collection of LORs - extract out TheValues from each one and create an array of objects to pass into the ctor of the BaseType
            //this should return an INTEGER / DOUBLE / STRING / (one of the codescriptdata types)
            //if we have no LORs then we need to create a default value
            if (lorc.Count > 0)
            {
                int i = 0;
                //this really could become problematic - once a string, always a string kind of thing
                //if they want to change datatypes after an application has shipped - it'll need to be in a codescript - setting one field to another
                EnumKeyDataType dataTypeK = (EnumKeyDataType)thisGraphicItem.DataType;
                switch (dataTypeK)
                {
                    case EnumKeyDataType.Integer:
                        int[] o = new int[lorc.Count];
                        i = 0;
                        foreach (LocatorObjectRecordEntity lor in lorc)
                        {
                            DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.DefaultValue;
                            o[i] = Convert.ToInt32(dataSourceVal);
                            i++;
                        }
                        INTEGER I = o;
                        return I;

                    case EnumKeyDataType.Money:
                        double[] d = new double[lorc.Count];
                        i = 0;
                        foreach (LocatorObjectRecordEntity lor in lorc)
                        {
                            DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.DefaultValue;
                            d[i] = Convert.ToDouble(dataSourceVal);
                            i++;
                        }
                        MONEY M = d;
                        return M;

                    case EnumKeyDataType.Boolean:
                        bool[] b = new bool[lorc.Count];
                        i = 0;
                        foreach (LocatorObjectRecordEntity lor in lorc)
                        {
                            DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.DefaultValue;
                            b[i] = Convert.ToBoolean(dataSourceVal);
                            i++;
                        }
                        BOOL B = b;
                        return B;

                    case EnumKeyDataType.DateTime:
                        DateTime[] dt = new DateTime[lorc.Count];
                        i = 0;
                        foreach (LocatorObjectRecordEntity lor in lorc)
                        {
                            DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.DefaultValue;
                            dt[i] = DateTime.Parse(dataSourceVal.ToString());
                            i++;
                        }
                        DATE D = dt;
                        return D;

                    case EnumKeyDataType.Ratio:
                        Double[] dd = new Double[lorc.Count];
                        i = 0;
                        foreach (LocatorObjectRecordEntity lor in lorc)
                        {
                            DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.DefaultValue;

                            dd[i] = Convert.ToDouble(dataSourceVal);
                            i++;
                        }
                        RATIO R = dd;
                        return R;

                    default:
                        string[] s = new string[lorc.Count];
                        i = 0;
                        foreach (LocatorObjectRecordEntity lor in lorc)
                        {
                            DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                            object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, thisGraphicItem, datasource);
                            if (dataSourceVal == null)
                                dataSourceVal = thisGraphicItem.DefaultValue;
                            s[i] = dataSourceVal.ToString();
                            i++;
                        }
                        STRING S = s;
                        return S;
                }
            }
            else
            {
                //there is no value for this GraphicInfoItem in the database - return the defaultvalue properly casted
                EnumKeyDataType dataType = (EnumKeyDataType)thisGraphicItem.DataType;
                switch (dataType)
                {
                    case EnumKeyDataType.DataTable:
                        return null;
                    case EnumKeyDataType.Boolean:
                        BOOL bdefault = Convert.ToBoolean(thisGraphicItem.DefaultValue);
                        return bdefault;
                    case EnumKeyDataType.DateTime:
                        //TODO: fix the default date
                        //DATE ddefault = DateTime.Parse(thisGraphicItem.DefaultValue.ToString());
                        DATE ddefault = Convert.ToDateTime(Constants.MinimumDateValue);
                        return ddefault;
                    case EnumKeyDataType.Ratio:
                        RATIO rdefault = Convert.ToDouble(thisGraphicItem.DefaultValue);
                        return rdefault;
                    case EnumKeyDataType.Image:
                        theLogger.Info("Image type cannot be a basetype - yet");
                        return null;
                    case EnumKeyDataType.Integer:
                        INTEGER idefault = Convert.ToInt32(thisGraphicItem.DefaultValue);
                        return idefault;
                    case EnumKeyDataType.Money:
                        MONEY mdefault = Convert.ToDouble(thisGraphicItem.DefaultValue);
                        return mdefault;
                    case EnumKeyDataType.String:
                        STRING sdefault = thisGraphicItem.DefaultValue.ToString();
                        return sdefault;
                    default:
                        return null;
                }
            }
		}
        public bool GetNodeConstraintIsThisNodeIDEnabled(int NavigationNodeID)
        {
            LocatorNodeComputedValueEntity lncve = new LocatorNodeComputedValueEntity(this.Year, this.LocatorID, NavigationNodeID);
            if (lncve.IsNew)
                return true;
            else
            {
                return lncve.Constraint_Result;
            }
        }
        public void SetValueFromConstraint(int NavigationNodeID, bool value)
        {
            LocatorNodeComputedValueEntity lncve = new LocatorNodeComputedValueEntity(this.Year, this.LocatorID, NavigationNodeID);
            if (lncve.IsNew)
            {
                lncve.Product_Year = this.Year;
                lncve.Locator_ID = this.LocatorID;
                lncve.Navigation_Node_ID = NavigationNodeID;
            }
            lncve.Constraint_Result = value;
            lncve.Save();
        }
        public void SetBasetypeValue(int PageID, int RuntimeGraphicID, IBaseType value, DataSourceEnum dataSource, int RecordLineage)
        {
            //this will save a BaseTypeValue
            GraphicInfoItem associatedGraphic = GetGraphicInfoItem(PageID, RuntimeGraphicID);
            if (associatedGraphic == null)
                return;

            bool TheValueWasUpdated = false;
            if (value.Rows == 1)
            {
                object typevalue = null;
                int RecordID = GetRecordIDForSingleValue(PageID, RuntimeGraphicID, 1, RecordLineage);
                // need to find the type value here
                EnumKeyDataType dataType = (EnumKeyDataType)associatedGraphic.DataType;
                switch (dataType)
                {
                    case EnumKeyDataType.Boolean:
                        bool b = (BOOL)value;
                        typevalue = b;
                        break;
                    case EnumKeyDataType.Integer:
                        int i = (INTEGER)value;
                        typevalue = i;
                        break;
                    case EnumKeyDataType.Money:
                        double d = (MONEY)value;
                        typevalue = d;
                        break;
                    case EnumKeyDataType.Ratio:
                        double de = (RATIO)value;
                        typevalue = de;
                        break;
                    case EnumKeyDataType.DateTime:
                        DateTime dt = (DateTime)((DATE)value);
                        typevalue = dt;
                        break;
                    case EnumKeyDataType.String:
                        typevalue = value.ToString();
                        break;

                }
                if (RecordID == 0)
                    TheValueWasUpdated = SaveGraphicObjectData(associatedGraphic.PageID, RuntimeGraphicID, ref RecordID, RecordLineage, typevalue, dataSource, true, 1, false);
                else
                    TheValueWasUpdated = SaveGraphicObjectData(associatedGraphic.PageID, RuntimeGraphicID, ref RecordID, RecordLineage, typevalue, dataSource, false, 1, false);
            }
            else
            {
                Dictionary<int, int> recordIDsbyDisplayRow = this.GetRecordIDsByDisplayRowForBaseTypeSave(PageID, RuntimeGraphicID, RecordLineage);
                //loop thru the values setting them all - update one for one on any rows that are already there
                for (int i = 1; i <= value.Rows; i++)
                {
                    value.ActiveRow = i;
                    //object typevalue = value.Value;
                    object typevalue = null;
                    EnumKeyDataType dataType = (EnumKeyDataType)associatedGraphic.DataType;
                    switch (dataType)
                    {
                        case EnumKeyDataType.Boolean:
                            bool b = (BOOL)value;
                            typevalue = b;
                            break;
                        case EnumKeyDataType.Integer:
                            int ii = (INTEGER)value;
                            typevalue = ii;
                            break;
                        case EnumKeyDataType.Money:
                            double d = (MONEY)value;
                            typevalue = d;
                            break;
                        case EnumKeyDataType.Ratio:
                            double de = (RATIO)value;
                            typevalue = de;
                            break;
                        case EnumKeyDataType.DateTime:
                            DateTime dt = (DateTime)((DATE)value);
                            typevalue = dt;
                            break;
                        case EnumKeyDataType.String:
                            typevalue = value.ToString();
                            break;

                    }
                    bool newRec = true;
                    int RecordID = 0;
                    if (recordIDsbyDisplayRow.ContainsKey(i))
                    {
                        RecordID = recordIDsbyDisplayRow[i];
                        newRec = false;
                    }
                    bool aValueWasUpdated = SaveGraphicObjectData(associatedGraphic.PageID, RuntimeGraphicID, ref RecordID, RecordLineage, typevalue, dataSource, newRec, i, false);
                    if (!TheValueWasUpdated && aValueWasUpdated)
                        TheValueWasUpdated = true;
                }
            }
            if (TheValueWasUpdated)
                this.PerformDynamicCompute(associatedGraphic.PageID, associatedGraphic.GraphicID, RecordLineage);


        }

        public int GetRecordLineageForThisRecordID(int RecordID)
        {
            LocatorObjectRecordEntity lor = new LocatorObjectRecordEntity(RecordID);
            return Convert.ToInt32(lor.Record_Lineage);
        }
        public int GetRecordIDForThisGraphicByDisplayOrder(int PageID, int GraphicID, int RecordLineage, int DisplayOrder)
        {
            LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, GraphicID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, PageID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Row_DisplayOrder, ComparisonOperator.Equal, DisplayOrder));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, RecordLineage));
            lorc.GetMulti(filter);
            if (lorc.Count == 0)
            {
                theLogger.Error(string.Format("RecordID not found for PageID/GraphicID/RecordLineage/DisplayOrder: {0}/{1}/{2}/{3}", PageID, GraphicID, RecordLineage, DisplayOrder));
                return 0;
            }
            if (lorc.Count > 1)
            {
                theLogger.Error(string.Format("More than one RecordID found, returning first one, for PageID/GraphicID/RecordLineage/DisplayOrder: {0}/{1}/{2}/{3}", PageID, GraphicID, RecordLineage, DisplayOrder));
            }
            return lorc[0].Record_ID;
        }
        public int GetRecordIDForSingleValue(int PageID, int RuntimeGraphicID, int RowDisplayOrder, int RecordLineage)
        {
            LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, PageID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, RuntimeGraphicID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, RecordLineage));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Row_DisplayOrder, ComparisonOperator.Equal, RowDisplayOrder));

            lorc.GetMulti(filter);
            if (lorc.Count == 1)
                return lorc[0].Record_ID;
            else if (lorc.Count == 0)
                return 0;
            else
                throw new InvalidOperationException("Multiple records exist for the unique key: PageID, RuntimeGraphicID, RowDisplayOrder, RecordLineage");

        }
        /// <summary>
        /// returns true if the value was updated in the database.
        /// </summary>
        /// <param name="PageID"></param>
        /// <param name="RuntimeGraphicID"></param>
        /// <param name="value"></param>
        /// <param name="dataSource"></param>
        /// <param name="RecordLineage"></param>
        /// <returns></returns>
		public bool SetValue(int PageID, int RuntimeGraphicID, object value, DataSourceEnum dataSource, int RecordLineage)
		{
			bool ValueUpdated = false;
            GraphicInfoItem updatedGraphic = GetGraphicInfoItem(PageID, RuntimeGraphicID);
			if (updatedGraphic.DataType == Convert.ToByte(EnumKeyDataType.DataTable))
			{
                int RowInd = -1;
                int nChangedColumnID = 0;
                ValueUpdated = SaveDataTable(PageID, RuntimeGraphicID, (DataTable)value, RecordLineage, out nChangedColumnID, out RowInd);
                if (ValueUpdated && nChangedColumnID != 0)
                {
                    ValueUpdated = true;
                }
    		}
			else
			{
                int RecordID = GetRecordIDForSingleValue(updatedGraphic.PageID, RuntimeGraphicID, 0, RecordLineage);
                bool newRec = false;
                if (RecordID == 0)
                    newRec = true;
				ValueUpdated = SaveGraphicObjectData(updatedGraphic.PageID, updatedGraphic.GraphicID, ref RecordID, RecordLineage, value, dataSource, newRec, 1, false);	
				theLogger.Info(string.Format("Set Single Value: RunTimeGraphicID: {0}  Value: {1} WasUpdated: {2}", updatedGraphic.GraphicID.ToString(), value.ToString(), ValueUpdated.ToString()));
			}
            if (ValueUpdated)
                this.PerformDynamicCompute(PageID, RuntimeGraphicID, RecordLineage);
			return ValueUpdated;


		}
        public void UpdateValue(int RecordID, object value, DataSourceEnum datasource)
        {
            if (theLogger.IsDebugEnabled)
                theLogger.Debug(string.Format("Update Value RecID / val / datasource: {0}/{1}/{2}", RecordID.ToString(), value.ToString(), datasource.ToString()));
            bool ValueUpdated = false;
            PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
            LocatorObjectRecordEntity lor = new LocatorObjectRecordEntity(RecordID, prefetch);
            bool found = false;
            foreach (LocatorObjectValueEntity lov in lor.LocatorObjectValue)
            {
                if (lov.DataSource_EnumValue == Convert.ToByte(datasource))
                {
                    ValueUpdated = SetValueInLocatorObjectValue(lov, value, (EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), lor.DataType_EnumValue.ToString()));
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                //if it got here then there is a record, but not of the datasource type being set.
				LocatorObjectValueEntity newlov = new LocatorObjectValueEntity();
				newlov.DataSource_EnumValue = Convert.ToByte(datasource);
				SetValueInLocatorObjectValue(newlov, value, (EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), lor.DataType_EnumValue.ToString()));  //ignore return value - it changed...
                lor.LocatorObjectValue.Add(newlov);
                ValueUpdated = true;
            }
            //updates are pretty much all computes... //TODO: confirm Datasource used setting here with business rules
            lor.DatasourceUsed = Convert.ToByte(datasource);
            lor.Save(true);

            //TODO: implement partials
            if (ValueUpdated)
                this.PerformFullCompute();
        }
        
        public void PerformFullCompute()
        {
            theLogger.Info("Running Full Compute");

            //using (ComputeModule compute = new ComputeModule(myScriptLibrary, myDatabaseAndBinaryPathSettings.MappingInfoFilePathAndName,myDatabaseAndBinaryPathSettings.DetailInfoFilePathAndName))
            //{
            //    try
            //    {
            //        compute.FullCompute(myLocatorID, myYear);
            //    }
            //    catch (Exception ex)
            //    {
            //        theLogger.Error("Error running full Compute", ex);
            //    }
            //}
        }
        public void PerformDynamicCompute(int PageID, int GraphicID, int RecordLineage)
        {
            //ComputeModule compute = new ComputeModule(myScriptLibrary, myUserconfig.MappingInfoFilePathAndName);
            try
            {
                theLogger.Warn("Dynamic compute currently turned off.  Re-enable Here");
                //compute.DynamicCompute(updatedFieldKey);
            }
            catch (Exception ex)
            {
                theLogger.Error("Error running dynamic Compute", ex);
            }

            if (PageUpdatedEvent != null)
            {
                PageUpdatedEvent(this, new List<int>());
            }
        }
        public void SelectDataSource(bool bClearOverride, int PageID, int RuntimeGraphicID, DataSourceEnum dataSource, int RecordLineage, int RowInd)
        {
            GraphicInfoItem updatedGraphic = GetGraphicInfoItem(PageID, RuntimeGraphicID);
            int RecordID = GetRecordIDForSingleValue(updatedGraphic.PageID, RuntimeGraphicID, RowInd, RecordLineage);
            if (RecordID == 0)
            {
                if (theLogger.IsDebugEnabled)
                    theLogger.Debug("Select DataSource - Record not found");
                return;
            }
            PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
            LocatorObjectRecordEntity lor = null;
            lor = new LocatorObjectRecordEntity(RecordID, prefetch);
            if (bClearOverride)
            {
                IPredicateExpression filer = new PredicateExpression();
                filer.Add(PredicateFactory.CompareValue(LocatorObjectValueFieldIndex.DataSource_EnumValue, ComparisonOperator.Equal, DataSourceEnum.Override));
                filer.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectValueFieldIndex.Record_ID, ComparisonOperator.Equal, RecordID));
                lor.LocatorObjectValue.DeleteMulti(filer);
                if (lor.DatasourceUsed == Convert.ToByte(DataSourceEnum.Override))
                {
                    lor.DatasourceUsed = lor.LocatorObjectValue[0].DataSource_EnumValue;
                    if (theLogger.IsDebugEnabled)
                        theLogger.Debug("SelectDataSource - ClearOverride - setting to " + lor.DatasourceUsed.ToString());
                }
            }
            else
            {
                lor.DatasourceUsed = Convert.ToByte(dataSource);
                if (theLogger.IsDebugEnabled)
                    theLogger.Debug("SelectDataSource - setting to " + lor.DatasourceUsed.ToString());
            }
            lor.Save();
        }
        
        
        #region Private Methods
        private void SetScriptLibraryAndMappingInfo()
        {
            string pathWithScript = myDatabaseAndBinaryPathSettings.CodeScriptDLLPathAndName;
            string scriptname = string.Empty;
            if (pathWithScript.Equals(string.Empty))
            {
                scriptname = "Thomson.Ria.TaxApp.AllApplications." + myUserconfig.Year.ToString() + ".Scripts.dll";
            }
            else
            {
                scriptname = pathWithScript;
            }
            theLogger.Info("Script Manager ScriptName: " + scriptname);

            try
            {
                //myScriptLibrary = new ScriptLibrary(scriptname);
                myScriptLibrary = new ScriptLibrary();
            }
            catch (System.IO.FileNotFoundException)// ex)
            {
                theLogger.Info("File: " + scriptname + " not found. Reseting entry to blank.");
                myDatabaseAndBinaryPathSettings.CodeScriptDLLPathAndName = "";
                return;
            }
            //now check the binary file info:
            string pathToBIN = myDatabaseAndBinaryPathSettings.MappingInfoFilePathAndName;
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(pathToBIN);
            }
            catch (Exception ex)
            {
                theLogger.Info("File: " + pathToBIN + " not found. Reseting entry to blank.");
                theLogger.Debug("Error: ", ex);
                return;
            }

            List<long> IndexOffsets = new List<long>();
            int recordCount = 0;
            if (fi.Exists)
            {
                using (FileStream myFileStream = new FileStream(pathToBIN, FileMode.Open))
                {
                    myFileStream.Seek(0, SeekOrigin.Begin);
                    BinaryReader br = new BinaryReader(myFileStream);
                    recordCount = br.ReadInt32();
                }
                theLogger.Info("Binary mapping info file confirmed.  Number of records: " + recordCount.ToString());
            }

        }
        private bool SetValueInLocatorObjectValue(LocatorObjectValueEntity lov, object value, EnumKeyDataType dataType)
        {
            switch (dataType)
            {
                case EnumKeyDataType.Boolean:
                    try
                    {
                        bool bv = Convert.ToBoolean(value);
                        lov.BooleanValue = bv;
                    }
                    catch (Exception ex)
                    {
                        theLogger.Error(string.Format("Value not set:: Record_ID/Value/EDT: {0}/{1}/{2}", lov.Record_ID.ToString(), value.ToString(), dataType.ToString()), ex);
                    }
                    break;
                case EnumKeyDataType.String:
                    lov.StringValue = value.ToString();
                    break;
                case EnumKeyDataType.Money:
                case EnumKeyDataType.Integer:
                    try
                    {
                        decimal num = Convert.ToDecimal(value);
                        lov.NumericValue = num;
                    }
                    catch (Exception ex)
                    {
                        theLogger.Error(string.Format("Value not set:: Record_ID/Value/EDT: {0}/{1}/{2}", lov.Record_ID.ToString(), value.ToString(), dataType.ToString()), ex);
                    }
                    break;
                case EnumKeyDataType.DateTime:
                    try
                    {
                        DateTime dt = DateTime.Parse(value.ToString());
                        lov.DateValue = dt;
                    }
                    catch (Exception ex)
                    {
                        theLogger.Error(string.Format("Value not set:: Record_ID/Value/EDT: {0}/{1}/{2}", lov.Record_ID.ToString(), value.ToString(), dataType.ToString()), ex);
                    }
                    break;
                case EnumKeyDataType.Ratio:
                    try
                    {
                        decimal fv = Convert.ToDecimal(value);
                        lov.FractionValue = fv;
                    }
                    catch (Exception ex)
                    {
                        theLogger.Error(string.Format("Value not set:: Record_ID/Value/EDT: {0}/{1}/{2}", lov.Record_ID.ToString(), value.ToString(), dataType.ToString()), ex);
                    }
                    break;
                //				case EnumKeyDataType.imageValue:
                //					lov.LocatorImage = Convert.tob;
                //					break;
            }
            if (lov.IsDirty || lov.IsNew)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool SaveDataTable(int PageID, int RuntimeGraphicID, DataTable dataTable, int RecordLineage, out int nChangedColumnID, out int RowInd)
        {
            if (theLogger.IsDebugEnabled)
                theLogger.Debug(string.Format("Save Data Table: PageID/Rowcount: {0}/{1}", PageID, dataTable.Rows.Count));
            bool bReturn = false;
            nChangedColumnID = 0;
            RowInd = -1;
            List<GraphicInfoItem> columns = GetGraphicInfoItem(PageID, RuntimeGraphicID).Columns;
            bool gridHasComputes = false;
            foreach (GraphicInfoItem c in columns)
            {
                if (c.IsComputed)
                {
                    gridHasComputes = true;
                    break;
                }
            }
            PropertyCollection tableProps = dataTable.ExtendedProperties;
            Dictionary<RowColumnKey, int> records = new Dictionary<RowColumnKey, int>();
            if (tableProps.ContainsKey("RecordIDS"))
                records = (Dictionary<RowColumnKey, int>)tableProps["RecordIDS"];
            Dictionary<RowColumnKey, int> recordsNewAdded = new Dictionary<RowColumnKey, int>();
            int rowIndex = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                if (theLogger.IsDebugEnabled)
                    theLogger.Debug(string.Format("DataRow Index / State: {0}/{1}", rowIndex, dr.RowState.ToString()));
                if (dr.RowState != DataRowState.Unchanged)
                {
                    if (dr.RowState == DataRowState.Deleted)
                    {
                        DeleteDataTableRow(rowIndex, columns, records, dataTable.Rows.Count);
                        RowInd = rowIndex;
                        nChangedColumnID = 0;
                        return true;
                    }
                    foreach (GraphicInfoItem column in columns)
                    {
                        RowColumnKey key = new RowColumnKey(rowIndex, column.GraphicID);
                        int RecordID = 0;
                        bool newRecord = true;
                        if (records.ContainsKey(key))
                        {
                            //they should always have one there
                            RecordID = records[key];
                            if (RecordID != -1)
                                newRecord = false;
                        }
                        if (dr[column.GraphicID.ToString()] == DBNull.Value)
                            continue;
                        object value = ((ValueWithDataSources)dr[column.GraphicID.ToString()]).Value;
                        if (SaveGraphicObjectData(column.PageID, column.GraphicID, ref RecordID, RecordLineage, value, ((ValueWithDataSources)dr[column.GraphicID.ToString()]).DataSource, newRecord, rowIndex + 1, false))
                        {
                            if (recordsNewAdded.ContainsKey(key))
                            {
                                //they should always have one there
                                int oldRecordID = recordsNewAdded[key];
                                if (oldRecordID == -1)
                                    records[key] = RecordID;
                            }
                            else
                                recordsNewAdded.Add(key, RecordID);

                            //records.Add(key, RecordID);
                            RowInd = rowIndex;
                            if (newRecord && gridHasComputes)
                            { 
                                //add records for computed fields
                                foreach (GraphicInfoItem c2 in columns)
                                {
                                    if (c2.IsComputed)
                                    { 
                                        RowColumnKey key2 = new RowColumnKey(rowIndex, c2.GraphicID);
                                        int RecordID2 = 0;
                                        bool saveCellJustSaved = false;
                                        if (records.ContainsKey(key2))
                                        {
                                            RecordID2 = records[key2];
                                            if (RecordID2 != -1)
                                                continue;
                                        }
                                        if (recordsNewAdded.ContainsKey(key2))
                                        {
                                            RecordID2 = recordsNewAdded[key2];
                                            saveCellJustSaved = true;
                                            //this is the cell that just saved the value, so should not change the DatasourceUsed field of the record
                                        }
                                        SaveGraphicObjectData(c2.PageID, c2.GraphicID, ref RecordID2, RecordLineage, c2.DefaultValue, DataSourceEnum.Compute, true, rowIndex + 1, saveCellJustSaved);

                                        theLogger.Debug("Computed Column value added. GraphicID / Display Row: " + c2.GraphicID + " / " + (rowIndex + 1));
                                    }
                                }
                            }
                            return true;
                        }
                    }
                }
                rowIndex++;
            }
            return bReturn;
        }
        private void DeleteLocatorObjecRecord(LocatorObjectRecordEntity record)
        {
            //delete the record lineage Data
            LocatorObjectRecordCollection childrenLoopRecords = new LocatorObjectRecordCollection();
            IPredicateExpression filer = new PredicateExpression();
            filer.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, record.Record_ID));
            childrenLoopRecords.GetMulti(filer);
            foreach (LocatorObjectRecordEntity childRecord in childrenLoopRecords)
                DeleteLocatorObjecRecord(childRecord);

            record.LocatorObjectValue.DeleteMulti();
            record.Delete();
        }
        private void DeleteDataTableRow(int rowInd, ICollection<GraphicInfoItem> columns, Dictionary<RowColumnKey, int> records, int rowCount)
        {
            //delete the current row
            foreach (GraphicInfoItem column in columns)
            {
                RowColumnKey key = new RowColumnKey(rowInd, column.GraphicID);
                int RecordID = 0;
                if (!records.ContainsKey(key))
                    continue;
                RecordID = records[key];
                PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
                prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
                LocatorObjectRecordEntity lor = new LocatorObjectRecordEntity(RecordID, prefetch);
                if (lor.IsNew)
                    continue;
                DeleteLocatorObjecRecord(lor);
            }
            //reset the following rows' displayorder
            for (int n = rowInd + 1; n < rowCount; n++)
            {
                foreach (GraphicInfoItem column in columns)
                {
                    RowColumnKey key = new RowColumnKey(n, column.GraphicID);
                    int RecordID = 0;
                    if (!records.ContainsKey(key))
                        continue;
                    RecordID = records[key];
                    PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
                    prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
                    LocatorObjectRecordEntity lor = new LocatorObjectRecordEntity(RecordID, prefetch);
                    if (lor.IsNew)
                        continue;
                    lor.Row_DisplayOrder--;
                    lor.Save();
                    //ALso need to run the proc that will update the row record lineage
                    //int outputError = 0;
                    //TestHarness.DataObjects.StoredProcedureCallerClasses.ActionProcedures.SpManageRowLineage(myLocatorID, myYear, lor.Record_ID, ref outputError);
                }
            }
        }
        private DataTable ProcessDataTable(GraphicInfoItem GridGraphicInfoItem, int RecordLineage)
        {
            DataTable Table = new DataTable(GridGraphicInfoItem.GraphicName);
            theLogger.Debug("Processing Grid DataTable...  GridID/RecordLineage: " + GridGraphicInfoItem.GraphicID + "/" + RecordLineage.ToString());
            //setup the DataTable Schema
            IList<GraphicInfoItem> columns = GridGraphicInfoItem.Columns;// myGraphicMatrix.GetGraphicInfoItem(GridGraphicInfoItem.PageID, GridGraphicInfoItem.GraphicID).Columns;
            theLogger.Debug("Adding Columns to datatable.  Column count: " + columns.Count);
            for (int i = 0; i < columns.Count; i++)
            {
                foreach (GraphicInfoItem gii in columns)
                {
                    if ((int)gii.ColumnDisplayOrder == i + 1)
                    {
                        DataColumn column = new DataColumn(gii.GraphicID.ToString(), typeof(ValueWithDataSources));
                        Table.Columns.Add(column);
                        break;
                    }
                    
                }
            }

            //load in the sets of data for each column
            int maxnumberRecords = 0;
            Dictionary<int, LocatorObjectRecordCollection> columnRecordCollections = new Dictionary<int, LocatorObjectRecordCollection>();

            for (int i = 0; i < columns.Count; i++)
            {
                LocatorObjectRecordCollection crc = new LocatorObjectRecordCollection();
                PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
                prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);
                PredicateExpression filter = new PredicateExpression();
                filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
                filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
                filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, columns[i].GraphicID));
                filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, columns[i].PageID));
                filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, RecordLineage));
                ISortExpression sortClause = new SortExpression(SortClauseFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder, SortOperator.Ascending));
                crc.GetMulti(filter, 0, sortClause, null, prefetch);
                if (crc.Count > 0)
                {
                    if (maxnumberRecords < crc[crc.Count - 1].Row_DisplayOrder)
                    {
                        maxnumberRecords = crc[crc.Count - 1].Row_DisplayOrder;
                    }
                }
                columnRecordCollections.Add(columns[i].GraphicID, crc);
            }
            PropertyCollection tableProps = Table.ExtendedProperties;
            Dictionary<RowColumnKey, int> RowColumnRecordIndex = new Dictionary<RowColumnKey, int>();

            //initialize all the row columnGID keys to -1
            for (int ColumnIndex = 0; ColumnIndex < columns.Count; ColumnIndex++)
            {
                int i = maxnumberRecords;
                if (i == 0)
                {
                    i = 1;  //TODO: pass in prefered "new row count for data entry (or does the grid have it?)"
                }
                GraphicInfoItem column = columns[ColumnIndex];
                for (int rowIndex = 0; rowIndex < i; rowIndex++)
                {
                    RowColumnRecordIndex.Add(new RowColumnKey(rowIndex + 1, column.GraphicID), -1);
                }
            }

            if (maxnumberRecords > 0)
            {
                //now loop thru and set each columns data
                int rowInd = 0;
                while (rowInd < maxnumberRecords)
                {
                    DataRow row = Table.NewRow();

                    for (int col = 0; col < columns.Count; col++)
                    {
                        GraphicInfoItem column = columns[col];
                        LocatorObjectRecordEntity lor = null;
                        for (int nInd = 0; nInd < columnRecordCollections[column.GraphicID].Count; nInd++)
                        {
                            lor = (LocatorObjectRecordEntity)columnRecordCollections[column.GraphicID][nInd];
                            if (rowInd == lor.Row_DisplayOrder - 1)
                            {
                                DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lor.DatasourceUsed.ToString());
                                object dataSourceVal = GetValueFromThisLocatorObjectRecordByDataSource(lor, column, datasource);
                                if (dataSourceVal == null)
                                    dataSourceVal = column.DefaultValue;
                                List<ValueWithDataSources> otherdatasources = GetOtherDataSources(lor, datasource);
                                ValueWithDataSources valueDataSource = new ValueWithDataSources(dataSourceVal, datasource, otherdatasources);

                                row[column.GraphicID.ToString()] = valueDataSource;
                                RowColumnKey rck = new RowColumnKey(rowInd, column.GraphicID);
                                RowColumnRecordIndex[rck] = lor.Record_ID;
                                break;
                            }
                        }
                    }
                    Table.Rows.Add(row);
                    rowInd++;
                }
                tableProps.Add("RecordIDS", RowColumnRecordIndex);
            }
            else
            {
                //empty - add one
                DataRow row = Table.NewRow();
                for (int col = 0; col < columns.Count; col++)
                {
                    GraphicInfoItem column = columns[col];
                    //this is where default values and system values come into play

                    ValueWithDataSources valueDataSource = new ValueWithDataSources(column.DefaultValue, DataSourceEnum.SystemDefault, new List<ValueWithDataSources>());
                    row[column.GraphicID.ToString()] = valueDataSource;
                }
            }
            Table.AcceptChanges();
            return Table;
        }
        private object GetValueFromLOV(LocatorObjectValueEntity lov, EnumKeyDataType type)
        {
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
                    return lov.DateValue;

                case EnumKeyDataType.Ratio:
                    return lov.FractionValue;

                case EnumKeyDataType.Image:
                    //TODO: hook up images
                    return lov.LocatorImage_ID;

                default:
                    return null;
            }
        }
        private object GetValueFromThisLocatorObjectRecordByDataSource(LocatorObjectRecordEntity lor, GraphicInfoItem graphicInfoItem, DataSourceEnum datasource)
        {
            //A record - each with a set of values - each with its own DataSource (Computed, DataEntry, Rollover, etc...)
            if (!lor.IsNew)
            {
                //get the passed in datasource
                foreach (LocatorObjectValueEntity lov in lor.LocatorObjectValue)
                {
                    if (lov.DataSource_EnumValue == Convert.ToByte(datasource))
                    {
                        return GetValueFromLOV(lov, (EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), lor.DataType_EnumValue.ToString()));
                    }
                }
                theLogger.Error("Value isn't found for specified datasource");
            }
            return null;
        }
        private List<ValueWithDataSources> GetOtherDataSources(LocatorObjectRecordEntity lor, DataSourceEnum originatingdatasource)
        {
            if (lor.LocatorObjectValue.Count == 1)
                return null;
            else if (lor.LocatorObjectValue.Count > 1)
            {
                List<ValueWithDataSources> list = new List<ValueWithDataSources>();
                foreach (LocatorObjectValueEntity lov in lor.LocatorObjectValue)
                {
                    if (lov.DataSource_EnumValue != Convert.ToByte(originatingdatasource))
                    {
                        object value = GetValueFromLOV(lov, (EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), lor.DataType_EnumValue.ToString()));
                        DataSourceEnum datasource = (DataSourceEnum)Enum.Parse(typeof(DataSourceEnum), lov.DataSource_EnumValue.ToString());
                        ValueWithDataSources vds = new ValueWithDataSources(value, datasource, null);
                        list.Add(vds);
                    }
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        private Dictionary<int, int> GetRecordIDsByDisplayRowForBaseTypeSave(int PageID, int GraphicID, int RecordLineage)
        {
            Dictionary<int, int> RecordIDsByIndex = new Dictionary<int, int>();

            GraphicInfoItem thisGraphicItem = GetGraphicInfoItem(PageID, GraphicID);
            PrefetchPath prefetch = new PrefetchPath((int)EntityType.LocatorObjectRecordEntity);
            prefetch.Add(LocatorObjectRecordEntity.PrefetchPathLocatorObjectValue);

            LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Locator_ID, ComparisonOperator.Equal, this.LocatorID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Product_Year, ComparisonOperator.Equal, this.Year));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.GraphicObject_ID, ComparisonOperator.Equal, GraphicID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Page_ID, ComparisonOperator.Equal, PageID));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorObjectRecordFieldIndex.Record_Lineage, ComparisonOperator.Equal, RecordLineage));

            ISortExpression sortClause = new SortExpression(SortClauseFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder, SortOperator.Ascending));
            lorc.GetMulti(filter, 0, sortClause, null, prefetch);

            int i = 1;
            foreach (LocatorObjectRecordEntity lor in lorc)
            {
                if (lor.Row_DisplayOrder != i)
                {
                    theLogger.Warn("LocatorObjectRecord's DisplayOrder not correct, Record_ID: " + lor.Record_ID.ToString());
                    break;
                }
                RecordIDsByIndex.Add(i, lor.Record_ID);
                i++;
            }
            return RecordIDsByIndex;

        }
        
        #endregion Private Methods

        public class RowColumnKey
        {
            int myRow = 0;
            int myColumn = 0;
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
        }
	}
	namespace Tests
	{
		[TestFixture] public class LocatorImplTests
		{
            private LocatorImpl myLocatorImplForTesting;
            [SetUp]
            public void Setup()
            {
                DatabaseInitializer.ClearDatabaseCompletely();
                DatabaseInitializer.CheckEnterpriseTableAndEnums();
                LocatorObjectValueCollection lovc = new LocatorObjectValueCollection();
                Assert.IsTrue(lovc.GetDbCount() == 0);

                UserConfigurationItems con = new UserConfigurationItems();

                myLocatorImplForTesting = new LocatorImpl();

                ClientImpl cli = new ClientImpl();
                int clientID = cli.GetClientByNameAddIfNew(con.ClientName, con.Year);
                int id = cli.AddNewLocatorToListForClient(clientID, "testLocator1", con.Year);

                myLocatorImplForTesting.Initialize("testLocator1", id, con.Year, con);
                myLocatorImplForTesting.LoadGraphicMatrix();
            }
            [Test]
            public void TestKeyStructure()
            {
                Dictionary<TestHarness.BusinessObjects.LocatorImpl.RowColumnKey, int> rck = new Dictionary<TestHarness.BusinessObjects.LocatorImpl.RowColumnKey, int>();
                TestHarness.BusinessObjects.LocatorImpl.RowColumnKey rck1 = new TestHarness.BusinessObjects.LocatorImpl.RowColumnKey(0, 0);
                TestHarness.BusinessObjects.LocatorImpl.RowColumnKey rck2 = new TestHarness.BusinessObjects.LocatorImpl.RowColumnKey(0, 1);
                TestHarness.BusinessObjects.LocatorImpl.RowColumnKey rck3 = new TestHarness.BusinessObjects.LocatorImpl.RowColumnKey(1, 0);
                TestHarness.BusinessObjects.LocatorImpl.RowColumnKey rck4 = new TestHarness.BusinessObjects.LocatorImpl.RowColumnKey(1, 1);

                rck.Add(rck1, 3);
                rck.Add(rck2, 4);
                rck.Add(rck3, 5);
                rck.Add(rck4, 6);

                Assert.AreEqual(4, rck.Count);
                Assert.AreEqual(3, rck[rck1]);
                Assert.AreEqual(4, rck[rck2]);
                Assert.AreEqual(5, rck[rck3]);
                Assert.AreEqual(6, rck[rck4]);

                TestHarness.BusinessObjects.LocatorImpl.RowColumnKey rck5 = new TestHarness.BusinessObjects.LocatorImpl.RowColumnKey(0, 0);
                Assert.IsTrue(rck.ContainsKey(rck5));

            }
			[Test] public void ObjectCD()
			{
                Assert.IsNotNull(myLocatorImplForTesting);

                Console.WriteLine("Locator ID: " + myLocatorImplForTesting.LocatorID );
                Console.WriteLine("Locator Name: " + myLocatorImplForTesting.LocatorName);
            }
			[Test] public void AddATestRecordValueAndRetrieveIt()
			{
                //these tests were using the TITaxApp - with all the various pieces...
                LocatorObjectValueCollection lovc = new LocatorObjectValueCollection();
                //Simple saves - testing the SaveGraphicObjectData function
                int nRecID = 0;
                Assert.IsTrue(myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 700, DataSourceEnum.DataEntry, true, 1, false));
                nRecID = 0;
                Assert.IsTrue(myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 8000, DataSourceEnum.Compute, false, 1, false));
				Assert.AreEqual(2, lovc.GetDbCount());
                decimal l = Convert.ToDecimal(myLocatorImplForTesting.GetSingleValue(1, 1, 0).Value);
				Assert.AreEqual(8000, l);

				//save it again, should update the value
                nRecID = 0;
                Assert.IsTrue(myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 800, DataSourceEnum.DataEntry, false, 1, false));
                Assert.IsTrue(myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 9000, DataSourceEnum.Compute, false, 1, false));
				Assert.AreEqual(2, lovc.GetDbCount());
                ValueWithDataSources vds = myLocatorImplForTesting.GetSingleValue(1, 1, 0);
                Assert.AreEqual(9000, Convert.ToInt32(vds.Value));

                //select the datasource
                myLocatorImplForTesting.SelectDataSource(false, 1, 1, DataSourceEnum.DataEntry, 0, 1);
                vds = myLocatorImplForTesting.GetSingleValue(1, 1, 0);
                Assert.AreEqual(800, Convert.ToInt32(vds.Value));

                //add an override value
                nRecID = 0;
                Assert.IsTrue(myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 7000, DataSourceEnum.Override, false, 1, false));
                Assert.AreEqual(3, lovc.GetDbCount());
                vds = myLocatorImplForTesting.GetSingleValue(1, 1, 0);
                Assert.AreEqual(7000, Convert.ToInt32(vds.Value));

                //clear override
                myLocatorImplForTesting.SelectDataSource(true, 1, 1, DataSourceEnum.DataEntry, 0, 1);
                Assert.AreEqual(2, lovc.GetDbCount());
                vds = myLocatorImplForTesting.GetSingleValue(1, 1, 0);
                Assert.AreNotEqual(DataSourceEnum.Override, Convert.ToInt32(vds.DataSource));

                myLocatorImplForTesting.SetValue(1, 1, 650, DataSourceEnum.DataEntry, 0);

                //base type
                MONEY i = 850;
                Assert.AreEqual(850.0, (double)i);
                myLocatorImplForTesting.SetBasetypeValue(1, 1, i, DataSourceEnum.Compute, 0);
				Assert.AreEqual(2, lovc.GetDbCount());
                vds = myLocatorImplForTesting.GetSingleValue(1, 1, 0);
                Assert.AreEqual(850, Convert.ToInt32(vds.Value));
                nRecID = 0;
                Assert.IsTrue(myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 860, DataSourceEnum.DataEntry, false, 1, false));
                Assert.IsTrue(!myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 860, DataSourceEnum.DataEntry, false, 1, false));
                Assert.IsNull(myLocatorImplForTesting.GetSingleValue(2, 2000, 0));

                MONEY ii = new double[2] { 333, 444 };
                Assert.AreEqual(2, ii.Rows);
                myLocatorImplForTesting.SetBasetypeValue(3, 3, ii, DataSourceEnum.DataEntry, 0);
                //that should add 2 more lov's
                Assert.AreEqual(4, lovc.GetDbCount());
                IBaseType bt = myLocatorImplForTesting.GetValueAsBaseType(3, 3, 0);
                Assert.AreEqual(2, bt.Rows);
                
                BOOL bb = new bool[3] { true, false, true };
                myLocatorImplForTesting.SetBasetypeValue(1, 1100, bb, DataSourceEnum.DataEntry, 0);
                Assert.AreEqual(7, lovc.GetDbCount());
                bt = myLocatorImplForTesting.GetValueAsBaseType(1, 1100, 0);
                Assert.AreEqual(3, bt.Rows);

                STRING ss = new string[4] { "X", "Y", "Z", "A"};
                myLocatorImplForTesting.SetBasetypeValue(1, 1101, ss, DataSourceEnum.DataEntry, 0);
                Assert.AreEqual(11, lovc.GetDbCount());
                bt = myLocatorImplForTesting.GetValueAsBaseType(1, 1101, 0);
                Assert.AreEqual(4, bt.Rows);

                DateTime[] dts = new DateTime[3];
                dts[0] = DateTime.Now;
                dts[1] = DateTime.Parse("1/1/2078") ;
                dts[2] = DateTime.Parse("12/07/1987");
                DATE dtt = dts;
                myLocatorImplForTesting.SetBasetypeValue(1, 1102, dtt, DataSourceEnum.DataEntry, 0);
                Assert.AreEqual(14, lovc.GetDbCount());
                bt = myLocatorImplForTesting.GetValueAsBaseType(1, 1102, 0);
                Assert.AreEqual(3, bt.Rows);
                
                //now test the Grid
                DataTable dt = new DataTable("GridGraphic");
                IList<GraphicInfoItem> columns = myLocatorImplForTesting.GetGraphicInfoItem(2, 2000).Columns;
                Assert.AreEqual(3, columns.Count);
                foreach (GraphicInfoItem gii in columns)
                {
                    DataColumn column = new DataColumn(gii.GraphicID.ToString(), typeof(ValueWithDataSources));
                    dt.Columns.Add(column);
                }
                Random r = new Random();
                DataRow dr = dt.NewRow();
                dr[0] = new ValueWithDataSources(true, DataSourceEnum.DataEntry, null);
                dr[1] = new ValueWithDataSources("stringValue", DataSourceEnum.DataEntry, null);
                dr[2] = new ValueWithDataSources(r.NextDouble(), DataSourceEnum.DataEntry, null);
                dt.Rows.Add(dr);

                DataRow dr2 = dt.NewRow();
                dr2[0] = new ValueWithDataSources(true, DataSourceEnum.DataEntry, null);
                dr2[1] = new ValueWithDataSources("stringValue", DataSourceEnum.DataEntry, null);
                dr2[2] = new ValueWithDataSources(r.NextDouble(), DataSourceEnum.DataEntry, null);
                dt.Rows.Add(dr2);

                Assert.IsTrue(myLocatorImplForTesting.SetValue(2, 2000, dt, DataSourceEnum.DataEntry, 0));

                DataTable dt2 = myLocatorImplForTesting.GetGridDataTable(2, 2000, 0);
                Assert.AreEqual(1, dt2.Rows.Count);

                Assert.IsFalse(myLocatorImplForTesting.SetValue(2, 2000, dt2, DataSourceEnum.DataEntry, 0));


                DataTable dtLevel = new DataTable("GridGraphic");
                columns = myLocatorImplForTesting.GetGraphicInfoItem(2, 2000).Columns;
                Assert.AreEqual(3, columns.Count);
                foreach (GraphicInfoItem gii in columns)
                {
                    DataColumn column = new DataColumn(gii.GraphicID.ToString(), typeof(ValueWithDataSources));
                    dtLevel.Columns.Add(column);
                }
                DataRow drLevelr1 = dtLevel.NewRow();
                drLevelr1[0] = new ValueWithDataSources(true, DataSourceEnum.DataEntry, null);
                drLevelr1[1] = new ValueWithDataSources("stringValueLevel1", DataSourceEnum.DataEntry, null);
                drLevelr1[2] = new ValueWithDataSources(r.NextDouble(), DataSourceEnum.DataEntry, null);
                dtLevel.Rows.Add(drLevelr1);

                DataRow drLevelr2 = dtLevel.NewRow();
                drLevelr2[0] = new ValueWithDataSources(true, DataSourceEnum.DataEntry, null);
                drLevelr2[1] = new ValueWithDataSources("stringValueLevel1", DataSourceEnum.DataEntry, null);
                drLevelr2[2] = new ValueWithDataSources(r.NextDouble(), DataSourceEnum.DataEntry, null);
                dtLevel.Rows.Add(drLevelr2);

                Assert.IsTrue(myLocatorImplForTesting.SetValue(2, 2000, dtLevel, DataSourceEnum.DataEntry, 1));

                DataTable dtLevela = myLocatorImplForTesting.GetGridDataTable(2, 2000, 1);
                Assert.AreEqual(1, dtLevela.Rows.Count);

                DataTable dtLevel2 = new DataTable("GridGraphic");
                columns = myLocatorImplForTesting.GetGraphicInfoItem(2, 2000).Columns;
                Assert.AreEqual(3, columns.Count);
                foreach (GraphicInfoItem gii in columns)
                {
                    DataColumn column = new DataColumn(gii.GraphicID.ToString(), typeof(ValueWithDataSources));
                    dtLevel2.Columns.Add(column);
                }
                DataRow drLevel1r3 = dtLevel2.NewRow();
                drLevel1r3[0] = new ValueWithDataSources(true, DataSourceEnum.DataEntry, null);
                drLevel1r3[1] = new ValueWithDataSources("stringValueLevel1-2", DataSourceEnum.DataEntry, null);
                drLevel1r3[2] = new ValueWithDataSources(r.NextDouble(), DataSourceEnum.DataEntry, null);
                dtLevel2.Rows.Add(drLevel1r3);

                DataRow drLevel1r4 = dtLevel2.NewRow();
                drLevel1r4[0] = new ValueWithDataSources(true, DataSourceEnum.DataEntry, null);
                drLevel1r4[1] = new ValueWithDataSources("stringValueLevel1-2", DataSourceEnum.DataEntry, null);
                drLevel1r4[2] = new ValueWithDataSources(r.NextDouble(), DataSourceEnum.DataEntry, null);
                dtLevel2.Rows.Add(drLevel1r4);

                Assert.IsTrue(myLocatorImplForTesting.SetValue(2, 2000, dtLevel2, DataSourceEnum.DataEntry, 2));
                DataTable dtLevel2a = myLocatorImplForTesting.GetGridDataTable(2, 2000, 2);
                Assert.AreEqual(1, dtLevel2a.Rows.Count);
			}
            [Test] public void TestGetFunctions()
            {
                int nRecID = 0;
                Assert.IsTrue(myLocatorImplForTesting.SaveGraphicObjectData(1, 1, ref nRecID, 0, 700, DataSourceEnum.DataEntry, true, 1, false));
                Assert.Greater(myLocatorImplForTesting.GetRecordIDForThisGraphicByDisplayOrder(1, 1, 0, 1), 0);
                Assert.AreEqual(0, myLocatorImplForTesting.GetRecordIDForThisGraphicByDisplayOrder(2, 1, 0, 1));
                Console.WriteLine("Previous test expected to cause error in log");

                myLocatorImplForTesting.GetRecordLineageForThisRecordID(1);

            }
            //[Test] public void TestBindingFunctions()
            //{
            //    Assert.AreEqual(true, myLocatorImplForTesting.DoesThisRunTimeGraphicBindToAList(2, 2000));
            //    Assert.AreEqual(false, myLocatorImplForTesting.DoesThisRunTimeGraphicBindToAList(1, 1));
            //    Assert.AreEqual(false, myLocatorImplForTesting.DoesThisRunTimeGraphicBindToAList(1, 0));
            //    Assert.AreEqual(false, myLocatorImplForTesting.DoesThisRunTimeGraphicBindToAList(3, 1));
            //    Assert.AreEqual(true, myLocatorImplForTesting.DoesThisRunTimeGraphicBindToAList(1, 1013));

            //    IDictionary<int, ValueList> lists = myLocatorImplForTesting.GetBindingLists(2, 2000);
            //    Assert.IsNotNull(lists);
            //    Assert.Greater(lists.Count, 0);

            //    IDictionary<int, ValueList> lists2 = myLocatorImplForTesting.GetBindingLists(1, 1013);
            //    Assert.IsNotNull(lists2);
            //    Assert.Greater(lists2.Count, 0);

            //}
            [Test] public void NodeConstraintResultTests()
            {
                bool result = myLocatorImplForTesting.GetNodeConstraintIsThisNodeIDEnabled(1);
                Assert.AreEqual(true, result);  //true is the defacto if it doesn't find any

                //add one and then get it
                LocatorNodeComputedValueEntity l = new LocatorNodeComputedValueEntity();
                l.Product_Year = myLocatorImplForTesting.Year;
                l.Locator_ID = myLocatorImplForTesting.LocatorID;
                l.Navigation_Node_ID = 2;
                l.Constraint_Result = false;
                l.Save();

                bool result2 = myLocatorImplForTesting.GetNodeConstraintIsThisNodeIDEnabled(2);
                Assert.AreEqual(false, result2);

            }
            [Test] public void ProcessNodeTests()
            { 
                //create some records, some runtimenodes, and call the processor
                RunTimeNode parentNode = new RunTimeNode();
                parentNode.ApplicationName = "Test";
                parentNode.HasChildren = true;
                parentNode.Name = "ParentNode";
                parentNode.NodeID = 7;
                parentNode.NodeType = NavigationNodeTypeEnum.TAHeaderNode;
                parentNode.RecordLineage = 0;

                SortedList<int, RunTimeNode> listOfchildren = new SortedList<int, RunTimeNode>();
                RunTimeNode childNode1 = new RunTimeNode();
                childNode1.ApplicationName = "Test";
                childNode1.HasChildren = false;
                childNode1.Name = "Child Node - Organizer";
                childNode1.NodeID = 8;
                childNode1.NodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                childNode1.RecordLineage = 0;
                listOfchildren.Add(1, childNode1);

                RunTimeNode childNode2 = new RunTimeNode();
                childNode2.ApplicationName = "Test";
                childNode2.HasChildren = false;
                childNode2.Name = "Child Node - Organizer2";
                childNode2.NodeID = 9;
                childNode2.NodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                listOfchildren.Add(2, childNode2);

                RunTimeNode childNode3 = new RunTimeNode();
                childNode3.ApplicationName = "Test";
                childNode3.HasChildren = true;
                childNode3.Name = "Child Node - Header";
                childNode3.NodeID = 10;
                childNode3.NodeType = NavigationNodeTypeEnum.TAHeaderNode;
                listOfchildren.Add(3, childNode3);

                SortedList<int, RunTimeNode> returnedNodes = myLocatorImplForTesting.ProcessRunTimeNodeCollection(parentNode, listOfchildren);
                Assert.AreEqual(3, returnedNodes.Count);

                childNode3.LoopRuntimeGraphicID = 1101;
                childNode3.LoopRuntimePageID = 1;

                STRING s = new string[4] { "A", "B", "C", "D" };
                myLocatorImplForTesting.SetBasetypeValue(1, 1101, s, DataSourceEnum.DataEntry, 0);
                returnedNodes = myLocatorImplForTesting.ProcessRunTimeNodeCollection(parentNode, listOfchildren);
                Assert.AreEqual(6, returnedNodes.Count);
                int count = 0;
                RunTimeNode childParentNode =  null;
                foreach (KeyValuePair<int, RunTimeNode> keypair in returnedNodes)
                {
                    if (keypair.Value.LoopRecordID > 0)
                    {
                        count++;
                        childParentNode = keypair.Value;
                    }
                }
                Assert.AreEqual(4, count);
                int loopingrecordID = childParentNode.LoopRecordID;

                //we need to add values using this recordID as recordLineage
                //going to use the grid graphic 2,2000
                STRING s2 = new string[6] {"GG","hh","fs","ddw","care","fdsa" };
                myLocatorImplForTesting.SetBasetypeValue(2, 2002, s2, DataSourceEnum.DataEntry, loopingrecordID);


                SortedList<int, RunTimeNode> childsRTNs = new SortedList<int, RunTimeNode>();

                RunTimeNode childchildNode1 = new RunTimeNode();
                childchildNode1.ApplicationName = "Test";
                childchildNode1.HasChildren = false;
                childchildNode1.Name = "Child Node - Organizer";
                childchildNode1.NodeID = 14;
                childchildNode1.NodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                childsRTNs.Add(1, childchildNode1);

                RunTimeNode childchildNode2 = new RunTimeNode();
                childchildNode2.ApplicationName = "Test";
                childchildNode2.HasChildren = false;
                childchildNode2.Name = "Child Node - Organizer2";
                childchildNode2.NodeID = 15;
                childchildNode2.PageID = 2;       //this node is pointing at Page 2- which has a grid.
                childchildNode2.NodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                childsRTNs.Add(2, childchildNode2);

                RunTimeNode childchildNode3 = new RunTimeNode();
                childchildNode3.ApplicationName = "Test";
                childchildNode3.HasChildren = true;
                childchildNode3.Name = "Child Node - Header";
                childchildNode3.NodeID = 16;
                childchildNode3.LoopRuntimePageID = 2;
                childchildNode3.LoopRuntimeGraphicID = 2002;
                childchildNode3.NodeType = NavigationNodeTypeEnum.TAHeaderNode;
                childsRTNs.Add(3, childchildNode3);


                //now ask for one of the looping nodes' nodes - we are getting the last one.
                SortedList<int, RunTimeNode> childChildNodes = myLocatorImplForTesting.ProcessRunTimeNodeCollection(childParentNode, childsRTNs);
                //there should be 8 nodes - 6 loopers and 2 normal
                Assert.AreEqual(8, childChildNodes.Count);
                int secondLevelLoopRecordID = 0;
                RunTimeNode childchildParent = null;
                foreach (KeyValuePair<int, RunTimeNode> keypairs in childChildNodes)
                {
                    Assert.AreEqual(loopingrecordID, keypairs.Value.RecordLineage);
                    if (keypairs.Value.NodeType == NavigationNodeTypeEnum.TAHeaderNode)
                    {
                        Assert.Greater(keypairs.Value.LoopRecordID, 0);
                    }
                    secondLevelLoopRecordID = keypairs.Value.LoopRecordID;
                    childchildParent = keypairs.Value;
                }

                //adding another level

                STRING s3 = new string[1] { "second level" };
                myLocatorImplForTesting.SetBasetypeValue(3, 3000, s3, DataSourceEnum.DataEntry, secondLevelLoopRecordID);


                SortedList<int, RunTimeNode> child3RTNs = new SortedList<int, RunTimeNode>();

                RunTimeNode childchildchildNode1 = new RunTimeNode();
                childchildchildNode1.ApplicationName = "Test";
                childchildchildNode1.HasChildren = false;
                childchildchildNode1.Name = "Child Node - Organizer";
                childchildchildNode1.NodeID = 14;
                childchildchildNode1.NodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                child3RTNs.Add(1, childchildchildNode1);

                SortedList<int, RunTimeNode> child3Nodes = myLocatorImplForTesting.ProcessRunTimeNodeCollection(childchildParent, child3RTNs);
                Assert.AreEqual(1, child3Nodes.Count);
                foreach (KeyValuePair<int, RunTimeNode> keypair in child3Nodes)
                {
                    Assert.AreEqual(secondLevelLoopRecordID, keypair.Value.RecordLineage);
                }

            }
            [Test] public void ProcessNodeTests2()
            {
                //create some records, some runtimenodes, and call the processor
                RunTimeNode parentNode = new RunTimeNode();
                parentNode.ApplicationName = "Test";
                parentNode.HasChildren = true;
                parentNode.Name = "ParentNode";
                parentNode.NodeID = 7;
                parentNode.NodeType = NavigationNodeTypeEnum.TAHeaderNode;
                parentNode.RecordLineage = 0;

                SortedList<int, RunTimeNode> listOfchildren = new SortedList<int, RunTimeNode>();
                RunTimeNode childNode1 = new RunTimeNode();
                childNode1.ApplicationName = "Test";
                childNode1.HasChildren = false;
                childNode1.Name = "Child Node - Organizer - looper";
                childNode1.NodeID = 8;
                childNode1.NodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                childNode1.RecordLineage = 0;
                childNode1.LoopRuntimeGraphicID = 1101;
                childNode1.LoopRuntimePageID = 1;
                listOfchildren.Add(1, childNode1);

                SortedList<int, RunTimeNode> returnedNodes = myLocatorImplForTesting.ProcessRunTimeNodeCollection(parentNode, listOfchildren);
                Assert.AreEqual(1, returnedNodes.Count);  //there should be a disabled one
                Assert.AreEqual(false, returnedNodes[0].Enabled);
                
                STRING s = new string[4] { "A", "B", "C", "D" };
                myLocatorImplForTesting.SetBasetypeValue(1, 1101, s, DataSourceEnum.DataEntry, 0);

                returnedNodes = myLocatorImplForTesting.ProcessRunTimeNodeCollection(parentNode, listOfchildren);
                Assert.AreEqual(4, returnedNodes.Count);
                int count = 0;
                RunTimeNode childParentNode = null;
                foreach (KeyValuePair<int, RunTimeNode> keypair in returnedNodes)
                {
                    if (keypair.Value.LoopRecordID > 0)
                    {
                        count++;
                        childParentNode = keypair.Value;
                    }
                }
                Assert.AreEqual(4, count);
                int loopingrecordID = childParentNode.LoopRecordID;

                //we need to add values using this recordID as recordLineage
                //going to use the grid graphic 2,2000
                STRING s2 = new string[6] { "GG", "hh", "fs", "ddw", "care", "fdsa" };
                myLocatorImplForTesting.SetBasetypeValue(2, 2002, s2, DataSourceEnum.DataEntry, loopingrecordID);
            }
			
		}
	}

}
