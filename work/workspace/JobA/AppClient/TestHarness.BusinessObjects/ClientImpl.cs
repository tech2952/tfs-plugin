using System;
using System.Collections.Generic;
using NUnit.Framework;
using log4net;
using TestHarness.DataObjects;
using TestHarness.DataObjects.CollectionClasses;
using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.FactoryClasses;
using TaxApp.InterfacesAndConstants ;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Configuration;

namespace TestHarness.BusinessObjects
{
	/// <summary>
	/// A collection of static functions to manipulate Clients on a PATRICKHENRY database.
	/// </summary>
	public class ClientImpl : ITaxAppClientData
	{
        public ClientImpl() { }
        public void Initialize(UserConfigurationItems configItems)
        { 

        }
        private static readonly ILog theLogger = LogManager.GetLogger("ClientImpl");
        /// <summary>
        /// Return all clients in the database.  This will return an empty collection if there are none.
        /// </summary>
        /// <returns></returns>
        public List<ClientIDAndNameWithLocatorDictionary> GetAllClientNames()
        {
            List<ClientIDAndNameWithLocatorDictionary> names = new List<ClientIDAndNameWithLocatorDictionary>();
            
            ClientCollection cc = new ClientCollection();
            cc.GetMulti(null);
            foreach (ClientEntity ce in cc)
            {
                ClientIDAndNameWithLocatorDictionary cl = new ClientIDAndNameWithLocatorDictionary(ce.Client_ID, ce.Client_Name);
                foreach (LocatorEntity le in ce.LocatorCollectionViaClientLocator)
                {
                    LocatorInfo lny = new LocatorInfo(le.Locator_ID, le.Locator_Name, le.Product_Year);
                    cl.Locators.Add(lny);
                }
                names.Add(cl);
            }
            return names;
        }
        /// <summary>
        /// Adds / Gets a client by name and year.  Returns the clientID.
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetClientByNameAddIfNew(string clientName, short year)
        { 
            ClientCollection cc = new ClientCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(ClientFieldIndex.Client_Name, ComparisonOperator.Equal, clientName));
            cc.GetMulti(filter);
            if (cc.Count == 1)
            {
                return cc[0].Client_ID;
            }
            else if (cc.Count > 1)
            {
                theLogger.Warn("More than one client with that name - returning ID of first one");
                return cc[0].Client_ID;
            }
            else
            {
                ClientEntity ce = new ClientEntity();
                ce.Client_Name = clientName;
                ce.Product_Year = year;
                ce.Firm_Code = "FIRMCODE";
                ce.Account_Code = "ACCT";
                ce.Product_License = "LICENSE";
                ce.Save();
                return ce.Client_ID;
            }
        }
        /// <summary>
        /// Adds a new locator for the client ID.  Locator Names are specific for a year / client.
        /// If there are no locators for this client, it will also create a default locator.
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="locatorName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int AddNewLocatorToListForClient(int clientID, string locatorName, short year)
        {
            //check to see if it already exists
            LocatorCollection lc = new LocatorCollection();
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PredicateFactory.CompareValue(LocatorFieldIndex.Locator_Name, ComparisonOperator.Equal, locatorName));
            filter.AddWithAnd(PredicateFactory.CompareValue(LocatorFieldIndex.Product_Year, ComparisonOperator.Equal, year));
            lc.GetMulti(filter);
            if (lc.Count > 0)
            {
                return 0;
            }
            //check to see if there are any locators for this client
            ClientEntity ce = new ClientEntity(year, clientID);
            if (ce.LocatorCollectionViaClientLocator.Count == 0)
            {
                theLogger.Info("Default locator created for Client: " + ce.Client_Name);
                LocatorEntity leDefault = new LocatorEntity();
                leDefault.Product_Year = year;
                leDefault.Locator_Name = "Default for " + ce.Client_Name;
                leDefault.Save();
                ClientLocatorEntity cleDefault = new ClientLocatorEntity();
                cleDefault.Product_Year = year;
                cleDefault.Client_ID = clientID;
                cleDefault.Locator_ID = leDefault.Locator_ID;
                cleDefault.IsTaxDefault = false;
                cleDefault.Save();
            }

            LocatorEntity le = new LocatorEntity();
            le.Product_Year = year;
            le.Locator_Name = locatorName;
            bool result = le.Save();
            if (result)
                theLogger.Info("Locator created for Client: " + ce.Client_Name + " LocatorID: " + le.Locator_ID);


            ClientLocatorEntity cle = new ClientLocatorEntity();
            cle.Product_Year = year;
            cle.Client_ID = clientID;
            cle.Locator_ID = le.Locator_ID;
            cle.IsTaxDefault = false;
            cle.Save();

