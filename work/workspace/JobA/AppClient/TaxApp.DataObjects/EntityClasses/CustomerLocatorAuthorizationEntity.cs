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
	/// Entity class which represents the entity 'CustomerLocatorAuthorization'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerLocatorAuthorizationEntity : EntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations


		private CustomerNameEntity _customerName;
		private bool	_alwaysFetchCustomerName, _alreadyFetchedCustomerName, _customerNameReturnsNewIfNotFound;
		private Enum_AuthorizationTypeEntity _enum_AuthorizationType;
		private bool	_alwaysFetchEnum_AuthorizationType, _alreadyFetchedEnum_AuthorizationType, _enum_AuthorizationTypeReturnsNewIfNotFound;


		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region DataBinding Change Event Handler Declarations
		/// <summary>Event which is thrown when Product_Year changes value. Databinding related.</summary>
		public event EventHandler Product_YearChanged;
		/// <summary>Event which is thrown when Customer_ID changes value. Databinding related.</summary>
		public event EventHandler Customer_IDChanged;
		/// <summary>Event which is thrown when Authorized_Locator_ID changes value. Databinding related.</summary>
		public event EventHandler Authorized_Locator_IDChanged;
		/// <summary>Event which is thrown when AuthorizationType_EnumValue changes value. Databinding related.</summary>
		public event EventHandler AuthorizationType_EnumValueChanged;

		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerLocatorAuthorizationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public CustomerLocatorAuthorizationEntity()
		{
			InitClassEmpty(new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), CreateValidator());
		}


		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		public CustomerLocatorAuthorizationEntity(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID)
		{
			InitClassFetch(product_Year, customer_ID, authorized_Locator_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public CustomerLocatorAuthorizationEntity(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(product_Year, customer_ID, authorized_Locator_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="validator">The custom validator object for this CustomerLocatorAuthorizationEntity</param>
		public CustomerLocatorAuthorizationEntity(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID, CustomerLocatorAuthorizationValidator validator)
		{
			InitClassFetch(product_Year, customer_ID, authorized_Locator_ID, validator, new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="validator">The custom validator object for this CustomerLocatorAuthorizationEntity</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public CustomerLocatorAuthorizationEntity(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID, CustomerLocatorAuthorizationValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassFetch(product_Year, customer_ID, authorized_Locator_ID, validator, propertyDescriptorFactoryToUse, entityFactoryToUse, null);
		}

		/// <summary>CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public CustomerLocatorAuthorizationEntity(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassEmpty(propertyDescriptorFactoryToUse, entityFactoryToUse, CreateValidator());
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CustomerLocatorAuthorizationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{


			_customerName = (CustomerNameEntity)info.GetValue("_customerName", typeof(CustomerNameEntity));
			if(_customerName!=null)
			{
				_customerName.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_customerNameReturnsNewIfNotFound = info.GetBoolean("_customerNameReturnsNewIfNotFound");
			_alwaysFetchCustomerName = info.GetBoolean("_alwaysFetchCustomerName");
			_alreadyFetchedCustomerName = info.GetBoolean("_alreadyFetchedCustomerName");
			_enum_AuthorizationType = (Enum_AuthorizationTypeEntity)info.GetValue("_enum_AuthorizationType", typeof(Enum_AuthorizationTypeEntity));
			if(_enum_AuthorizationType!=null)
			{
				_enum_AuthorizationType.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_enum_AuthorizationTypeReturnsNewIfNotFound = info.GetBoolean("_enum_AuthorizationTypeReturnsNewIfNotFound");
			_alwaysFetchEnum_AuthorizationType = info.GetBoolean("_alwaysFetchEnum_AuthorizationType");
			_alreadyFetchedEnum_AuthorizationType = info.GetBoolean("_alreadyFetchedEnum_AuthorizationType");

			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary> Will perform post-ReadXml actions as well as the normal ReadXml() actions, performed by the base class.</summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element of the entity's Xml data</param>
		public override void ReadXml(System.Xml.XmlNode node)
		{
			base.ReadXml (node);


			_alreadyFetchedCustomerName = (_customerName != null);
			_alreadyFetchedEnum_AuthorizationType = (_enum_AuthorizationType != null);

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


			info.AddValue("_customerName", _customerName);
			info.AddValue("_customerNameReturnsNewIfNotFound", _customerNameReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchCustomerName", _alwaysFetchCustomerName);
			info.AddValue("_alreadyFetchedCustomerName", _alreadyFetchedCustomerName);
			info.AddValue("_enum_AuthorizationType", _enum_AuthorizationType);
			info.AddValue("_enum_AuthorizationTypeReturnsNewIfNotFound", _enum_AuthorizationTypeReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchEnum_AuthorizationType", _alwaysFetchEnum_AuthorizationType);
			info.AddValue("_alreadyFetchedEnum_AuthorizationType", _alreadyFetchedEnum_AuthorizationType);

			
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
				case "CustomerName":
					_alreadyFetchedCustomerName = true;
					this.CustomerName = (CustomerNameEntity)entity;
					break;
				case "Enum_AuthorizationType":
					_alreadyFetchedEnum_AuthorizationType = true;
					this.Enum_AuthorizationType = (Enum_AuthorizationTypeEntity)entity;
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
				case "CustomerName":
					SetupSyncCustomerName(relatedEntity);
					break;
				case "Enum_AuthorizationType":
					SetupSyncEnum_AuthorizationType(relatedEntity);
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
				case "CustomerName":
					DesetupSyncCustomerName(false);
					break;
				case "Enum_AuthorizationType":
					DesetupSyncEnum_AuthorizationType(false);
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
			if(_customerName!=null)
			{
				toReturn.Add(_customerName);
			}
			if(_enum_AuthorizationType!=null)
			{
				toReturn.Add(_enum_AuthorizationType);
			}


			return toReturn;
		}
		
		/// <summary> Gets an ArrayList of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override ArrayList GetMemberEntityCollections()
		{
			ArrayList toReturn = new ArrayList();


			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID)
		{
			return FetchUsingPK(product_Year, customer_ID, authorized_Locator_ID, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(product_Year, customer_ID, authorized_Locator_ID, prefetchPathToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(product_Year, customer_ID, authorized_Locator_ID, prefetchPathToUse, contextToUse);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Product_Year, this.Customer_ID, this.Authorized_Locator_ID, null, null);
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
		public bool TestOriginalFieldValueForNull(CustomerLocatorAuthorizationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerLocatorAuthorizationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("CustomerLocatorAuthorizationEntity", ((TestHarness.DataObjects.EntityType)typeOfEntity).ToString());
		}




		/// <summary> Retrieves the related entity of type 'CustomerNameEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'CustomerNameEntity' which is related to this entity.</returns>
		public CustomerNameEntity GetSingleCustomerName()
		{
			return GetSingleCustomerName(false);
		}

		/// <summary> Retrieves the related entity of type 'CustomerNameEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'CustomerNameEntity' which is related to this entity.</returns>
		public virtual CustomerNameEntity GetSingleCustomerName(bool forceFetch)
		{
 			if( ( !_alreadyFetchedCustomerName || forceFetch || _alwaysFetchCustomerName) && !base.IsSerializing && !base.IsDeserializing )
			{

				CustomerNameEntity newEntity = new CustomerNameEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = newEntity.FetchUsingPK(this.Customer_ID);
				if(!_customerNameReturnsNewIfNotFound && !fetchResult)
				{
					this.CustomerName = null;
				}
				else
				{
					if((base.ActiveContext!=null)&&fetchResult)
					{
						newEntity = (CustomerNameEntity)base.ActiveContext.Get(newEntity);
					}
					this.CustomerName = newEntity;
					_alreadyFetchedCustomerName = fetchResult;
				}
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _customerName;
		}

		/// <summary> Retrieves the related entity of type 'Enum_AuthorizationTypeEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'Enum_AuthorizationTypeEntity' which is related to this entity.</returns>
		public Enum_AuthorizationTypeEntity GetSingleEnum_AuthorizationType()
		{
			return GetSingleEnum_AuthorizationType(false);
		}

		/// <summary> Retrieves the related entity of type 'Enum_AuthorizationTypeEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'Enum_AuthorizationTypeEntity' which is related to this entity.</returns>
		public virtual Enum_AuthorizationTypeEntity GetSingleEnum_AuthorizationType(bool forceFetch)
		{
 			if( ( !_alreadyFetchedEnum_AuthorizationType || forceFetch || _alwaysFetchEnum_AuthorizationType) && !base.IsSerializing && !base.IsDeserializing )
			{

				Enum_AuthorizationTypeEntity newEntity = new Enum_AuthorizationTypeEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = newEntity.FetchUsingPK(this.AuthorizationType_EnumValue);
				if(!_enum_AuthorizationTypeReturnsNewIfNotFound && !fetchResult)
				{
					this.Enum_AuthorizationType = null;
				}
				else
				{
					if((base.ActiveContext!=null)&&fetchResult)
					{
						newEntity = (Enum_AuthorizationTypeEntity)base.ActiveContext.Get(newEntity);
					}
					this.Enum_AuthorizationType = newEntity;
					_alreadyFetchedEnum_AuthorizationType = fetchResult;
				}
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _enum_AuthorizationType;
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

		/// <summary> Event thrower for the Customer_IDChanged event, which is thrown when Customer_ID changes value. Databinding related.</summary>
		protected virtual void OnCustomer_IDChanged()
		{
			if(Customer_IDChanged!=null)
			{
				Customer_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Authorized_Locator_IDChanged event, which is thrown when Authorized_Locator_ID changes value. Databinding related.</summary>
		protected virtual void OnAuthorized_Locator_IDChanged()
		{
			if(Authorized_Locator_IDChanged!=null)
			{
				Authorized_Locator_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the AuthorizationType_EnumValueChanged event, which is thrown when AuthorizationType_EnumValue changes value. Databinding related.</summary>
		protected virtual void OnAuthorizationType_EnumValueChanged()
		{
			if(AuthorizationType_EnumValueChanged!=null)
			{
				AuthorizationType_EnumValueChanged(this, new EventArgs());
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
				switch((CustomerLocatorAuthorizationFieldIndex)fieldIndex)
				{
					case CustomerLocatorAuthorizationFieldIndex.Customer_ID:
						DecoupleEventsCustomerName();
						_customerName = null;
						_alreadyFetchedCustomerName = false;
						break;
					case CustomerLocatorAuthorizationFieldIndex.AuthorizationType_EnumValue:
						DecoupleEventsEnum_AuthorizationType();
						_enum_AuthorizationType = null;
						_alreadyFetchedEnum_AuthorizationType = false;
						break;
					default:
						break;
				}
				base.PostFieldValueSetAction(toReturn);
				switch((CustomerLocatorAuthorizationFieldIndex)fieldIndex)
				{
					case CustomerLocatorAuthorizationFieldIndex.Product_Year:
						OnProduct_YearChanged();
						break;
					case CustomerLocatorAuthorizationFieldIndex.Customer_ID:
						OnCustomer_IDChanged();
						break;
					case CustomerLocatorAuthorizationFieldIndex.Authorized_Locator_ID:
						OnAuthorized_Locator_IDChanged();
						break;
					case CustomerLocatorAuthorizationFieldIndex.AuthorizationType_EnumValue:
						OnAuthorizationType_EnumValueChanged();
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
			CustomerLocatorAuthorizationDAO dao = (CustomerLocatorAuthorizationDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerName!=null)
			{
				_customerName.ActiveContext = base.ActiveContext;
			}
			if(_enum_AuthorizationType!=null)
			{
				_enum_AuthorizationType.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			CustomerLocatorAuthorizationDAO dao = (CustomerLocatorAuthorizationDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			CustomerLocatorAuthorizationDAO dao = (CustomerLocatorAuthorizationDAO)CreateDAOInstance();
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
			OnCustomer_IDChanged();
			OnAuthorized_Locator_IDChanged();
			OnAuthorizationType_EnumValueChanged();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity);
		}

		/// <summary>Creates field validator object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IValidator CreateValidator()
		{
			return new CustomerLocatorAuthorizationValidator();
		}


		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validator">The validator object for this CustomerLocatorAuthorizationEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID, IValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);

			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(product_Year, customer_ID, authorized_Locator_ID, prefetchPathToUse, null);
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


			_customerName = null;
			_customerNameReturnsNewIfNotFound = true;
			_alwaysFetchCustomerName = false;
			_alreadyFetchedCustomerName = false;
			_enum_AuthorizationType = null;
			_enum_AuthorizationTypeReturnsNewIfNotFound = true;
			_alwaysFetchEnum_AuthorizationType = false;
			_alreadyFetchedEnum_AuthorizationType = false;

			
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

			_fieldsCustomProperties.Add("Customer_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Authorized_Locator_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AuthorizationType_EnumValue", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _customerName</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		private void DesetupSyncCustomerName(bool signalRelatedEntity)
		{
			if(_customerName != null)
			{

				_customerName.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("CustomerName", _customerName, CustomerLocatorAuthorizationEntity.Relations.CustomerNameEntityUsingCustomer_ID);
				if(signalRelatedEntity)
				{
					_customerName.UnsetRelatedEntity(this, "CustomerLocatorAuthorization");
				}
				SetNewFieldValue((int)CustomerLocatorAuthorizationFieldIndex.Customer_ID, null, false);
				_customerName = null;
			}
		}
		
		/// <summary> Decouples events from member _customerName</summary>
		private void DecoupleEventsCustomerName()
		{
			if(_customerName != null)
			{

				
				_customerName.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("CustomerName", _customerName, CustomerLocatorAuthorizationEntity.Relations.CustomerNameEntityUsingCustomer_ID);
			}
		}
		
		/// <summary> setups the sync logic for member _customerName</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerName(IEntity relatedEntity)
		{
			DesetupSyncCustomerName(true);
			if(relatedEntity!=null)
			{
				_customerName = (CustomerNameEntity)relatedEntity;
				_customerName.ActiveContext = base.ActiveContext;
				_alreadyFetchedCustomerName = true;
				_customerName.AfterSave+=new EventHandler(OnEntityAfterSave);
				base.SetEntitySyncInformation("CustomerName", _customerName, CustomerLocatorAuthorizationEntity.Relations.CustomerNameEntityUsingCustomer_ID);

			}
			else
			{
				_alreadyFetchedCustomerName = false;
			}
		}

		/// <summary> Removes the sync logic for member _enum_AuthorizationType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		private void DesetupSyncEnum_AuthorizationType(bool signalRelatedEntity)
		{
			if(_enum_AuthorizationType != null)
			{

				_enum_AuthorizationType.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_AuthorizationType", _enum_AuthorizationType, CustomerLocatorAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue);
				if(signalRelatedEntity)
				{
					_enum_AuthorizationType.UnsetRelatedEntity(this, "CustomerLocatorAuthorization");
				}
				SetNewFieldValue((int)CustomerLocatorAuthorizationFieldIndex.AuthorizationType_EnumValue, null, false);
				_enum_AuthorizationType = null;
			}
		}
		
		/// <summary> Decouples events from member _enum_AuthorizationType</summary>
		private void DecoupleEventsEnum_AuthorizationType()
		{
			if(_enum_AuthorizationType != null)
			{

				
				_enum_AuthorizationType.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_AuthorizationType", _enum_AuthorizationType, CustomerLocatorAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue);
			}
		}
		
		/// <summary> setups the sync logic for member _enum_AuthorizationType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEnum_AuthorizationType(IEntity relatedEntity)
		{
			DesetupSyncEnum_AuthorizationType(true);
			if(relatedEntity!=null)
			{
				_enum_AuthorizationType = (Enum_AuthorizationTypeEntity)relatedEntity;
				_enum_AuthorizationType.ActiveContext = base.ActiveContext;
				_alreadyFetchedEnum_AuthorizationType = true;
				_enum_AuthorizationType.AfterSave+=new EventHandler(OnEntityAfterSave);
				base.SetEntitySyncInformation("Enum_AuthorizationType", _enum_AuthorizationType, CustomerLocatorAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue);

			}
			else
			{
				_alreadyFetchedEnum_AuthorizationType = false;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="product_Year">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="customer_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="authorized_Locator_ID">PK value for CustomerLocatorAuthorization which data should be fetched into this CustomerLocatorAuthorization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int16 product_Year, System.Int32 customer_ID, System.Int32 authorized_Locator_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)CustomerLocatorAuthorizationFieldIndex.Product_Year].ForcedCurrentValueWrite(product_Year);
				base.Fields[(int)CustomerLocatorAuthorizationFieldIndex.Customer_ID].ForcedCurrentValueWrite(customer_ID);
				base.Fields[(int)CustomerLocatorAuthorizationFieldIndex.Authorized_Locator_ID].ForcedCurrentValueWrite(authorized_Locator_ID);
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
			return DAOFactory.CreateCustomerLocatorAuthorizationDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactoryInstance()
		{
			return new CustomerLocatorAuthorizationEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static CustomerLocatorAuthorizationRelations Relations
		{
			get	{ return new CustomerLocatorAuthorizationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'CustomerName' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCustomerName
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.CustomerNameCollection(),
					CustomerLocatorAuthorizationEntity.Relations.CustomerNameEntityUsingCustomer_ID, 
					(int)TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity, (int)TestHarness.DataObjects.EntityType.CustomerNameEntity, 0, null, null, null, "CustomerName", RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_AuthorizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_AuthorizationType
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_AuthorizationTypeCollection(),
					CustomerLocatorAuthorizationEntity.Relations.Enum_AuthorizationTypeEntityUsingAuthorizationType_EnumValue, 
					(int)TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity, (int)TestHarness.DataObjects.EntityType.Enum_AuthorizationTypeEntity, 0, null, null, null, "Enum_AuthorizationType", RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return CustomerLocatorAuthorizationEntity.CustomProperties;}
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
			get { return CustomerLocatorAuthorizationEntity.FieldsCustomProperties;}
		}

		/// <summary> The Product_Year property of the Entity CustomerLocatorAuthorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerLocatorAuthorization"."Product_Year"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int16 Product_Year
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerLocatorAuthorizationFieldIndex.Product_Year);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int16));
				}
				return (System.Int16)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerLocatorAuthorizationFieldIndex.Product_Year, value); }
		}
		/// <summary> The Customer_ID property of the Entity CustomerLocatorAuthorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerLocatorAuthorization"."Customer_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 Customer_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerLocatorAuthorizationFieldIndex.Customer_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerLocatorAuthorizationFieldIndex.Customer_ID, value); }
		}
		/// <summary> The Authorized_Locator_ID property of the Entity CustomerLocatorAuthorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerLocatorAuthorization"."Authorized_Locator_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 Authorized_Locator_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerLocatorAuthorizationFieldIndex.Authorized_Locator_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerLocatorAuthorizationFieldIndex.Authorized_Locator_ID, value); }
		}
		/// <summary> The AuthorizationType_EnumValue property of the Entity CustomerLocatorAuthorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CustomerLocatorAuthorization"."AuthorizationType_EnumValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte AuthorizationType_EnumValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)CustomerLocatorAuthorizationFieldIndex.AuthorizationType_EnumValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				return (System.Byte)valueToReturn;
			}
			set	{ SetNewFieldValue((int)CustomerLocatorAuthorizationFieldIndex.AuthorizationType_EnumValue, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerNameEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleCustomerName()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual CustomerNameEntity CustomerName
		{
			get	{ return GetSingleCustomerName(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerName(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerName != null)
						{
							_customerName.UnsetRelatedEntity(this, "CustomerLocatorAuthorization");
						}
					}
					else
					{
						((IEntity)value).SetRelatedEntity(this, "CustomerLocatorAuthorization");
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for CustomerName. When set to true, CustomerName is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time CustomerName is accessed. You can always execute
		/// a forced fetch by calling GetSingleCustomerName(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCustomerName
		{
			get	{ return _alwaysFetchCustomerName; }
			set	{ _alwaysFetchCustomerName = value; }	
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property CustomerName is not found
		/// in the database. When set to true, CustomerName will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool CustomerNameReturnsNewIfNotFound
		{
			get	{ return _customerNameReturnsNewIfNotFound; }
			set { _customerNameReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'Enum_AuthorizationTypeEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleEnum_AuthorizationType()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual Enum_AuthorizationTypeEntity Enum_AuthorizationType
		{
			get	{ return GetSingleEnum_AuthorizationType(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEnum_AuthorizationType(value);
				}
				else
				{
					if(value==null)
					{
						if(_enum_AuthorizationType != null)
						{
							_enum_AuthorizationType.UnsetRelatedEntity(this, "CustomerLocatorAuthorization");
						}
					}
					else
					{
						((IEntity)value).SetRelatedEntity(this, "CustomerLocatorAuthorization");
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_AuthorizationType. When set to true, Enum_AuthorizationType is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_AuthorizationType is accessed. You can always execute
		/// a forced fetch by calling GetSingleEnum_AuthorizationType(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_AuthorizationType
		{
			get	{ return _alwaysFetchEnum_AuthorizationType; }
			set	{ _alwaysFetchEnum_AuthorizationType = value; }	
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Enum_AuthorizationType is not found
		/// in the database. When set to true, Enum_AuthorizationType will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool Enum_AuthorizationTypeReturnsNewIfNotFound
		{
			get	{ return _enum_AuthorizationTypeReturnsNewIfNotFound; }
			set { _enum_AuthorizationTypeReturnsNewIfNotFound = value; }	
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
			get { return (int)TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity; }
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
