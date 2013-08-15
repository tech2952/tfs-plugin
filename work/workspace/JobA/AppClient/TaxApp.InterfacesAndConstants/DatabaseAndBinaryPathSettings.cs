using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TaxApp.InterfacesAndConstants
{
    public class DatabaseAndBinaryPathSettings
    {
        private string myCodeScriptDLLPathAndName = "";
        private string myMappingInfoFilePathAndName = "";
        private string myDetailInfoFilePathAndName = "";

        private string myLocatorDatabaseName = "";
        private string myLocatorDatabaseServerName = "";
        private string myDesignDatabaseName = "";
        private string myDesignDatabaseServerName = "";

        private string myBinaryOutputDirectory;

        public string BinaryOutputDirectory
        {
            get { return myBinaryOutputDirectory; }
            set { myBinaryOutputDirectory = value; }
        }

        public string CodeScriptDLLPathAndName
        {
            get { return myCodeScriptDLLPathAndName; }
            set { myCodeScriptDLLPathAndName = value; }
        }
        public string MappingInfoFilePathAndName
        {
            get { return myMappingInfoFilePathAndName; }
            set { myMappingInfoFilePathAndName = value; }
        }

        public string DetailInfoFilePathAndName
        {
            get { return myDetailInfoFilePathAndName; }
            set { myDetailInfoFilePathAndName = value; }
        }


        public string LocatorDatabaseName { get { return myLocatorDatabaseName; } set { myLocatorDatabaseName = value; } }

        public string LocatorDatabaseServerName { get { return myLocatorDatabaseServerName; } set { myLocatorDatabaseServerName = value; } }

        public string DesignDatabaseName { get { return myDesignDatabaseName; } set { myDesignDatabaseName = value; } }

        public string DesignDatabaseServerName { get { return myDesignDatabaseServerName; } set { myDesignDatabaseServerName = value; } }

    }
}
