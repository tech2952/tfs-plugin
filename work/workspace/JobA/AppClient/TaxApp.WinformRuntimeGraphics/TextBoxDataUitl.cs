using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
    class TextBoxDataUitl
    {
        public static bool DataInRange(TextBoxGraphic go, decimal num)
        {
            try
            {
                if (go.MaxValue.Length != 0)
                {
                    decimal max = Convert.ToDecimal(go.MaxValue);
                    if (num > max)
                    {
                        MessageBox.Show("Data is out of range. The MaxValue is " + go.MaxValue, "Invalid Entry");
                        return false;
                    }
                }
                if (go.MinValue.Length != 0)
                {
                    decimal min = Convert.ToDecimal(go.MinValue);
                    if (num < min)
                    {
                        MessageBox.Show("Data is out of range. The MinValue is " + go.MinValue, "Invalid Entry");
                        return false;
                    }
                }
            }
            catch
            {
            }
            return true;
        }
        public static bool DataInRange(TextBoxGraphic go, ref DateTime date)
        {
            try
            {
                if (go.MaxValue.Length != 0)
                {
                    DateTime maxDate = Convert.ToDateTime(go.MaxValue);
                    if (date > maxDate)
                    {
                        MessageBox.Show("Data is out of range. The MaxValue is " + go.MaxValue, "Invalid Entry");
                        date = maxDate;
                        return false;
                    }
                }
                if (go.MinValue.Length != 0)
                {
                    DateTime minDate = Convert.ToDateTime(go.MinValue);
                    if (date < minDate)
                    {
                        MessageBox.Show("Data is out of range. The MinValue is " + go.MinValue, "Invalid Entry");
                        date = minDate;
                        return false;
                    }
                }
            }
            catch
            {
            }
            return true;
        }
        public static string RemoveMask(string str)
        {
            string strTemp = str;
            strTemp = strTemp.Replace("-", "");
            strTemp = strTemp.Replace("(", "");
            strTemp = strTemp.Replace(")", "");
            strTemp = strTemp.Replace("X", "");
            strTemp = strTemp.Trim();
            return strTemp;
        }
    }
}
