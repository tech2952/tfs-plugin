using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Runtime.Serialization;

namespace TaxApp.InterfacesAndConstants
{
    [DataContract]
    public class ClientIDAndNameWithLocatorDictionary
    {
        private string myClientName;
        private int myClientID;
        private List<LocatorInfo> myLocators;

        public ClientIDAndNameWithLocatorDictionary(int ID, string Name)
        {
            myClientName = Name;
            myClientID = ID;
            myLocators = new List<LocatorInfo>();
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
        public List<LocatorInfo> Locators
        {
            get { return myLocators; }
            set { myLocators = value; }
        }
        
    }
    namespace Tests
    {
        [TestFixture]
        public class ClientIDAndNameWithLocatorDictionaryTests
        {
            [Test]
            public void ObjectCD()
            {
                ClientIDAndNameWithLocatorDictionary o = new ClientIDAndNameWithLocatorDictionary(1, "Test");
                Assert.AreEqual(1, o.ClientID);
                Assert.AreEqual("Test", o.ClientName);
                Assert.IsNotNull(o.Locators);
                o.ClientID = 2;
                Assert.AreEqual(2, o.ClientID);
                o.ClientName = "Test2";
                Assert.AreEqual("Test2", o.ClientName);
                LocatorInfo li = new LocatorInfo(10, "TL", 2007);
                o.Locators.Add(li);
                Assert.AreEqual(1, o.Locators.Count);
                List<LocatorInfo> lis = new List<LocatorInfo>();
                lis.Add(li);
                o.Locators = lis;
                Assert.AreEqual(1, o.Locators.Count);
            }
        }
    }
}
