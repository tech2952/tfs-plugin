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
	/// Implements the static Relations variant for the entity: LocatorObjectRecord.
	/// This class is generated. Do not modify.
	/// </summary>
	public partial class LocatorObjectRecordRelations
	{
		/// <summary>
		/// CTor
		/// </summary>
		public LocatorObjectRecordRelations()
		{
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LocatorObjectRecordEntity and LocatorObjectValueEntity over the 1:n relation they have, using the relation between the fields:
		/// LocatorObjectRecord.Record_ID - LocatorObjectValue.Record_ID
		/// </summary>
		public virtual IEntityRelation LocatorObjectValueEntityUsingRecord_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Record_ID), EntityFieldFactory.Create(LocatorObjectValueFieldIndex.Record_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectRecordEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectValueEntity", false);
				return relation;
			}
		}
	
	
	
		/// <summary>Returns a new IEntityRelation object, between LocatorObjectRecordEntity and Enum_DataSourceEntity over the m:1 relation they have, using the relation between the fields:
		/// LocatorObjectRecord.DatasourceUsed - Enum_DataSource.Enum_Value
		/// </summary>
		public virtual IEntityRelation Enum_DataSourceEntityUsingDatasourceUsed
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.ManyToOne);
				relation.StartEntityIsPkSide = false;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Value), EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.DatasourceUsed));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("Enum_DataSourceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectRecordEntity", true);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between LocatorObjectRecordEntity and Enum_DataTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// LocatorObjectRecord.DataType_EnumValue - Enum_DataType.Enum_Value
		/// </summary>
		public virtual IEntityRelation Enum_DataTypeEntityUsingDataType_EnumValue
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.ManyToOne);
				relation.StartEntityIsPkSide = false;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(Enum_DataTypeFieldIndex.Enum_Value), EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.DataType_EnumValue));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("Enum_DataTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectRecordEntity", true);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between LocatorObjectRecordEntity and LocatorEntity over the m:1 relation they have, using the relation between the fields:
		/// LocatorObjectRecord.Product_Year - Locator.Product_Year
		/// LocatorObjectRecord.Locator_ID - Locator.Locator_ID
		/// </summary>
		public virtual IEntityRelation LocatorEntityUsingProduct_YearLocator_ID
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.ManyToOne);
				relation.StartEntityIsPkSide = false;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Product_Year));
				relation.AddEntityFieldPair(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Locator_ID));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectRecordEntity", true);
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
