using System;
using System.Collections.Generic;
using System.Text;
using TaxApp.IntrinsicFunctions;
using TaxBuilder.GraphicObjects;

namespace TestHarnessFitness
{
    public class FitnessHelpers
    {
        public static byte GetGraphicTypeByString(string GraphicType)
        {
            if (GraphicType.StartsWith("gridcolumn"))
            {
                if (GraphicType.EndsWith("textbox"))
                    return (byte)GraphicObjectTypeEnum.Textbox;
            }
            switch (GraphicType.ToLower())
            { 
                case "textbox":
                    return (byte)GraphicObjectTypeEnum.Textbox;
                case "grid":
                    return (byte)GraphicObjectTypeEnum.Grid;
            }
            return 0;        
        }
        public static byte GetDataTypeByString(string DataType)
        {
            switch (DataType.ToLower())
            { 
                case "integer":
                    return (byte)EnumKeyDataType.Integer;
                case "string":
                    return (byte)EnumKeyDataType.String;
                case "date":
                    return (byte)EnumKeyDataType.DateTime;
                case "ratio":
                    return (byte)EnumKeyDataType.Ratio;
                case "money":
                    return (byte)EnumKeyDataType.Money;
            }
            //just default to string if it isn't properly set
            return (byte)EnumKeyDataType.String;
        }
        public static int GetValidOrganizerPageID()
        {
            return TaxBuilder.BusinessObjects.Tests.NavigationImplementorTests.GetAValidOrganizerPageID();
        }
    }
}
