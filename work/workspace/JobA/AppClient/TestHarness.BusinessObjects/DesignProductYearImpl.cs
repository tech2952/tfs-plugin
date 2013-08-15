using System;
using NUnit.Framework;
using System.Configuration;
using TaxBuilder.BusinessObjects;
using TaxBuilder.DataObjects.HelperClasses;

namespace TestHarness.BusinessObjects
{
	/// <summary>
	/// Summary description for DesignProductYearImpl.
	/// </summary>
	public class DesignProductYearImpl
	{
		private static short myDesignProductYear = 0;
		public static short DesignProductYear
		{
			get
			{
				if (myDesignProductYear == 0)
				{
					DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
                    TaxBuilder.BusinessObjects.DatabaseInitializer di = TaxBuilder.BusinessObjects.DatabaseInitializer.GetInstance();
					myDesignProductYear= Convert.ToInt16(di.ProductYear);
					DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
				}
				return myDesignProductYear;
			}
		}
		public DesignProductYearImpl(){}
	}
	namespace Tests
	{
		[TestFixture] public class DesignProductYearImplTester
		{
			[Test] public void ObjectCD()
			{
				Assert.IsTrue(DesignProductYearImpl.DesignProductYear > 0);
			}
		}
	}
}
