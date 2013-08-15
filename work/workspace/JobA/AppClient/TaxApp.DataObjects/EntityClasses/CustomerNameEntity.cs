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
	/// Entity class which represents the entity 'CustomerName'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerNameEntity : EntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection	_clientCustomer;
		private bool	_alwaysFetchClientCustomer, _alreadyFetchedClientCustomer;
		private TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection	_customerLocatorAuthorization;
		private bool	_alwaysFetchCustomerLocatorAuthorization, _alreadyFetchedCustomerLocatorAuthorization;
		private TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection	_customerNamespaceAuthorization;
		private bool	_alwaysFetchCustomerNamespaceAuthorization, _alreadyFetchedCustomerNamespaceAuthorization;
		private TestHarness.DataObjects.CollectionClasses.ClientCollection _clientCollectionViaClientCustomer;
		private bool	_alwaysFetchClientCollectionViaClientCustomer, _alreadyFetchedClientCollectionViaClientCustomer;
		private TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection _enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization;
		private bool	_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization, _alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization;
		private TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection _enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization;
		private bool	_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization, _alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization;



		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region DataBinding Change Event Handler Declarations
		/// <summary>Event which is thrown when Customer_ID changes value. Databinding related.</summary>
		public event EventHandler Customer_IDChanged;
		/// <summary>Event which is thrown when WindowsDomainLogin changes value. Databinding related.</summary>
		public event EventHandler WindowsDomainLoginChanged;
		/// <summary>Event which is thrown when AlternateLogin changes value. Databinding related.</summary>
		public event EventHandler AlternateLoginChanged;
		/// <summary>Event which is thrown when FirstName changes value. Databinding related.</summary>
		public event EventHandler FirstNameChanged;
		/// <summary>Event which is thrown when LastName changes value. Databinding related.</summary>
		public event EventHandler LastNameChanged;
		/// <summary>Event which is thrown when IsAdministrator changes value. Databinding related.</summary>
		public event EventHandler IsAdministratorChanged;

		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerNameEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public CustomerNameEntity()
		{
			InitClassEmpty(new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), CreateValidator());
		}


		/// <summary>CTor</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		public CustomerNameEntity(System.Int32 customer_ID)
		{
			InitClassFetch(customer_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public CustomerNameEntity(System.Int32 customer_ID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(customer_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <param name="validator">The custom validator object for this CustomerNameEntity</param>
		public CustomerNameEntity(System.Int32 customer_ID, CustomerNameValidator validator)
		{
			InitClassFetch(customer_ID, validator, new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <param name="validator">The custom validator object for this CustomerNameEntity</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public CustomerNameEntity(System.Int32 customer_ID, CustomerNameValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassFetch(customer_ID, validator, propertyDescriptorFactoryToUse, entityFactoryToUse, null);
		}

		/// <summary>CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public CustomerNameEntity(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassEmpty(propertyDescriptorFactoryToUse, entityFactoryToUse, CreateValidator());
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CustomerNameEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_clientCustomer = (TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection)info.GetValue("_clientCustomer", typeof(TestHarness.DataObjects.CollectionClasses.ClientCustomerCollection));
			_alwaysFetchClientCustomer = info.GetBoolean("_alwaysFetchClientCustomer");
			_alreadyFetchedClientCustomer = info.GetBoolean("_alreadyFetchedClientCustomer");
			_customerLocatorAuthorization = (TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection)info.GetValue("_customerLocatorAuthorization", typeof(TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection));
			_alwaysFetchCustomerLocatorAuthorization = info.GetBoolean("_alwaysFetchCustomerLocatorAuthorization");
			_alreadyFetchedCustomerLocatorAuthorization = info.GetBoolean("_alreadyFetchedCustomerLocatorAuthorization");
			_customerNamespaceAuthorization = (TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection)info.GetValue("_customerNamespaceAuthorization", typeof(TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection));
			_alwaysFetchCustomerNamespaceAuthorization = info.GetBoolean("_alwaysFetchCustomerNamespaceAuthorization");
			_alreadyFetchedCustomerNamespaceAuthorization = info.GetBoolean("_alreadyFetchedCustomerNamespaceAuthorization");
			_clientCollectionViaClientCustomer = (TestHarness.DataObjects.CollectionClasses.ClientCollection)info.GetValue("_clientCollectionViaClientCustomer", typeof(TestHarness.DataObjects.CollectionClasses.ClientCollection));
			_alwaysFetchClientCollectionViaClientCustomer = info.GetBoolean("_alwaysFetchClientCollectionViaClientCustomer");
			_alreadyFetchedClientCollectionViaClientCustomer = info.GetBoolean("_alreadyFetchedClientCollectionViaClientCustomer");
			_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = (TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection)info.GetValue("_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization", typeof(TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection));
			_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = info.GetBoolean("_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization");
			_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = info.GetBoolean("_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization");
			_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = (TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection)info.GetValue("_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization", typeof(TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection));
			_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = info.GetBoolean("_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization");
			_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = info.GetBoolean("_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization");


			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary> Will perform post-ReadXml actions as well as the normal ReadXml() actions, performed by the base class.</summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element of the entity's Xml data</param>
		public override void ReadXml(System.Xml.XmlNode node)
		{
			base.ReadXml (node);
			_alreadyFetchedClientCustomer = (_clientCustomer.Count > 0);
			_alreadyFetchedCustomerLocatorAuthorization = (_customerLocatorAuthorization.Count > 0);
			_alreadyFetchedCustomerNamespaceAuthorization = (_customerNamespaceAuthorization.Count > 0);
			_alreadyFetchedClientCollectionViaClientCustomer = (_clientCollectionViaClientCustomer.Count > 0);
			_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = (_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.Count > 0);
			_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = (_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.Count > 0);


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
			info.AddValue("_customerLocatorAuthorization", _customerLocatorAuthorization);
			info.AddValue("_alwaysFetchCustomerLocatorAuthorization", _alwaysFetchCustomerLocatorAuthorization);
			info.AddValue("_alreadyFetchedCustomerLocatorAuthorization", _alreadyFetchedCustomerLocatorAuthorization);
			info.AddValue("_customerNamespaceAuthorization", _customerNamespaceAuthorization);
			info.AddValue("_alwaysFetchCustomerNamespaceAuthorization", _alwaysFetchCustomerNamespaceAuthorization);
			info.AddValue("_alreadyFetchedCustomerNamespaceAuthorization", _alreadyFetchedCustomerNamespaceAuthorization);
			info.AddValue("_clientCollectionViaClientCustomer", _clientCollectionViaClientCustomer);
			info.AddValue("_alwaysFetchClientCollectionViaClientCustomer", _alwaysFetchClientCollectionViaClientCustomer);
			info.AddValue("_alreadyFetchedClientCollectionViaClientCustomer", _alreadyFetchedClientCollectionViaClientCustomer);
			info.AddValue("_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization", _enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization);
			info.AddValue("_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization", _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization);
			info.AddValue("_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization", _alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization);
			info.AddValue("_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization", _enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization);
			info.AddValue("_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization", _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization);
			info.AddValue("_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization", _alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization);


			
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
				case "CustomerLocatorAuthorization":
					_alreadyFetchedCustomerLocatorAuthorization = true;
					if(entity!=null)
					{
						this.CustomerLocatorAuthorization.Add((CustomerLocatorAuthorizationEntity)entity);
					}
					break;
				case "CustomerNamespaceAuthorization":
					_alreadyFetchedCustomerNamespaceAuthorization = true;
					if(entity!=null)
					{
						this.CustomerNamespaceAuthorization.Add((CustomerNamespaceAuthorizationEntity)entity);
					}
					break;
				case "ClientCollectionViaClientCustomer":
					_alreadyFetchedClientCollectionViaClientCustomer = true;
					if(entity!=null)
					{
						this.ClientCollectionViaClientCustomer.Add((ClientEntity)entity);
					}
					break;
				case "Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization":
					_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = true;
					if(entity!=null)
					{
						this.Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.Add((Enum_AuthorizationTypeEntity)entity);
					}
					break;
				case "Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization":
					_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = true;
					if(entity!=null)
					{
						this.Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.Add((Enum_AuthorizationTypeEntity)entity);
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
				case "CustomerLocatorAuthorization":
					_customerLocatorAuthorization.Add(relatedEntity);
					break;
				case "CustomerNamespaceAuthorization":
					_customerNamespaceAuthorization.Add(relatedEntity);
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
				case "CustomerLocatorAuthorization":
					_customerLocatorAuthorization.Remove(relatedEntity);
					break;
				case "CustomerNamespaceAuthorization":
					_customerNamespaceAuthorization.Remove(relatedEntity);
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
			toReturn.Add(_customerLocatorAuthorization);
			toReturn.Add(_customerNamespaceAuthorization);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 customer_ID)
		{
			return FetchUsingPK(customer_ID, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 customer_ID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(customer_ID, prefetchPathToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 customer_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(customer_ID, prefetchPathToUse, contextToUse);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Customer_ID, null, null);
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
		public bool TestOriginalFieldValueForNull(CustomerNameFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerNameFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("CustomerNameEntity", ((TestHarness.DataObjects.EntityType)typeOfEntity).ToString());
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
				_clientCustomer.GetMultiManyToOne(null, this, filter);
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

		/// <summary> Retrieves all related entities of type 'CustomerLocatorAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'CustomerLocatorAuthorizationEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection GetMultiCustomerLocatorAuthorization(bool forceFetch)
		{
			return GetMultiCustomerLocatorAuthorization(forceFetch, _customerLocatorAuthorization.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CustomerLocatorAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'CustomerLocatorAuthorizationEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection GetMultiCustomerLocatorAuthorization(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiCustomerLocatorAuthorization(forceFetch, _customerLocatorAuthorization.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'CustomerLocatorAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection GetMultiCustomerLocatorAuthorization(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiCustomerLocatorAuthorization(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CustomerLocatorAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection GetMultiCustomerLocatorAuthorization(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedCustomerLocatorAuthorization || forceFetch || _alwaysFetchCustomerLocatorAuthorization) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_customerLocatorAuthorization.ParticipatesInTransaction)
					{
						base.Transaction.Add(_customerLocatorAuthorization);
					}
				}
				_customerLocatorAuthorization.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_customerLocatorAuthorization.EntityFactoryToUse = entityFactoryToUse;
				}
				_customerLocatorAuthorization.GetMultiManyToOne(this, null, filter);
				_customerLocatorAuthorization.SuppressClearInGetMulti=false;
				_alreadyFetchedCustomerLocatorAuthorization = true;
			}
			return _customerLocatorAuthorization;
		}

		/// <summary> Sets the collection parameters for the collection for 'CustomerLocatorAuthorization'. These settings will be taken into account
		/// when the property CustomerLocatorAuthorization is requested or GetMultiCustomerLocatorAuthorization is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersCustomerLocatorAuthorization(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_customerLocatorAuthorization.SortClauses=sortClauses;
			_customerLocatorAuthorization.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'CustomerNamespaceAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'CustomerNamespaceAuthorizationEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection GetMultiCustomerNamespaceAuthorization(bool forceFetch)
		{
			return GetMultiCustomerNamespaceAuthorization(forceFetch, _customerNamespaceAuthorization.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CustomerNamespaceAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'CustomerNamespaceAuthorizationEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection GetMultiCustomerNamespaceAuthorization(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiCustomerNamespaceAuthorization(forceFetch, _customerNamespaceAuthorization.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'CustomerNamespaceAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection GetMultiCustomerNamespaceAuthorization(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiCustomerNamespaceAuthorization(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CustomerNamespaceAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection GetMultiCustomerNamespaceAuthorization(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedCustomerNamespaceAuthorization || forceFetch || _alwaysFetchCustomerNamespaceAuthorization) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_customerNamespaceAuthorization.ParticipatesInTransaction)
					{
						base.Transaction.Add(_customerNamespaceAuthorization);
					}
				}
				_customerNamespaceAuthorization.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_customerNamespaceAuthorization.EntityFactoryToUse = entityFactoryToUse;
				}
				_customerNamespaceAuthorization.GetMultiManyToOne(this, null, filter);
				_customerNamespaceAuthorization.SuppressClearInGetMulti=false;
				_alreadyFetchedCustomerNamespaceAuthorization = true;
			}
			return _customerNamespaceAuthorization;
		}

		/// <summary> Sets the collection parameters for the collection for 'CustomerNamespaceAuthorization'. These settings will be taken into account
		/// when the property CustomerNamespaceAuthorization is requested or GetMultiCustomerNamespaceAuthorization is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersCustomerNamespaceAuthorization(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_customerNamespaceAuthorization.SortClauses=sortClauses;
			_customerNamespaceAuthorization.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ClientEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ClientEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientCollection GetMultiClientCollectionViaClientCustomer(bool forceFetch)
		{
			return GetMultiClientCollectionViaClientCustomer(forceFetch, _clientCollectionViaClientCustomer.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'ClientEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientCollection GetMultiClientCollectionViaClientCustomer(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedClientCollectionViaClientCustomer || forceFetch || _alwaysFetchClientCollectionViaClientCustomer) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_clientCollectionViaClientCustomer.ParticipatesInTransaction)
					{
						base.Transaction.Add(_clientCollectionViaClientCustomer);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(CustomerNameEntity.Relations.ClientCustomerEntityUsingCustomer_ID, "ClientCustomer_");
				relations.Add(ClientCustomerEntity.Relations.ClientEntityUsingProduct_YearClient_ID, "ClientCustomer_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(CustomerNameFieldIndex.Customer_ID), ComparisonOperator.Equal, this.Customer_ID));
				_clientCollectionViaClientCustomer.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_clientCollectionViaClientCustomer.EntityFactoryToUse = entityFactoryToUse;
				}
				_clientCollectionViaClientCustomer.GetMulti(filter, relations);
				_clientCollectionViaClientCustomer.SuppressClearInGetMulti=false;
				_alreadyFetchedClientCollectionViaClientCustomer = true;
			}
			return _clientCollectionViaClientCustomer;
		}

		/// <summary> Sets the collection parameters for the collection for 'ClientCollectionViaClientCustomer'. These settings will be taken into account
		/// when the property ClientCollectionViaClientCustomer is requested or GetMultiClientCollectionViaClientCustomer is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersClientCollectionViaClientCustomer(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_clientCollectionViaClientCustomer.SortClauses=sortClauses;
			_clientCollectionViaClientCustomer.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'Enum_AuthorizationTypeEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'Enum_AuthorizationTypeEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection GetMultiEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization(bool forceFetch)
		{
			return GetMultiEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization(forceFetch, _enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'Enum_AuthorizationTypeEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection GetMultiEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization || forceFetch || _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.ParticipatesInTransaction)
					{
						base.Transaction.Add(_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(CustomerNameEntity.Relations.CustomerLocatorAuthorizationEntityUsingCustomer_ID, "CustomerLocatorAuthorization_");
				relations.Add(CustomerLocatorAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue, "CustomerLocatorAuthorization_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(CustomerNameFieldIndex.Customer_ID), ComparisonOperator.Equal, this.Customer_ID));
				_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.EntityFactoryToUse = entityFactoryToUse;
				}
				_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.GetMulti(filter, relations);
				_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.SuppressClearInGetMulti=false;
				_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = true;
			}
			return _enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization;
		}

		/// <summary> Sets the collection parameters for the collection for 'Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization'. These settings will be taken into account
		/// when the property Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization is requested or GetMultiEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.SortClauses=sortClauses;
			_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'Enum_AuthorizationTypeEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'Enum_AuthorizationTypeEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection GetMultiEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization(bool forceFetch)
		{
			return GetMultiEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization(forceFetch, _enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'Enum_AuthorizationTypeEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection GetMultiEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization || forceFetch || _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.ParticipatesInTransaction)
					{
						base.Transaction.Add(_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(CustomerNameEntity.Relations.CustomerNamespaceAuthorizationEntityUsingCustomer_ID, "CustomerNamespaceAuthorization_");
				relations.Add(CustomerNamespaceAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue, "CustomerNamespaceAuthorization_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(CustomerNameFieldIndex.Customer_ID), ComparisonOperator.Equal, this.Customer_ID));
				_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.EntityFactoryToUse = entityFactoryToUse;
				}
				_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.GetMulti(filter, relations);
				_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.SuppressClearInGetMulti=false;
				_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = true;
			}
			return _enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization;
		}

		/// <summary> Sets the collection parameters for the collection for 'Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization'. These settings will be taken into account
		/// when the property Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization is requested or GetMultiEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.SortClauses=sortClauses;
			_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


	
		#region Data binding change event raising methods

		/// <summary> Event thrower for the Customer_IDChanged event, which is thrown when Customer_ID changes value. Databinding related.</summary>
		protected virtual void OnCustomer_IDChanged()
		{
			if(Customer_IDChanged!=null)
			{
				Customer_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the WindowsDomainLoginChanged event, which is thrown when WindowsDomainLogin changes value. Databinding related.</summary>
		protected virtual void OnWindowsDomainLoginChanged()
		{
			if(WindowsDomainLoginChanged!=null)
			{
				WindowsDomainLoginChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the AlternateLoginChanged event, which is thrown when AlternateLogin changes value. Databinding related.</summary>
		protected virtual void OnAlternateLoginChanged()
		{
			if(AlternateLoginChanged!=null)
			{
				AlternateLoginChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the FirstNameChanged event, which is thrown when FirstName changes value. Databinding related.</summary>
		protected virtual void OnFirstNameChanged()
		{
			if(FirstNameChanged!=null)
			{
				FirstNameChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the LastNameChanged event, which is thrown when LastName changes value. Databinding related.</summary>
		protected virtual void OnLastNameChanged()
		{
			if(LastNameChanged!=null)
			{
				LastNameChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the IsAdministratorChanged event, which is thrown when IsAdministrator changes value. Databinding related.</summary>
		protected virtual void OnIsAdministratorChanged()
		{
			if(IsAdministratorChanged!=null)
			{
				IsAdministratorChanged(this, new EventArgs());
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
				switch((CustomerNameFieldIndex)fieldIndex)
				{
					default:
						break;
				}
				base.PostFieldValueSetAction(toReturn);
				switch((CustomerNameFieldIndex)fieldIndex)
				{
					case CustomerNameFieldIndex.Customer_ID:
						OnCustomer_IDChanged();
						break;
					case CustomerNameFieldIndex.WindowsDomainLogin:
						OnWindowsDomainLoginChanged();
						break;
					case CustomerNameFieldIndex.AlternateLogin:
						OnAlternateLoginChanged();
						break;
					case CustomerNameFieldIndex.FirstName:
						OnFirstNameChanged();
						break;
					case CustomerNameFieldIndex.LastName:
						OnLastNameChanged();
						break;
					case CustomerNameFieldIndex.IsAdministrator:
						OnIsAdministratorChanged();
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
			CustomerNameDAO dao = (CustomerNameDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_clientCustomer.ActiveContext = base.ActiveContext;
			_customerLocatorAuthorization.ActiveContext = base.ActiveContext;
			_customerNamespaceAuthorization.ActiveContext = base.ActiveContext;
			_clientCollectionViaClientCustomer.ActiveContext = base.ActiveContext;
			_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization.ActiveContext = base.ActiveContext;
			_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization.ActiveContext = base.ActiveContext;



		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			CustomerNameDAO dao = (CustomerNameDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			CustomerNameDAO dao = (CustomerNameDAO)CreateDAOInstance();
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
			OnCustomer_IDChanged();
			OnWindowsDomainLoginChanged();
			OnAlternateLoginChanged();
			OnFirstNameChanged();
			OnLastNameChanged();
			OnIsAdministratorChanged();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.CustomerNameEntity);
		}

		/// <summary>Creates field validator object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IValidator CreateValidator()
		{
			return new CustomerNameValidator();
		}


		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validator">The validator object for this CustomerNameEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 customer_ID, IValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);

			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(customer_ID, prefetchPathToUse, null);
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
			_clientCustomer.SetContainingEntityInfo(this, "CustomerName");
			_alwaysFetchClientCustomer = false;
			_alreadyFetchedClientCustomer = false;
			_customerLocatorAuthorization = new TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection(propertyDescriptorFactoryToUse, new CustomerLocatorAuthorizationEntityFactory());
			_customerLocatorAuthorization.SetContainingEntityInfo(this, "CustomerName");
			_alwaysFetchCustomerLocatorAuthorization = false;
			_alreadyFetchedCustomerLocatorAuthorization = false;
			_customerNamespaceAuthorization = new TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection(propertyDescriptorFactoryToUse, new CustomerNamespaceAuthorizationEntityFactory());
			_customerNamespaceAuthorization.SetContainingEntityInfo(this, "CustomerName");
			_alwaysFetchCustomerNamespaceAuthorization = false;
			_alreadyFetchedCustomerNamespaceAuthorization = false;
			_clientCollectionViaClientCustomer = new TestHarness.DataObjects.CollectionClasses.ClientCollection(propertyDescriptorFactoryToUse, new ClientEntityFactory());
			_alwaysFetchClientCollectionViaClientCustomer = false;
			_alreadyFetchedClientCollectionViaClientCustomer = false;
			_enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = new TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection(propertyDescriptorFactoryToUse, new Enum_AuthorizationTypeEntityFactory());
			_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = false;
			_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = false;
			_enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = new TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection(propertyDescriptorFactoryToUse, new Enum_AuthorizationTypeEntityFactory());
			_alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = false;
			_alreadyFetchedEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = false;


			
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

			_fieldsCustomProperties.Add("Customer_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("WindowsDomainLogin", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AlternateLogin", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsAdministrator", fieldHashtable);
		}
		#endregion




		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="customer_ID">PK value for CustomerName which data should be fetched into this CustomerName object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 customer_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)CustomerNameFieldIndex.Customer_ID].ForcedCurrentValueWrite(customer_ID);
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
			return DAOFactory.CreateCustomerNameDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactoryInstance()
		{
			return new CustomerNameEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static CustomerNameRelations Relations
		{
			get	{ return new CustomerNameRelations(); }
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
					CustomerNameEntity.Relations.ClientCustomerEntityUsingCustomer_ID, 
					(int)TestHarness.DataObjects.EntityType.CustomerNameEntity, (int)TestHarness.DataObjects.EntityType.ClientCustomerEntity, 0, null, null, null, "ClientCustomer", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'CustomerLocatorAuthorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCustomerLocatorAuthorization
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection(),
					CustomerNameEntity.Relations.CustomerLocatorAuthorizationEntityUsingCustomer_ID, 
					(int)TestHarness.DataObjects.EntityType.CustomerNameEntity, (int)TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity, 0, null, null, null, "CustomerLocatorAuthorization", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'CustomerNamespaceAuthorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCustomerNamespaceAuthorization
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection(),
					CustomerNameEntity.Relations.CustomerNamespaceAuthorizationEntityUsingCustomer_ID, 
					(int)TestHarness.DataObjects.EntityType.CustomerNameEntity, (int)TestHarness.DataObjects.EntityType.CustomerNamespaceAuthorizationEntity, 0, null, null, null, "CustomerNamespaceAuthorization", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Client' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathClientCollectionViaClientCustomer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(CustomerNameEntity.Relations.ClientCustomerEntityUsingCustomer_ID);
				relations.Add(ClientCustomerEntity.Relations.ClientEntityUsingProduct_YearClient_ID);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.ClientCollection(),
					CustomerNameEntity.Relations.ClientCustomerEntityUsingCustomer_ID,
					(int)TestHarness.DataObjects.EntityType.CustomerNameEntity, (int)TestHarness.DataObjects.EntityType.ClientEntity, 0, null, null, relations, "ClientCollectionViaClientCustomer", RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_AuthorizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(CustomerNameEntity.Relations.CustomerLocatorAuthorizationEntityUsingCustomer_ID);
				relations.Add(CustomerLocatorAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection(),
					CustomerNameEntity.Relations.CustomerLocatorAuthorizationEntityUsingCustomer_ID,
					(int)TestHarness.DataObjects.EntityType.CustomerNameEntity, (int)TestHarness.DataObjects.EntityType.Enum_AuthorizationTypeEntity, 0, null, null, relations, "Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization", RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_AuthorizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(CustomerNameEntity.Relations.CustomerNamespaceAuthorizationEntityUsingCustomer_ID);
				relations.Add(CustomerNamespaceAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection(),
					CustomerNameEntity.Relations.CustomerNamespaceAuthorizationEntityUsingCustomer_ID,
					(int)TestHarness.DataObjects.EntityType.CustomerNameEntity, (int)TestHarness.DataObjects.EntityType.Enum_AuthorizationTypeEntity, 0, null, null, relations, "Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization", RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return CustomerNameEntity.CustomProperties;}
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
			get { return CustomerNameEntity.FieldsCustomProperties;}
		}

		/// <summary> The Customer_ID property of the Entity CustomerName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerName"."Customer_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Customer_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerNameFieldIndex.Customer_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerNameFieldIndex.Customer_ID, value); }
		}
		/// <summary> The WindowsDomainLogin property of the Entity CustomerName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerName"."WindowsDomainLogin"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String WindowsDomainLogin
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerNameFieldIndex.WindowsDomainLogin);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerNameFieldIndex.WindowsDomainLogin, value); }
		}
		/// <summary> The AlternateLogin property of the Entity CustomerName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerName"."AlternateLogin"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AlternateLogin
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerNameFieldIndex.AlternateLogin);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerNameFieldIndex.AlternateLogin, value); }
		}
		/// <summary> The FirstName property of the Entity CustomerName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerName"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FirstName
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerNameFieldIndex.FirstName);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerNameFieldIndex.FirstName, value); }
		}
		/// <summary> The LastName property of the Entity CustomerName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerName"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LastName
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerNameFieldIndex.LastName);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerNameFieldIndex.LastName, value); }
		}
		/// <summary> The IsAdministrator property of the Entity CustomerName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerName"."IsAdministrator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Boolean IsAdministrator
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerNameFieldIndex.IsAdministrator);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				return (System.Boolean)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerNameFieldIndex.IsAdministrator, value); }
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
		/// <summary> Retrieves all related entities of type 'CustomerLocatorAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiCustomerLocatorAuthorization()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.CustomerLocatorAuthorizationCollection CustomerLocatorAuthorization
		{
			get	{ return GetMultiCustomerLocatorAuthorization(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for CustomerLocatorAuthorization. When set to true, CustomerLocatorAuthorization is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time CustomerLocatorAuthorization is accessed. You can always execute
		/// a forced fetch by calling GetMultiCustomerLocatorAuthorization(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCustomerLocatorAuthorization
		{
			get	{ return _alwaysFetchCustomerLocatorAuthorization; }
			set	{ _alwaysFetchCustomerLocatorAuthorization = value; }	
		}
		/// <summary> Retrieves all related entities of type 'CustomerNamespaceAuthorizationEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiCustomerNamespaceAuthorization()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.CustomerNamespaceAuthorizationCollection CustomerNamespaceAuthorization
		{
			get	{ return GetMultiCustomerNamespaceAuthorization(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for CustomerNamespaceAuthorization. When set to true, CustomerNamespaceAuthorization is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time CustomerNamespaceAuthorization is accessed. You can always execute
		/// a forced fetch by calling GetMultiCustomerNamespaceAuthorization(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCustomerNamespaceAuthorization
		{
			get	{ return _alwaysFetchCustomerNamespaceAuthorization; }
			set	{ _alwaysFetchCustomerNamespaceAuthorization = value; }	
		}

		/// <summary> Retrieves all related entities of type 'ClientEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiClientCollectionViaClientCustomer()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.ClientCollection ClientCollectionViaClientCustomer
		{
			get { return GetMultiClientCollectionViaClientCustomer(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ClientCollectionViaClientCustomer. When set to true, ClientCollectionViaClientCustomer is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ClientCollectionViaClientCustomer is accessed. You can always execute
		/// a forced fetch by calling GetMultiClientCollectionViaClientCustomer(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchClientCollectionViaClientCustomer
		{
			get	{ return _alwaysFetchClientCollectionViaClientCustomer; }
			set	{ _alwaysFetchClientCollectionViaClientCustomer = value; }	
		}
		/// <summary> Retrieves all related entities of type 'Enum_AuthorizationTypeEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization
		{
			get { return GetMultiEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization. When set to true, Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization is accessed. You can always execute
		/// a forced fetch by calling GetMultiEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization
		{
			get	{ return _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization; }
			set	{ _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerLocatorAuthorization = value; }	
		}
		/// <summary> Retrieves all related entities of type 'Enum_AuthorizationTypeEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization
		{
			get { return GetMultiEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization. When set to true, Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization is accessed. You can always execute
		/// a forced fetch by calling GetMultiEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization
		{
			get	{ return _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization; }
			set	{ _alwaysFetchEnum_AuthorizationTypeCollectionViaCustomerNamespaceAuthorization = value; }	
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
			get { return (int)TestHarness.DataObjects.EntityType.CustomerNameEntity; }
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
