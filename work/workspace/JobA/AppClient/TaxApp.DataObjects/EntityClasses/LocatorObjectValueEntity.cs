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
	/// Entity class which represents the entity 'LocatorObjectValue'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LocatorObjectValueEntity : EntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations


		private Enum_DataSourceEntity _enum_DataSource;
		private bool	_alwaysFetchEnum_DataSource, _alreadyFetchedEnum_DataSource, _enum_DataSourceReturnsNewIfNotFound;
		private LocatorObjectRecordEntity _locatorObjectRecord;
		private bool	_alwaysFetchLocatorObjectRecord, _alreadyFetchedLocatorObjectRecord, _locatorObjectRecordReturnsNewIfNotFound;


		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region DataBinding Change Event Handler Declarations
		/// <summary>Event which is thrown when Record_ID changes value. Databinding related.</summary>
		public event EventHandler Record_IDChanged;
		/// <summary>Event which is thrown when DataSource_EnumValue changes value. Databinding related.</summary>
		public event EventHandler DataSource_EnumValueChanged;
		/// <summary>Event which is thrown when BooleanValue changes value. Databinding related.</summary>
		public event EventHandler BooleanValueChanged;
		/// <summary>Event which is thrown when StringValue changes value. Databinding related.</summary>
		public event EventHandler StringValueChanged;
		/// <summary>Event which is thrown when NumericValue changes value. Databinding related.</summary>
		public event EventHandler NumericValueChanged;
		/// <summary>Event which is thrown when DateValue changes value. Databinding related.</summary>
		public event EventHandler DateValueChanged;
		/// <summary>Event which is thrown when FractionValue changes value. Databinding related.</summary>
		public event EventHandler FractionValueChanged;
		/// <summary>Event which is thrown when LocatorImage_ID changes value. Databinding related.</summary>
		public event EventHandler LocatorImage_IDChanged;
		/// <summary>Event which is thrown when Save_History changes value. Databinding related.</summary>
		public event EventHandler Save_HistoryChanged;
		/// <summary>Event which is thrown when DateLastSaved changes value. Databinding related.</summary>
		public event EventHandler DateLastSavedChanged;

		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LocatorObjectValueEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public LocatorObjectValueEntity()
		{
			InitClassEmpty(new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), CreateValidator());
		}


		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		public LocatorObjectValueEntity(System.Int32 record_ID, System.Byte dataSource_EnumValue)
		{
			InitClassFetch(record_ID, dataSource_EnumValue, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public LocatorObjectValueEntity(System.Int32 record_ID, System.Byte dataSource_EnumValue, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(record_ID, dataSource_EnumValue, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="validator">The custom validator object for this LocatorObjectValueEntity</param>
		public LocatorObjectValueEntity(System.Int32 record_ID, System.Byte dataSource_EnumValue, LocatorObjectValueValidator validator)
		{
			InitClassFetch(record_ID, dataSource_EnumValue, validator, new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="validator">The custom validator object for this LocatorObjectValueEntity</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public LocatorObjectValueEntity(System.Int32 record_ID, System.Byte dataSource_EnumValue, LocatorObjectValueValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassFetch(record_ID, dataSource_EnumValue, validator, propertyDescriptorFactoryToUse, entityFactoryToUse, null);
		}

		/// <summary>CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public LocatorObjectValueEntity(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassEmpty(propertyDescriptorFactoryToUse, entityFactoryToUse, CreateValidator());
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LocatorObjectValueEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{


			_enum_DataSource = (Enum_DataSourceEntity)info.GetValue("_enum_DataSource", typeof(Enum_DataSourceEntity));
			if(_enum_DataSource!=null)
			{
				_enum_DataSource.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_enum_DataSourceReturnsNewIfNotFound = info.GetBoolean("_enum_DataSourceReturnsNewIfNotFound");
			_alwaysFetchEnum_DataSource = info.GetBoolean("_alwaysFetchEnum_DataSource");
			_alreadyFetchedEnum_DataSource = info.GetBoolean("_alreadyFetchedEnum_DataSource");
			_locatorObjectRecord = (LocatorObjectRecordEntity)info.GetValue("_locatorObjectRecord", typeof(LocatorObjectRecordEntity));
			if(_locatorObjectRecord!=null)
			{
				_locatorObjectRecord.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_locatorObjectRecordReturnsNewIfNotFound = info.GetBoolean("_locatorObjectRecordReturnsNewIfNotFound");
			_alwaysFetchLocatorObjectRecord = info.GetBoolean("_alwaysFetchLocatorObjectRecord");
			_alreadyFetchedLocatorObjectRecord = info.GetBoolean("_alreadyFetchedLocatorObjectRecord");

			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary> Will perform post-ReadXml actions as well as the normal ReadXml() actions, performed by the base class.</summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element of the entity's Xml data</param>
		public override void ReadXml(System.Xml.XmlNode node)
		{
			base.ReadXml (node);


			_alreadyFetchedEnum_DataSource = (_enum_DataSource != null);
			_alreadyFetchedLocatorObjectRecord = (_locatorObjectRecord != null);

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


			info.AddValue("_enum_DataSource", _enum_DataSource);
			info.AddValue("_enum_DataSourceReturnsNewIfNotFound", _enum_DataSourceReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchEnum_DataSource", _alwaysFetchEnum_DataSource);
			info.AddValue("_alreadyFetchedEnum_DataSource", _alreadyFetchedEnum_DataSource);
			info.AddValue("_locatorObjectRecord", _locatorObjectRecord);
			info.AddValue("_locatorObjectRecordReturnsNewIfNotFound", _locatorObjectRecordReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchLocatorObjectRecord", _alwaysFetchLocatorObjectRecord);
			info.AddValue("_alreadyFetchedLocatorObjectRecord", _alreadyFetchedLocatorObjectRecord);

			
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
				case "LocatorObjectRecord":
					_alreadyFetchedLocatorObjectRecord = true;
					this.LocatorObjectRecord = (LocatorObjectRecordEntity)entity;
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
				case "LocatorObjectRecord":
					SetupSyncLocatorObjectRecord(relatedEntity);
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
				case "LocatorObjectRecord":
					DesetupSyncLocatorObjectRecord(false);
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
			if(_locatorObjectRecord!=null)
			{
				toReturn.Add(_locatorObjectRecord);
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
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 record_ID, System.Byte dataSource_EnumValue)
		{
			return FetchUsingPK(record_ID, dataSource_EnumValue, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 record_ID, System.Byte dataSource_EnumValue, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(record_ID, dataSource_EnumValue, prefetchPathToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 record_ID, System.Byte dataSource_EnumValue, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(record_ID, dataSource_EnumValue, prefetchPathToUse, contextToUse);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Record_ID, this.DataSource_EnumValue, null, null);
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
		public bool TestOriginalFieldValueForNull(LocatorObjectValueFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(LocatorObjectValueFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("LocatorObjectValueEntity", ((TestHarness.DataObjects.EntityType)typeOfEntity).ToString());
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
				bool fetchResult = newEntity.FetchUsingPK(this.DataSource_EnumValue);
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

		/// <summary> Retrieves the related entity of type 'LocatorObjectRecordEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'LocatorObjectRecordEntity' which is related to this entity.</returns>
		public LocatorObjectRecordEntity GetSingleLocatorObjectRecord()
		{
			return GetSingleLocatorObjectRecord(false);
		}

		/// <summary> Retrieves the related entity of type 'LocatorObjectRecordEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'LocatorObjectRecordEntity' which is related to this entity.</returns>
		public virtual LocatorObjectRecordEntity GetSingleLocatorObjectRecord(bool forceFetch)
		{
 			if( ( !_alreadyFetchedLocatorObjectRecord || forceFetch || _alwaysFetchLocatorObjectRecord) && !base.IsSerializing && !base.IsDeserializing )
			{

				LocatorObjectRecordEntity newEntity = new LocatorObjectRecordEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = newEntity.FetchUsingPK(this.Record_ID);
				if(!_locatorObjectRecordReturnsNewIfNotFound && !fetchResult)
				{
					this.LocatorObjectRecord = null;
				}
				else
				{
					if((base.ActiveContext!=null)&&fetchResult)
					{
						newEntity = (LocatorObjectRecordEntity)base.ActiveContext.Get(newEntity);
					}
					this.LocatorObjectRecord = newEntity;
					_alreadyFetchedLocatorObjectRecord = fetchResult;
				}
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _locatorObjectRecord;
		}

	
		#region Data binding change event raising methods

		/// <summary> Event thrower for the Record_IDChanged event, which is thrown when Record_ID changes value. Databinding related.</summary>
		protected virtual void OnRecord_IDChanged()
		{
			if(Record_IDChanged!=null)
			{
				Record_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the DataSource_EnumValueChanged event, which is thrown when DataSource_EnumValue changes value. Databinding related.</summary>
		protected virtual void OnDataSource_EnumValueChanged()
		{
			if(DataSource_EnumValueChanged!=null)
			{
				DataSource_EnumValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the BooleanValueChanged event, which is thrown when BooleanValue changes value. Databinding related.</summary>
		protected virtual void OnBooleanValueChanged()
		{
			if(BooleanValueChanged!=null)
			{
				BooleanValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the StringValueChanged event, which is thrown when StringValue changes value. Databinding related.</summary>
		protected virtual void OnStringValueChanged()
		{
			if(StringValueChanged!=null)
			{
				StringValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the NumericValueChanged event, which is thrown when NumericValue changes value. Databinding related.</summary>
		protected virtual void OnNumericValueChanged()
		{
			if(NumericValueChanged!=null)
			{
				NumericValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the DateValueChanged event, which is thrown when DateValue changes value. Databinding related.</summary>
		protected virtual void OnDateValueChanged()
		{
			if(DateValueChanged!=null)
			{
				DateValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the FractionValueChanged event, which is thrown when FractionValue changes value. Databinding related.</summary>
		protected virtual void OnFractionValueChanged()
		{
			if(FractionValueChanged!=null)
			{
				FractionValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the LocatorImage_IDChanged event, which is thrown when LocatorImage_ID changes value. Databinding related.</summary>
		protected virtual void OnLocatorImage_IDChanged()
		{
			if(LocatorImage_IDChanged!=null)
			{
				LocatorImage_IDChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Save_HistoryChanged event, which is thrown when Save_History changes value. Databinding related.</summary>
		protected virtual void OnSave_HistoryChanged()
		{
			if(Save_HistoryChanged!=null)
			{
				Save_HistoryChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the DateLastSavedChanged event, which is thrown when DateLastSaved changes value. Databinding related.</summary>
		protected virtual void OnDateLastSavedChanged()
		{
			if(DateLastSavedChanged!=null)
			{
				DateLastSavedChanged(this, new EventArgs());
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
				switch((LocatorObjectValueFieldIndex)fieldIndex)
				{
					case LocatorObjectValueFieldIndex.Record_ID:
						DecoupleEventsLocatorObjectRecord();
						_locatorObjectRecord = null;
						_alreadyFetchedLocatorObjectRecord = false;
						break;
					case LocatorObjectValueFieldIndex.DataSource_EnumValue:
						DecoupleEventsEnum_DataSource();
						_enum_DataSource = null;
						_alreadyFetchedEnum_DataSource = false;
						break;
					default:
						break;
				}
				base.PostFieldValueSetAction(toReturn);
				switch((LocatorObjectValueFieldIndex)fieldIndex)
				{
					case LocatorObjectValueFieldIndex.Record_ID:
						OnRecord_IDChanged();
						break;
					case LocatorObjectValueFieldIndex.DataSource_EnumValue:
						OnDataSource_EnumValueChanged();
						break;
					case LocatorObjectValueFieldIndex.BooleanValue:
						OnBooleanValueChanged();
						break;
					case LocatorObjectValueFieldIndex.StringValue:
						OnStringValueChanged();
						break;
					case LocatorObjectValueFieldIndex.NumericValue:
						OnNumericValueChanged();
						break;
					case LocatorObjectValueFieldIndex.DateValue:
						OnDateValueChanged();
						break;
					case LocatorObjectValueFieldIndex.FractionValue:
						OnFractionValueChanged();
						break;
					case LocatorObjectValueFieldIndex.LocatorImage_ID:
						OnLocatorImage_IDChanged();
						break;
					case LocatorObjectValueFieldIndex.Save_History:
						OnSave_HistoryChanged();
						break;
					case LocatorObjectValueFieldIndex.DateLastSaved:
						OnDateLastSavedChanged();
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
			LocatorObjectValueDAO dao = (LocatorObjectValueDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_enum_DataSource!=null)
			{
				_enum_DataSource.ActiveContext = base.ActiveContext;
			}
			if(_locatorObjectRecord!=null)
			{
				_locatorObjectRecord.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			LocatorObjectValueDAO dao = (LocatorObjectValueDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			LocatorObjectValueDAO dao = (LocatorObjectValueDAO)CreateDAOInstance();
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
			OnRecord_IDChanged();
			OnDataSource_EnumValueChanged();
			OnBooleanValueChanged();
			OnStringValueChanged();
			OnNumericValueChanged();
			OnDateValueChanged();
			OnFractionValueChanged();
			OnLocatorImage_IDChanged();
			OnSave_HistoryChanged();
			OnDateLastSavedChanged();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectValueEntity);
		}

		/// <summary>Creates field validator object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IValidator CreateValidator()
		{
			return new LocatorObjectValueValidator();
		}


		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validator">The validator object for this LocatorObjectValueEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 record_ID, System.Byte dataSource_EnumValue, IValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);

			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(record_ID, dataSource_EnumValue, prefetchPathToUse, null);
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


			_enum_DataSource = null;
			_enum_DataSourceReturnsNewIfNotFound = true;
			_alwaysFetchEnum_DataSource = false;
			_alreadyFetchedEnum_DataSource = false;
			_locatorObjectRecord = null;
			_locatorObjectRecordReturnsNewIfNotFound = true;
			_alwaysFetchLocatorObjectRecord = false;
			_alreadyFetchedLocatorObjectRecord = false;

			
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

			_fieldsCustomProperties.Add("Record_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DataSource_EnumValue", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("BooleanValue", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("StringValue", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("NumericValue", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DateValue", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FractionValue", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LocatorImage_ID", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Save_History", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DateLastSaved", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _enum_DataSource</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		private void DesetupSyncEnum_DataSource(bool signalRelatedEntity)
		{
			if(_enum_DataSource != null)
			{

				_enum_DataSource.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_DataSource", _enum_DataSource, LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue);
				if(signalRelatedEntity)
				{
					_enum_DataSource.UnsetRelatedEntity(this, "LocatorObjectValue");
				}
				SetNewFieldValue((int)LocatorObjectValueFieldIndex.DataSource_EnumValue, null, false);
				_enum_DataSource = null;
			}
		}
		
		/// <summary> Decouples events from member _enum_DataSource</summary>
		private void DecoupleEventsEnum_DataSource()
		{
			if(_enum_DataSource != null)
			{

				
				_enum_DataSource.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("Enum_DataSource", _enum_DataSource, LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue);
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
				base.SetEntitySyncInformation("Enum_DataSource", _enum_DataSource, LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue);

			}
			else
			{
				_alreadyFetchedEnum_DataSource = false;
			}
		}

		/// <summary> Removes the sync logic for member _locatorObjectRecord</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		private void DesetupSyncLocatorObjectRecord(bool signalRelatedEntity)
		{
			if(_locatorObjectRecord != null)
			{

				_locatorObjectRecord.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("LocatorObjectRecord", _locatorObjectRecord, LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID);
				if(signalRelatedEntity)
				{
					_locatorObjectRecord.UnsetRelatedEntity(this, "LocatorObjectValue");
				}
				SetNewFieldValue((int)LocatorObjectValueFieldIndex.Record_ID, null, false);
				_locatorObjectRecord = null;
			}
		}
		
		/// <summary> Decouples events from member _locatorObjectRecord</summary>
		private void DecoupleEventsLocatorObjectRecord()
		{
			if(_locatorObjectRecord != null)
			{

				
				_locatorObjectRecord.AfterSave-=new EventHandler(OnEntityAfterSave);
				base.UnsetEntitySyncInformation("LocatorObjectRecord", _locatorObjectRecord, LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID);
			}
		}
		
		/// <summary> setups the sync logic for member _locatorObjectRecord</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLocatorObjectRecord(IEntity relatedEntity)
		{
			DesetupSyncLocatorObjectRecord(true);
			if(relatedEntity!=null)
			{
				_locatorObjectRecord = (LocatorObjectRecordEntity)relatedEntity;
				_locatorObjectRecord.ActiveContext = base.ActiveContext;
				_alreadyFetchedLocatorObjectRecord = true;
				_locatorObjectRecord.AfterSave+=new EventHandler(OnEntityAfterSave);
				base.SetEntitySyncInformation("LocatorObjectRecord", _locatorObjectRecord, LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID);

			}
			else
			{
				_alreadyFetchedLocatorObjectRecord = false;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="record_ID">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="dataSource_EnumValue">PK value for LocatorObjectValue which data should be fetched into this LocatorObjectValue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 record_ID, System.Byte dataSource_EnumValue, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)LocatorObjectValueFieldIndex.Record_ID].ForcedCurrentValueWrite(record_ID);
				base.Fields[(int)LocatorObjectValueFieldIndex.DataSource_EnumValue].ForcedCurrentValueWrite(dataSource_EnumValue);
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
			return DAOFactory.CreateLocatorObjectValueDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactoryInstance()
		{
			return new LocatorObjectValueEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static LocatorObjectValueRelations Relations
		{
			get	{ return new LocatorObjectValueRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_DataSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_DataSource
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection(),
					LocatorObjectValueEntity.Relations.Enum_DataSourceEntityUsingDataSource_EnumValue, 
					(int)TestHarness.DataObjects.EntityType.LocatorObjectValueEntity, (int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, 0, null, null, null, "Enum_DataSource", RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorObjectRecord' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorObjectRecord
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection(),
					LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorObjectValueEntity, (int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, 0, null, null, null, "LocatorObjectRecord", RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return LocatorObjectValueEntity.CustomProperties;}
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
			get { return LocatorObjectValueEntity.FieldsCustomProperties;}
		}

		/// <summary> The Record_ID property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."Record_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 Record_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.Record_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.Record_ID, value); }
		}
		/// <summary> The DataSource_EnumValue property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."DataSource_EnumValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Byte DataSource_EnumValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.DataSource_EnumValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				return (System.Byte)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.DataSource_EnumValue, value); }
		}
		/// <summary> The BooleanValue property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."BooleanValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Boolean BooleanValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.BooleanValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				return (System.Boolean)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.BooleanValue, value); }
		}
		/// <summary> The StringValue property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."StringValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String StringValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.StringValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.StringValue, value); }
		}
		/// <summary> The NumericValue property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."NumericValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 22, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Decimal NumericValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.NumericValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				return (System.Decimal)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.NumericValue, value); }
		}
		/// <summary> The DateValue property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."DateValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.DateTime DateValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.DateValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				return (System.DateTime)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.DateValue, value); }
		}
		/// <summary> The FractionValue property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."FractionValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 20, 9, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Decimal FractionValue
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.FractionValue);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				return (System.Decimal)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.FractionValue, value); }
		}
		/// <summary> The LocatorImage_ID property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."LocatorImage_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int32 LocatorImage_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.LocatorImage_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.LocatorImage_ID, value); }
		}
		/// <summary> The Save_History property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."Save_History"<br/>
		/// Table field type characteristics (type, precision, scale, length): Text, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Save_History
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.Save_History);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.Save_History, value); }
		}
		/// <summary> The DateLastSaved property of the Entity LocatorObjectValue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "LocatorObjectValue"."DateLastSaved"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.DateTime DateLastSaved
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorObjectValueFieldIndex.DateLastSaved);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				return (System.DateTime)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorObjectValueFieldIndex.DateLastSaved, value); }
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
							_enum_DataSource.UnsetRelatedEntity(this, "LocatorObjectValue");
						}
					}
					else
					{
						((IEntity)value).SetRelatedEntity(this, "LocatorObjectValue");
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
		/// <summary> Gets / sets related entity of type 'LocatorObjectRecordEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleLocatorObjectRecord()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual LocatorObjectRecordEntity LocatorObjectRecord
		{
			get	{ return GetSingleLocatorObjectRecord(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLocatorObjectRecord(value);
				}
				else
				{
					if(value==null)
					{
						if(_locatorObjectRecord != null)
						{
							_locatorObjectRecord.UnsetRelatedEntity(this, "LocatorObjectValue");
						}
					}
					else
					{
						((IEntity)value).SetRelatedEntity(this, "LocatorObjectValue");
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorObjectRecord. When set to true, LocatorObjectRecord is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorObjectRecord is accessed. You can always execute
		/// a forced fetch by calling GetSingleLocatorObjectRecord(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorObjectRecord
		{
			get	{ return _alwaysFetchLocatorObjectRecord; }
			set	{ _alwaysFetchLocatorObjectRecord = value; }	
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property LocatorObjectRecord is not found
		/// in the database. When set to true, LocatorObjectRecord will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool LocatorObjectRecordReturnsNewIfNotFound
		{
			get	{ return _locatorObjectRecordReturnsNewIfNotFound; }
			set { _locatorObjectRecordReturnsNewIfNotFound = value; }	
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
			get { return (int)TestHarness.DataObjects.EntityType.LocatorObjectValueEntity; }
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
