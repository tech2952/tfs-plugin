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
	/// Implements the static Relations variant for the entity: LocatorNodeComputedValue.
	/// This class is generated. Do not modify.
	/// </summary>
	public partial class LocatorNodeComputedValueRelations
	{
		/// <summary>
		/// CTor
		/// </summary>
		public LocatorNodeComputedValueRelations()
		{
		}

		#region Class Property Declarations

	
	
		/// <summary>Returns a new IEntityRelation object, between LocatorNodeComputedValueEntity and LocatorEntity over the m:1 relation they have, using the relation between the fields:
		/// LocatorNodeComputedValue.Product_Year - Locator.Product_Year
		/// LocatorNodeComputedValue.Locator_ID - Locator.Locator_ID
		/// </summary>
		public virtual IEntityRelation LocatorEntityUsingProduct_YearLocator_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.ManyToOne);
				relation.StartEntityIsPkSide = false;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Locator_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorNodeComputedValueEntity", true);
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
