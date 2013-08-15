using System;
using System.Collections.Generic;
using System.Text;
using fit;
using fitnesse;
using TestHarness.BusinessObjects;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.DataObjects.EntityClasses;
using TaxBuilder.DataObjects;
using TaxBuilder.DataObjects.CollectionClasses;
using TaxBuilder.BusinessObjects;
using TaxApp.IntrinsicFunctions;
using log4net;

namespace TestHarnessFitness
{
    public class CreateScriptThreeParms : CreateScript
    {
        public string parm3Name;
        public string parm3datatype;
        public override bool saved()
        {
            base.saved();
            //go set the last one
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            if (!CodeScriptImpl.ScriptNameExists(scriptname))
            {
                CodeScriptImpl csi = new CodeScriptImpl((EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), FitnessHelpers.GetDataTypeByString(returnDatatype).ToString()));
                csi.SetParameter(parm3Name, (EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), FitnessHelpers.GetDataTypeByString(parm3datatype).ToString()));
                csi.Save();
            }
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return true;
        }
    }
}
