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
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Data;
using System.Xml.Serialization;

using TestHarness.DataObjects;
using TestHarness.DataObjects.FactoryClasses;
using TestHarness.DataObjects.DaoClasses;
using TestHarness.DataObjects.RelationClasses;
using TestHarness.DataObjects.ValidatorClasses;
using TestHarness.DataObjects.HelperClasses;
using TestHarness.DataObjects.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	

	/// <summary>
	/// Entity class which represents the entity 'Client'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ClientEntity : EntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection	_clientCustomer;
		private bool	_alwaysFetchClientCustomer, _alreadyFetchedClientCustomer;
		private TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection	_clientLocator;
		private bool	_alwaysFetchClientLocator, _alreadyFetchedClientLocator;
		private TestHarness.DataObjects.CollectionClasses.CustomerNameCollection _customerNameCollectionViaClientCustomer;
		private bool	_alwaysFetchCustomerNameCollectionViaClientCustomer, _alreadyFetchedCustomerNameCollectionViaClientCustomer;
		private TestHarness.DataObjects.CollectionClasses.LocatorCollection _locatorCollectionViaClientLocator;
		private bool	_alwaysFetchLocatorCollectionViaClientLocator, _alreadyFetchedLocatorCollectionViaClientLocator;



		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region DataBinding Change Event Handler Declarations
		/// <summary>Event which is thrown when Product_Year changes value. Databinding related.</summary>
		public event EventHandler Product_YearChanged;
		/// <summary>Event which is thrown when Client_ID changes value. Databinding related.</summary>
		public event EventHandler Client_IDChanged;
		/// <summary>Event which is thrown when Client_Name changes value. Databinding related.</summary>
		public event EventHandler Client_NameChanged;
		/// <summary>Event which is thrown when Firm_Code changes value. Databinding related.</summary>
		public event EventHandler Firm_CodeChanged;
		/// <summary>Event which is thrown when Account_Code changes value. Databinding related.</summary>
		public event EventHandler Account_CodeChanged;
		/// <summary>Event which is thrown when Product_License changes value. Databinding related.</summary>
		public event EventHandler Product_LicenseChanged;

		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ClientEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ClientEntity()
		{
			InitClassEmpty(new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), CreateValidator());
		}


		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		public ClientEntity(System.Int16 product_Year, System.Int32 client_ID)
		{
			InitClassFetch(product_Year, client_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ClientEntity(System.Int16 product_Year, System.Int32 client_ID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(product_Year, client_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="validator">The custom validator object for this ClientEntity</param>
		public ClientEntity(System.Int16 product_Year, System.Int32 client_ID, ClientValidator validator)
		{
			InitClassFetch(product_Year, client_ID, validator, new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="validator">The custom validator object for this ClientEntity</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public ClientEntity(System.Int16 product_Year, System.Int32 client_ID, ClientValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassFetch(product_Year, client_ID, validator, propertyDescriptorFactoryToUse, entityFactoryToUse, null);
		}

		/// <summary>CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public ClientEntity(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassEmpty(propertyDescriptorFactoryToUse, entityFactoryToUse, CreateValidator());
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ClientEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_clientCustomer = (TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection)info.GetValue("_clientCustomer", typeof(TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection));
			_alwaysFetchClientCustomer = info.GetBoolean("_alwaysFetchClientCustomer");
			_alreadyFetchedClientCustomer = info.GetBoolean("_alreadyFetchedClientCustomer");
			_clientLocator = (TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection)info.GetValue("_clientLocator", typeof(TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection));
			_alwaysFetchClientLocator = info.GetBoolean("_alwaysFetchClientLocator");
			_alreadyFetchedClientLocator = info.GetBoolean("_alreadyFetchedClientLocator");
			_customerNameCollectionViaClientCustomer = (TestHarness.DataObjects.CollectionClasses.CustomerNameCollection)info.GetValue("_customerNameCollectionViaClientCustomer", typeof(TestHarness.DataObjects.CollectionClasses.CustomerNameCollection));
			_alwaysFetchCustomerNameCollectionViaClientCustomer = info.GetBoolean("_alwaysFetchCustomerNameCollectionViaClientCustomer");
			_alreadyFetchedCustomerNameCollectionViaClientCustomer = info.GetBoolean("_alreadyFetchedCustomerNameCollectionViaClientCustomer");
			_locatorCollectionViaClientLocator = (TestHarness.DataObjects.CollectionClasses.LocatorCollection)info.GetValue("_locatorCollectionViaClientLocator", typeof(TestHarness.DataObjects.CollectionClasses.LocatorCollection));
			_alwaysFetchLocatorCollectionViaClientLocator = info.GetBoolean("_alwaysFetchLocatorCollectionViaClientLocator");
			_alreadyFetchedLocatorCollectionViaClientLocator = info.GetBoolean("_alreadyFetchedLocatorCollectionViaClientLocator");


			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary> Will perform post-ReadXml actions as well as the normal ReadXml() actions, performed by the base class.</summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element of the entity's Xml data</param>
		public override void ReadXml(System.Xml.XmlNode node)
		{
			base.ReadXml (node);
			_alreadyFetchedClientCustomer = (_clientCustomer.Count > 0);
			_alreadyFetchedClientLocator = (_clientLocator.Count > 0);
			_alreadyFetchedCustomerNameCollectionViaClientCustomer = (_customerNameCollectionViaClientCustomer.Count > 0);
			_alreadyFetchedLocatorCollectionViaClientLocator = (_locatorCollectionViaClientLocator.Count > 0);


		}
		
		/// <summary> Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. If the entity is new, an insert is done and the updateRestriction is ignored. If the entity is not new, the updateRestriction
		/// predicate is used to create an additional where clause (it will be added with AND) for the update query. This predicate can be used for
		/// concurrency checks, like checks on timestamp column values.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored when the entity is new </param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// <returns>true if Save succeeded, false otherwise</returns>
		/// <remarks>Do not call this routine directly, use the overloaded version in a derived class as this version doesn't construct a
		/// local transaction during recursive save, this is done in the overloaded version in a derived class.</remarks>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework implemented.</exception>
		public override bool Save(IPredicate updateRestriction, bool recurse)
		{
			bool transactionStartedInThisScope = false;
			Transaction transactionManager = null;

			if(recurse || ((this.LLBLGenProIsInHierarchyOfType==InheritanceHierarchyType.TargetPerEntity) && this.LLBLGenProIsSubType))
			{
				if(!base.ParticipatesInTransaction)
				{
					transactionManager = new Transaction(IsolationLevel.ReadCommitted, "SaveRecursively");
					transactionManager.Add(this);
					transactionStartedInThisScope=true;
				}
			}
			try
			{
				bool result = base.Save(updateRestriction, recurse);
				if(transactionStartedInThisScope)
				{
					transactionManager.Commit();
				}
				return result;
			}
			catch
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Rollback();
				}
				throw;
			}
			finally
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Dispose();
				}
			}
		}
		


		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_clientCustomer", _clientCustomer);
			info.AddValue("_alwaysFetchClientCustomer", _alwaysFetchClientCustomer);
			info.AddValue("_alreadyFetchedClientCustomer", _alreadyFetchedClientCustomer);
			info.AddValue("_clientLocator", _clientLocator);
			info.AddValue("_alwaysFetchClientLocator", _alwaysFetchClientLocator);
			info.AddValue("_alreadyFetchedClientLocator", _alreadyFetchedClientLocator);
			info.AddValue("_customerNameCollectionViaClientCustomer", _customerNameCollectionViaClientCustomer);
			info.AddValue("_alwaysFetchCustomerNameCollectionViaClientCustomer", _alwaysFetchCustomerNameCollectionViaClientCustomer);
			info.AddValue("_alreadyFetchedCustomerNameCollectionViaClientCustomer", _alreadyFetchedCustomerNameCollectionViaClientCustomer);
			info.AddValue("_locatorCollectionViaClientLocator", _locatorCollectionViaClientLocator);
			info.AddValue("_alwaysFetchLocatorCollectionViaClientLocator", _alwaysFetchLocatorCollectionViaClientLocator);
			info.AddValue("_alreadyFetchedLocatorCollectionViaClientLocator", _alreadyFetchedLocatorCollectionViaClientLocator);


			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{

				case "ClientCustomer":
					_alreadyFetchedClientCustomer = true;
					if(entity!=null)
					{
						this.ClientCustomer.Add((ClientCustomerEntity)entity);
					}
					break;
				case "ClientLocator":
					_alreadyFetchedClientLocator = true;
					if(entity!=null)
					{
						this.ClientLocator.Add((ClientLocatorEntity)entity);
					}
					break;
				case "CustomerNameCollectionViaClientCustomer":
					_alreadyFetchedCustomerNameCollectionViaClientCustomer = true;
					if(entity!=null)
					{
						this.CustomerNameCollectionViaClientCustomer.Add((CustomerNameEntity)entity);
					}
					break;
				case "LocatorCollectionViaClientLocator":
					_alreadyFetchedLocatorCollectionViaClientLocator = true;
					if(entity!=null)
					{
						this.LocatorCollectionViaClientLocator.Add((LocatorEntity)entity);
					}
					break;

				default:

					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{

				case "ClientCustomer":
					_clientCustomer.Add(relatedEntity);
					break;
				case "ClientLocator":
					_clientLocator.Add(relatedEntity);
					break;

				default:

					break;
			}
		}
		
		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{

				case "ClientCustomer":
					_clientCustomer.Remove(relatedEntity);
					break;
				case "ClientLocator":
					_clientLocator.Remove(relatedEntity);
					break;

				default:

					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override ArrayList GetDependingRelatedEntities()
		{
			ArrayList toReturn = new ArrayList();


			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override ArrayList GetDependentRelatedEntities()
		{
			ArrayList toReturn = new ArrayList();



			return toReturn;
		}
		
		/// <summary> Gets an ArrayList of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override ArrayList GetMemberEntityCollections()
		{
			ArrayList toReturn = new ArrayList();
			toReturn.Add(_clientCustomer);
			toReturn.Add(_clientLocator);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 client_ID)
		{
			return FetchUsingPK(product_Year, client_ID, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 client_ID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(product_Year, client_ID, prefetchPathToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 client_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(product_Year, client_ID, prefetchPathToUse, contextToUse);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Product_Year, this.Client_ID, null, null);
		}


		/// <summary> Deletes the Entity from the persistent storage. This method succeeds also when the Entity is not present.</summary>
		/// <param name="deleteRestriction">Predicate expression, meant for concurrency checks in a delete query. Overrules the predicate returned by a set ConcurrencyPredicateFactory object.</param>
		/// <returns>true if Delete succeeded, false otherwise</returns>
		public override bool Delete(IPredicate deleteRestriction)
		{
			bool transactionStartedInThisScope = false;
			Transaction transactionManager = null;
			if((this.LLBLGenProIsInHierarchyOfType==InheritanceHierarchyType.TargetPerEntity) && this.LLBLGenProIsSubType)
			{
				if(!base.ParticipatesInTransaction)
				{
					transactionManager = new Transaction(IsolationLevel.ReadCommitted, "DeleteEntity");
					transactionManager.Add(this);
					transactionStartedInThisScope=true;
				}
			}
			try
			{
				OnDelete();
				IDao dao = CreateDAOInstance();
				bool wasSuccesful = dao.DeleteExisting(base.Fields, base.Transaction, deleteRestriction);
				if(wasSuccesful)
				{
					base.Delete(deleteRestriction);
				}
				if(transactionStartedInThisScope)
				{
					transactionManager.Commit();
				}
				return wasSuccesful;
			}
			catch
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Rollback();
				}
				throw;
			}
			finally
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Dispose();
				}
				OnDeleteComplete();
			}
		}

		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ClientFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ClientFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("ClientEntity", ((TestHarness.DataObjects.EntityType)typeOfEntity).ToString());
		}


		/// <summary> Retrieves all related entities of type 'ClientCustomerEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ClientCustomerEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection GetMultiClientCustomer(bool forceFetch)
		{
			return GetMultiClientCustomer(forceFetch, _clientCustomer.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ClientCustomerEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ClientCustomerEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection GetMultiClientCustomer(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiClientCustomer(forceFetch, _clientCustomer.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ClientCustomerEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection GetMultiClientCustomer(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiClientCustomer(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ClientCustomerEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection GetMultiClientCustomer(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedClientCustomer || forceFetch || _alwaysFetchClientCustomer) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_clientCustomer.ParticipatesInTransaction)
					{
						base.Transaction.Add(_clientCustomer);
					}
				}
				_clientCustomer.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_clientCustomer.EntityFactoryToUse = entityFactoryToUse;
				}
				_clientCustomer.GetMultiManyToOne(this, null, filter);
				_clientCustomer.SuppressClearInGetMulti=false;
				_alreadyFetchedClientCustomer = true;
			}
			return _clientCustomer;
		}

		/// <summary> Sets the collection parameters for the collection for 'ClientCustomer'. These settings will be taken into account
		/// when the property ClientCustomer is requested or GetMultiClientCustomer is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersClientCustomer(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_clientCustomer.SortClauses=sortClauses;
			_clientCustomer.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ClientLocatorEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ClientLocatorEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection GetMultiClientLocator(bool forceFetch)
		{
			return GetMultiClientLocator(forceFetch, _clientLocator.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ClientLocatorEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ClientLocatorEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection GetMultiClientLocator(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiClientLocator(forceFetch, _clientLocator.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ClientLocatorEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection GetMultiClientLocator(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiClientLocator(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ClientLocatorEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection GetMultiClientLocator(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedClientLocator || forceFetch || _alwaysFetchClientLocator) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_clientLocator.ParticipatesInTransaction)
					{
						base.Transaction.Add(_clientLocator);
					}
				}
				_clientLocator.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_clientLocator.EntityFactoryToUse = entityFactoryToUse;
				}
				_clientLocator.GetMultiManyToOne(this, null, filter);
				_clientLocator.SuppressClearInGetMulti=false;
				_alreadyFetchedClientLocator = true;
			}
			return _clientLocator;
		}

		/// <summary> Sets the collection parameters for the collection for 'ClientLocator'. These settings will be taken into account
		/// when the property ClientLocator is requested or GetMultiClientLocator is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersClientLocator(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_clientLocator.SortClauses=sortClauses;
			_clientLocator.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'CustomerNameEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'CustomerNameEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerNameCollection GetMultiCustomerNameCollectionViaClientCustomer(bool forceFetch)
		{
			return GetMultiCustomerNameCollectionViaClientCustomer(forceFetch, _customerNameCollectionViaClientCustomer.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'CustomerNameEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerNameCollection GetMultiCustomerNameCollectionViaClientCustomer(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedCustomerNameCollectionViaClientCustomer || forceFetch || _alwaysFetchCustomerNameCollectionViaClientCustomer) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_customerNameCollectionViaClientCustomer.ParticipatesInTransaction)
					{
						base.Transaction.Add(_customerNameCollectionViaClientCustomer);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(ClientEntity.Relations.ClientCustomerEntityUsingProduct_YearClient_ID, "ClientCustomer_");
				relations.Add(ClientCustomerEntity.Relations.CustomerNameEntityUsingCustomer_ID, "ClientCustomer_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(ClientFieldIndex.Product_Year), ComparisonOperator.Equal, this.Product_Year));
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(ClientFieldIndex.Client_ID), ComparisonOperator.Equal, this.Client_ID));
				_customerNameCollectionViaClientCustomer.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_customerNameCollectionViaClientCustomer.EntityFactoryToUse = entityFactoryToUse;
				}
				_customerNameCollectionViaClientCustomer.GetMulti(filter, relations);
				_customerNameCollectionViaClientCustomer.SuppressClearInGetMulti=false;
				_alreadyFetchedCustomerNameCollectionViaClientCustomer = true;
			}
			return _customerNameCollectionViaClientCustomer;
		}

		/// <summary> Sets the collection parameters for the collection for 'CustomerNameCollectionViaClientCustomer'. These settings will be taken into account
		/// when the property CustomerNameCollectionViaClientCustomer is requested or GetMultiCustomerNameCollectionViaClientCustomer is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersCustomerNameCollectionViaClientCustomer(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_customerNameCollectionViaClientCustomer.SortClauses=sortClauses;
			_customerNameCollectionViaClientCustomer.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'LocatorEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorCollection GetMultiLocatorCollectionViaClientLocator(bool forceFetch)
		{
			return GetMultiLocatorCollectionViaClientLocator(forceFetch, _locatorCollectionViaClientLocator.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'LocatorEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorCollection GetMultiLocatorCollectionViaClientLocator(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedLocatorCollectionViaClientLocator || forceFetch || _alwaysFetchLocatorCollectionViaClientLocator) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorCollectionViaClientLocator.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorCollectionViaClientLocator);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(ClientEntity.Relations.ClientLocatorEntityUsingProduct_YearClient_ID, "ClientLocator_");
				relations.Add(ClientLocatorEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID, "ClientLocator_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(ClientFieldIndex.Product_Year), ComparisonOperator.Equal, this.Product_Year));
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(ClientFieldIndex.Client_ID), ComparisonOperator.Equal, this.Client_ID));
				_locatorCollectionViaClientLocator.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorCollectionViaClientLocator.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorCollectionViaClientLocator.GetMulti(filter, relations);
				_locatorCollectionViaClientLocator.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorCollectionViaClientLocator = true;
			}
			return _locatorCollectionViaClientLocator;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorCollectionViaClientLocator'. These settings will be taken into account
		/// when the property LocatorCollectionViaClientLocator is requested or GetMultiLocatorCollectionViaClientLocator is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorCollectionViaClientLocator(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorCollectionViaClientLocator.SortClauses=sortClauses;
			_locatorCollectionViaClientLocator.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


	
		#region Data binding change event raising methods

		/// <summary> Event thrower for the Product_YearChanged event, which is thrown when Product_Year changes value. Databinding related.</summary>
		protected virtual void OnProduct_YearChanged()
		{
			if(Product_YearChanged!=null)
			{
				Product_YearChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Client_IDChanged event, which is thrown when Client_ID changes value. Databinding related.</summary>
		protected virtual void OnClient_IDChanged()
		{
			if(Client_IDChanged!=null)
			{
				Client_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Client_NameChanged event, which is thrown when Client_Name changes value. Databinding related.</summary>
		protected virtual void OnClient_NameChanged()
		{
			if(Client_NameChanged!=null)
			{
				Client_NameChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Firm_CodeChanged event, which is thrown when Firm_Code changes value. Databinding related.</summary>
		protected virtual void OnFirm_CodeChanged()
		{
			if(Firm_CodeChanged!=null)
			{
				Firm_CodeChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Account_CodeChanged event, which is thrown when Account_Code changes value. Databinding related.</summary>
		protected virtual void OnAccount_CodeChanged()
		{
			if(Account_CodeChanged!=null)
			{
				Account_CodeChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Product_LicenseChanged event, which is thrown when Product_License changes value. Databinding related.</summary>
		protected virtual void OnProduct_LicenseChanged()
		{
			if(Product_LicenseChanged!=null)
			{
				Product_LicenseChanged(this, new EventArgs());
			}
		}

		#endregion
		
		/// <summary> Sets the field on index fieldIndex to the new value value. Marks also the fields object as dirty. </summary>
		/// <param name="fieldIndex">Index of field to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <param name="checkForRefetch">If set to true, it will check if this entity is out of sync and will refetch it first if it is. Use true in normal behavior, false for framework specific code.</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		/// <remarks>Dereferences a related object in an 1:1/m:1 relation if the field is an FK field and responsible for the reference of that particular related object.</remarks>
		/// <exception cref="ArgumentOutOfRangeException">When fieldIndex is smaller than 0 or bigger than the number of fields in the fields collection.</exception>
		protected override bool SetNewFieldValue(int fieldIndex, object value, bool checkForRefetch)
		{
			bool toReturn = base.SetNewFieldValue (fieldIndex, value, checkForRefetch, false);
			if(toReturn)
			{
				switch((ClientFieldIndex)fieldIndex)
				{
					default:
						break;
				}
				base.PostFieldValueSetAction(toReturn);
				switch((ClientFieldIndex)fieldIndex)
				{
					case ClientFieldIndex.Product_Year:
						OnProduct_YearChanged();
						break;
					case ClientFieldIndex.Client_ID:
						OnClient_IDChanged();
						break;
					case ClientFieldIndex.Client_Name:
						OnClient_NameChanged();
						break;
					case ClientFieldIndex.Firm_Code:
						OnFirm_CodeChanged();
						break;
					case ClientFieldIndex.Account_Code:
						OnAccount_CodeChanged();
						break;
					case ClientFieldIndex.Product_License:
						OnProduct_LicenseChanged();
						break;
					default:
						break;
				}
			}
			return toReturn;
		}

		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			ClientDAO dao = (ClientDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_clientCustomer.ActiveContext = base.ActiveContext;
			_clientLocator.ActiveContext = base.ActiveContext;
			_customerNameCollectionViaClientCustomer.ActiveContext = base.ActiveContext;
			_locatorCollectionViaClientLocator.ActiveContext = base.ActiveContext;



		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			ClientDAO dao = (ClientDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			ClientDAO dao = (ClientDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction, updateRestriction);
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validatorToUse">Validator to use.</param>
		protected virtual void InitClassEmpty(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IValidator validatorToUse)
		{
			base.Fields = CreateFields();
			base.IsNew=true;
			base.EntityFactoryToUse = entityFactoryToUse;
			base.Validator = validatorToUse;

			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END
			

		}

		/// <summary> A method which calls all OnFieldnameChanged methods to signal that the field has been changed
		/// to bound controls. This is required after a RollbackFields() call.</summary>
		protected override void FlagAllFieldsAsChanged()
		{
			OnProduct_YearChanged();
			OnClient_IDChanged();
			OnClient_NameChanged();
			OnFirm_CodeChanged();
			OnAccount_CodeChanged();
			OnProduct_LicenseChanged();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.ClientEntity);
		}

		/// <summary>Creates field validator object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IValidator CreateValidator()
		{
			return new ClientValidator();
		}


		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validator">The validator object for this ClientEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int16 product_Year, System.Int32 client_ID, IValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);

			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(product_Year, client_ID, prefetchPathToUse, null);
			base.IsNew = !wasSuccesful;
			base.Validator = validator;
			base.EntityFactoryToUse = entityFactoryToUse;

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

		}

		/// <summary> Initializes the class members</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		private void InitClassMembers(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			_clientCustomer = new TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection(propertyDescriptorFactoryToUse, new ClientCustomerEntityFactory());
			_clientCustomer.SetContainingEntityInfo(this, "Client");
			_alwaysFetchClientCustomer = false;
			_alreadyFetchedClientCustomer = false;
			_clientLocator = new TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection(propertyDescriptorFactoryToUse, new ClientLocatorEntityFactory());
			_clientLocator.SetContainingEntityInfo(this, "Client");
			_alwaysFetchClientLocator = false;
			_alreadyFetchedClientLocator = false;
			_customerNameCollectionViaClientCustomer = new TestHarness.DataObjects.CollectionClasses.CustomerNameCollection(propertyDescriptorFactoryToUse, new CustomerNameEntityFactory());
			_alwaysFetchCustomerNameCollectionViaClientCustomer = false;
			_alreadyFetchedCustomerNameCollectionViaClientCustomer = false;
			_locatorCollectionViaClientLocator = new TestHarness.DataObjects.CollectionClasses.LocatorCollection(propertyDescriptorFactoryToUse, new LocatorEntityFactory());
			_alwaysFetchLocatorCollectionViaClientLocator = false;
			_alreadyFetchedLocatorCollectionViaClientLocator = false;


			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();

			Hashtable fieldHashtable = null;
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Product_Year", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Client_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Client_Name", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Firm_Code", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Account_Code", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Product_License", fieldHashtable);
		}
		#endregion




		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="product_Year">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="client_ID">PK value for Client which data should be fetched into this Client object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int16 product_Year, System.Int32 client_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)ClientFieldIndex.Product_Year].ForcedCurrentValueWrite(product_Year);
				base.Fields[(int)ClientFieldIndex.Client_ID].ForcedCurrentValueWrite(client_ID);
				dao.FetchExisting(this, base.Transaction, prefetchPathToUse, contextToUse);
				bool fetchResult = false;
				if(base.Fields.State == EntityState.Fetched)
				{
					base.IsNew = false;
					fetchResult = true;
					if(contextToUse!=null)
					{
						base.ActiveContext = contextToUse;
						IEntity dummy = contextToUse.Get(this);
					}
				}
				return fetchResult;
			}
			finally
			{
				OnFetchComplete();
			}
		}


		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateClientDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactoryInstance()
		{
			return new ClientEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ClientRelations Relations
		{
			get	{ return new ClientRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ClientCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathClientCustomer
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection(),
					ClientEntity.Relations.ClientCustomerEntityUsingProduct_YearClient_ID, 
					(int)TestHarness.DataObjects.EntityType.ClientEntity, (int)TestHarness.DataObjects.EntityType.ClientCustomerEntity, 0, null, null, null, "ClientCustomer", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ClientLocator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathClientLocator
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection(),
					ClientEntity.Relations.ClientLocatorEntityUsingProduct_YearClient_ID, 
					(int)TestHarness.DataObjects.EntityType.ClientEntity, (int)TestHarness.DataObjects.EntityType.ClientLocatorEntity, 0, null, null, null, "ClientLocator", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'CustomerName' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCustomerNameCollectionViaClientCustomer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(ClientEntity.Relations.ClientCustomerEntityUsingProduct_YearClient_ID);
				relations.Add(ClientCustomerEntity.Relations.CustomerNameEntityUsingCustomer_ID);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.CustomerNameCollection(),
					ClientEntity.Relations.ClientCustomerEntityUsingProduct_YearClient_ID,
					(int)TestHarness.DataObjects.EntityType.ClientEntity, (int)TestHarness.DataObjects.EntityType.CustomerNameEntity, 0, null, null, relations, "CustomerNameCollectionViaClientCustomer", RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Locator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorCollectionViaClientLocator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(ClientEntity.Relations.ClientLocatorEntityUsingProduct_YearClient_ID);
				relations.Add(ClientLocatorEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorCollection(),
					ClientEntity.Relations.ClientLocatorEntityUsingProduct_YearClient_ID,
					(int)TestHarness.DataObjects.EntityType.ClientEntity, (int)TestHarness.DataObjects.EntityType.LocatorEntity, 0, null, null, relations, "LocatorCollectionViaClientLocator", RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return ClientEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Hashtable FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable FieldsCustomPropertiesOfType
		{
			get { return ClientEntity.FieldsCustomProperties;}
		}

		/// <summary> The Product_Year property of the Entity Client<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Client"."Product_Year"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int16 Product_Year
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)ClientFieldIndex.Product_Year);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int16));
				}
				return (System.Int16)valueToReturn;
			}
			set	{ SetNewFieldValue((int)ClientFieldIndex.Product_Year, value); }
		}
		/// <summary> The Client_ID property of the Entity Client<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Client"."Client_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Client_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)ClientFieldIndex.Client_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)ClientFieldIndex.Client_ID, value); }
		}
		/// <summary> The Client_Name property of the Entity Client<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Client"."Client_Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Client_Name
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)ClientFieldIndex.Client_Name);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)ClientFieldIndex.Client_Name, value); }
		}
		/// <summary> The Firm_Code property of the Entity Client<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Client"."Firm_Code"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Firm_Code
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)ClientFieldIndex.Firm_Code);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)ClientFieldIndex.Firm_Code, value); }
		}
		/// <summary> The Account_Code property of the Entity Client<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Client"."Account_Code"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Account_Code
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)ClientFieldIndex.Account_Code);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)ClientFieldIndex.Account_Code, value); }
		}
		/// <summary> The Product_License property of the Entity Client<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Client"."Product_License"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Product_License
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)ClientFieldIndex.Product_License);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)ClientFieldIndex.Product_License, value); }
		}

		/// <summary> Retrieves all related entities of type 'ClientCustomerEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiClientCustomer()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection ClientCustomer
		{
			get	{ return GetMultiClientCustomer(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ClientCustomer. When set to true, ClientCustomer is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ClientCustomer is accessed. You can always execute
		/// a forced fetch by calling GetMultiClientCustomer(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchClientCustomer
		{
			get	{ return _alwaysFetchClientCustomer; }
			set	{ _alwaysFetchClientCustomer = value; }	
		}
		/// <summary> Retrieves all related entities of type 'ClientLocatorEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiClientLocator()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection ClientLocator
		{
			get	{ return GetMultiClientLocator(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ClientLocator. When set to true, ClientLocator is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ClientLocator is accessed. You can always execute
		/// a forced fetch by calling GetMultiClientLocator(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchClientLocator
		{
			get	{ return _alwaysFetchClientLocator; }
			set	{ _alwaysFetchClientLocator = value; }	
		}

		/// <summary> Retrieves all related entities of type 'CustomerNameEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiCustomerNameCollectionViaClientCustomer()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.CustomerNameCollection CustomerNameCollectionViaClientCustomer
		{
			get { return GetMultiCustomerNameCollectionViaClientCustomer(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for CustomerNameCollectionViaClientCustomer. When set to true, CustomerNameCollectionViaClientCustomer is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time CustomerNameCollectionViaClientCustomer is accessed. You can always execute
		/// a forced fetch by calling GetMultiCustomerNameCollectionViaClientCustomer(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCustomerNameCollectionViaClientCustomer
		{
			get	{ return _alwaysFetchCustomerNameCollectionViaClientCustomer; }
			set	{ _alwaysFetchCustomerNameCollectionViaClientCustomer = value; }	
		}
		/// <summary> Retrieves all related entities of type 'LocatorEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorCollectionViaClientLocator()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorCollection LocatorCollectionViaClientLocator
		{
			get { return GetMultiLocatorCollectionViaClientLocator(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorCollectionViaClientLocator. When set to true, LocatorCollectionViaClientLocator is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorCollectionViaClientLocator is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorCollectionViaClientLocator(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorCollectionViaClientLocator
		{
			get	{ return _alwaysFetchLocatorCollectionViaClientLocator; }
			set	{ _alwaysFetchLocatorCollectionViaClientLocator = value; }	
		}




		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary>Returns the EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)TestHarness.DataObjects.EntityType.ClientEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Included code

		#endregion
	}
}
