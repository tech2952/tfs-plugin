using System;
using System.Collections.Generic;
using System.Text;
using TaxApp.InterfacesAndConstants;
using TaxAppClient.WCFService;
using log4net;
using NUnit.Framework;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace TaxAppClient.BusinessObjects
{
    public class TaxAppClientData : ITaxAppClientData
    {
        private static readonly ILog theLogger = LogManager.GetLogger("TaxAppClientData");
        private UserConfigurationItems myUserConfig = null;

        #region ITaxAppClientData Members
        public void Initialize(UserConfigurationItems configItems)
        {
            myUserConfig = configItems;
            //send a bing to the WCFService to make sure it is ready...
            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            try
            {
                string parms = string.Empty;
                int returnInt = myTACWCFService.RunMethodByMessageTypeReturnInt("Initialize", parms);
                if (returnInt == 1)
                {
                    theLogger.Debug("Database Initialized.");
                }
                else
                {
                    theLogger.Error("Database failed to initialize - check logs");
                }
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error communicating with WCFService during Initialize call.");
                theLogger.Error("Error: ", ex);
            }
            finally
            {
                myTACWCFService.Close();
            }

        }

        public List<ClientIDAndNameWithLocatorDictionary> GetAllClientNames()
        {
            List<ClientIDAndNameWithLocatorDictionary> clientNames = new List<ClientIDAndNameWithLocatorDictionary>();
            
            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            try
            {

                CliInfo[] clis = myTACWCFService.GetClientAndLocatorInfo();

                foreach (CliInfo cli in clis)
                {
                    ClientIDAndNameWithLocatorDictionary newClientInfo = new ClientIDAndNameWithLocatorDictionary(cli.ClientID, cli.ClientName);
                    List<LocatorInfo> lis = new List<LocatorInfo>();
                    foreach (LocInfo li in cli.Locators)
                    {
                        lis.Add(new LocatorInfo(li.LocatorID, li.Name, li.Year));
                    }
                    newClientInfo.Locators = lis;
                    clientNames.Add(newClientInfo);
                }
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error communicating with WCFService during GetAllClientNames call.");
                theLogger.Error("Error: ", ex);
            }
            finally
            {
                myTACWCFService.Close();
            }

            return clientNames;
        }
        /// <summary>
        /// This will get the ClientID for a clientName & year.  This should be tied into the authentication system.
        /// </summary>
        /// <param name="clientName">Client Name</param>
        /// <param name="year">year</param>
        /// <returns>client ID</returns>
        public int GetClientByNameAddIfNew(string clientName, short year)
        {
            int clientID = 0;

            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            try
            {
                string parms = "ClientName=\"" + clientName + "\";Year=\"" + year.ToString() + "\"";
                clientID = myTACWCFService.RunMethodByMessageTypeReturnInt("RequestClientID", parms);
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error communicating with WCFService during GetClientByNameAddIfNew call.");
                theLogger.Error("Error: ", ex);
            }
            finally 
            {
                myTACWCFService.Close();
            }

            return clientID;
        }
        /// <summary>
        /// Adds a new locator for the client
        /// </summary>
        /// <param name="clientID">ClientID</param>
        /// <param name="locatorName">new name</param>
        /// <param name="year">year</param>
        /// <returns>new locator id</returns>
        public int AddNewLocatorToListForClient(int clientID, string locatorName, short year)
        {
            int locatorID = 0;

            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            try
            {
                string parms = "ClientID=\"" + clientID + "\";LocatorName=\"" + locatorName + "\";Year=\"" + year.ToString() + "\"";
                locatorID = myTACWCFService.RunMethodByMessageTypeReturnInt("RequestAddNewLocatorToListForClient", parms);
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error communicating with WCFService during AddNewLocatorToListForClient call.");
                theLogger.Error("Error: ", ex);
            }
            finally 
            {
                myTACWCFService.Close();
            }

            return locatorID;
        }

        public void DeleteLocator(int locatorID, int productYear)
        {
            TaxAppClientServiceClient myTACWCFService = new TaxAppClientServiceClient();
            try
            {
                string parms = "LocatorID=\"" + locatorID + "\";Year=\"" + productYear + "\"";
                locatorID = myTACWCFService.RunMethodByMessageTypeReturnInt("DeleteLocator", parms);
            }
            catch (Exception ex)
            {
                theLogger.Warn("Error communicating with WCFService during DeleteLocator call.");
                theLogger.Error("Error: ", ex);
            }
            finally
            {
                myTACWCFService.Close();
            }
        }
        #endregion
    }
    namespace Tests
    {
        [TestFixture]
        public class TaxAppClientDataTests
        {
            private Process WCFprocess = null;
            [TestFixtureSetUp]
            public void SetupWCFService()
            { 
                //run all functions before firing up the service so the exception lines will be tested.
                TaxAppClientData o = new TaxAppClientData();
                UserConfigurationItems ucon = new UserConfigurationItems();
                o.Initialize(ucon);
                o.GetAllClientNames();
                o.GetClientByNameAddIfNew("Exception Test", ucon.Year);
                o.AddNewLocatorToListForClient(2, "Exception Test", ucon.Year);
                o.DeleteLocator(1, ucon.Year);


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
            public void InitializeTest()
            {
                //fire up the wcfservice host for this
                //in order to run these tests, the GraphicObjects.TaxAppRuntime.Tests.BuildSampleApplication.Build method needs to be ran.
                //also the WCFServiceHost's app.config setting needs to point at the outputdirectory of those tests (bin\debug\RunTimebinaries) of where the unit tests are ran.
                //TaxBuilder.GraphicObjects.TaxAppRuntime.Tests.BuildSampleApplication.Build();
                TaxAppClientData o = new TaxAppClientData();
                UserConfigurationItems ucon = new UserConfigurationItems();
                o.Initialize(ucon);
                Random r = new Random();

                List<ClientIDAndNameWithLocatorDictionary> cliLoc = o.GetAllClientNames();
                Assert.IsNotNull(cliLoc);
                bool found = false;
                int cliID = 0;
                foreach (ClientIDAndNameWithLocatorDictionary c in cliLoc)
                {
                    if (c.ClientName == "unit test Client")
                    {
                        found = true;
                        cliID = c.ClientID;
                        break;
                    }
                }

                if (!found)
                {
                    cliID = o.GetClientByNameAddIfNew("unit test Client", ucon.Year);
                }
                else 
                {
                    //add a new one - to exercise the function
                    int CliID2 = o.GetClientByNameAddIfNew("UnitTest." + r.NextDouble().ToString(), ucon.Year);
                    Assert.AreNotEqual(0, CliID2);
                }
                Assert.AreNotEqual(0, cliID);
                found = false;
                cliLoc = o.GetAllClientNames();
                foreach (ClientIDAndNameWithLocatorDictionary c in cliLoc)
                {
                    if (c.ClientName == "unit test Client")
                    {
                        found = true;
                        break;
                    }
                }
                Assert.IsTrue(found);

                string locName = "New Locator." + r.NextDouble().ToString();
                int newLocID = o.AddNewLocatorToListForClient(cliID, locName, ucon.Year);
                Assert.AreNotEqual(0, newLocID);

                o.DeleteLocator(newLocID, ucon.Year);

                cliLoc = o.GetAllClientNames();
                found = false;
                bool foundLoc = false;
                foreach (ClientIDAndNameWithLocatorDictionary c in cliLoc)
                {
                    if (c.ClientID == cliID)
                    {
                        found = true;
                        foreach (LocatorInfo li in c.Locators)
                        {
                            if (li.Name == locName)
                            {
                                foundLoc = true;
                            }
                        }
                    }
                }
                Assert.IsTrue(found);
                Assert.IsFalse(foundLoc);
            }
        }
    }
}
