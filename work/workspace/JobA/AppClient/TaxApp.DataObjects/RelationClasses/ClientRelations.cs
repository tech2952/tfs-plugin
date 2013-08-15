﻿///////////////////////////////////////////////////////////////
// This is generated code. If you modify this code, be aware
// of the fact that when you re-generate the code, your changes
// are lost. If you want to keep your changes, make this file read-only
// when you have finished your changes, however it is recommended that
// you inherit from this class to extend the functionality of this generated
// class or you modify / extend the templates used to generate this code.
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 1.0.2005.1
// Code is generated on: Wednesday, August 13, 2008 10:50:44 AM
// Code is generated using templates: C# template set for SqlServer (1.0.2005.1)
// Templates vendor: Solutions Design.
// Templates version: 1.0.2005.1.102305
//////////////////////////////////////////////////////////////
using System;

using TestHarness.DataObjects;
using TestHarness.DataObjects.FactoryClasses;
using TestHarness.DataObjects.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.RelationClasses
{
	/// <summary>
	/// Implements the static Relations variant for the entity: Client.
	/// This class is generated. Do not modify.
	/// </summary>
	public partial class ClientRelations
	{
		/// <summary>
		/// CTor
		/// </summary>
		public ClientRelations()
		{
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ClientEntity and ClientCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Client.Product_Year - ClientCustomer.Product_Year
		/// Client.Client_ID - ClientCustomer.Client_ID
		/// </summary>
		public virtual IEntityRelation ClientCustomerEntityUsingProduct_YearClient_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(ClientFieldIndex.Product_Year), EntityFieldFactory.Create(ClientCustomerFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(ClientFieldIndex.Client_ID), EntityFieldFactory.Create(ClientCustomerFieldIndex.Client_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClientEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClientCustomerEntity", false);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between ClientEntity and ClientLocatorEntity over the 1:n relation they have, using the relation between the fields:
		/// Client.Product_Year - ClientLocator.Product_Year
		/// Client.Client_ID - ClientLocator.Client_ID
		/// </summary>
		public virtual IEntityRelation ClientLocatorEntityUsingProduct_YearClient_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(ClientFieldIndex.Product_Year), EntityFieldFactory.Create(ClientLocatorFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(ClientFieldIndex.Client_ID), EntityFieldFactory.Create(ClientLocatorFieldIndex.Client_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClientEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClientLocatorEntity", false);
				return relation;
			}
		}
	
	
	

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
