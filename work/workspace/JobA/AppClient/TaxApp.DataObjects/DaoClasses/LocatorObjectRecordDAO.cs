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
using System.Data;
using System.Data.Common;

using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.FactoryClasses;
using TestHarness.DataObjects.CollectionClasses;
using TestHarness.DataObjects.HelperClasses;
using TestHarness.DataObjects.ValidatorClasses;
using TestHarness.DataObjects;

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;


namespace TestHarness.DataObjects.DaoClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	

	/// <summary>
	/// General DAO class for the LocatorObjectRecord Entity. It will perform database oriented actions for
	/// a entity of type 'LocatorObjectRecordEntity'. This DAO works on an EntityFields object. 
	/// </summary>
	public partial class LocatorObjectRecordDAO : DaoBase
	{
		/// <summary>CTor</summary>
		public LocatorObjectRecordDAO() : base(InheritanceInfoProviderSingleton.GetInstance(), new DynamicQueryEngine(), InheritanceHierarchyType.None, "LocatorObjectRecordEntity", new LocatorObjectRecordEntityFactory(), new TypeDefaultValue())
		{
		}
		
		/// <summary>CTor</summary>
		/// <param name="inheritanceInfoProviderToUse">Inheritance info provider to use.</param>
		/// <param name="dqeToUse">Dqe to use.</param>
		/// <param name="typeOfInheritance">Type of inheritance.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="entityFactory">Entity factory.</param>
		/// <param name="typeDefaultvalueSupplier">Type defaultvalue supplier.</param>
		internal LocatorObjectRecordDAO(IInheritanceInfoProvider inheritanceInfoProviderToUse, DynamicQueryEngineBase dqeToUse, InheritanceHierarchyType typeOfInheritance, string entityName, IEntityFactory entityFactory, ITypeDefaultValue typeDefaultvalueSupplier) : base(inheritanceInfoProviderToUse, dqeToUse, typeOfInheritance, entityName, entityFactory, new TypeDefaultValue())
		{
		}


		/// <summary>
		/// Retrieves in the calling LocatorObjectRecordCollection object all LocatorObjectRecordEntity objects which have data in common
		/// with the specified related Entities. If one is omitted, that entity is not used as a filter. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="filter">Extra filter to limit the resultset. Predicate expression can be null, in which case it will be ignored.</param>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity instance to use as a filter for the LocatorObjectRecordEntity objects to return</param>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity instance to use as a filter for the LocatorObjectRecordEntity objects to return</param>
		/// <param name="locatorInstance">LocatorEntity instance to use as a filter for the LocatorObjectRecordEntity objects to return</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		public bool GetMulti(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IPredicateExpression filter, IEntity enum_DataSourceInstance, IEntity enum_DataTypeInstance, IEntity locatorInstance, int pageNumber, int pageSize)
		{
			base.EntityFactoryToUse = entityFactoryToUse;
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
			IPredicateExpression selectFilter = CreateFilterUsingForeignKeys(enum_DataSourceInstance, enum_DataTypeInstance, locatorInstance, fieldsToReturn);
			if(filter!=null)
			{
				selectFilter.AddWithAnd(filter);
			}
			return base.PerformGetMultiAction(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, validatorToUse, selectFilter, null, pageNumber, pageSize);
		}

		/// <summary>
		/// Retrieves entities of the type 'LocatorObjectRecordEntity' in a datatable which match the specified filter. 
		/// It will always create a new connection to the database.
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>a filled datatable if succeeded, false otherwise</returns>
		public virtual DataTable GetMultiAsDataTable(long maxNumberOfItemsToReturn, ISortExpression sortClauses, IPredicate selectFilter, IRelationCollection relations, int pageNumber, int pageSize)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
			return base.PerformGetMultiAsDataTableAction(maxNumberOfItemsToReturn, sortClauses, selectFilter, relations, pageNumber, pageSize);
		}

	
		/// <summary>
		/// Retrieves in the calling LocatorObjectRecordCollection object all LocatorObjectRecordEntity objects
		/// which are related via a relation of type 'm:n' with the passed in Enum_DataSourceEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity object to be used as a filter in the m:n relation</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingEnum_DataSourceCollectionViaLocatorObjectValue(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity enum_DataSourceInstance, int pageNumber, int pageSize)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(LocatorObjectRecordEntity.Relations.LocatorObjectValueEntityUsingRecord_ID, "LocatorObjectValue_");
			relations.Add(LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue, "LocatorObjectValue_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(enum_DataSourceInstance.Fields[(int)Enum_DataSourceFieldIndex.Enum_Value], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, pageNumber, pageSize);
		}

		/// <summary>
		/// Retrieves in the calling LocatorObjectRecordCollection object all LocatorObjectRecordEntity objects
		/// which are related via a relation of type 'm:n' with the passed in Enum_DataSourceEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity object to be used as a filter in the m:n relation</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingEnum_DataSourceCollectionViaLocatorObjectValue(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity enum_DataSourceInstance, IPrefetchPath prefetchPathToUse)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(LocatorObjectRecordEntity.Relations.LocatorObjectValueEntityUsingRecord_ID, "LocatorObjectValue_");
			relations.Add(LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue, "LocatorObjectValue_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(enum_DataSourceInstance.Fields[(int)Enum_DataSourceFieldIndex.Enum_Value], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, prefetchPathToUse);
		}

	
		/// <summary>
		/// Deletes from the persistent storage all 'LocatorObjectRecord' entities which have data in common
		/// with the specified related Entities. If one is omitted, that entity is not used as a filter. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity instance to use as a filter for the LocatorObjectRecordEntity objects to delete</param>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity instance to use as a filter for the LocatorObjectRecordEntity objects to delete</param>
		/// <param name="locatorInstance">LocatorEntity instance to use as a filter for the LocatorObjectRecordEntity objects to delete</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int DeleteMulti(ITransaction containingTransaction, IEntity enum_DataSourceInstance, IEntity enum_DataTypeInstance, IEntity locatorInstance)
		{
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
			IPredicateExpression deleteFilter = CreateFilterUsingForeignKeys(enum_DataSourceInstance, enum_DataTypeInstance, locatorInstance, fields);
			return base.DeleteMulti(containingTransaction, deleteFilter);
		}

		/// <summary>
		/// Updates all entities of the same type or subtype of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. Entities of a subtype of the type
		/// of <i>entityWithNewValues</i> which are affected by the filterBucket's filter will thus also be updated. 
		/// </summary>
		/// <param name="entityWithNewValues">IEntity instance which holds the new values for the matching entities to update. Only changed fields are taken into account</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity instance to use as a filter for the LocatorObjectRecordEntity objects to update</param>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity instance to use as a filter for the LocatorObjectRecordEntity objects to update</param>
		/// <param name="locatorInstance">LocatorEntity instance to use as a filter for the LocatorObjectRecordEntity objects to update</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int UpdateMulti(IEntity entityWithNewValues, ITransaction containingTransaction, IEntity enum_DataSourceInstance, IEntity enum_DataTypeInstance, IEntity locatorInstance)
		{
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
			IPredicateExpression updateFilter = CreateFilterUsingForeignKeys(enum_DataSourceInstance, enum_DataTypeInstance, locatorInstance, fields);
			return base.UpdateMulti(entityWithNewValues, containingTransaction, updateFilter);
		}
	

		/// <summary>
		/// Determines the connection to use. If transaction to use is null, a new connection is created, otherwise the connection of the transaction is used.
		/// </summary>
		/// <param name="transactionToUse">Transaction to use.</param>
		/// <returns>a ready to use connection object.</returns>
		protected override IDbConnection DetermineConnectionToUse(ITransaction transactionToUse)
		{
			return DbUtils.DetermineConnectionToUse(transactionToUse);
		}
		
		/// <summary>
		/// Creates a new ADO.NET data adapter.
		/// </summary>
		/// <returns>ready to use ADO.NET data-adapter</returns>
		protected override DbDataAdapter CreateDataAdapter()
		{
			return DbUtils.CreateDataAdapter();
		}


		/// <summary>
		/// Creates a PredicateExpression which should be used as a filter when any combination of available foreign keys is specified.
		/// </summary>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity instance to use as a filter for the LocatorObjectRecordEntity objects</param>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity instance to use as a filter for the LocatorObjectRecordEntity objects</param>
		/// <param name="locatorInstance">LocatorEntity instance to use as a filter for the LocatorObjectRecordEntity objects</param>
		/// <param name="fieldsToReturn">IEntityFields implementation which forms the definition of the fieldset of the target entity.</param>
		/// <returns>A ready to use PredicateExpression based on the passed in foreign key value holders.</returns>
		private IPredicateExpression CreateFilterUsingForeignKeys(IEntity enum_DataSourceInstance, IEntity enum_DataTypeInstance, IEntity locatorInstance, IEntityFields fieldsToReturn)
		{
			IPredicateExpression selectFilter = new PredicateExpression();
			
			if(enum_DataSourceInstance != null)
			{
				selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)LocatorObjectRecordFieldIndex.DatasourceUsed], ComparisonOperator.Equal, ((Enum_DataSourceEntity)enum_DataSourceInstance).Enum_Value));
			}
			if(enum_DataTypeInstance != null)
			{
				selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)LocatorObjectRecordFieldIndex.DataType_EnumValue], ComparisonOperator.Equal, ((Enum_DataTypeEntity)enum_DataTypeInstance).Enum_Value));
			}
			if(locatorInstance != null)
			{
				selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)LocatorObjectRecordFieldIndex.Product_Year], ComparisonOperator.Equal, ((LocatorEntity)locatorInstance).Product_Year));
selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)LocatorObjectRecordFieldIndex.Locator_ID], ComparisonOperator.Equal, ((LocatorEntity)locatorInstance).Locator_ID));
			}
			return selectFilter;
		}

		#region Custom DAO code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomDAOCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion
		
		#region Included Code

		#endregion
	}
}
