using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Runtime.Serialization;

namespace TaxApp.InterfacesAndConstants
{
    public class LocatorInfo
    {
        private int myLocatorID;
        private short myYear;
        private string myName;

        public LocatorInfo(){}
        public LocatorInfo(int ID, string Name, short Year)
        {
            myLocatorID = ID;
            myYear = Year;
            myName = Name;
        }
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
        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }
    }
    

    namespace Tests
    {
        [TestFixture]
        public class LocatorInfoTests
        {
            [Test]
            public void ObjectCD()
            {
                LocatorInfo li = new LocatorInfo(1, "Test", 2007);
                Assert.AreEqual(1, li.LocatorID);
                Assert.AreEqual("Test", li.Name);
                Assert.AreEqual(2007, li.Year);
                li.LocatorID = 2;
                Assert.AreEqual(2, li.LocatorID);
                li.Name = "Test2";
                Assert.AreEqual("Test2", li.Name);
                li.Year = 2008;
                Assert.AreEqual(2008, li.Year);
                
            }
        }
    }
}
