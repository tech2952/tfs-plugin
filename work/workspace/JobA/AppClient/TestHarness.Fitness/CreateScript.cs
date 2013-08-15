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
    //TestHarnessFitness.CreateScript
    //scriptname 	parm1Name 	parm1datatype 	parm2Name 	parm2datatype 	scriptsyntax 	saved?
    public class CreateScript : ColumnFixture
    {
        private static readonly ILog theLogger = LogManager.GetLogger("CreateScript");
        public string scriptname;
        public string returnDatatype;
        public string parm1Name;
        public string parm1datatype;
        public string parm2Name;
        public string parm2datatype;
        public string scriptsyntax;
        public virtual bool saved()
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            if (CodeScriptImpl.ScriptNameExists(scriptname))
            {
                CodeScriptImpl csi = CodeScriptImpl.GetScriptByName(scriptname);
                csi.Delete();
                theLogger.Info("CodeScriptImpl.Delete called to clear current script");
            }

            if (!CodeScriptImpl.ScriptNameExists(scriptname))
            {
                CodeScriptImpl csi = new CodeScriptImpl((EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), FitnessHelpers.GetDataTypeByString(returnDatatype).ToString()));
                csi.Syntax = scriptsyntax;
                csi.Name = scriptname;
                csi.SetParameter(parm1Name, (EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), FitnessHelpers.GetDataTypeByString(parm1datatype).ToString()));
                if (parm2Name != string.Empty)
                {
                    csi.SetParameter(parm2Name, (EnumKeyDataType)Enum.Parse(typeof(EnumKeyDataType), FitnessHelpers.GetDataTypeByString(parm2datatype).ToString()));
                }
                csi.Save();
                theLogger.Info("Code Script created and saved: " + scriptname);
            }
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return true;

        }

    }
}
