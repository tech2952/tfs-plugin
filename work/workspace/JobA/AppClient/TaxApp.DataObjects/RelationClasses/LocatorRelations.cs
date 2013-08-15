///////////////////////////////////////////////////////////////
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
	/// Implements the static Relations variant for the entity: Locator.
	/// This class is generated. Do not modify.
	/// </summary>
	public partial class LocatorRelations
	{
		/// <summary>
		/// CTor
		/// </summary>
		public LocatorRelations()
		{
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LocatorEntity and ClientLocatorEntity over the 1:n relation they have, using the relation between the fields:
		/// Locator.Product_Year - ClientLocator.Product_Year
		/// Locator.Locator_ID - ClientLocator.Locator_ID
		/// </summary>
		public virtual IEntityRelation ClientLocatorEntityUsingProduct_YearLocator_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), EntityFieldFactory.Create(ClientLocatorFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), EntityFieldFactory.Create(ClientLocatorFieldIndex.Locator_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClientLocatorEntity", false);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between LocatorEntity and LocatorNodeComputedValueEntity over the 1:n relation they have, using the relation between the fields:
		/// Locator.Product_Year - LocatorNodeComputedValue.Product_Year
		/// Locator.Locator_ID - LocatorNodeComputedValue.Locator_ID
		/// </summary>
		public virtual IEntityRelation LocatorNodeComputedValueEntityUsingProduct_YearLocator_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Locator_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorNodeComputedValueEntity", false);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between LocatorEntity and LocatorObjectRecordEntity over the 1:n relation they have, using the relation between the fields:
		/// Locator.Product_Year - LocatorObjectRecord.Product_Year
		/// Locator.Locator_ID - LocatorObjectRecord.Locator_ID
		/// </summary>
		public virtual IEntityRelation LocatorObjectRecordEntityUsingProduct_YearLocator_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Locator_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectRecordEntity", false);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between LocatorEntity and LocatorRolloverEntity over the 1:n relation they have, using the relation between the fields:
		/// Locator.Product_Year - LocatorRollover.Product_Year
		/// Locator.Locator_ID - LocatorRollover.Target_Locator_ID
		/// </summary>
		public virtual IEntityRelation LocatorRolloverEntityUsingProduct_YearTarget_Locator_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), EntityFieldFactory.Create(LocatorRolloverFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), EntityFieldFactory.Create(LocatorRolloverFieldIndex.Target_Locator_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorRolloverEntity", false);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between LocatorEntity and LocatorRolloverEntity over the 1:n relation they have, using the relation between the fields:
		/// Locator.Product_Year - LocatorRollover.Product_Year
		/// Locator.Locator_ID - LocatorRollover.Source_Locator_ID
		/// </summary>
		public virtual IEntityRelation LocatorRolloverEntityUsingProduct_YearSource_Locator_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), EntityFieldFactory.Create(LocatorRolloverFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), EntityFieldFactory.Create(LocatorRolloverFieldIndex.Source_Locator_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorRolloverEntity", false);
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
