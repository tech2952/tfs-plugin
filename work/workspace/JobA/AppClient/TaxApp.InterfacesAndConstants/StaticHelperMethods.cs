using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace TaxApp.InterfacesAndConstants
{
    /// <summary>
    /// And general helper methods can be placed in here.
    /// </summary>
    public class StaticHelperMethods
    {
        /// <summary>
        /// Gets the Cache directory eg C:\Documents and Settings\{User}\Local Settings\Application Data\Thomson\TaxAppClient
        /// </summary>
        /// <returns>Full directory string</returns>
        public static string GetCacheDirectory()
        {
            string strFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            strFile = Path.Combine(strFile, "Thomson");
            DirectoryInfo di = new DirectoryInfo(strFile);
            if (!di.Exists)
            {
                di.Create();
            }
            
            strFile = Path.Combine(strFile, "TaxAppClient");
            di = new DirectoryInfo(strFile);
            if (!di.Exists)
            {
                di.Create();
            }
            return strFile;
        }
    }
    namespace Tests
    {
        [TestFixture]public class StaticHelperMethodTests
        {
            [Test]
            public void GetCacheDirectory()
            {
                string strFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fullPath1 = Path.Combine(strFile, "Thomson");
                string fullPath2 = Path.Combine(fullPath1, "TaxAppClient");
                string fullPath3 = Path.Combine(fullPath2, "Images");
                DirectoryInfo di3 = new DirectoryInfo(fullPath3);
                if (di3.Exists)
                {
                    foreach (FileInfo fi in di3.GetFiles())
                    {
                        fi.Delete();
                    }
                    di3.Delete();
                }
                

                DirectoryInfo di2 = new DirectoryInfo(fullPath2);
                if (di2.Exists)
                {
                    foreach (FileInfo fi in di2.GetFiles())
                    {
                        fi.Delete();
                    }
                    di2.Delete();
                }
                
                
                string cacheDirectory = StaticHelperMethods.GetCacheDirectory();
                Assert.AreNotEqual(string.Empty, cacheDirectory);
                DirectoryInfo di = new DirectoryInfo(cacheDirectory);
                Assert.IsTrue(di.Exists);
            }
        }
    }
}
