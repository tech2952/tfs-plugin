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
using TestHarness.DataObjects.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.HelperClasses
{
	/// <summary>
	/// Helper class which will eases the creation of custom made resultsets. Usable in typed lists
	/// and dynamic lists created using the dynamic query engine.
	/// </summary>
	public partial class ResultsetFields : EntityFields
	{
		/// <summary>CTor</summary>
		public ResultsetFields(int amountFields) : base(amountFields, InheritanceInfoProviderSingleton.GetInstance())
		{
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(ClientFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(ClientFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(ClientFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(ClientCustomerFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(ClientCustomerFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(ClientCustomerFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(ClientLocatorFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(ClientLocatorFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(ClientLocatorFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(CustomerLocatorAuthorizationFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(CustomerLocatorAuthorizationFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(CustomerLocatorAuthorizationFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(CustomerNameFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(CustomerNameFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(CustomerNameFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(CustomerNamespaceAuthorizationFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(CustomerNamespaceAuthorizationFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(CustomerNamespaceAuthorizationFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(Enterprise_InformationFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(Enterprise_InformationFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(Enterprise_InformationFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(Enum_AuthorizationTypeFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(Enum_AuthorizationTypeFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(Enum_AuthorizationTypeFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(Enum_DataSourceFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(Enum_DataSourceFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(Enum_DataSourceFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(Enum_DataTypeFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(Enum_DataTypeFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(Enum_DataTypeFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(FirmFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(FirmFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(FirmFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(LocatorFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(LocatorFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(LocatorFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(LocatorGridRowFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(LocatorGridRowFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(LocatorGridRowFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(LocatorNodeComputedValueFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(LocatorNodeComputedValueFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(LocatorNodeComputedValueFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(LocatorObjectRecordFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(LocatorObjectRecordFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(LocatorObjectRecordFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(LocatorObjectValueFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(LocatorObjectValueFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(LocatorObjectValueFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(LocatorRolloverFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(LocatorRolloverFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(LocatorRolloverFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(TempComputedResultsFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(TempComputedResultsFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(TempComputedResultsFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}
		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField(TempComputeFieldsFieldIndex fieldToDefine, int indexInResultset, string alias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, string.Empty, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField(TempComputeFieldsFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias)
		{
			DefineField(fieldToDefine, indexInResultset, alias, entityAlias, AggregateFunction.None);
		}

		/// <summary>Creates the specified field on the position indexInResultset in the resultset.</summary>
		/// <param name="fieldToDefine">The specification of the field to create.</param>
		/// <param name="indexInResultset">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField(TempComputeFieldsFieldIndex fieldToDefine, int indexInResultset, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply)
		{
			IEntityField fieldToAdd = EntityFieldFactory.Create(fieldToDefine); 
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			base[indexInResultset] = fieldToAdd;
		}


		#region Included Code

		#endregion
	}
}
