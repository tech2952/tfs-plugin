using System;
using System.Collections.Generic;
using System.Text;
using TestHarness.BusinessObjects;
using TaxApp.InterfacesAndConstants;

namespace TestHarnessFitness
{
    public class DesignDatabaseSecurityCheck
    {
        //server 	database 	admin
        private string myServer;

        public string server
        {
            get { return myServer; }
            set { myServer = value; }
        }
        private string myDatabase;

        public string database
        {
            get { return myDatabase; }
            set { myDatabase = value; }
        }
        
        public string admin()
        {
            DesignDatabaseConnectionSwitcher.SetServerAndDatabase(myServer, myDatabase);
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();

            ITaxAppInfo appRetriever = new ApplicationInfoRetrieverFromTaxBuilderDesignDB();
            UserConfigurationItems uci = new UserConfigurationItems();
            DatabaseAndBinaryPathSettings db = new DatabaseAndBinaryPathSettings();
            db.DesignDatabaseName = myDatabase;
            db.DesignDatabaseServerName = myServer;
            uci.DatabaseAndBinaryPathSettings = db;
            appRetriever.Initialize(uci);
            

            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return string.Empty;
        }

    }
}
