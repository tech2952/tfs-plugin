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
using TaxBuilder.GraphicObjects;
using log4net;

namespace TestHarnessFitness
{
    public class SetMappings : ColumnFixture
    {
        //TestHarnessFitness.SetMappings
        //scriptname IDofFieldWithScript 	ParmName? 	IDOfFieldMappedtoThisField 	saved?
        public string scriptname;
        public int IDofFieldWithScript;
        public string parmName;
        public string IDOfFieldMappedtoThisField;
        public bool saved()
        { 
            //first get the script
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            CodeScriptImpl csi = CodeScriptImpl.GetScriptByName(scriptname);
            GraphicObjectEntity goe = new GraphicObjectEntity(IDofFieldWithScript);
            CodeScriptAssignmentImpl csai = new CodeScriptAssignmentImpl(IDofFieldWithScript, goe.Page_ID, csi.CodeID, ScriptType.Compute, false);
            
            if (IDOfFieldMappedtoThisField.StartsWith("C"))
            {
                //csai.AddMapping( false, IDOfFieldMappedtoThisField.Substring(1));
            }
            else
            {
                //csai.AddMapping(Convert.ToInt32(IDOfFieldMappedtoThisField), goe.Page_ID, false, TaxApp.IntrinsicFunctions.SpecialReturnEnum.byValue);
            }

            //in order for it to show up in the designer - it needs to be assigned to the property of the graphic also
            PropertyValuesForGraphicEntity pvge = new PropertyValuesForGraphicEntity(IDofFieldWithScript, goe.Page_ID, Constants.ComputeAssignmentID);
            if (pvge.IsNew)
            {
                pvge.Property_Name = Constants.ComputeAssignmentID;
                pvge.GraphicObject_ID = IDofFieldWithScript;
                pvge.Page_ID = goe.Page_ID;
            }
            pvge.Property_Value = csai.AssignmentID;
            pvge.Save();

            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();

            return true;
        }

    }
}
