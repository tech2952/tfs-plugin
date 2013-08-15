using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TaxBuilder.GraphicObjects;
using TaxApp.IntrinsicFunctions;
using NUnit.Framework;
using TaxBuilder.GraphicObjects.TaxAppRuntime;

namespace TaxApp.InterfacesAndConstants
{
    public class RecordValue
    {
        private int myRecordLineage;
        private IBaseType myValue;
        private Type myBaseTypeType;
        private DataSourceEnum myDataSource;
        private Dictionary<int, double> myRowToRecordIDLookup;



        public int RecordLineage { get { return myRecordLineage; } set { myRecordLineage = value; } }
        public IBaseType value { get { return myValue; } set { myValue = value; } }
        public Type basetypeType { get { return myBaseTypeType; } set { myBaseTypeType = value; } }
        public DataSourceEnum DataSource { get { return myDataSource; } set { myDataSource = value; } }
        public Dictionary<int, double> RowToRecordIDLoopup { get { return myRowToRecordIDLookup; } }
        
        public RecordValue(int RecordLineage, IBaseType value, Type type, DataSourceEnum datasource)
        {
            this.RecordLineage = RecordLineage;
            this.value = value;
            this.basetypeType = type;
            this.DataSource = datasource;
            Random r = new Random(RecordLineage);  //just using the RL as a seed
            //when a new one is created, for each row in the basetype, create a unique "recordID" for it
            myRowToRecordIDLookup = new Dictionary<int, double>();
            for (int i = 1; i <= value.Rows; i++)
            {
                myRowToRecordIDLookup.Add(i, r.NextDouble());
            }
        }
    }
    public class TILocatorDatabase : ITaxAppData
    {
        #region IInterfaceWithALocatorDatabase Members
        private string myLocatorName;
        private int myLocatorID;
        private short myYear;
        private Dictionary<int, bool> myConstraintResults;
        private Dictionary<int, Dictionary<int, List<RecordValue>>> myValues;
        private DatabaseAndBinaryPathSettings myDatabaseAndBinaryPathSettings;
        public event PageUpdatedEventHandler PageUpdatedEvent;

        //the locator database will load up its own GraphicInfo Matrix - the TaxApp interface will be only used for display
        private Dictionary<KeyValuePair<int, int>, GraphicInfoItem> myGraphicMatrix;
        //exposed for testing purposes
        public Dictionary<KeyValuePair<int, int>, GraphicInfoItem> GraphicMatrix { get { return myGraphicMatrix; } }

