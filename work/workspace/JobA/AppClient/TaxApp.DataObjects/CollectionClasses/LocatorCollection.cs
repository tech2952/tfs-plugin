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
using System.Collections;
using System.ComponentModel;
using System.Xml;
using System.Runtime.Serialization;

using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.FactoryClasses;
using TestHarness.DataObjects.DaoClasses;
using TestHarness.DataObjects.HelperClasses;
using TestHarness.DataObjects.ValidatorClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.CollectionClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	

	/// <summary>Collection class for storing and retrieving collections of LocatorEntity objects. </summary>
	[Serializable]
	public partial class LocatorCollection : EntityCollectionBase
	{
		/// <summary> CTor</summary>
		public LocatorCollection():base(new PropertyDescriptorFactory(), typeof(LocatorCollection), new LocatorEntityFactory(), null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public LocatorCollection(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse):base(propertyDescriptorFactoryToUse, typeof(LocatorCollection), entityFactoryToUse, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">The validator object to use when creating entity objects during a GetMulti() call.</param>
		public LocatorCollection(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, LocatorValidator validatorToUse):base(propertyDescriptorFactoryToUse, typeof(LocatorCollection), entityFactoryToUse, validatorToUse)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method. Complex databinding related.</param>
		/// <param name="typeOfDirectInheritor">Type of direct inheriting class. Used in GetItemProperties method. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		///  <param name="validatorToUse">The validator object to use when creating entity objects during a GetMulti() call.</param>
		protected LocatorCollection(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, Type typeOfDirectInheritor, IEntityFactory entityFactoryToUse, LocatorValidator validatorToUse):base(propertyDescriptorFactoryToUse, typeOfDirectInheritor, entityFactoryToUse, validatorToUse)
		{
		}

		/// <summary> Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LocatorCollection(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}



		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  Relation of type 'm:n' with the passed in ClientEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="clientInstance">ClientEntity object to be used as a filter in the m:n relation</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingClientCollectionViaClientLocator(IEntity clientInstance)
		{
			return GetMultiManyToManyUsingClientCollectionViaClientLocator(clientInstance, base.MaxNumberOfItemsToReturn, base.SortClauses, 0, 0);
		}
		
		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in ClientEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="clientInstance">ClientEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingClientCollectionViaClientLocator(IEntity clientInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			return GetMultiManyToManyUsingClientCollectionViaClientLocator(clientInstance, maxNumberOfItemsToReturn, sortClauses, 0, 0);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in ClientEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="clientInstance">ClientEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public virtual bool GetMultiManyToManyUsingClientCollectionViaClientLocator(IEntity clientInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses, int pageNumber, int pageSize)
		{
			if(!base.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetMultiUsingClientCollectionViaClientLocator(base.Transaction, this, maxNumberOfItemsToReturn, sortClauses, base.EntityFactoryToUse, base.ValidatorToUse, clientInstance, pageNumber, pageSize);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a Relation of type 'm:n' with the passed in ClientEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="clientInstance">ClientEntity object to be used as a filter in the m:n relation</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingClientCollectionViaClientLocator(IEntity clientInstance, IPrefetchPath prefetchPathToUse)
		{
			return GetMultiManyToManyUsingClientCollectionViaClientLocator(clientInstance, base.MaxNumberOfItemsToReturn, base.SortClauses, prefetchPathToUse);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in ClientEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="clientInstance">ClientEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingClientCollectionViaClientLocator(IEntity clientInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IPrefetchPath prefetchPathToUse)
		{
			if(!base.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetMultiUsingClientCollectionViaClientLocator(base.Transaction, this, maxNumberOfItemsToReturn, sortClauses, base.EntityFactoryToUse, base.ValidatorToUse, clientInstance, prefetchPathToUse);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  Relation of type 'm:n' with the passed in Enum_DataSourceEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity object to be used as a filter in the m:n relation</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(IEntity enum_DataSourceInstance)
		{
			return GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(enum_DataSourceInstance, base.MaxNumberOfItemsToReturn, base.SortClauses, 0, 0);
		}
		
		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in Enum_DataSourceEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(IEntity enum_DataSourceInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			return GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(enum_DataSourceInstance, maxNumberOfItemsToReturn, sortClauses, 0, 0);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in Enum_DataSourceEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public virtual bool GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(IEntity enum_DataSourceInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses, int pageNumber, int pageSize)
		{
			if(!base.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetMultiUsingEnum_DataSourceCollectionViaLocatorObjectRecord(base.Transaction, this, maxNumberOfItemsToReturn, sortClauses, base.EntityFactoryToUse, base.ValidatorToUse, enum_DataSourceInstance, pageNumber, pageSize);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a Relation of type 'm:n' with the passed in Enum_DataSourceEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity object to be used as a filter in the m:n relation</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(IEntity enum_DataSourceInstance, IPrefetchPath prefetchPathToUse)
		{
			return GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(enum_DataSourceInstance, base.MaxNumberOfItemsToReturn, base.SortClauses, prefetchPathToUse);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in Enum_DataSourceEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataSourceInstance">Enum_DataSourceEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataSourceCollectionViaLocatorObjectRecord(IEntity enum_DataSourceInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IPrefetchPath prefetchPathToUse)
		{
			if(!base.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetMultiUsingEnum_DataSourceCollectionViaLocatorObjectRecord(base.Transaction, this, maxNumberOfItemsToReturn, sortClauses, base.EntityFactoryToUse, base.ValidatorToUse, enum_DataSourceInstance, prefetchPathToUse);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  Relation of type 'm:n' with the passed in Enum_DataTypeEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity object to be used as a filter in the m:n relation</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(IEntity enum_DataTypeInstance)
		{
			return GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(enum_DataTypeInstance, base.MaxNumberOfItemsToReturn, base.SortClauses, 0, 0);
		}
		
		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in Enum_DataTypeEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(IEntity enum_DataTypeInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			return GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(enum_DataTypeInstance, maxNumberOfItemsToReturn, sortClauses, 0, 0);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in Enum_DataTypeEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public virtual bool GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(IEntity enum_DataTypeInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses, int pageNumber, int pageSize)
		{
			if(!base.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetMultiUsingEnum_DataTypeCollectionViaLocatorObjectRecord(base.Transaction, this, maxNumberOfItemsToReturn, sortClauses, base.EntityFactoryToUse, base.ValidatorToUse, enum_DataTypeInstance, pageNumber, pageSize);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a Relation of type 'm:n' with the passed in Enum_DataTypeEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity object to be used as a filter in the m:n relation</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(IEntity enum_DataTypeInstance, IPrefetchPath prefetchPathToUse)
		{
			return GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(enum_DataTypeInstance, base.MaxNumberOfItemsToReturn, base.SortClauses, prefetchPathToUse);
		}

		/// <summary> Retrieves in this LocatorCollection object all LocatorEntity objects which are related via a  relation of type 'm:n' with the passed in Enum_DataTypeEntity. 
		/// All current elements in the collection are removed from the collection.</summary>
		/// <param name="enum_DataTypeInstance">Enum_DataTypeEntity object to be used as a filter in the m:n relation</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if the retrieval succeeded, false otherwise</returns>
		public bool GetMultiManyToManyUsingEnum_DataTypeCollectionViaLocatorObjectRecord(IEntity enum_DataTypeInstance, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IPrefetchPath prefetchPathToUse)
		{
			if(!base.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetMultiUsingEnum_DataTypeCollectionViaLocatorObjectRecord(base.Transaction, this, maxNumberOfItemsToReturn, sortClauses, base.EntityFactoryToUse, base.ValidatorToUse, enum_DataTypeInstance, prefetchPathToUse);
		}


		/// <summary> Retrieves Entity rows in a datatable which match the specified filter. It will always create a new connection to the database.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <returns>DataTable with the rows requested.</returns>
		public  static DataTable GetMultiAsDataTable(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			return GetMultiAsDataTable(selectFilter, maxNumberOfItemsToReturn, sortClauses, null, 0, 0);
		}

		/// <summary> Retrieves Entity rows in a datatable which match the specified filter. It will always create a new connection to the database.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <returns>DataTable with the rows requested.</returns>
		public  static DataTable GetMultiAsDataTable(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations)
		{
			return GetMultiAsDataTable(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, 0, 0);
		}
		
		/// <summary> Retrieves Entity rows in a datatable which match the specified filter. It will always create a new connection to the database.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>DataTable with the rows requested.</returns>
		public  static DataTable GetMultiAsDataTable(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, int pageNumber, int pageSize)
		{
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetMultiAsDataTable(maxNumberOfItemsToReturn, sortClauses, selectFilter, relations, pageNumber, pageSize);
		}


		/// <summary> Deletes from the persistent storage all Locator entities which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete. Can be null, which will result in a query removing all Locator entities from the persistent storage</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public virtual int DeleteMulti(IPredicate deleteFilter)
		{
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.DeleteMulti(base.Transaction, deleteFilter);
		}

		/// <summary> Deletes from the persistent storage all Locator entities which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public virtual int DeleteMulti(IPredicate deleteFilter, IRelationCollection relations)
		{
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.DeleteMulti(base.Transaction, deleteFilter, relations);
		}

		/// <summary> Updates in the persistent storage all entities which have data in common with the specified LocatorEntity. If one is omitted that entity is not used as a filter. Which fields are updated in those matching entities depends on which fields are
		/// <i>changed</i> in entityWithNewValues. The new values of these fields are read from entityWithNewValues. </summary>
		/// <param name="entityWithNewValues">LocatorEntity instance which holds the new values for the matching entities to update. Only changed fields are taken into account</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update. Can be null, which
		/// will result in an update action which will affect all Locator entities.</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int UpdateMulti(LocatorEntity entityWithNewValues, IPredicate updateFilter)
		{
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.UpdateMulti(entityWithNewValues, base.Transaction, updateFilter);
		}

		/// <summary> Updates in the persistent storage all entities which have data in common with the specified LocatorEntity. If one is omitted that entity is not used as a filter. Which fields are updated in those matching entities depends on which fields are
		/// <i>changed</i> in entityWithNewValues. The new values of these fields are read from entityWithNewValues. </summary>
		/// <param name="entityWithNewValues">LocatorEntity instance which holds the new values for the matching entities to update. Only changed fields are taken into account</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int UpdateMulti(LocatorEntity entityWithNewValues, IPredicate updateFilter, IRelationCollection relations)
		{
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.UpdateMulti(entityWithNewValues, base.Transaction, updateFilter, relations);
		}

		/// <summary> Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a new Transaction (which is created in an inherited method.)</summary>
		/// <param name="recurse">If true, will recursively save the entities inside the collection</param>
		/// <returns>Amount of entities inserted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		public override int SaveMulti(bool recurse)
		{
			int amountSaved = 0;
			if(!this.ParticipatesInTransaction)
			{
				Transaction transactionManager = new Transaction(IsolationLevel.ReadCommitted, "SaveMulti");
				transactionManager.Add(this);
				try
				{
					amountSaved = base.SaveMulti(recurse);
					transactionManager.Commit();
				}
				catch
				{
					transactionManager.Rollback();
					throw;
				}
			}
			else
			{
				amountSaved = base.SaveMulti(recurse);
			}
			return amountSaved;
		}

		/// <summary> Deletes all Entities in the IEntityCollection from the persistent storage. If this IEntityCollection is added
		/// to a transaction, the delete processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the deletes are done in a/ new Transaction.
		/// Deleted entities are marked deleted and are removed from the collection.</summary>
		/// <returns>Amount of entities deleted</returns>
		public override int DeleteMulti()
		{
			int amountDeleted = 0;
			if(!this.ParticipatesInTransaction)
			{
				Transaction transactionManager = new Transaction(IsolationLevel.ReadCommitted, "DeleteMulti");
				transactionManager.Add(this);
				try
				{
					amountDeleted = base.DeleteMulti();
					transactionManager.Commit();
				}
				catch
				{
					transactionManager.Rollback();
					throw;
				}
			}
			else
			{
				amountDeleted = base.DeleteMulti();
			}
			return amountDeleted;
		}

		/// <summary> Routine used for complex databinding. Part of ITypedList.</summary>
		/// <param name="listAccessors">An array of PropertyDescriptor objects, the list name for which is returned. This can be a null reference.</param>
		/// <returns>The name of this list</returns>
		public override string GetListName(PropertyDescriptor[] listAccessors)
		{
			return "LocatorCollection";
		}

		/// <summary> Gets a scalar value, calculated with the aggregate. the field index specified is the field the aggregate are applied on.</summary>
		/// <param name="fieldIndex">Field index of field to which to apply the aggregate function and expression</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(LocatorFieldIndex fieldIndex, AggregateFunction aggregateToApply)
		{
			return GetScalar(fieldIndex, null, aggregateToApply, null, null, null);
		}

		/// <summary> Gets a scalar value, calculated with the aggregate and expression specified. the field index specified is the field the expression and aggregate are applied on.</summary>
		/// <param name="fieldIndex">Field index of field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(LocatorFieldIndex fieldIndex, IExpression expressionToExecute, AggregateFunction aggregateToApply)
		{
			return GetScalar(fieldIndex, expressionToExecute, aggregateToApply, null, null, null);
		}

		/// <summary> Gets a scalar value, calculated with the aggregate and expression specified. the field index specified is the field the expression and aggregate are
		/// applied on.</summary>
		/// <param name="fieldIndex">Field index of field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(LocatorFieldIndex fieldIndex, IExpression expressionToExecute, AggregateFunction aggregateToApply, IPredicate filter)
		{
			return GetScalar(fieldIndex, expressionToExecute, aggregateToApply, filter, null, null);
		}

		/// <summary> Gets a scalar value, calculated with the aggregate and expression specified. the field index specified is the field the expression and aggregate are applied on.</summary>
		/// <param name="fieldIndex">Field index of field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <param name="groupByClause">The groupby clause to apply to retrieve the scalar</param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(LocatorFieldIndex fieldIndex, IExpression expressionToExecute, AggregateFunction aggregateToApply, IPredicate filter, IGroupByCollection groupByClause)
		{
			return GetScalar(fieldIndex, expressionToExecute, aggregateToApply, filter, null, groupByClause);
		}

		/// <summary> Gets a scalar value, calculated with the aggregate and expression specified. the field index specified is the field the expression and aggregate are applied on.</summary>
		/// <param name="fieldIndex">Field index of field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The groupby clause to apply to retrieve the scalar</param>
		/// <returns>the scalar value requested</returns>
		public virtual object GetScalar(LocatorFieldIndex fieldIndex, IExpression expressionToExecute, AggregateFunction aggregateToApply, IPredicate filter, IRelationCollection relations, IGroupByCollection groupByClause)
		{
			EntityFields fields = new EntityFields(1);
			fields[0] = EntityFieldFactory.Create(fieldIndex);
			fields[0].ExpressionToApply = expressionToExecute;
			fields[0].AggregateFunctionToApply = aggregateToApply;
			LocatorDAO dao = DAOFactory.CreateLocatorDAO();
			return dao.GetScalar(fields, base.Transaction, filter, relations, groupByClause);
		}
		
		/// <summary>Creats a new DAO instance so code which is in the base class can still use the proper DAO object.</summary>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateLocatorDAO();
		}

		#region Class Property Declarations
		/// <summary> Strong typed indexer. </summary>
		public  LocatorEntity this [int index]
		{
			get { return (LocatorEntity)List[index]; }
		}
		#endregion

		#region Custom EntityCollection code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCollectionCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion
		
		#region Included Code

		#endregion
	}
}
