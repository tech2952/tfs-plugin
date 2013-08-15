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
	/// Entity class which represents the entity 'LocatorObjectRecord'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LocatorObjectRecordEntity : EntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection	_locatorObjectValue;
		private bool	_alwaysFetchLocatorObjectValue, _alreadyFetchedLocatorObjectValue;
		private TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection _enum_DataSourceCollectionViaLocatorObjectValue;
		private bool	_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue, _alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue;
		private Enum_DataSourceEntity _enum_DataSource;
		private bool	_alwaysFetchEnum_DataSource, _alreadyFetchedEnum_DataSource, _enum_DataSourceReturnsNewIfNotFound;
		private Enum_DataTypeEntity _enum_DataType;
		private bool	_alwaysFetchEnum_DataType, _alreadyFetchedEnum_DataType, _enum_DataTypeReturnsNewIfNotFound;
		private LocatorEntity _locator;
		private bool	_alwaysFetchLocator, _alreadyFetchedLocator, _locatorReturnsNewIfNotFound;


		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region DataBinding Change Event Handler Declarations
		/// <summary>Event which is thrown when Product_Year changes value. Databinding related.</summary>
		public event EventHandler Product_YearChanged;
		/// <summary>Event which is thrown when Locator_ID changes value. Databinding related.</summary>
		public event EventHandler Locator_IDChanged;
		/// <summary>Event which is thrown when Page_ID changes value. Databinding related.</summary>
		public event EventHandler Page_IDChanged;
		/// <summary>Event which is thrown when Record_ID changes value. Databinding related.</summary>
		public event EventHandler Record_IDChanged;
		/// <summary>Event which is thrown when GraphicObject_ID changes value. Databinding related.</summary>
		public event EventHandler GraphicObject_IDChanged;
		/// <summary>Event which is thrown when DataType_EnumValue changes value. Databinding related.</summary>
		public event EventHandler DataType_EnumValueChanged;
		/// <summary>Event which is thrown when Row_DisplayOrder changes value. Databinding related.</summary>
		public event EventHandler Row_DisplayOrderChanged;
		/// <summary>Event which is thrown when Record_Lineage changes value. Databinding related.</summary>
		public event EventHandler Record_LineageChanged;
		/// <summary>Event which is thrown when DatasourceUsed changes value. Databinding related.</summary>
		public event EventHandler DatasourceUsedChanged;

		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LocatorObjectRecordEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public LocatorObjectRecordEntity()
		{
			InitClassEmpty(new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), CreateValidator());
		}


		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		public LocatorObjectRecordEntity(System.Int32 record_ID)
		{
			InitClassFetch(record_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public LocatorObjectRecordEntity(System.Int32 record_ID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(record_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <param name="validator">The custom validator object for this LocatorObjectRecordEntity</param>
		public LocatorObjectRecordEntity(System.Int32 record_ID, LocatorObjectRecordValidator validator)
		{
			InitClassFetch(record_ID, validator, new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <param name="validator">The custom validator object for this LocatorObjectRecordEntity</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public LocatorObjectRecordEntity(System.Int32 record_ID, LocatorObjectRecordValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassFetch(record_ID, validator, propertyDescriptorFactoryToUse, entityFactoryToUse, null);
		}

		/// <summary>CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public LocatorObjectRecordEntity(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassEmpty(propertyDescriptorFactoryToUse, entityFactoryToUse, CreateValidator());
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LocatorObjectRecordEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_locatorObjectValue = (TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection)info.GetValue("_locatorObjectValue", typeof(TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection));
			_alwaysFetchLocatorObjectValue = info.GetBoolean("_alwaysFetchLocatorObjectValue");
			_alreadyFetchedLocatorObjectValue = info.GetBoolean("_alreadyFetchedLocatorObjectValue");
			_enum_DataSourceCollectionViaLocatorObjectValue = (TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection)info.GetValue("_enum_DataSourceCollectionViaLocatorObjectValue", typeof(TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection));
			_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue = info.GetBoolean("_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue");
			_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue = info.GetBoolean("_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue");
			_enum_DataSource = (Enum_DataSourceEntity)info.GetValue("_enum_DataSource", typeof(Enum_DataSourceEntity));
			if(_enum_DataSource!=null)
			{
				_enum_DataSource.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_enum_DataSourceReturnsNewIfNotFound = info.GetBoolean("_enum_DataSourceReturnsNewIfNotFound");
			_alwaysFetchEnum_DataSource = info.GetBoolean("_alwaysFetchEnum_DataSource");
			_alreadyFetchedEnum_DataSource = info.GetBoolean("_alreadyFetchedEnum_DataSource");
			_enum_DataType = (Enum_DataTypeEntity)info.GetValue("_enum_DataType", typeof(Enum_DataTypeEntity));
			if(_enum_DataType!=null)
			{
				_enum_DataType.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_enum_DataTypeReturnsNewIfNotFound = info.GetBoolean("_enum_DataTypeReturnsNewIfNotFound");
			_alwaysFetchEnum_DataType = info.GetBoolean("_alwaysFetchEnum_DataType");
			_alreadyFetchedEnum_DataType = info.GetBoolean("_alreadyFetchedEnum_DataType");
			_locator = (LocatorEntity)info.GetValue("_locator", typeof(LocatorEntity));
			if(_locator!=null)
			{
				_locator.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_locatorReturnsNewIfNotFound = info.GetBoolean("_locatorReturnsNewIfNotFound");
			_alwaysFetchLocator = info.GetBoolean("_alwaysFetchLocator");
			_alreadyFetchedLocator = info.GetBoolean("_alreadyFetchedLocator");

			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary> Will perform post-ReadXml actions as well as the normal ReadXml() actions, performed by the base class.</summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element of the entity's Xml data</param>
		public override void ReadXml(System.Xml.XmlNode node)
		{
			base.ReadXml (node);
			_alreadyFetchedLocatorObjectValue = (_locatorObjectValue.Count > 0);
			_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue = (_enum_DataSourceCollectionViaLocatorObjectValue.Count > 0);
			_alreadyFetchedEnum_DataSource = (_enum_DataSource != null);
			_alreadyFetchedEnum_DataType = (_enum_DataType != null);
			_alreadyFetchedLocator = (_locator != null);

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
			info.AddValue("_locatorObjectValue", _locatorObjectValue);
			info.AddValue("_alwaysFetchLocatorObjectValue", _alwaysFetchLocatorObjectValue);
			info.AddValue("_alreadyFetchedLocatorObjectValue", _alreadyFetchedLocatorObjectValue);
			info.AddValue("_enum_DataSourceCollectionViaLocatorObjectValue", _enum_DataSourceCollectionViaLocatorObjectValue);
			info.AddValue("_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue", _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue);
			info.AddValue("_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue", _alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue);
			info.AddValue("_enum_DataSource", _enum_DataSource);
			info.AddValue("_enum_DataSourceReturnsNewIfNotFound", _enum_DataSourceReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchEnum_DataSource", _alwaysFetchEnum_DataSource);
			info.AddValue("_alreadyFetchedEnum_DataSource", _alreadyFetchedEnum_DataSource);
			info.AddValue("_enum_DataType", _enum_DataType);
			info.AddValue("_enum_DataTypeReturnsNewIfNotFound", _enum_DataTypeReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchEnum_DataType", _alwaysFetchEnum_DataType);
			info.AddValue("_alreadyFetchedEnum_DataType", _alreadyFetchedEnum_DataType);
			info.AddValue("_locator", _locator);
			info.AddValue("_locatorReturnsNewIfNotFound", _locatorReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchLocator", _alwaysFetchLocator);
			info.AddValue("_alreadyFetchedLocator", _alreadyFetchedLocator);

			
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
				case "Enum_DataSource":
					_alreadyFetchedEnum_DataSource = true;
					this.Enum_DataSource = (Enum_DataSourceEntity)entity;
					break;
				case "Enum_DataType":
					_alreadyFetchedEnum_DataType = true;
					this.Enum_DataType = (Enum_DataTypeEntity)entity;
					break;
				case "Locator":
					_alreadyFetchedLocator = true;
					this.Locator = (LocatorEntity)entity;
					break;
				case "LocatorObjectValue":
					_alreadyFetchedLocatorObjectValue = true;
					if(entity!=null)
					{
						this.LocatorObjectValue.Add((LocatorObjectValueEntity)entity);
					}
					break;
				case "Enum_DataSourceCollectionViaLocatorObjectValue":
					_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue = true;
					if(entity!=null)
					{
						this.Enum_DataSourceCollectionViaLocatorObjectValue.Add((Enum_DataSourceEntity)entity);
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
				case "Enum_DataSource":
					SetupSyncEnum_DataSource(relatedEntity);
					break;
				case "Enum_DataType":
					SetupSyncEnum_DataType(relatedEntity);
					break;
				case "Locator":
					SetupSyncLocator(relatedEntity);
					break;
				case "LocatorObjectValue":
					_locatorObjectValue.Add(relatedEntity);
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
				case "Enum_DataSource":
					DesetupSyncEnum_DataSource(false);
					break;
				case "Enum_DataType":
					DesetupSyncEnum_DataType(false);
					break;
				case "Locator":
					DesetupSyncLocator(false);
					break;
				case "LocatorObjectValue":
					_locatorObjectValue.Remove(relatedEntity);
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
			if(_enum_DataSource!=null)
			{
				toReturn.Add(_enum_DataSource);
			}
			if(_enum_DataType!=null)
			{
				toReturn.Add(_enum_DataType);
			}
			if(_locator!=null)
			{
				toReturn.Add(_locator);
			}


			return toReturn;
		}
		
		/// <summary> Gets an ArrayList of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override ArrayList GetMemberEntityCollections()
		{
			ArrayList toReturn = new ArrayList();
			toReturn.Add(_locatorObjectValue);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 record_ID)
		{
			return FetchUsingPK(record_ID, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 record_ID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(record_ID, prefetchPathToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 record_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(record_ID, prefetchPathToUse, contextToUse);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Record_ID, null, null);
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
		public bool TestOriginalFieldValueForNull(LocatorObjectRecordFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(LocatorObjectRecordFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("LocatorObjectRecordEntity", ((TestHarness.DataObjects.EntityType)typeOfEntity).ToString());
		}


		/// <summary> Retrieves all related entities of type 'LocatorObjectValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorObjectValueEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection GetMultiLocatorObjectValue(bool forceFetch)
		{
			return GetMultiLocatorObjectValue(forceFetch, _locatorObjectValue.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'LocatorObjectValueEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection GetMultiLocatorObjectValue(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiLocatorObjectValue(forceFetch, _locatorObjectValue.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection GetMultiLocatorObjectValue(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiLocatorObjectValue(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection GetMultiLocatorObjectValue(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedLocatorObjectValue || forceFetch || _alwaysFetchLocatorObjectValue) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorObjectValue.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorObjectValue);
					}
				}
				_locatorObjectValue.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorObjectValue.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorObjectValue.GetMultiManyToOne(null, this, filter);
				_locatorObjectValue.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorObjectValue = true;
			}
			return _locatorObjectValue;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorObjectValue'. These settings will be taken into account
		/// when the property LocatorObjectValue is requested or GetMultiLocatorObjectValue is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorObjectValue(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorObjectValue.SortClauses=sortClauses;
			_locatorObjectValue.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'Enum_DataSourceEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'Enum_DataSourceEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection GetMultiEnum_DataSourceCollectionViaLocatorObjectValue(bool forceFetch)
		{
			return GetMultiEnum_DataSourceCollectionViaLocatorObjectValue(forceFetch, _enum_DataSourceCollectionViaLocatorObjectValue.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'Enum_DataSourceEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection GetMultiEnum_DataSourceCollectionViaLocatorObjectValue(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue || forceFetch || _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_enum_DataSourceCollectionViaLocatorObjectValue.ParticipatesInTransaction)
					{
						base.Transaction.Add(_enum_DataSourceCollectionViaLocatorObjectValue);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(LocatorObjectRecordEntity.Relations.LocatorObjectValueEntityUsingRecord_ID, "LocatorObjectValue_");
				relations.Add(LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue, "LocatorObjectValue_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Record_ID), ComparisonOperator.Equal, this.Record_ID));
				_enum_DataSourceCollectionViaLocatorObjectValue.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_enum_DataSourceCollectionViaLocatorObjectValue.EntityFactoryToUse = entityFactoryToUse;
				}
				_enum_DataSourceCollectionViaLocatorObjectValue.GetMulti(filter, relations);
				_enum_DataSourceCollectionViaLocatorObjectValue.SuppressClearInGetMulti=false;
				_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue = true;
			}
			return _enum_DataSourceCollectionViaLocatorObjectValue;
		}

		/// <summary> Sets the collection parameters for the collection for 'Enum_DataSourceCollectionViaLocatorObjectValue'. These settings will be taken into account
		/// when the property Enum_DataSourceCollectionViaLocatorObjectValue is requested or GetMultiEnum_DataSourceCollectionViaLocatorObjectValue is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersEnum_DataSourceCollectionViaLocatorObjectValue(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_enum_DataSourceCollectionViaLocatorObjectValue.SortClauses=sortClauses;
			_enum_DataSourceCollectionViaLocatorObjectValue.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves the related entity of type 'Enum_DataSourceEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'Enum_DataSourceEntity' which is related to this entity.</returns>
		public Enum_DataSourceEntity GetSingleEnum_DataSource()
		{
			return GetSingleEnum_DataSource(false);
		}

		/// <summary> Retrieves the related entity of type 'Enum_DataSourceEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'Enum_DataSourceEntity' which is related to this entity.</returns>
		public virtual Enum_DataSourceEntity GetSingleEnum_DataSource(bool forceFetch)
		{
 			if( ( !_alreadyFetchedEnum_DataSource || forceFetch || _alwaysFetchEnum_DataSource) && !base.IsSerializing && !base.IsDeserializing )
			{

				Enum_DataSourceEntity newEntity = new Enum_DataSourceEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = newEntity.FetchUsingPK(this.DatasourceUsed);
				if(!_enum_DataSourceReturnsNewIfNotFound && !fetchResult)
				{
					this.Enum_DataSource = null;
				}
				else
				{
					if((base.ActiveContext!=null)&&fetchResult)
					{
						newEntity = (Enum_DataSourceEntity)base.ActiveContext.Get(newEntity);
					}
					this.Enum_DataSource = newEntity;
					_alreadyFetchedEnum_DataSource = fetchResult;
				}
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _enum_DataSource;
		}

		/// <summary> Retrieves the related entity of type 'Enum_DataTypeEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'Enum_DataTypeEntity' which is related to this entity.</returns>
		public Enum_DataTypeEntity GetSingleEnum_DataType()
		{
			return GetSingleEnum_DataType(false);
		}

		/// <summary> Retrieves the related entity of type 'Enum_DataTypeEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'Enum_DataTypeEntity' which is related to this entity.</returns>
		public virtual Enum_DataTypeEntity GetSingleEnum_DataType(bool forceFetch)
		{
 			if( ( !_alreadyFetchedEnum_DataType || forceFetch || _alwaysFetchEnum_DataType) && !base.IsSerializing && !base.IsDeserializing )
			{

				Enum_DataTypeEntity newEntity = new Enum_DataTypeEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = newEntity.FetchUsingPK(this.DataType_EnumValue);
				if(!_enum_DataTypeReturnsNewIfNotFound && !fetchResult)
				{
					this.Enum_DataType = null;
				}
				else
				{
					if((base.ActiveContext!=null)&&fetchResult)
					{
						newEntity = (Enum_DataTypeEntity)base.ActiveContext.Get(newEntity);
					}
					this.Enum_DataType = newEntity;
					_alreadyFetchedEnum_DataType = fetchResult;
				}
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _enum_DataType;
		}

		/// <summary> Retrieves the related entity of type 'LocatorEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'LocatorEntity' which is related to this entity.</returns>
		public LocatorEntity GetSingleLocator()
		{
			return GetSingleLocator(false);
		}

		/// <summary> Retrieves the related entity of type 'LocatorEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'LocatorEntity' which is related to this entity.</returns>
		public virtual LocatorEntity GetSingleLocator(bool forceFetch)
		{
 			if( ( !_alreadyFetchedLocator || forceFetch || _alwaysFetchLocator) && !base.IsSerializing && !base.IsDeserializing )
			{

				LocatorEntity newEntity = new LocatorEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = newEntity.FetchUsingPK(this.Product_Year, this.Locator_ID);
				if(!_locatorReturnsNewIfNotFound && !fetchResult)
				{
					this.Locator = null;
				}
				else
				{
					if((base.ActiveContext!=null)&&fetchResult)
					{
						newEntity = (LocatorEntity)base.ActiveContext.Get(newEntity);
					}
					this.Locator = newEntity;
					_alreadyFetchedLocator = fetchResult;
				}
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _locator;
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

		/// <summary> Event thrower for the Locator_IDChanged event, which is thrown when Locator_ID changes value. Databinding related.</summary>
		protected virtual void OnLocator_IDChanged()
		{
			if(Locator_IDChanged!=null)
			{
				Locator_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Page_IDChanged event, which is thrown when Page_ID changes value. Databinding related.</summary>
		protected virtual void OnPage_IDChanged()
		{
			if(Page_IDChanged!=null)
			{
				Page_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Record_IDChanged event, which is thrown when Record_ID changes value. Databinding related.</summary>
		protected virtual void OnRecord_IDChanged()
		{
			if(Record_IDChanged!=null)
			{
				Record_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the GraphicObject_IDChanged event, which is thrown when GraphicObject_ID changes value. Databinding related.</summary>
		protected virtual void OnGraphicObject_IDChanged()
		{
			if(GraphicObject_IDChanged!=null)
			{
				GraphicObject_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the DataType_EnumValueChanged event, which is thrown when DataType_EnumValue changes value. Databinding related.</summary>
		protected virtual void OnDataType_EnumValueChanged()
		{
			if(DataType_EnumValueChanged!=null)
			{
				DataType_EnumValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Row_DisplayOrderChanged event, which is thrown when Row_DisplayOrder changes value. Databinding related.</summary>
		protected virtual void OnRow_DisplayOrderChanged()
		{
			if(Row_DisplayOrderChanged!=null)
			{
				Row_DisplayOrderChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Record_LineageChanged event, which is thrown when Record_Lineage changes value. Databinding related.</summary>
		protected virtual void OnRecord_LineageChanged()
		{
			if(Record_LineageChanged!=null)
			{
				Record_LineageChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the DatasourceUsedChanged event, which is thrown when DatasourceUsed changes value. Databinding related.</summary>
		protected virtual void OnDatasourceUsedChanged()
		{
			if(DatasourceUsedChanged!=null)
			{
				DatasourceUsedChanged(this, new EventArgs());
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
				switch((LocatorObjectRecordFieldIndex)fieldIndex)
				{
					case LocatorObjectRecordFieldIndex.Product_Year:
						DecoupleEventsLocator();
						_locator = null;
						_alreadyFetchedLocator = false;
						break;
					case LocatorObjectRecordFieldIndex.Locator_ID:
						DecoupleEventsLocator();
						_locator = null;
						_alreadyFetchedLocator = false;
						break;
					case LocatorObjectRecordFieldIndex.DataType_EnumValue:
						DecoupleEventsEnum_DataType();
						_enum_DataType = null;
						_alreadyFetchedEnum_DataType = false;
						break;
					case LocatorObjectRecordFieldIndex.DatasourceUsed:
						DecoupleEventsEnum_DataSource();
						_enum_DataSource = null;
						_alreadyFetchedEnum_DataSource = false;
						break;
					default:
						break;
				}
				base.PostFieldValueSetAction(toReturn);
				switch((LocatorObjectRecordFieldIndex)fieldIndex)
				{
					case LocatorObjectRecordFieldIndex.Product_Year:
						OnProduct_YearChanged();
						break;
					case LocatorObjectRecordFieldIndex.Locator_ID:
						OnLocator_IDChanged();
						break;
					case LocatorObjectRecordFieldIndex.Page_ID:
						OnPage_IDChanged();
						break;
					case LocatorObjectRecordFieldIndex.Record_ID:
						OnRecord_IDChanged();
						break;
					case LocatorObjectRecordFieldIndex.GraphicObject_ID:
						OnGraphicObject_IDChanged();
						break;
					case LocatorObjectRecordFieldIndex.DataType_EnumValue:
						OnDataType_EnumValueChanged();
						break;
					case LocatorObjectRecordFieldIndex.Row_DisplayOrder:
						OnRow_DisplayOrderChanged();
						break;
					case LocatorObjectRecordFieldIndex.Record_Lineage:
						OnRecord_LineageChanged();
						break;
					case LocatorObjectRecordFieldIndex.DatasourceUsed:
						OnDatasourceUsedChanged();
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
			LocatorObjectRecordDAO dao = (LocatorObjectRecordDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_locatorObjectValue.ActiveContext = base.ActiveContext;
			_enum_DataSourceCollectionViaLocatorObjectValue.ActiveContext = base.ActiveContext;
			if(_enum_DataSource!=null)
			{
				_enum_DataSource.ActiveContext = base.ActiveContext;
			}
			if(_enum_DataType!=null)
			{
				_enum_DataType.ActiveContext = base.ActiveContext;
			}
			if(_locator!=null)
			{
				_locator.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			LocatorObjectRecordDAO dao = (LocatorObjectRecordDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			LocatorObjectRecordDAO dao = (LocatorObjectRecordDAO)CreateDAOInstance();
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
			OnLocator_IDChanged();
			OnPage_IDChanged();
			OnRecord_IDChanged();
			OnGraphicObject_IDChanged();
			OnDataType_EnumValueChanged();
			OnRow_DisplayOrderChanged();
			OnRecord_LineageChanged();
			OnDatasourceUsedChanged();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
		}

		/// <summary>Creates field validator object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IValidator CreateValidator()
		{
			return new LocatorObjectRecordValidator();
		}


		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validator">The validator object for this LocatorObjectRecordEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 record_ID, IValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);

			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(record_ID, prefetchPathToUse, null);
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
			_locatorObjectValue = new TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection(propertyDescriptorFactoryToUse, new LocatorObjectValueEntityFactory());
			_locatorObjectValue.SetContainingEntityInfo(this, "LocatorObjectRecord");
			_alwaysFetchLocatorObjectValue = false;
			_alreadyFetchedLocatorObjectValue = false;
			_enum_DataSourceCollectionViaLocatorObjectValue = new TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection(propertyDescriptorFactoryToUse, new Enum_DataSourceEntityFactory());
			_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue = false;
			_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectValue = false;
			_enum_DataSource = null;
			_enum_DataSourceReturnsNewIfNotFound = true;
			_alwaysFetchEnum_DataSource = false;
			_alreadyFetchedEnum_DataSource = false;
			_enum_DataType = null;
			_enum_DataTypeReturnsNewIfNotFound = true;
			_alwaysFetchEnum_DataType = false;
			_alreadyFetchedEnum_DataType = false;
			_locator = null;
			_locatorReturnsNewIfNotFound = true;
			_alwaysFetchLocator = false;
			_alreadyFetchedLocator = false;

			
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

			_fieldsCustomProperties.Add("Locator_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Page_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Record_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("GraphicObject_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DataType_EnumValue", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Row_DisplayOrder", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Record_Lineage", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DatasourceUsed", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _enum_DataSource</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		private void DesetupSyncEnum_DataSource(bool signalRelatedEntity)
		{
			if(_enum_DataSource != null)
			{

				_enum_DataSource.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_DataSource", _enum_DataSource, LocatorObjectRecordEntity.Relations.Enum_DataSourceEntityUsingDatasourceUsed);
				if(signalRelatedEntity)
				{
					_enum_DataSource.UnsetRelatedEntity(this, "LocatorObjectRecord");
				}
				SetNewFieldValue((int)LocatorObjectRecordFieldIndex.DatasourceUsed, null, false);
				_enum_DataSource = null;
			}
		}
		
		/// <summary> Decouples events from member _enum_DataSource</summary>
		private void DecoupleEventsEnum_DataSource()
		{
			if(_enum_DataSource != null)
			{

				
				_enum_DataSource.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_DataSource", _enum_DataSource, LocatorObjectRecordEntity.Relations.Enum_DataSourceEntityUsingDatasourceUsed);
			}
		}
		
		/// <summary> setups the sync logic for member _enum_DataSource</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEnum_DataSource(IEntity relatedEntity)
		{
			DesetupSyncEnum_DataSource(true);
			if(relatedEntity!=null)
			{
				_enum_DataSource = (Enum_DataSourceEntity)relatedEntity;
				_enum_DataSource.ActiveContext = base.ActiveContext;
				_alreadyFetchedEnum_DataSource = true;
				_enum_DataSource.AfterSave+=new EventHandler(OnEntityAfterSave);
				base.SetEntitySyncInformation("Enum_DataSource", _enum_DataSource, LocatorObjectRecordEntity.Relations.Enum_DataSourceEntityUsingDatasourceUsed);

			}
			else
			{
				_alreadyFetchedEnum_DataSource = false;
			}
		}

		/// <summary> Removes the sync logic for member _enum_DataType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		private void DesetupSyncEnum_DataType(bool signalRelatedEntity)
		{
			if(_enum_DataType != null)
			{

				_enum_DataType.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_DataType", _enum_DataType, LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue);
				if(signalRelatedEntity)
				{
					_enum_DataType.UnsetRelatedEntity(this, "LocatorObjectRecord");
				}
				SetNewFieldValue((int)LocatorObjectRecordFieldIndex.DataType_EnumValue, null, false);
				_enum_DataType = null;
			}
		}
		
		/// <summary> Decouples events from member _enum_DataType</summary>
		private void DecoupleEventsEnum_DataType()
		{
			if(_enum_DataType != null)
			{

				
				_enum_DataType.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_DataType", _enum_DataType, LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue);
			}
		}
		
		/// <summary> setups the sync logic for member _enum_DataType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEnum_DataType(IEntity relatedEntity)
		{
			DesetupSyncEnum_DataType(true);
			if(relatedEntity!=null)
			{
				_enum_DataType = (Enum_DataTypeEntity)relatedEntity;
				_enum_DataType.ActiveContext = base.ActiveContext;
				_alreadyFetchedEnum_DataType = true;
				_enum_DataType.AfterSave+=new EventHandler(OnEntityAfterSave);
				base.SetEntitySyncInformation("Enum_DataType", _enum_DataType, LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue);

			}
			else
			{
				_alreadyFetchedEnum_DataType = false;
			}
		}

		/// <summary> Removes the sync logic for member _locator</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		private void DesetupSyncLocator(bool signalRelatedEntity)
		{
			if(_locator != null)
			{

				_locator.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Locator", _locator, LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID);
				if(signalRelatedEntity)
				{
					_locator.UnsetRelatedEntity(this, "LocatorObjectRecord");
				}
				SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Product_Year, null, false);
				SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Locator_ID, null, false);
				_locator = null;
			}
		}
		
		/// <summary> Decouples events from member _locator</summary>
		private void DecoupleEventsLocator()
		{
			if(_locator != null)
			{

				
				_locator.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Locator", _locator, LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID);
			}
		}
		
		/// <summary> setups the sync logic for member _locator</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLocator(IEntity relatedEntity)
		{
			DesetupSyncLocator(true);
			if(relatedEntity!=null)
			{
				_locator = (LocatorEntity)relatedEntity;
				_locator.ActiveContext = base.ActiveContext;
				_alreadyFetchedLocator = true;
				_locator.AfterSave+=new EventHandler(OnEntityAfterSave);
				base.SetEntitySyncInformation("Locator", _locator, LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID);

			}
			else
			{
				_alreadyFetchedLocator = false;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="record_ID">PK value for LocatorObjectRecord which data should be fetched into this LocatorObjectRecord object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 record_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)LocatorObjectRecordFieldIndex.Record_ID].ForcedCurrentValueWrite(record_ID);
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
			return DAOFactory.CreateLocatorObjectRecordDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactoryInstance()
		{
			return new LocatorObjectRecordEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static LocatorObjectRecordRelations Relations
		{
			get	{ return new LocatorObjectRecordRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorObjectValue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorObjectValue
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection(),
					LocatorObjectRecordEntity.Relations.LocatorObjectValueEntityUsingRecord_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, (int)TestHarness.DataObjects.EntityType.LocatorObjectValueEntity, 0, null, null, null, "LocatorObjectValue", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_DataSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_DataSourceCollectionViaLocatorObjectValue
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(LocatorObjectRecordEntity.Relations.LocatorObjectValueEntityUsingRecord_ID);
				relations.Add(LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection(),
					LocatorObjectRecordEntity.Relations.LocatorObjectValueEntityUsingRecord_ID,
					(int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, (int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, 0, null, null, relations, "Enum_DataSourceCollectionViaLocatorObjectValue", RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_DataSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_DataSource
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection(),
					LocatorObjectRecordEntity.Relations.Enum_DataSourceEntityUsingDatasourceUsed, 
					(int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, (int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, 0, null, null, null, "Enum_DataSource", RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_DataType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_DataType
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection(),
					LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue, 
					(int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, (int)TestHarness.DataObjects.EntityType.Enum_DataTypeEntity, 0, null, null, null, "Enum_DataType", RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Locator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocator
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorCollection(),
					LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, (int)TestHarness.DataObjects.EntityType.LocatorEntity, 0, null, null, null, "Locator", RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return LocatorObjectRecordEntity.CustomProperties;}
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
			get { return LocatorObjectRecordEntity.FieldsCustomProperties;}
		}

		/// <summary> The Product_Year property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."Product_Year"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Product_Year
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.Product_Year);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int16));
				}
				return (System.Int16)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Product_Year, value); }
		}
		/// <summary> The Locator_ID property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."Locator_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Locator_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.Locator_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Locator_ID, value); }
		}
		/// <summary> The Page_ID property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."Page_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Page_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.Page_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Page_ID, value); }
		}
		/// <summary> The Record_ID property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."Record_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Record_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.Record_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Record_ID, value); }
		}
		/// <summary> The GraphicObject_ID property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."GraphicObject_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 GraphicObject_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.GraphicObject_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.GraphicObject_ID, value); }
		}
		/// <summary> The DataType_EnumValue property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."DataType_EnumValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte DataType_EnumValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.DataType_EnumValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				return (System.Byte)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.DataType_EnumValue, value); }
		}
		/// <summary> The Row_DisplayOrder property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."Row_DisplayOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int32 Row_DisplayOrder
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.Row_DisplayOrder);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Row_DisplayOrder, value); }
		}
		/// <summary> The Record_Lineage property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."Record_Lineage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int32 Record_Lineage
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.Record_Lineage);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.Record_Lineage, value); }
		}
		/// <summary> The DatasourceUsed property of the Entity LocatorObjectRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectRecord"."DatasourceUsed"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Byte DatasourceUsed
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectRecordFieldIndex.DatasourceUsed);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				return (System.Byte)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectRecordFieldIndex.DatasourceUsed, value); }
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectValueEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorObjectValue()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection LocatorObjectValue
		{
			get	{ return GetMultiLocatorObjectValue(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorObjectValue. When set to true, LocatorObjectValue is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorObjectValue is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorObjectValue(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorObjectValue
		{
			get	{ return _alwaysFetchLocatorObjectValue; }
			set	{ _alwaysFetchLocatorObjectValue = value; }	
		}

		/// <summary> Retrieves all related entities of type 'Enum_DataSourceEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiEnum_DataSourceCollectionViaLocatorObjectValue()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection Enum_DataSourceCollectionViaLocatorObjectValue
		{
			get { return GetMultiEnum_DataSourceCollectionViaLocatorObjectValue(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_DataSourceCollectionViaLocatorObjectValue. When set to true, Enum_DataSourceCollectionViaLocatorObjectValue is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_DataSourceCollectionViaLocatorObjectValue is accessed. You can always execute
		/// a forced fetch by calling GetMultiEnum_DataSourceCollectionViaLocatorObjectValue(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue
		{
			get	{ return _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue; }
			set	{ _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectValue = value; }	
		}

		/// <summary> Gets / sets related entity of type 'Enum_DataSourceEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleEnum_DataSource()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual Enum_DataSourceEntity Enum_DataSource
		{
			get	{ return GetSingleEnum_DataSource(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEnum_DataSource(value);
				}
				else
				{
					if(value==null)
					{
						if(_enum_DataSource != null)
						{
							_enum_DataSource.UnsetRelatedEntity(this, "LocatorObjectRecord");
						}
					}
					else
					{
						((IEntity)value).SetRelatedEntity(this, "LocatorObjectRecord");
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_DataSource. When set to true, Enum_DataSource is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_DataSource is accessed. You can always execute
		/// a forced fetch by calling GetSingleEnum_DataSource(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_DataSource
		{
			get	{ return _alwaysFetchEnum_DataSource; }
			set	{ _alwaysFetchEnum_DataSource = value; }	
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Enum_DataSource is not found
		/// in the database. When set to true, Enum_DataSource will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool Enum_DataSourceReturnsNewIfNotFound
		{
			get	{ return _enum_DataSourceReturnsNewIfNotFound; }
			set { _enum_DataSourceReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'Enum_DataTypeEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleEnum_DataType()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual Enum_DataTypeEntity Enum_DataType
		{
			get	{ return GetSingleEnum_DataType(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEnum_DataType(value);
				}
				else
				{
					if(value==null)
					{
						if(_enum_DataType != null)
						{
							_enum_DataType.UnsetRelatedEntity(this, "LocatorObjectRecord");
						}
					}
					else
					{
						((IEntity)value).SetRelatedEntity(this, "LocatorObjectRecord");
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_DataType. When set to true, Enum_DataType is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_DataType is accessed. You can always execute
		/// a forced fetch by calling GetSingleEnum_DataType(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_DataType
		{
			get	{ return _alwaysFetchEnum_DataType; }
			set	{ _alwaysFetchEnum_DataType = value; }	
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Enum_DataType is not found
		/// in the database. When set to true, Enum_DataType will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool Enum_DataTypeReturnsNewIfNotFound
		{
			get	{ return _enum_DataTypeReturnsNewIfNotFound; }
			set { _enum_DataTypeReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'LocatorEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleLocator()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual LocatorEntity Locator
		{
			get	{ return GetSingleLocator(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLocator(value);
				}
				else
				{
					if(value==null)
					{
						if(_locator != null)
						{
							_locator.UnsetRelatedEntity(this, "LocatorObjectRecord");
						}
					}
					else
					{
						((IEntity)value).SetRelatedEntity(this, "LocatorObjectRecord");
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Locator. When set to true, Locator is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Locator is accessed. You can always execute
		/// a forced fetch by calling GetSingleLocator(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocator
		{
			get	{ return _alwaysFetchLocator; }
			set	{ _alwaysFetchLocator = value; }	
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Locator is not found
		/// in the database. When set to true, Locator will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool LocatorReturnsNewIfNotFound
		{
			get	{ return _locatorReturnsNewIfNotFound; }
			set { _locatorReturnsNewIfNotFound = value; }	
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
			get { return (int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity; }
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