        public void Initialize(string LocatorName, int LocatorID, short Year, UserConfigurationItems configItems)
        {
            myLocatorID = LocatorID;
            myYear = Year;
            myLocatorName = LocatorName;
            myDatabaseAndBinaryPathSettings = configItems.DatabaseAndBinaryPathSettings;

            myConstraintResults = new Dictionary<int, bool>();
            myConstraintResults.Add(1, true);
            //PageID: 1, GraphicID: 1001, Value: 50, RLineage: 0, Basetype: MONEY
            List<RecordValue> valuesForAGraphic = new List<RecordValue>();
            MONEY m = 50;
            RecordValue x = new RecordValue(0, m, typeof(MONEY), DataSourceEnum.DataEntry);
            valuesForAGraphic.Add(x);
            Dictionary<int, List<RecordValue>> val1 = new Dictionary<int, List<RecordValue>>();
            val1.Add(1001, valuesForAGraphic);               
            myValues = new Dictionary<int, Dictionary<int, List<RecordValue>>>();
            myValues.Add(1, val1);

            //adding another to this page
            //PageID: 1, GraphicID: 1002, Value: 100, RLineage: 0, Basetype: MONEY
            List<RecordValue> valuesForAGraphic2 = new List<RecordValue>();
            MONEY m2 = 100;
            RecordValue x2 = new RecordValue(0, m2, typeof(MONEY), DataSourceEnum.DataEntry);
            valuesForAGraphic2.Add(x2);
            val1.Add(1002, valuesForAGraphic2);
            InitGraphicMatrix();

        }
        private void InitGraphicMatrix()
        {
            myGraphicMatrix = new Dictionary<KeyValuePair<int, int>, GraphicInfoItem>();
            for (int i = 0; i < 1000; i++)
            {
                GraphicInfoItem gii = new GraphicInfoItem(i, i, i.ToString(), Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0);
                myGraphicMatrix.Add(new KeyValuePair<int, int>(i, i), gii);
            }

            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1000), new GraphicInfoItem(1, 1000, "TestGraphic For DataEntryDrivenCompute0", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1001), new GraphicInfoItem(1, 1001, "TestGraphic For DataEntryDrivenCompute1", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1002), new GraphicInfoItem(1, 1002, "TestGraphic For DataEntryDrivenCompute2", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1003), new GraphicInfoItem(1, 1003, "TestGraphic For DataEntryDrivenCompute3", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1004), new GraphicInfoItem(1, 1004, "TestGraphic For DataEntryDrivenCompute4", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1005), new GraphicInfoItem(1, 1005, "TestGraphic For DataEntryDrivenCompute5", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1006), new GraphicInfoItem(1, 1006, "TestGraphic For DataEntryDrivenCompute6", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1007), new GraphicInfoItem(1, 1007, "TestGraphic For DataEntryDrivenCompute7", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1008), new GraphicInfoItem(1, 1008, "TestGraphic For DataEntryDrivenCompute8", Convert.ToByte(EnumKeyDataType.DateTime), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1009), new GraphicInfoItem(1, 1009, "TestGraphic For DataEntryDrivenCompute9", Convert.ToByte(EnumKeyDataType.DateTime), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1010), new GraphicInfoItem(1, 1010, "TestGraphic For DataEntryDrivenCompute10", Convert.ToByte(EnumKeyDataType.String), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1011), new GraphicInfoItem(1, 1011, "TestGraphic For DataEntryDrivenCompute11", Convert.ToByte(EnumKeyDataType.String), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1012), new GraphicInfoItem(1, 1012, "TestGraphic For DataEntryDrivenCompute12", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1013), new GraphicInfoItem(1, 1013, "TestDropDown", Convert.ToByte(EnumKeyDataType.String), false, "blue", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1100), new GraphicInfoItem(1, 1100, "TestBOOL", Convert.ToByte(EnumKeyDataType.Boolean), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1101), new GraphicInfoItem(1, 1101, "TestSTRING", Convert.ToByte(EnumKeyDataType.String), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1102), new GraphicInfoItem(1, 1102, "TestDATE", Convert.ToByte(EnumKeyDataType.DateTime), false, "04/15/2008", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1103), new GraphicInfoItem(1, 1103, "TestINTEGER", Convert.ToByte(EnumKeyDataType.Integer), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1104), new GraphicInfoItem(1, 1104, "TestMONEY", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 0));
            myGraphicMatrix.Add(new KeyValuePair<int, int>(1, 1105), new GraphicInfoItem(1, 1105, "TestRATIO", Convert.ToByte(EnumKeyDataType.Ratio), false, ".45", false, 0, 0, 0));

            GraphicInfoItem g1 = new GraphicInfoItem(2, 2000, "GridGraphic", Convert.ToByte(EnumKeyDataType.DataTable), false, "0", false, 0, 0, 0);
            GraphicInfoItem g2 = new GraphicInfoItem(2, 2001, "GridGraphicCol1", Convert.ToByte(EnumKeyDataType.Boolean), false, "true", false, 0, 0, 1);
            GraphicInfoItem g3 = new GraphicInfoItem(2, 2002, "GridGraphicCol2", Convert.ToByte(EnumKeyDataType.String), false, "0", false, 0, 0, 2);
            GraphicInfoItem g4 = new GraphicInfoItem(2, 2003, "GridGraphicCol3", Convert.ToByte(EnumKeyDataType.Money), false, "0", false, 0, 0, 3);
            g1.Columns.Add(g2);
            g1.Columns.Add(g3);
            g1.Columns.Add(g4);
            myGraphicMatrix.Add(new KeyValuePair<int, int>(2, 2000), g1);
            //add columns to overall dictionary also - for individual lookup
            myGraphicMatrix.Add(new KeyValuePair<int, int>(2, 2001), g2);
            myGraphicMatrix.Add(new KeyValuePair<int, int>(2, 2002), g3);
            myGraphicMatrix.Add(new KeyValuePair<int, int>(2, 2003), g4);

