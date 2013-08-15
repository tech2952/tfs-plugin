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
	/// Entity class which represents the entity 'Enum_DataSource'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class Enum_DataSourceEntity : EntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection	_locatorObjectRecord;
		private bool	_alwaysFetchLocatorObjectRecord, _alreadyFetchedLocatorObjectRecord;
		private TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection	_locatorObjectValue;
		private bool	_alwaysFetchLocatorObjectValue, _alreadyFetchedLocatorObjectValue;
		private TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection _enum_DataTypeCollectionViaLocatorObjectRecord;
		private bool	_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord, _alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord;
		private TestHarness.DataObjects.CollectionClasses.LocatorCollection _locatorCollectionViaLocatorObjectRecord;
		private bool	_alwaysFetchLocatorCollectionViaLocatorObjectRecord, _alreadyFetchedLocatorCollectionViaLocatorObjectRecord;
		private TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection _locatorObjectRecordCollectionViaLocatorObjectValue;
		private bool	_alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue, _alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue;



		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region DataBinding Change Event Handler Declarations
		/// <summary>Event which is thrown when Enum_Value changes value. Databinding related.</summary>
		public event EventHandler Enum_ValueChanged;
		/// <summary>Event which is thrown when Enum_Description changes value. Databinding related.</summary>
		public event EventHandler Enum_DescriptionChanged;

		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static Enum_DataSourceEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public Enum_DataSourceEntity()
		{
			InitClassEmpty(new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), CreateValidator());
		}


		/// <summary>CTor</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		public Enum_DataSourceEntity(System.Byte enum_Value)
		{
			InitClassFetch(enum_Value, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public Enum_DataSourceEntity(System.Byte enum_Value, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(enum_Value, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <param name="validator">The custom validator object for this Enum_DataSourceEntity</param>
		public Enum_DataSourceEntity(System.Byte enum_Value, Enum_DataSourceValidator validator)
		{
			InitClassFetch(enum_Value, validator, new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <param name="validator">The custom validator object for this Enum_DataSourceEntity</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public Enum_DataSourceEntity(System.Byte enum_Value, Enum_DataSourceValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassFetch(enum_Value, validator, propertyDescriptorFactoryToUse, entityFactoryToUse, null);
		}

		/// <summary>CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public Enum_DataSourceEntity(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassEmpty(propertyDescriptorFactoryToUse, entityFactoryToUse, CreateValidator());
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected Enum_DataSourceEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_locatorObjectRecord = (TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection)info.GetValue("_locatorObjectRecord", typeof(TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection));
			_alwaysFetchLocatorObjectRecord = info.GetBoolean("_alwaysFetchLocatorObjectRecord");
			_alreadyFetchedLocatorObjectRecord = info.GetBoolean("_alreadyFetchedLocatorObjectRecord");
			_locatorObjectValue = (TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection)info.GetValue("_locatorObjectValue", typeof(TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection));
			_alwaysFetchLocatorObjectValue = info.GetBoolean("_alwaysFetchLocatorObjectValue");
			_alreadyFetchedLocatorObjectValue = info.GetBoolean("_alreadyFetchedLocatorObjectValue");
			_enum_DataTypeCollectionViaLocatorObjectRecord = (TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection)info.GetValue("_enum_DataTypeCollectionViaLocatorObjectRecord", typeof(TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection));
			_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord = info.GetBoolean("_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord");
			_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = info.GetBoolean("_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord");
			_locatorCollectionViaLocatorObjectRecord = (TestHarness.DataObjects.CollectionClasses.LocatorCollection)info.GetValue("_locatorCollectionViaLocatorObjectRecord", typeof(TestHarness.DataObjects.CollectionClasses.LocatorCollection));
			_alwaysFetchLocatorCollectionViaLocatorObjectRecord = info.GetBoolean("_alwaysFetchLocatorCollectionViaLocatorObjectRecord");
			_alreadyFetchedLocatorCollectionViaLocatorObjectRecord = info.GetBoolean("_alreadyFetchedLocatorCollectionViaLocatorObjectRecord");
			_locatorObjectRecordCollectionViaLocatorObjectValue = (TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection)info.GetValue("_locatorObjectRecordCollectionViaLocatorObjectValue", typeof(TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection));
			_alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue = info.GetBoolean("_alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue");
			_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue = info.GetBoolean("_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue");


			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary> Will perform post-ReadXml actions as well as the normal ReadXml() actions, performed by the base class.</summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element of the entity's Xml data</param>
		public override void ReadXml(System.Xml.XmlNode node)
		{
			base.ReadXml (node);
			_alreadyFetchedLocatorObjectRecord = (_locatorObjectRecord.Count > 0);
			_alreadyFetchedLocatorObjectValue = (_locatorObjectValue.Count > 0);
			_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = (_enum_DataTypeCollectionViaLocatorObjectRecord.Count > 0);
			_alreadyFetchedLocatorCollectionViaLocatorObjectRecord = (_locatorCollectionViaLocatorObjectRecord.Count > 0);
			_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue = (_locatorObjectRecordCollectionViaLocatorObjectValue.Count > 0);


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
			info.AddValue("_locatorObjectRecord", _locatorObjectRecord);
			info.AddValue("_alwaysFetchLocatorObjectRecord", _alwaysFetchLocatorObjectRecord);
			info.AddValue("_alreadyFetchedLocatorObjectRecord", _alreadyFetchedLocatorObjectRecord);
			info.AddValue("_locatorObjectValue", _locatorObjectValue);
			info.AddValue("_alwaysFetchLocatorObjectValue", _alwaysFetchLocatorObjectValue);
			info.AddValue("_alreadyFetchedLocatorObjectValue", _alreadyFetchedLocatorObjectValue);
			info.AddValue("_enum_DataTypeCollectionViaLocatorObjectRecord", _enum_DataTypeCollectionViaLocatorObjectRecord);
			info.AddValue("_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord", _alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord);
			info.AddValue("_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord", _alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord);
			info.AddValue("_locatorCollectionViaLocatorObjectRecord", _locatorCollectionViaLocatorObjectRecord);
			info.AddValue("_alwaysFetchLocatorCollectionViaLocatorObjectRecord", _alwaysFetchLocatorCollectionViaLocatorObjectRecord);
			info.AddValue("_alreadyFetchedLocatorCollectionViaLocatorObjectRecord", _alreadyFetchedLocatorCollectionViaLocatorObjectRecord);
			info.AddValue("_locatorObjectRecordCollectionViaLocatorObjectValue", _locatorObjectRecordCollectionViaLocatorObjectValue);
			info.AddValue("_alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue", _alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue);
			info.AddValue("_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue", _alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue);


			
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

				case "LocatorObjectRecord":
					_alreadyFetchedLocatorObjectRecord = true;
					if(entity!=null)
					{
						this.LocatorObjectRecord.Add((LocatorObjectRecordEntity)entity);
					}
					break;
				case "LocatorObjectValue":
					_alreadyFetchedLocatorObjectValue = true;
					if(entity!=null)
					{
						this.LocatorObjectValue.Add((LocatorObjectValueEntity)entity);
					}
					break;
				case "Enum_DataTypeCollectionViaLocatorObjectRecord":
					_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = true;
					if(entity!=null)
					{
						this.Enum_DataTypeCollectionViaLocatorObjectRecord.Add((Enum_DataTypeEntity)entity);
					}
					break;
				case "LocatorCollectionViaLocatorObjectRecord":
					_alreadyFetchedLocatorCollectionViaLocatorObjectRecord = true;
					if(entity!=null)
					{
						this.LocatorCollectionViaLocatorObjectRecord.Add((LocatorEntity)entity);
					}
					break;
				case "LocatorObjectRecordCollectionViaLocatorObjectValue":
					_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue = true;
					if(entity!=null)
					{
						this.LocatorObjectRecordCollectionViaLocatorObjectValue.Add((LocatorObjectRecordEntity)entity);
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

				case "LocatorObjectRecord":
					_locatorObjectRecord.Add(relatedEntity);
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

				case "LocatorObjectRecord":
					_locatorObjectRecord.Remove(relatedEntity);
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



			return toReturn;
		}
		
		/// <summary> Gets an ArrayList of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override ArrayList GetMemberEntityCollections()
		{
			ArrayList toReturn = new ArrayList();
			toReturn.Add(_locatorObjectRecord);
			toReturn.Add(_locatorObjectValue);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Byte enum_Value)
		{
			return FetchUsingPK(enum_Value, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Byte enum_Value, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(enum_Value, prefetchPathToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Byte enum_Value, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(enum_Value, prefetchPathToUse, contextToUse);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Enum_Value, null, null);
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
		public bool TestOriginalFieldValueForNull(Enum_DataSourceFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(Enum_DataSourceFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("Enum_DataSourceEntity", ((TestHarness.DataObjects.EntityType)typeOfEntity).ToString());
		}


		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorObjectRecordEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection GetMultiLocatorObjectRecord(bool forceFetch)
		{
			return GetMultiLocatorObjectRecord(forceFetch, _locatorObjectRecord.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'LocatorObjectRecordEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection GetMultiLocatorObjectRecord(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiLocatorObjectRecord(forceFetch, _locatorObjectRecord.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection GetMultiLocatorObjectRecord(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiLocatorObjectRecord(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection GetMultiLocatorObjectRecord(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedLocatorObjectRecord || forceFetch || _alwaysFetchLocatorObjectRecord) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorObjectRecord.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorObjectRecord);
					}
				}
				_locatorObjectRecord.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorObjectRecord.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorObjectRecord.GetMultiManyToOne(this, null, null, filter);
				_locatorObjectRecord.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorObjectRecord = true;
			}
			return _locatorObjectRecord;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorObjectRecord'. These settings will be taken into account
		/// when the property LocatorObjectRecord is requested or GetMultiLocatorObjectRecord is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorObjectRecord(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorObjectRecord.SortClauses=sortClauses;
			_locatorObjectRecord.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
				_locatorObjectValue.GetMultiManyToOne(this, null, filter);
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

		/// <summary> Retrieves all related entities of type 'Enum_DataTypeEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'Enum_DataTypeEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection GetMultiEnum_DataTypeCollectionViaLocatorObjectRecord(bool forceFetch)
		{
			return GetMultiEnum_DataTypeCollectionViaLocatorObjectRecord(forceFetch, _enum_DataTypeCollectionViaLocatorObjectRecord.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'Enum_DataTypeEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection GetMultiEnum_DataTypeCollectionViaLocatorObjectRecord(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord || forceFetch || _alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_enum_DataTypeCollectionViaLocatorObjectRecord.ParticipatesInTransaction)
					{
						base.Transaction.Add(_enum_DataTypeCollectionViaLocatorObjectRecord);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed, "LocatorObjectRecord_");
				relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue, "LocatorObjectRecord_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Value), ComparisonOperator.Equal, this.Enum_Value));
				_enum_DataTypeCollectionViaLocatorObjectRecord.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_enum_DataTypeCollectionViaLocatorObjectRecord.EntityFactoryToUse = entityFactoryToUse;
				}
				_enum_DataTypeCollectionViaLocatorObjectRecord.GetMulti(filter, relations);
				_enum_DataTypeCollectionViaLocatorObjectRecord.SuppressClearInGetMulti=false;
				_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = true;
			}
			return _enum_DataTypeCollectionViaLocatorObjectRecord;
		}

		/// <summary> Sets the collection parameters for the collection for 'Enum_DataTypeCollectionViaLocatorObjectRecord'. These settings will be taken into account
		/// when the property Enum_DataTypeCollectionViaLocatorObjectRecord is requested or GetMultiEnum_DataTypeCollectionViaLocatorObjectRecord is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersEnum_DataTypeCollectionViaLocatorObjectRecord(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_enum_DataTypeCollectionViaLocatorObjectRecord.SortClauses=sortClauses;
			_enum_DataTypeCollectionViaLocatorObjectRecord.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'LocatorEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorCollection GetMultiLocatorCollectionViaLocatorObjectRecord(bool forceFetch)
		{
			return GetMultiLocatorCollectionViaLocatorObjectRecord(forceFetch, _locatorCollectionViaLocatorObjectRecord.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'LocatorEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorCollection GetMultiLocatorCollectionViaLocatorObjectRecord(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedLocatorCollectionViaLocatorObjectRecord || forceFetch || _alwaysFetchLocatorCollectionViaLocatorObjectRecord) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorCollectionViaLocatorObjectRecord.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorCollectionViaLocatorObjectRecord);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed, "LocatorObjectRecord_");
				relations.Add(LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID, "LocatorObjectRecord_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Value), ComparisonOperator.Equal, this.Enum_Value));
				_locatorCollectionViaLocatorObjectRecord.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorCollectionViaLocatorObjectRecord.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorCollectionViaLocatorObjectRecord.GetMulti(filter, relations);
				_locatorCollectionViaLocatorObjectRecord.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorCollectionViaLocatorObjectRecord = true;
			}
			return _locatorCollectionViaLocatorObjectRecord;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorCollectionViaLocatorObjectRecord'. These settings will be taken into account
		/// when the property LocatorCollectionViaLocatorObjectRecord is requested or GetMultiLocatorCollectionViaLocatorObjectRecord is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorCollectionViaLocatorObjectRecord(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorCollectionViaLocatorObjectRecord.SortClauses=sortClauses;
			_locatorCollectionViaLocatorObjectRecord.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorObjectRecordEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection GetMultiLocatorObjectRecordCollectionViaLocatorObjectValue(bool forceFetch)
		{
			return GetMultiLocatorObjectRecordCollectionViaLocatorObjectValue(forceFetch, _locatorObjectRecordCollectionViaLocatorObjectValue.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection GetMultiLocatorObjectRecordCollectionViaLocatorObjectValue(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue || forceFetch || _alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorObjectRecordCollectionViaLocatorObjectValue.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorObjectRecordCollectionViaLocatorObjectValue);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectValueEntityUsingDataSource_EnumValue, "LocatorObjectValue_");
				relations.Add(LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID, "LocatorObjectValue_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Value), ComparisonOperator.Equal, this.Enum_Value));
				_locatorObjectRecordCollectionViaLocatorObjectValue.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorObjectRecordCollectionViaLocatorObjectValue.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorObjectRecordCollectionViaLocatorObjectValue.GetMulti(filter, relations);
				_locatorObjectRecordCollectionViaLocatorObjectValue.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue = true;
			}
			return _locatorObjectRecordCollectionViaLocatorObjectValue;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorObjectRecordCollectionViaLocatorObjectValue'. These settings will be taken into account
		/// when the property LocatorObjectRecordCollectionViaLocatorObjectValue is requested or GetMultiLocatorObjectRecordCollectionViaLocatorObjectValue is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorObjectRecordCollectionViaLocatorObjectValue(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorObjectRecordCollectionViaLocatorObjectValue.SortClauses=sortClauses;
			_locatorObjectRecordCollectionViaLocatorObjectValue.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


	
		#region Data binding change event raising methods

		/// <summary> Event thrower for the Enum_ValueChanged event, which is thrown when Enum_Value changes value. Databinding related.</summary>
		protected virtual void OnEnum_ValueChanged()
		{
			if(Enum_ValueChanged!=null)
			{
				Enum_ValueChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the Enum_DescriptionChanged event, which is thrown when Enum_Description changes value. Databinding related.</summary>
		protected virtual void OnEnum_DescriptionChanged()
		{
			if(Enum_DescriptionChanged!=null)
			{
				Enum_DescriptionChanged(this, new EventArgs());
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
				switch((Enum_DataSourceFieldIndex)fieldIndex)
				{
					default:
						break;
				}
				base.PostFieldValueSetAction(toReturn);
				switch((Enum_DataSourceFieldIndex)fieldIndex)
				{
					case Enum_DataSourceFieldIndex.Enum_Value:
						OnEnum_ValueChanged();
						break;
					case Enum_DataSourceFieldIndex.Enum_Description:
						OnEnum_DescriptionChanged();
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
			Enum_DataSourceDAO dao = (Enum_DataSourceDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_locatorObjectRecord.ActiveContext = base.ActiveContext;
			_locatorObjectValue.ActiveContext = base.ActiveContext;
			_enum_DataTypeCollectionViaLocatorObjectRecord.ActiveContext = base.ActiveContext;
			_locatorCollectionViaLocatorObjectRecord.ActiveContext = base.ActiveContext;
			_locatorObjectRecordCollectionViaLocatorObjectValue.ActiveContext = base.ActiveContext;



		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			Enum_DataSourceDAO dao = (Enum_DataSourceDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			Enum_DataSourceDAO dao = (Enum_DataSourceDAO)CreateDAOInstance();
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
			OnEnum_ValueChanged();
			OnEnum_DescriptionChanged();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
		}

		/// <summary>Creates field validator object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IValidator CreateValidator()
		{
			return new Enum_DataSourceValidator();
		}


		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validator">The validator object for this Enum_DataSourceEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Byte enum_Value, IValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);

			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(enum_Value, prefetchPathToUse, null);
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
			_locatorObjectRecord = new TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection(propertyDescriptorFactoryToUse, new LocatorObjectRecordEntityFactory());
			_locatorObjectRecord.SetContainingEntityInfo(this, "Enum_DataSource");
			_alwaysFetchLocatorObjectRecord = false;
			_alreadyFetchedLocatorObjectRecord = false;
			_locatorObjectValue = new TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection(propertyDescriptorFactoryToUse, new LocatorObjectValueEntityFactory());
			_locatorObjectValue.SetContainingEntityInfo(this, "Enum_DataSource");
			_alwaysFetchLocatorObjectValue = false;
			_alreadyFetchedLocatorObjectValue = false;
			_enum_DataTypeCollectionViaLocatorObjectRecord = new TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection(propertyDescriptorFactoryToUse, new Enum_DataTypeEntityFactory());
			_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord = false;
			_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = false;
			_locatorCollectionViaLocatorObjectRecord = new TestHarness.DataObjects.CollectionClasses.LocatorCollection(propertyDescriptorFactoryToUse, new LocatorEntityFactory());
			_alwaysFetchLocatorCollectionViaLocatorObjectRecord = false;
			_alreadyFetchedLocatorCollectionViaLocatorObjectRecord = false;
			_locatorObjectRecordCollectionViaLocatorObjectValue = new TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection(propertyDescriptorFactoryToUse, new LocatorObjectRecordEntityFactory());
			_alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue = false;
			_alreadyFetchedLocatorObjectRecordCollectionViaLocatorObjectValue = false;


			
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

			_fieldsCustomProperties.Add("Enum_Value", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Enum_Description", fieldHashtable);
		}
		#endregion




		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="enum_Value">PK value for Enum_DataSource which data should be fetched into this Enum_DataSource object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Byte enum_Value, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)Enum_DataSourceFieldIndex.Enum_Value].ForcedCurrentValueWrite(enum_Value);
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
			return DAOFactory.CreateEnum_DataSourceDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactoryInstance()
		{
			return new Enum_DataSourceEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static Enum_DataSourceRelations Relations
		{
			get	{ return new Enum_DataSourceRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorObjectRecord' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorObjectRecord
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection(),
					Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed, 
					(int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, (int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, 0, null, null, null, "LocatorObjectRecord", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorObjectValue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorObjectValue
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorObjectValueCollection(),
					Enum_DataSourceEntity.Relations.LocatorObjectValueEntityUsingDataSource_EnumValue, 
					(int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, (int)TestHarness.DataObjects.EntityType.LocatorObjectValueEntity, 0, null, null, null, "LocatorObjectValue", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_DataType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_DataTypeCollectionViaLocatorObjectRecord
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed);
				relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection(),
					Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed,
					(int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, (int)TestHarness.DataObjects.EntityType.Enum_DataTypeEntity, 0, null, null, relations, "Enum_DataTypeCollectionViaLocatorObjectRecord", RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Locator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorCollectionViaLocatorObjectRecord
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed);
				relations.Add(LocatorObjectRecordEntity.Relations.LocatorEntityUsingProduct_YearLocator_ID);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorCollection(),
					Enum_DataSourceEntity.Relations.LocatorObjectRecordEntityUsingDatasourceUsed,
					(int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, (int)TestHarness.DataObjects.EntityType.LocatorEntity, 0, null, null, relations, "LocatorCollectionViaLocatorObjectRecord", RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorObjectRecord' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorObjectRecordCollectionViaLocatorObjectValue
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(Enum_DataSourceEntity.Relations.LocatorObjectValueEntityUsingDataSource_EnumValue);
				relations.Add(LocatorObjectValueEntity.Relations.LocatorObjectRecordEntityUsingRecord_ID);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection(),
					Enum_DataSourceEntity.Relations.LocatorObjectValueEntityUsingDataSource_EnumValue,
					(int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, (int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, 0, null, null, relations, "LocatorObjectRecordCollectionViaLocatorObjectValue", RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return Enum_DataSourceEntity.CustomProperties;}
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
			get { return Enum_DataSourceEntity.FieldsCustomProperties;}
		}

		/// <summary> The Enum_Value property of the Entity Enum_DataSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Enum_DataSource"."Enum_Value"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Byte Enum_Value
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)Enum_DataSourceFieldIndex.Enum_Value);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				return (System.Byte)valueToReturn;
			}
			set	{ SetNewFieldValue((int)Enum_DataSourceFieldIndex.Enum_Value, value); }
		}
		/// <summary> The Enum_Description property of the Entity Enum_DataSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Enum_DataSource"."Enum_Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Enum_Description
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)Enum_DataSourceFieldIndex.Enum_Description);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)Enum_DataSourceFieldIndex.Enum_Description, value); }
		}

		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorObjectRecord()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection LocatorObjectRecord
		{
			get	{ return GetMultiLocatorObjectRecord(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorObjectRecord. When set to true, LocatorObjectRecord is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorObjectRecord is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorObjectRecord(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorObjectRecord
		{
			get	{ return _alwaysFetchLocatorObjectRecord; }
			set	{ _alwaysFetchLocatorObjectRecord = value; }	
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

		/// <summary> Retrieves all related entities of type 'Enum_DataTypeEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiEnum_DataTypeCollectionViaLocatorObjectRecord()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection Enum_DataTypeCollectionViaLocatorObjectRecord
		{
			get { return GetMultiEnum_DataTypeCollectionViaLocatorObjectRecord(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_DataTypeCollectionViaLocatorObjectRecord. When set to true, Enum_DataTypeCollectionViaLocatorObjectRecord is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_DataTypeCollectionViaLocatorObjectRecord is accessed. You can always execute
		/// a forced fetch by calling GetMultiEnum_DataTypeCollectionViaLocatorObjectRecord(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord
		{
			get	{ return _alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord; }
			set	{ _alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord = value; }	
		}
		/// <summary> Retrieves all related entities of type 'LocatorEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorCollectionViaLocatorObjectRecord()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorCollection LocatorCollectionViaLocatorObjectRecord
		{
			get { return GetMultiLocatorCollectionViaLocatorObjectRecord(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorCollectionViaLocatorObjectRecord. When set to true, LocatorCollectionViaLocatorObjectRecord is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorCollectionViaLocatorObjectRecord is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorCollectionViaLocatorObjectRecord(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorCollectionViaLocatorObjectRecord
		{
			get	{ return _alwaysFetchLocatorCollectionViaLocatorObjectRecord; }
			set	{ _alwaysFetchLocatorCollectionViaLocatorObjectRecord = value; }	
		}
		/// <summary> Retrieves all related entities of type 'LocatorObjectRecordEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorObjectRecordCollectionViaLocatorObjectValue()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection LocatorObjectRecordCollectionViaLocatorObjectValue
		{
			get { return GetMultiLocatorObjectRecordCollectionViaLocatorObjectValue(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorObjectRecordCollectionViaLocatorObjectValue. When set to true, LocatorObjectRecordCollectionViaLocatorObjectValue is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorObjectRecordCollectionViaLocatorObjectValue is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorObjectRecordCollectionViaLocatorObjectValue(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue
		{
			get	{ return _alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue; }
			set	{ _alwaysFetchLocatorObjectRecordCollectionViaLocatorObjectValue = value; }	
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
			get { return (int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity; }
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
