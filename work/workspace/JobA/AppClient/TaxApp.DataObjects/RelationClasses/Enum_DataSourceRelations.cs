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
	/// Implements the static Relations variant for the entity: Enum_DataSource.
	/// This class is generated. Do not modify.
	/// </summary>
	public partial class Enum_DataSourceRelations
	{
		/// <summary>
		/// CTor
		/// </summary>
		public Enum_DataSourceRelations()
		{
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between Enum_DataSourceEntity and LocatorObjectRecordEntity over the 1:n relation they have, using the relation between the fields:
		/// Enum_DataSource.Enum_Value - LocatorObjectRecord.DatasourceUsed
		/// </summary>
		public virtual IEntityRelation LocatorObjectRecordEntityUsingDatasourceUsed
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Value), EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.DatasourceUsed));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("Enum_DataSourceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectRecordEntity", false);
				return relation;
			}
		}
	
		/// <summary>Returns a new IEntityRelation object, between Enum_DataSourceEntity and LocatorObjectValueEntity over the 1:n relation they have, using the relation between the fields:
		/// Enum_DataSource.Enum_Value - LocatorObjectValue.DataSource_EnumValue
		/// </summary>
		public virtual IEntityRelation LocatorObjectValueEntityUsingDataSource_EnumValue
		{
			get
			{

				IEntityRelation relation = new EntityRelation(RelationType.OneToMany);
				relation.StartEntityIsPkSide = true;
				relation.AddEntityFieldPair(EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Value), EntityFieldFactory.Create(LocatorObjectValueFieldIndex.DataSource_EnumValue));
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("Enum_DataSourceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocatorObjectValueEntity", false);
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