            myGraphicMatrix.Add(new KeyValuePair<int, int>(3, 3000), new GraphicInfoItem(3, 3000, "AnotherBASETypeTestingString", Convert.ToByte(EnumKeyDataType.String), false, "", false, 0, 0, 0));

        }

        public GraphicInfoItem GetGraphicInfoItem(int PageID, int RunTimeGraphicID)
        {
            KeyValuePair<int, int> key = new KeyValuePair<int, int>(PageID, RunTimeGraphicID);
            if (myGraphicMatrix.ContainsKey(key))
                return myGraphicMatrix[key];
            else
                return null;
        }
        public IDictionary<KeyValuePair<int, int>, GraphicInfoItem> GetGraphicInfoItems(ICollection<KeyValuePair<int, int>> pageIDgraphicIDs)
        {
            Dictionary<KeyValuePair<int, int>, GraphicInfoItem> list = new Dictionary<KeyValuePair<int, int>, GraphicInfoItem>();
            foreach (KeyValuePair<int, int> key in pageIDgraphicIDs)
            {
                list.Add(key, GetGraphicInfoItem(key.Key, key.Value));
            }
            return list;
        }

        public SortedList<int, RunTimeNode> ProcessRunTimeNodeCollection(RunTimeNode parentNode, SortedList<int, RunTimeNode> rtns)
        {
            return rtns;
        }

        public int LocatorID { get { return myLocatorID; } }
        public short Year { get { return myYear; } }
        public string LocatorName { get { return myLocatorName; } }

        //public bool DoesThisRunTimeGraphicBindToAList(int PageID, int RuntimeGraphicID)
        //{
        //    GraphicInfoItem gii = myTaxAppInfo.GetGraphicInfoItem(PageID, RuntimeGraphicID);
        //    if (gii.AttachedValueListID > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public IDictionary<int, ValueList> GetBindingLists(int PageID, int RuntimeGraphicID)
        //{
        //    GraphicInfoItem gii = myTaxAppInfo.GetGraphicInfoItem(PageID, RuntimeGraphicID);

        //    if (gii.AttachedValueListID > 0)
        //    {
        //        Dictionary<int, ValueList> returnval = new Dictionary<int, ValueList>();
        //        returnval.Add(gii.AttachedValueListID, myTaxAppInfo.GetValueListByID(gii.AttachedValueListID));
        //        return returnval;
        //    }
        //    else
        //        return null;
        //}

        public ValueWithDataSources GetSingleValue(int PageID, int GraphicID, int RecordLineage)
        {
            if (myValues.ContainsKey(PageID))
            {
                if (myValues[PageID].ContainsKey(GraphicID))
                {
                    foreach (RecordValue rv in myValues[PageID][GraphicID])
                    {
                        if (rv.RecordLineage == RecordLineage)
                        {
                            double d = (double)((MONEY)rv.value);
                            ValueWithDataSources vds = new ValueWithDataSources(d, rv.DataSource, null);
                            return vds;
                        }
                    }
                }
            }
            return null;
        }
        public DataTable GetGridDataTable(int PageID, int RuntimeGraphicID, int RecordLineage) 
        {
            DataTable dt = new DataTable("TestGrid");
            //TODO: implement this
            return dt;
        }

        public IBaseType GetValueAsBaseType(int PageID, int GraphicID, int RecordLineage)
        {
            GraphicInfoItem gii = GetGraphicInfoItem(PageID, GraphicID);
            if (gii == null) 
                return null;

            if (myValues.ContainsKey(PageID))
            {
                if (myValues[PageID].ContainsKey(GraphicID))
                {
                    foreach (RecordValue rv in myValues[PageID][GraphicID])
                    {
                        if (rv.RecordLineage == RecordLineage)
                        {
                            return rv.value;
                        }
                    }
                }

            }
            return null;
        }
        public bool GetNodeConstraintIsThisNodeIDEnabled(int NavigationNodeID)
        {
            if (myConstraintResults == null)
                myConstraintResults = new Dictionary<int, bool>();
            if (myConstraintResults.ContainsKey(NavigationNodeID))
            {
                return myConstraintResults[NavigationNodeID];
            }
            else
            {
                return true;
            }
        }
        public int GetRecordLineageForThisRecordID(int RecordID)
        {
            return 0;
        }
        public int GetRecordIDForThisGraphicByDisplayOrder(int PageID, int GraphicID, int RecordLineage, int DisplayOrder)
        {
            return 0;
        }
        //public int GetRecordIDForThisGraphicByMatchingRecordIDOfSibling(int RecordIDofSibling, int GraphicID)
        //{
        //    return 0;
        //}
        //public List<int> GetRecordIDsForGraphicKeyValuePair<int, int>(int GraphicID, int PageID)
        //{
        //    List<int> list = new List<int>();
        //    return list;
        //}
        public IDictionary<int, string> GetSetofRecordIDandValueForSameGraphicAndLineage(int RecordID)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            return list;
        }
        public void UpdateValue(int RecordID, object value, DataSourceEnum datasource)
        { 
            //would be for updating specific records
        }
        public void SetBasetypeValue(int PageID, int RuntimeGraphicID, IBaseType valuebt, DataSourceEnum dataSource, int RecordLineage)
        {
            Dictionary<int, List<RecordValue>> aPageOfValues = null;
            //init a value
            if (!myValues.ContainsKey(PageID))
            {
                aPageOfValues = new Dictionary<int, List<RecordValue>>();
                myValues.Add(PageID, aPageOfValues);
            }
            else
            {
                aPageOfValues = myValues[PageID];
            }

            RecordValue x = new RecordValue(RecordLineage, valuebt, valuebt.GetType(), dataSource);
            if (!aPageOfValues.ContainsKey(RuntimeGraphicID))
            {
                List<RecordValue> vals = new List<RecordValue>();
                vals.Add(x);
                aPageOfValues.Add(RuntimeGraphicID, vals);
            }
            else
            {
                foreach (RecordValue rv in aPageOfValues[RuntimeGraphicID])
                {
                    if (rv.RecordLineage == RecordLineage)
                    {
                        rv.value = valuebt;
                        return;
                    }
                }
                aPageOfValues[RuntimeGraphicID].Add(x);
            }

        }
        
        public void SetValueFromConstraint(int NavigationNodeID, bool value)
        {
            myConstraintResults[NavigationNodeID] = value;

        }

        public bool SetValue(int PageID, int RuntimeGraphicID, object valuePrimitive, DataSourceEnum dataSource, int RecordLineage)
        {
            //TODO: write a test and then fix this to get the GII and convert the primitive accordingly.
            MONEY m = Convert.ToDouble(valuePrimitive);
            RecordValue x = new RecordValue(RecordLineage, m, typeof(MONEY), dataSource);

            Dictionary<int, List<RecordValue>> aPageOfValues = null;
            if (myValues.ContainsKey(PageID))
            {
                aPageOfValues = myValues[PageID];
            }
            else
            {
                aPageOfValues = new Dictionary<int, List<RecordValue>>();
                myValues.Add(PageID, aPageOfValues);
            }

            List<RecordValue> vals = null;
            if (aPageOfValues.ContainsKey(RuntimeGraphicID))
            {
                vals = aPageOfValues[RuntimeGraphicID];
                foreach (RecordValue rv in vals)
                {
                    if (rv.RecordLineage == RecordLineage)
                    {
                        if ((MONEY)rv.value == m)
                            return false;
                        else
                        {
                            rv.value = m;
                            return true;
                        }

                    }
                }
                vals.Add(x);
                return true;
            }
            else
            {
                vals = new List<RecordValue>();
                aPageOfValues.Add(RuntimeGraphicID, vals);
                vals.Add(x);
                return true;
            }
        }
        public void PerformFullCompute()
        {
            //how to implement this?  The most straight forward way would be to "compute" by just adding the appropriate values directly.
            if (PageUpdatedEvent != null)
            {
                PageUpdatedEvent(this, new List<int>());
            }
        }
        public void SelectDataSource(bool bClearOverride, int PageID, int RuntimeGraphicID, DataSourceEnum dataSource, int RecordLineage, int RowInd)
        {
            //how to implement this?  should be real close to the real implementation and just does it to the values in memory.
        }

        #endregion
    }
    namespace Tests
    {
        [TestFixture]
        public class TILocatorDatabaseTests
        {
            [Test]
            public void ObjectCD()
            {
                TILocatorDatabase til = new TILocatorDatabase();
                UserConfigurationItems config = new UserConfigurationItems();
                til.Initialize("LocatorName", 1, 2005, config);
                Assert.IsNotNull(til);
                Assert.AreEqual("LocatorName", til.LocatorName);
                Assert.AreEqual(1, til.LocatorID);
                Assert.AreEqual(2005, til.Year);
                ITaxAppData til2 = new TILocatorDatabase();
                til2.Initialize("LocatorName", 1, 2005, config);
                Assert.IsNotNull(til2);
                //Assert.IsTrue(til2.DoesThisRunTimeGraphicBindToAList(1, 1013));
                //Assert.AreEqual(3, til2.GetBindingLists(1, 1013)[1].Items.Count);
                
                int i = Convert.ToInt32(til2.GetSingleValue(1, 1001, 0).Value);
                Assert.AreEqual(50, i);

                til2.SetValue(5, 50, 0, DataSourceEnum.DataEntry, 10);
                til2.SetValue(5, 50, 10, DataSourceEnum.DataEntry, 10);

                GraphicInfoItem gii = til.GetGraphicInfoItem(1, 1001);
                Assert.IsNotNull(gii);
                Assert.AreEqual("TestGraphic For DataEntryDrivenCompute1", gii.GraphicName);

                //test getting two at a time
                List<KeyValuePair<int, int>> keys = new List<KeyValuePair<int, int>>();
                keys.Add(new KeyValuePair<int, int>(10, 10));
                keys.Add(new KeyValuePair<int, int>(11, 11));
                IDictionary<KeyValuePair<int, int>, GraphicInfoItem> giis = til.GetGraphicInfoItems(keys);
                Assert.AreEqual(2, giis.Count);

                
            }
            [Test]
            public void TestBaseTypeValue()
            {
                TILocatorDatabase til = new TILocatorDatabase();
                UserConfigurationItems config = new UserConfigurationItems();
                DatabaseAndBinaryPathSettings db = new DatabaseAndBinaryPathSettings();
                til.Initialize("LocatorName", 1, 2005, config);
                STRING s = new string[2]{"X","Y"};
                til.SetBasetypeValue(1, 1, s, DataSourceEnum.DataEntry, 0);
                Assert.AreEqual(s, til.GetValueAsBaseType(1, 1, 0));
                Assert.IsNull(til.GetValueAsBaseType(292929, 292929, 0));
                Assert.IsNull(til.GetValueAsBaseType(1, 1, 1100));

            }
            [Test]
            public void GetGridTest()
            {
                TILocatorDatabase til = new TILocatorDatabase();
                DataTable dt = til.GetGridDataTable(1, 1, 1);
                Assert.IsNotNull(dt);
            }
            [Test]
            public void GetNodeConstraint()
            {
                TILocatorDatabase til = new TILocatorDatabase();
                Assert.IsTrue(til.GetNodeConstraintIsThisNodeIDEnabled(1121344));
                til.SetValueFromConstraint(2, true);
                Assert.IsTrue(til.GetNodeConstraintIsThisNodeIDEnabled(2));
            }
            [Test]
            public void ToBeImplemented()
            {
                TILocatorDatabase til = new TILocatorDatabase();
                Assert.AreEqual(0, til.GetRecordIDForThisGraphicByDisplayOrder(1, 1, 1, 1));
                Assert.AreEqual(0, til.GetRecordLineageForThisRecordID(1));
                Assert.IsNotNull(til.GetSetofRecordIDandValueForSameGraphicAndLineage(1));
                til.PerformFullCompute();
                Assert.IsNotNull( til.ProcessRunTimeNodeCollection(new RunTimeNode(), new SortedList<int, RunTimeNode>()));
                til.SelectDataSource(true, 1, 1, DataSourceEnum.Override, 0, 1);
                
            }
        }
    

    }
}
