using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace TaxAppClient.WCFService
{
    [DataContract]
    public class CliInfo
    {
        private string myClientName;
        private int myClientID;
        private List<LocInfo> myLocators;

        public CliInfo(int ID, string Name)
        {
            myClientName = Name;
            myClientID = ID;
            myLocators = new List<LocInfo>();
        }

        [DataMember]
        public string ClientName
        {
            get { return myClientName; }
            set { myClientName = value; }
        }

        [DataMember]
        public int ClientID
        {
            get { return myClientID; }
            set { myClientID = value; }
        }

        [DataMember]
        public List<LocInfo> Locators
        {
            get { return myLocators; }
            set { myLocators = value; }
        }


    }
    [DataContract]
    public class LocInfo
    {
        private int myLocatorID;
        private short myYear;
        private string myName;

        public LocInfo() { }
        public LocInfo(int ID, string Name, short Year)
        {
            myLocatorID = ID;
            myYear = Year;
            myName = Name;
        }
        [DataMember]
        public int LocatorID
        {
            get { return myLocatorID; }
            set { myLocatorID = value; }
        }
        [DataMember]
        public short Year
        {
            get { return myYear; }
            set { myYear = value; }
        }
        [DataMember]
        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }
    }
    [DataContract]
    public class LORecord
    {
        public LORecord()
        {
            myValues = new List<LOValue>();
        }
        private int myRecordID;
        private short myProductYear;
        private int myLocatorID;
        private int myPageID;
        private int myGraphicObjectID;
        private byte myDataType;
        private short myRowDisplayOrder;
        private int myRecordLineage;
        private byte myDataSourceUsed;
        private int myParentGraphicID;
        private bool myRecordWasDeleted;
        private bool myRecordWasAdded;

        public bool myIsComputedField;
        private List<LOValue> myValues;

        [DataMember]public int RecordID
        {
            get { return myRecordID; }
            set { myRecordID = value; }
        }
        [DataMember]public short ProductYear
        {
            get { return myProductYear; }
            set { myProductYear = value; }
        }
        [DataMember]public int LocatorID
        {
            get { return myLocatorID; }
            set { myLocatorID = value; }
        }
        [DataMember]public int PageID
        {
            get { return myPageID; }
            set { myPageID = value; }
        }
        [DataMember]public int GraphicObjectID
        {
            get { return myGraphicObjectID; }
            set { myGraphicObjectID = value; }
        }
        [DataMember]public byte DataType
        {
            get { return myDataType; }
            set { myDataType = value; }
        }
        [DataMember]public short RowDisplayOrder
        {
            get { return myRowDisplayOrder; }
            set { myRowDisplayOrder = value; }
        }
        [DataMember]public int RecordLineage
        {
            get { return myRecordLineage; }
            set { myRecordLineage = value; }
        }
        [DataMember]public byte DataSourceUsed
        {
            get { return myDataSourceUsed; }
            set { myDataSourceUsed = value; }
        }
        [DataMember]public bool IsComputedField
        {
            get { return myIsComputedField; }
            set { myIsComputedField = value; }
        }
        [DataMember]public int ParentGraphicID
        {
            get { return myParentGraphicID; }
            set { myParentGraphicID = value; }
        }
        [DataMember]public bool RecordWasDeleted
        {
            get { return myRecordWasDeleted; }
            set { myRecordWasDeleted = value; }
        }
        [DataMember]public bool RecordWasAdded
        {
            get { return myRecordWasAdded; }
            set { myRecordWasAdded = value; }
        }
        [DataMember]public List<LOValue> Values
        {
            get { return myValues; }
            set { myValues = value; }
        }
        
        public LocatorObjectRecordKey NonRecordIDKey
        {
            get
            {
                LocatorObjectRecordKey Key = new LocatorObjectRecordKey(this);
                return Key;
            }
        }
	
    }
    [DataContract]
    public class LOValue
    {
        private byte myDataSource;
        private bool myBooleanValue;
        private string myStringValue;
        private decimal myNumericValue;
        private DateTime myDateLastSaved;
        private DateTime myDateTimeValue;
        private decimal myFractionValue;
        public LOValue()
        {

        }
        [DataMember]public byte DataSource
        {
            get { return myDataSource; }
            set { myDataSource = value; }
        }
        [DataMember]public bool BooleanValue
        {
            get { return myBooleanValue; }
            set { myBooleanValue = value; }
        }
        [DataMember]public string StringValue
        {
            get { return myStringValue; }
            set { myStringValue = value; }
        }
        [DataMember]public decimal NumericValue
        {
            get { return myNumericValue; }
            set { myNumericValue = value; }
        }
        [DataMember]public DateTime DateTimeValue
        {
            get { return myDateTimeValue; }
            set { myDateTimeValue = value; }
        }
        [DataMember]public decimal FractionValue
        {
            get { return myFractionValue; }
            set { myFractionValue = value; }
        }
        [DataMember]public DateTime DateLastSaved
        {
            get { return myDateLastSaved; }
            set { myDateLastSaved = value; }
        }

    }
    namespace Tests
    {
        [TestFixture]public class CliInfoTests
        { 
            [Test] public void ObjectCD()
            {
                CliInfo o = new CliInfo(1, "NUNITTest");
                Assert.AreEqual(1, o.ClientID);
                Assert.AreEqual("NUNITTest", o.ClientName);
                Assert.IsNotNull(o.Locators);

                o.ClientID = 4;
                Assert.AreEqual(4, o.ClientID);

                o.ClientName = "NUNITestChange";
                Assert.AreEqual("NUNITestChange", o.ClientName);

                LocInfo loc = new LocInfo();
                o.Locators.Add(loc);
                Assert.AreEqual(1, o.Locators.Count);

                List<LocInfo> locs = new List<LocInfo>();
                locs.Add(new LocInfo(1, "1", 2008));
                locs.Add(new LocInfo(2, "2", 2008));
                o.Locators = locs;
                Assert.AreEqual(2, o.Locators.Count);
                Assert.AreEqual(1, o.Locators[0].LocatorID);
            }
        }
        [TestFixture]public class LocInfoTests
        {
            [Test]
            public void ObjectCD()
            {
                LocInfo o = new LocInfo();
                Assert.IsNotNull(o);
                o.LocatorID = 66;
                Assert.AreEqual(66, o.LocatorID);
                o.Name = "Test1";
                Assert.AreEqual("Test1", o.Name);
                o.Year = 2007;
                Assert.AreEqual(2007, o.Year);

                LocInfo o2 = new LocInfo(1, "LocInfo", 2008);
                Assert.IsNotNull(o2);
                Assert.AreEqual(1, o2.LocatorID);
                Assert.AreEqual("LocInfo", o2.Name);
                Assert.AreEqual(2008, o2.Year);

                
            }
        }
        [TestFixture]public class LORecordTests
        {
            [Test]public void ObjectCD()
            {
                LORecord o = new LORecord();
                Assert.IsNotNull(o);
                o.RecordID = 2;
                o.ProductYear = 2008;
                o.LocatorID = 27;
                o.PageID = 5;
                o.GraphicObjectID = 6;
                o.DataType = 1;
                o.RowDisplayOrder = 8;
                o.RecordLineage = 9;
                o.DataSourceUsed = 2;
                Assert.AreEqual(2, o.RecordID);
                Assert.AreEqual(2008, o.ProductYear);
                Assert.AreEqual(27, o.LocatorID);
                Assert.AreEqual(5, o.PageID);
                Assert.AreEqual(6, o.GraphicObjectID);
                Assert.AreEqual(1, o.DataType);
                Assert.AreEqual(8, o.RowDisplayOrder);
                Assert.AreEqual(9, o.RecordLineage);
                Assert.AreEqual(2, o.DataSourceUsed);

                Assert.IsNotNull(o.Values);
                LocatorObjectRecordKey lorKey = o.NonRecordIDKey;
                Assert.IsNotNull(lorKey);

                Assert.AreEqual(6, lorKey.GraphicID);
                Assert.AreEqual(9, lorKey.RecordLineage);
                Assert.AreEqual(27, lorKey.LocatorID);
                Assert.AreEqual(2008, lorKey.Year);
                Assert.AreEqual(5, lorKey.PageID);

            }
        }
        [TestFixture]public class LOValueTests
        {
            [Test]public void ObjectCD()
            {
                LOValue o = new LOValue();
                Assert.IsNotNull(o);
                o.DataSource = 1;
                o.BooleanValue = true;
                o.StringValue = "test";
                o.NumericValue = 33;
                o.DateTimeValue = new DateTime(2008, 5, 29);
                o.FractionValue = 3.45M;
                o.DateLastSaved = new DateTime(2008, 2, 2);

                Assert.AreEqual(1, o.DataSource);
                Assert.AreEqual(true, o.BooleanValue);
                Assert.AreEqual("test", o.StringValue);
                Assert.AreEqual(33, o.NumericValue);
                Assert.AreEqual(new DateTime(2008, 5, 29), o.DateTimeValue);
                Assert.AreEqual(3.45M, o.FractionValue);
                Assert.AreEqual(new DateTime(2008, 2, 2), o.DateLastSaved);



            }
        }
    }
}
