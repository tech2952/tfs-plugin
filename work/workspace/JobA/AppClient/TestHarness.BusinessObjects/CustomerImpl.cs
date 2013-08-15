using System;
using NUnit.Framework;
using TestHarness.DataObjects;
using TestHarness.DataObjects.CollectionClasses;
using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Security.Principal;
using log4net;

namespace TestHarness.BusinessObjects
{
	/// <summary>
	/// Identifies the Tax Application user
	/// </summary>
	public class CustomerImpl
	{
        private static readonly ILog theLogger = LogManager.GetLogger("CustomerImpl");
		private CustomerNameEntity myCustomerNameEntity;
		public CustomerImpl()
		{
			WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();

			CustomerNameCollection cnc = new CustomerNameCollection();
			PredicateExpression filter = new PredicateExpression();
			filter.Add(PredicateFactory.CompareValue(CustomerNameFieldIndex.WindowsDomainLogin, ComparisonOperator.Equal, wi.Name));
			cnc.GetMulti(filter);
		
			if (cnc.Count == 0)
			{
				ProcessNewLogin(wi);
			}
			else
			{
				myCustomerNameEntity = cnc[0];
			}
		}
		private void ProcessNewLogin(WindowsIdentity windowIden)
		{
			CustomerNameEntity cne = new CustomerNameEntity();
			cne.WindowsDomainLogin = windowIden.Name;
			//TODO: new users shouldn't automatically be admins :)
			cne.IsAdministrator = true;
			cne.FirstName = "First";
			cne.LastName = "Last";
			cne.Save();
			myCustomerNameEntity = cne;
            theLogger.Info("New Customer Name Entity created associated with WindowsDomainLogin: " + cne.WindowsDomainLogin.ToString());
		}
		
		public string FirstName
		{
			get{return myCustomerNameEntity.FirstName;}
			set{myCustomerNameEntity.FirstName = value;}
		}
		public string LastName
		{
			get{return myCustomerNameEntity.LastName;}
			set{myCustomerNameEntity.LastName = value;}
		}
		public bool IsAdmin
		{
			get{return myCustomerNameEntity.IsAdministrator;}
			set{myCustomerNameEntity.IsAdministrator = value;}
		}
		public void Save()
		{
			myCustomerNameEntity.Save();
		}
	}
	namespace Tests
	{
		[TestFixture] public class CustomerImplTests
		{
			[Test] public void ObjectCD()
			{
				CustomerNameCollection cnc1 = new CustomerNameCollection();
				cnc1.GetMulti(null);

				CustomerImpl ci = new CustomerImpl();
				Assert.IsNotNull(ci);
				CustomerNameCollection cnc = new CustomerNameCollection();
				cnc.GetMulti(null);
				Assert.IsTrue(cnc.Count > 0);

				ci.FirstName = "TestFirst";
				ci.LastName = "TestLast";
				ci.IsAdmin = true;
				ci.Save();

				CustomerImpl ci2 = new CustomerImpl();
				Assert.AreEqual("TestFirst", ci2.FirstName);
				Assert.AreEqual("TestLast", ci2.LastName);
				Assert.IsTrue(ci2.IsAdmin);

			}
		}
	}
}