            return le.Locator_ID;
        }
        public void DeleteLocator(int locatorID, int productYear)
        {
            try
            {
                LocatorGridRowCollection rows = new LocatorGridRowCollection();
                IPredicateExpression filer = new PredicateExpression();
                filer.Add(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Product_Year, ComparisonOperator.Equal, productYear));
                filer.AddWithAnd(PredicateFactory.CompareValue(LocatorGridRowFieldIndex.Locator_ID, ComparisonOperator.Equal, locatorID));
                rows.DeleteMulti(filer);

                TempComputedResultsCollection tempComps = new TempComputedResultsCollection();
                filer = new PredicateExpression();
                filer.Add(PredicateFactory.CompareValue(TempComputedResultsFieldIndex.Product_Year, ComparisonOperator.Equal, productYear));
                filer.AddWithAnd(PredicateFactory.CompareValue(TempComputedResultsFieldIndex.Locator_ID, ComparisonOperator.Equal, locatorID));
                tempComps.DeleteMulti(filer);

                LocatorCollection locators = new LocatorCollection();
                filer = new PredicateExpression();
                filer.Add(PredicateFactory.CompareValue(LocatorFieldIndex.Product_Year, ComparisonOperator.Equal, productYear));
                filer.AddWithAnd(PredicateFactory.CompareValue(LocatorFieldIndex.Locator_ID, ComparisonOperator.Equal, locatorID));
                locators.GetMulti(filer);
                if (locators.Count < 1)
                    return;

                LocatorEntity locator = locators[0];
                locator.LocatorRollover.DeleteMulti();
                locator.LocatorNodeComputedValue.DeleteMulti();
                LocatorObjectRecordCollection records = locator.LocatorObjectRecord;
                foreach (LocatorObjectRecordEntity record in records)
                    record.LocatorObjectValue.DeleteMulti();
                records.DeleteMulti();

                ClientLocatorCollection clientLocators = new ClientLocatorCollection();
                filer = new PredicateExpression();
                filer.Add(PredicateFactory.CompareValue(ClientLocatorFieldIndex.Product_Year, ComparisonOperator.Equal, productYear));
                filer.AddWithAnd(PredicateFactory.CompareValue(ClientLocatorFieldIndex.Locator_ID, ComparisonOperator.Equal, locatorID));
                clientLocators.DeleteMulti(filer);

                locator.Delete();
                theLogger.Info(string.Format("Deleted Locator with ProductYear {0}, LocatorID {1}", productYear, locatorID));
            }
            catch (Exception ex)
            {
                theLogger.Error(string.Format("Error in deleting Locator with ProductYear {0}, LocatorID {1}", productYear, locatorID, ex));
            }
        }
	}
	namespace Tests
	{
		[TestFixture] public class ClientImplTests
		{
			[Test] public void ObjectCD()
			{
                ClientImpl myClientImpl = new ClientImpl();
                //ClientIDAndNameWithLocatorDictionary
                ClientIDAndNameWithLocatorDictionary c = new ClientIDAndNameWithLocatorDictionary(1, "test");
                Assert.AreEqual(1, c.ClientID);
                Assert.AreEqual("test", c.ClientName);
                Assert.IsNotNull(c.Locators);

                c.ClientID = 2;
                c.ClientName = "test2";
                Assert.AreEqual(2, c.ClientID);
                Assert.AreEqual("test2", c.ClientName);

                LocatorInfo lny = new LocatorInfo(10, "L", 1910);
                Assert.AreEqual(10, lny.LocatorID);
                Assert.AreEqual("L", lny.Name);
                Assert.AreEqual(1910, lny.Year);
                lny.LocatorID = 11;
                lny.Name = "LD";
                lny.Year = 1911;
                Assert.AreEqual(11, lny.LocatorID);
                Assert.AreEqual("LD", lny.Name);
                Assert.AreEqual(1911, lny.Year);

                c.Locators.Add(lny);
                Assert.AreEqual(1, c.Locators.Count);

				DatabaseInitializer.ClearDatabaseCompletely();
                DatabaseInitializer.CheckEnterpriseTableAndEnums();

                List<ClientIDAndNameWithLocatorDictionary> names = myClientImpl.GetAllClientNames();
                Assert.IsNotNull(names);
                Assert.AreEqual(0, names.Count);

                UserConfigurationItems con = new UserConfigurationItems();
                int clientid = myClientImpl.GetClientByNameAddIfNew(con.ClientName, con.Year);
                Assert.IsTrue(clientid > 0, "Client ID should be greater than zero on a myClientImpl.GetClientByNameAddIfNew call");

                names = myClientImpl.GetAllClientNames();
                Assert.AreEqual(1, names.Count);
                Assert.AreEqual(0, names[0].Locators.Count);

                int locID = myClientImpl.AddNewLocatorToListForClient(clientid, "X", con.Year);
                Assert.IsTrue(locID > 0, "Locator ID should be greater than zero on a myClientImpl.AddNewLocatorToListForClient call");
                names = myClientImpl.GetAllClientNames();
                Assert.AreEqual(1, names.Count);
                Assert.AreEqual(2, names[0].Locators.Count);

                //now try to add one that is already there
                int locID2 = myClientImpl.AddNewLocatorToListForClient(clientid, "X", con.Year);
                Assert.AreEqual(0, locID2);

                //now try to get the client - to test the get when alrady there
                int clientid2 = myClientImpl.GetClientByNameAddIfNew(con.ClientName, con.Year);
                Assert.AreEqual(clientid, clientid2);

                //the last test will be to add another client of the same name
                ClientEntity ce = new ClientEntity();
                ce.Client_Name = con.ClientName;
                ce.Product_Year = con.Year;
                ce.Firm_Code = "FIRMCODE";
                ce.Account_Code = "ACCT";
                ce.Product_License = "LICENSE";
                ce.Save();

                //still should get the first one.
                int clientid3 = myClientImpl.GetClientByNameAddIfNew(con.ClientName, con.Year);
                Assert.AreEqual(clientid, clientid3);

                //delete locator
                myClientImpl.DeleteLocator(locID, con.Year);
                names = myClientImpl.GetAllClientNames();
                Assert.AreEqual(1, names[0].Locators.Count);
            }
		}
	}
}
