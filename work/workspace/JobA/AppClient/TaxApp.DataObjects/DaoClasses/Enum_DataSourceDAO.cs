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
	/// General DAO class for the Enum_DataSource Entity. It will perform database oriented actions for
	/// a entity of type 'Enum_DataSourceEntity'. This DAO works on an EntityFields object. 
	/// </summary>
	public partial class Enum_DataSourceDAO : DaoBase
	{
		/// <summary>CTor</summary>
		public Enum_DataSourceDAO() : base(InheritanceInfoProviderSingleton.GetInstance(), new DynamicQueryEngine(), InheritanceHierarchyType.None, "Enum_DataSourceEntity", new Enum_DataSourceEntityFactory(), new TypeDefaultValue())
		{
		}
		
		/// <summary>CTor</summary>
		/// <param name="inheritanceInfoProviderToUse">Inheritance info provider to use.</param>
		/// <param name="dqeToUse">Dqe to use.</param>
		/// <param name="typeOfInheritance">Type of inheritance.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="entityFactory">Entity factory.</param>
		/// <param name="typeDefaultvalueSupplier">Type defaultvalue supplier.</param>
		internal Enum_DataSourceDAO(IInheritanceInfoProvider inheritanceInfoProviderToUse, DynamicQueryEngineBase dqeToUse, InheritanceHierarchyType typeOfInheritance, string entityName, IEntityFactory entityFactory, ITypeDefaultValue typeDefaultvalueSupplier) : base(inheritanceInfoProviderToUse, dqeToUse, typeOfInheritance, entityName, entityFactory, new TypeDefaultValue())
		{
		}


		/// <summary>
		/// Retrieves entities of the type 'Enum_DataSourceEntity' in a datatable which match the specified filter. 
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
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
			return base.PerformGetMultiAsDataTableAction(maxNumberOfItemsToReturn, sortClauses, selectFilter, relations, pageNumber, pageSize);
		}

	
		/// <summary>
		/// Retrieves in the calling Enum_DataSourceCollection object all Enum_DataSourceEntity objects
		/// which are related via a relation of type 'm:n' with the passed in Enum_DataTypeEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity object to be used as a filter in the m:n relation</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingEnum_DataTypeCollectionViaLocatorObjectRecord(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity enum_DataTypeInstance, int pageNumber, int pageSize)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed, "LocatorObjectRecord_");
			relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue, "LocatorObjectRecord_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(enum_DataTypeInstance.Fields[(int)Enum_DataTypeFieldIndex.Enum_Value], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, pageNumber, pageSize);
		}

		/// <summary>
		/// Retrieves in the calling Enum_DataSourceCollection object all Enum_DataSourceEntity objects
		/// which are related via a relation of type 'm:n' with the passed in Enum_DataTypeEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity object to be used as a filter in the m:n relation</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingEnum_DataTypeCollectionViaLocatorObjectRecord(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity enum_DataTypeInstance, IPrefetchPath prefetchPathToUse)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed, "LocatorObjectRecord_");
			relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue, "LocatorObjectRecord_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(enum_DataTypeInstance.Fields[(int)Enum_DataTypeFieldIndex.Enum_Value], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, prefetchPathToUse);
		}

		/// <summary>
		/// Retrieves in the calling Enum_DataSourceCollection object all Enum_DataSourceEntity objects
		/// which are related via a relation of type 'm:n' with the passed in LocatorEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="locatorInstance">LocatorEntity object to be used as a filter in the m:n relation</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingLocatorCollectionViaLocatorObjectRecord(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity locatorInstance, int pageNumber, int pageSize)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed, "LocatorObjectRecord_");
			relations.Add(LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID, "LocatorObjectRecord_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(locatorInstance.Fields[(int)LocatorFieldIndex.Product_Year], ComparisonOperator.Equal));
selectFilter.Add(new FieldCompareValuePredicate(locatorInstance.Fields[(int)LocatorFieldIndex.Locator_ID], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, pageNumber, pageSize);
		}

		/// <summary>
		/// Retrieves in the calling Enum_DataSourceCollection object all Enum_DataSourceEntity objects
		/// which are related via a relation of type 'm:n' with the passed in LocatorEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="locatorInstance">LocatorEntity object to be used as a filter in the m:n relation</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingLocatorCollectionViaLocatorObjectRecord(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity locatorInstance, IPrefetchPath prefetchPathToUse)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed, "LocatorObjectRecord_");
			relations.Add(LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID, "LocatorObjectRecord_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(locatorInstance.Fields[(int)LocatorFieldIndex.Product_Year], ComparisonOperator.Equal));
selectFilter.Add(new FieldCompareValuePredicate(locatorInstance.Fields[(int)LocatorFieldIndex.Locator_ID], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, prefetchPathToUse);
		}

		/// <summary>
		/// Retrieves in the calling Enum_DataSourceCollection object all Enum_DataSourceEntity objects
		/// which are related via a relation of type 'm:n' with the passed in LocatorObjectRecordEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="locatorObjectRecordInstance">LocatorObjectRecordEntity object to be used as a filter in the m:n relation</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingLocatorObjectRecordCollectionViaLocatorObjectValue(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity locatorObjectRecordInstance, int pageNumber, int pageSize)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectValueEntityUsingDataSource_EnumValue, "LocatorObjectValue_");
			relations.Add(LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID, "LocatorObjectValue_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(locatorObjectRecordInstance.Fields[(int)LocatorObjectRecordFieldIndex.Record_ID], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, pageNumber, pageSize);
		}

		/// <summary>
		/// Retrieves in the calling Enum_DataSourceCollection object all Enum_DataSourceEntity objects
		/// which are related via a relation of type 'm:n' with the passed in LocatorObjectRecordEntity. 
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The Validator object to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="locatorObjectRecordInstance">LocatorObjectRecordEntity object to be used as a filter in the m:n relation</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMultiUsingLocatorObjectRecordCollectionViaLocatorObjectValue(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IValidator validatorToUse, IEntity locatorObjectRecordInstance, IPrefetchPath prefetchPathToUse)
		{
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
			RelationCollection relations = new RelationCollection();
			relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectValueEntityUsingDataSource_EnumValue, "LocatorObjectValue_");
			relations.Add(LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID, "LocatorObjectValue_", string.Empty, JoinHint.None);
			IPredicateExpression selectFilter = new PredicateExpression();
			selectFilter.Add(new FieldCompareValuePredicate(locatorObjectRecordInstance.Fields[(int)LocatorObjectRecordFieldIndex.Record_ID], ComparisonOperator.Equal));
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, validatorToUse, selectFilter, relations, prefetchPathToUse);
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


		#region Custom DAO code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomDAOCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion
		
		#region Included Code

		#endregion
	}
}
