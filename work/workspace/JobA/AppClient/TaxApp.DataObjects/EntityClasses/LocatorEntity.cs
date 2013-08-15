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
	/// Entity class which represents the entity 'Locator'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LocatorEntity : EntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection	_clientLocator;
		private bool	_alwaysFetchClientLocator, _alreadyFetchedClientLocator;
		private TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection	_locatorNodeComputedValue;
		private bool	_alwaysFetchLocatorNodeComputedValue, _alreadyFetchedLocatorNodeComputedValue;
		private TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection	_locatorObjectRecord;
		private bool	_alwaysFetchLocatorObjectRecord, _alreadyFetchedLocatorObjectRecord;
		private TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection	_locatorRollover;
		private bool	_alwaysFetchLocatorRollover, _alreadyFetchedLocatorRollover;
		private TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection	_locatorRollover_;
		private bool	_alwaysFetchLocatorRollover_, _alreadyFetchedLocatorRollover_;
		private TestHarness.DataObjects.CollectionClasses.ClientCollection _clientCollectionViaClientLocator;
		private bool	_alwaysFetchClientCollectionViaClientLocator, _alreadyFetchedClientCollectionViaClientLocator;
		private TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection _enum_DataSourceCollectionViaLocatorObjectRecord;
		private bool	_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord, _alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord;
		private TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection _enum_DataTypeCollectionViaLocatorObjectRecord;
		private bool	_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord, _alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord;



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
		/// <summary>Event which is thrown when Locator_Name changes value. Databinding related.</summary>
		public event EventHandler Locator_NameChanged;
		/// <summary>Event which is thrown when TaxPeriod changes value. Databinding related.</summary>
		public event EventHandler TaxPeriodChanged;

		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LocatorEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public LocatorEntity()
		{
			InitClassEmpty(new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), CreateValidator());
		}


		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		public LocatorEntity(System.Int16 product_Year, System.Int32 locator_ID)
		{
			InitClassFetch(product_Year, locator_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public LocatorEntity(System.Int16 product_Year, System.Int32 locator_ID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(product_Year, locator_ID, CreateValidator(), new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="validator">The custom validator object for this LocatorEntity</param>
		public LocatorEntity(System.Int16 product_Year, System.Int32 locator_ID, LocatorValidator validator)
		{
			InitClassFetch(product_Year, locator_ID, validator, new PropertyDescriptorFactory(), CreateEntityFactoryInstance(), null);
		}

		/// <summary>CTor</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="validator">The custom validator object for this LocatorEntity</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public LocatorEntity(System.Int16 product_Year, System.Int32 locator_ID, LocatorValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassFetch(product_Year, locator_ID, validator, propertyDescriptorFactoryToUse, entityFactoryToUse, null);
		}

		/// <summary>CTor</summary>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public LocatorEntity(IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse)
		{
			InitClassEmpty(propertyDescriptorFactoryToUse, entityFactoryToUse, CreateValidator());
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LocatorEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_clientLocator = (TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection)info.GetValue("_clientLocator", typeof(TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection));
			_alwaysFetchClientLocator = info.GetBoolean("_alwaysFetchClientLocator");
			_alreadyFetchedClientLocator = info.GetBoolean("_alreadyFetchedClientLocator");
			_locatorNodeComputedValue = (TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection)info.GetValue("_locatorNodeComputedValue", typeof(TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection));
			_alwaysFetchLocatorNodeComputedValue = info.GetBoolean("_alwaysFetchLocatorNodeComputedValue");
			_alreadyFetchedLocatorNodeComputedValue = info.GetBoolean("_alreadyFetchedLocatorNodeComputedValue");
			_locatorObjectRecord = (TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection)info.GetValue("_locatorObjectRecord", typeof(TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection));
			_alwaysFetchLocatorObjectRecord = info.GetBoolean("_alwaysFetchLocatorObjectRecord");
			_alreadyFetchedLocatorObjectRecord = info.GetBoolean("_alreadyFetchedLocatorObjectRecord");
			_locatorRollover = (TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection)info.GetValue("_locatorRollover", typeof(TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection));
			_alwaysFetchLocatorRollover = info.GetBoolean("_alwaysFetchLocatorRollover");
			_alreadyFetchedLocatorRollover = info.GetBoolean("_alreadyFetchedLocatorRollover");
			_locatorRollover_ = (TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection)info.GetValue("_locatorRollover_", typeof(TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection));
			_alwaysFetchLocatorRollover_ = info.GetBoolean("_alwaysFetchLocatorRollover_");
			_alreadyFetchedLocatorRollover_ = info.GetBoolean("_alreadyFetchedLocatorRollover_");
			_clientCollectionViaClientLocator = (TestHarness.DataObjects.CollectionClasses.ClientCollection)info.GetValue("_clientCollectionViaClientLocator", typeof(TestHarness.DataObjects.CollectionClasses.ClientCollection));
			_alwaysFetchClientCollectionViaClientLocator = info.GetBoolean("_alwaysFetchClientCollectionViaClientLocator");
			_alreadyFetchedClientCollectionViaClientLocator = info.GetBoolean("_alreadyFetchedClientCollectionViaClientLocator");
			_enum_DataSourceCollectionViaLocatorObjectRecord = (TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection)info.GetValue("_enum_DataSourceCollectionViaLocatorObjectRecord", typeof(TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection));
			_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord = info.GetBoolean("_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord");
			_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord = info.GetBoolean("_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord");
			_enum_DataTypeCollectionViaLocatorObjectRecord = (TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection)info.GetValue("_enum_DataTypeCollectionViaLocatorObjectRecord", typeof(TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection));
			_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord = info.GetBoolean("_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord");
			_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = info.GetBoolean("_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord");


			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary> Will perform post-ReadXml actions as well as the normal ReadXml() actions, performed by the base class.</summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element of the entity's Xml data</param>
		public override void ReadXml(System.Xml.XmlNode node)
		{
			base.ReadXml (node);
			_alreadyFetchedClientLocator = (_clientLocator.Count > 0);
			_alreadyFetchedLocatorNodeComputedValue = (_locatorNodeComputedValue.Count > 0);
			_alreadyFetchedLocatorObjectRecord = (_locatorObjectRecord.Count > 0);
			_alreadyFetchedLocatorRollover = (_locatorRollover.Count > 0);
			_alreadyFetchedLocatorRollover_ = (_locatorRollover_.Count > 0);
			_alreadyFetchedClientCollectionViaClientLocator = (_clientCollectionViaClientLocator.Count > 0);
			_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord = (_enum_DataSourceCollectionViaLocatorObjectRecord.Count > 0);
			_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = (_enum_DataTypeCollectionViaLocatorObjectRecord.Count > 0);


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
			info.AddValue("_clientLocator", _clientLocator);
			info.AddValue("_alwaysFetchClientLocator", _alwaysFetchClientLocator);
			info.AddValue("_alreadyFetchedClientLocator", _alreadyFetchedClientLocator);
			info.AddValue("_locatorNodeComputedValue", _locatorNodeComputedValue);
			info.AddValue("_alwaysFetchLocatorNodeComputedValue", _alwaysFetchLocatorNodeComputedValue);
			info.AddValue("_alreadyFetchedLocatorNodeComputedValue", _alreadyFetchedLocatorNodeComputedValue);
			info.AddValue("_locatorObjectRecord", _locatorObjectRecord);
			info.AddValue("_alwaysFetchLocatorObjectRecord", _alwaysFetchLocatorObjectRecord);
			info.AddValue("_alreadyFetchedLocatorObjectRecord", _alreadyFetchedLocatorObjectRecord);
			info.AddValue("_locatorRollover", _locatorRollover);
			info.AddValue("_alwaysFetchLocatorRollover", _alwaysFetchLocatorRollover);
			info.AddValue("_alreadyFetchedLocatorRollover", _alreadyFetchedLocatorRollover);
			info.AddValue("_locatorRollover_", _locatorRollover_);
			info.AddValue("_alwaysFetchLocatorRollover_", _alwaysFetchLocatorRollover_);
			info.AddValue("_alreadyFetchedLocatorRollover_", _alreadyFetchedLocatorRollover_);
			info.AddValue("_clientCollectionViaClientLocator", _clientCollectionViaClientLocator);
			info.AddValue("_alwaysFetchClientCollectionViaClientLocator", _alwaysFetchClientCollectionViaClientLocator);
			info.AddValue("_alreadyFetchedClientCollectionViaClientLocator", _alreadyFetchedClientCollectionViaClientLocator);
			info.AddValue("_enum_DataSourceCollectionViaLocatorObjectRecord", _enum_DataSourceCollectionViaLocatorObjectRecord);
			info.AddValue("_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord", _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord);
			info.AddValue("_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord", _alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord);
			info.AddValue("_enum_DataTypeCollectionViaLocatorObjectRecord", _enum_DataTypeCollectionViaLocatorObjectRecord);
			info.AddValue("_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord", _alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord);
			info.AddValue("_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord", _alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord);


			
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

				case "ClientLocator":
					_alreadyFetchedClientLocator = true;
					if(entity!=null)
					{
						this.ClientLocator.Add((ClientLocatorEntity)entity);
					}
					break;
				case "LocatorNodeComputedValue":
					_alreadyFetchedLocatorNodeComputedValue = true;
					if(entity!=null)
					{
						this.LocatorNodeComputedValue.Add((LocatorNodeComputedValueEntity)entity);
					}
					break;
				case "LocatorObjectRecord":
					_alreadyFetchedLocatorObjectRecord = true;
					if(entity!=null)
					{
						this.LocatorObjectRecord.Add((LocatorObjectRecordEntity)entity);
					}
					break;
				case "LocatorRollover":
					_alreadyFetchedLocatorRollover = true;
					if(entity!=null)
					{
						this.LocatorRollover.Add((LocatorRolloverEntity)entity);
					}
					break;
				case "LocatorRollover_":
					_alreadyFetchedLocatorRollover_ = true;
					if(entity!=null)
					{
						this.LocatorRollover_.Add((LocatorRolloverEntity)entity);
					}
					break;
				case "ClientCollectionViaClientLocator":
					_alreadyFetchedClientCollectionViaClientLocator = true;
					if(entity!=null)
					{
						this.ClientCollectionViaClientLocator.Add((ClientEntity)entity);
					}
					break;
				case "Enum_DataSourceCollectionViaLocatorObjectRecord":
					_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord = true;
					if(entity!=null)
					{
						this.Enum_DataSourceCollectionViaLocatorObjectRecord.Add((Enum_DataSourceEntity)entity);
					}
					break;
				case "Enum_DataTypeCollectionViaLocatorObjectRecord":
					_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = true;
					if(entity!=null)
					{
						this.Enum_DataTypeCollectionViaLocatorObjectRecord.Add((Enum_DataTypeEntity)entity);
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

				case "ClientLocator":
					_clientLocator.Add(relatedEntity);
					break;
				case "LocatorNodeComputedValue":
					_locatorNodeComputedValue.Add(relatedEntity);
					break;
				case "LocatorObjectRecord":
					_locatorObjectRecord.Add(relatedEntity);
					break;
				case "LocatorRollover":
					_locatorRollover.Add(relatedEntity);
					break;
				case "LocatorRollover_":
					_locatorRollover_.Add(relatedEntity);
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

				case "ClientLocator":
					_clientLocator.Remove(relatedEntity);
					break;
				case "LocatorNodeComputedValue":
					_locatorNodeComputedValue.Remove(relatedEntity);
					break;
				case "LocatorObjectRecord":
					_locatorObjectRecord.Remove(relatedEntity);
					break;
				case "LocatorRollover":
					_locatorRollover.Remove(relatedEntity);
					break;
				case "LocatorRollover_":
					_locatorRollover_.Remove(relatedEntity);
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
			toReturn.Add(_clientLocator);
			toReturn.Add(_locatorNodeComputedValue);
			toReturn.Add(_locatorObjectRecord);
			toReturn.Add(_locatorRollover);
			toReturn.Add(_locatorRollover_);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 locator_ID)
		{
			return FetchUsingPK(product_Year, locator_ID, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 locator_ID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(product_Year, locator_ID, prefetchPathToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 product_Year, System.Int32 locator_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(product_Year, locator_ID, prefetchPathToUse, contextToUse);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Product_Year, this.Locator_ID, null, null);
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
		public bool TestOriginalFieldValueForNull(LocatorFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(LocatorFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("LocatorEntity", ((TestHarness.DataObjects.EntityType)typeOfEntity).ToString());
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
				_clientLocator.GetMultiManyToOne(null, this, filter);
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

		/// <summary> Retrieves all related entities of type 'LocatorNodeComputedValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorNodeComputedValueEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection GetMultiLocatorNodeComputedValue(bool forceFetch)
		{
			return GetMultiLocatorNodeComputedValue(forceFetch, _locatorNodeComputedValue.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorNodeComputedValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'LocatorNodeComputedValueEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection GetMultiLocatorNodeComputedValue(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiLocatorNodeComputedValue(forceFetch, _locatorNodeComputedValue.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'LocatorNodeComputedValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection GetMultiLocatorNodeComputedValue(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiLocatorNodeComputedValue(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorNodeComputedValueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection GetMultiLocatorNodeComputedValue(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedLocatorNodeComputedValue || forceFetch || _alwaysFetchLocatorNodeComputedValue) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorNodeComputedValue.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorNodeComputedValue);
					}
				}
				_locatorNodeComputedValue.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorNodeComputedValue.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorNodeComputedValue.GetMultiManyToOne(this, filter);
				_locatorNodeComputedValue.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorNodeComputedValue = true;
			}
			return _locatorNodeComputedValue;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorNodeComputedValue'. These settings will be taken into account
		/// when the property LocatorNodeComputedValue is requested or GetMultiLocatorNodeComputedValue is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorNodeComputedValue(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorNodeComputedValue.SortClauses=sortClauses;
			_locatorNodeComputedValue.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
				_locatorObjectRecord.GetMultiManyToOne(null, null, this, filter);
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

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorRolloverEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover(bool forceFetch)
		{
			return GetMultiLocatorRollover(forceFetch, _locatorRollover.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'LocatorRolloverEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiLocatorRollover(forceFetch, _locatorRollover.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiLocatorRollover(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedLocatorRollover || forceFetch || _alwaysFetchLocatorRollover) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorRollover.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorRollover);
					}
				}
				_locatorRollover.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorRollover.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorRollover.GetMultiManyToOne(this, null, filter);
				_locatorRollover.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorRollover = true;
			}
			return _locatorRollover;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorRollover'. These settings will be taken into account
		/// when the property LocatorRollover is requested or GetMultiLocatorRollover is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorRollover(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorRollover.SortClauses=sortClauses;
			_locatorRollover.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocatorRolloverEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover_(bool forceFetch)
		{
			return GetMultiLocatorRollover_(forceFetch, _locatorRollover_.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'LocatorRolloverEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover_(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiLocatorRollover_(forceFetch, _locatorRollover_.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover_(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiLocatorRollover_(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection GetMultiLocatorRollover_(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedLocatorRollover_ || forceFetch || _alwaysFetchLocatorRollover_) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_locatorRollover_.ParticipatesInTransaction)
					{
						base.Transaction.Add(_locatorRollover_);
					}
				}
				_locatorRollover_.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_locatorRollover_.EntityFactoryToUse = entityFactoryToUse;
				}
				_locatorRollover_.GetMultiManyToOne(null, this, filter);
				_locatorRollover_.SuppressClearInGetMulti=false;
				_alreadyFetchedLocatorRollover_ = true;
			}
			return _locatorRollover_;
		}

		/// <summary> Sets the collection parameters for the collection for 'LocatorRollover_'. These settings will be taken into account
		/// when the property LocatorRollover_ is requested or GetMultiLocatorRollover_ is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocatorRollover_(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locatorRollover_.SortClauses=sortClauses;
			_locatorRollover_.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ClientEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ClientEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientCollection GetMultiClientCollectionViaClientLocator(bool forceFetch)
		{
			return GetMultiClientCollectionViaClientLocator(forceFetch, _clientCollectionViaClientLocator.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'ClientEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.ClientCollection GetMultiClientCollectionViaClientLocator(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedClientCollectionViaClientLocator || forceFetch || _alwaysFetchClientCollectionViaClientLocator) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_clientCollectionViaClientLocator.ParticipatesInTransaction)
					{
						base.Transaction.Add(_clientCollectionViaClientLocator);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(LocatorEntity.Relations.ClientLocatorEntityUsingProduct_YearLocator_ID, "ClientLocator_");
				relations.Add(ClientLocatorEntity.Relations.ClientEntityUsingProduct_YearClient_ID, "ClientLocator_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), ComparisonOperator.Equal, this.Product_Year));
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), ComparisonOperator.Equal, this.Locator_ID));
				_clientCollectionViaClientLocator.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_clientCollectionViaClientLocator.EntityFactoryToUse = entityFactoryToUse;
				}
				_clientCollectionViaClientLocator.GetMulti(filter, relations);
				_clientCollectionViaClientLocator.SuppressClearInGetMulti=false;
				_alreadyFetchedClientCollectionViaClientLocator = true;
			}
			return _clientCollectionViaClientLocator;
		}

		/// <summary> Sets the collection parameters for the collection for 'ClientCollectionViaClientLocator'. These settings will be taken into account
		/// when the property ClientCollectionViaClientLocator is requested or GetMultiClientCollectionViaClientLocator is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersClientCollectionViaClientLocator(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_clientCollectionViaClientLocator.SortClauses=sortClauses;
			_clientCollectionViaClientLocator.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'Enum_DataSourceEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'Enum_DataSourceEntity'</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection GetMultiEnum_DataSourceCollectionViaLocatorObjectRecord(bool forceFetch)
		{
			return GetMultiEnum_DataSourceCollectionViaLocatorObjectRecord(forceFetch, _enum_DataSourceCollectionViaLocatorObjectRecord.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'Enum_DataSourceEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection GetMultiEnum_DataSourceCollectionViaLocatorObjectRecord(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord || forceFetch || _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord) && !base.IsSerializing && !base.IsDeserializing && !EntityCollectionBase.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_enum_DataSourceCollectionViaLocatorObjectRecord.ParticipatesInTransaction)
					{
						base.Transaction.Add(_enum_DataSourceCollectionViaLocatorObjectRecord);
					}
				}
				IRelationCollection relations = new RelationCollection();
				IPredicateExpression filter = new PredicateExpression();
				relations.Add(LocatorEntity.Relations.LocatorObjectRecordEntityUsingProduct_YearLocator_ID, "LocatorObjectRecord_");
				relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataSourceEntityUsingDatasourceUsed, "LocatorObjectRecord_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), ComparisonOperator.Equal, this.Product_Year));
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), ComparisonOperator.Equal, this.Locator_ID));
				_enum_DataSourceCollectionViaLocatorObjectRecord.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_enum_DataSourceCollectionViaLocatorObjectRecord.EntityFactoryToUse = entityFactoryToUse;
				}
				_enum_DataSourceCollectionViaLocatorObjectRecord.GetMulti(filter, relations);
				_enum_DataSourceCollectionViaLocatorObjectRecord.SuppressClearInGetMulti=false;
				_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord = true;
			}
			return _enum_DataSourceCollectionViaLocatorObjectRecord;
		}

		/// <summary> Sets the collection parameters for the collection for 'Enum_DataSourceCollectionViaLocatorObjectRecord'. These settings will be taken into account
		/// when the property Enum_DataSourceCollectionViaLocatorObjectRecord is requested or GetMultiEnum_DataSourceCollectionViaLocatorObjectRecord is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersEnum_DataSourceCollectionViaLocatorObjectRecord(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_enum_DataSourceCollectionViaLocatorObjectRecord.SortClauses=sortClauses;
			_enum_DataSourceCollectionViaLocatorObjectRecord.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
				relations.Add(LocatorEntity.Relations.LocatorObjectRecordEntityUsingProduct_YearLocator_ID, "LocatorObjectRecord_");
				relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue, "LocatorObjectRecord_", string.Empty, JoinHint.None);
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(LocatorFieldIndex.Product_Year), ComparisonOperator.Equal, this.Product_Year));
				filter.Add(new FieldCompareValuePredicate(EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID), ComparisonOperator.Equal, this.Locator_ID));
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

		/// <summary> Event thrower for the Locator_NameChanged event, which is thrown when Locator_Name changes value. Databinding related.</summary>
		protected virtual void OnLocator_NameChanged()
		{
			if(Locator_NameChanged!=null)
			{
				Locator_NameChanged(this, new EventArgs());
			}
		}

		/// <summary> Event thrower for the TaxPeriodChanged event, which is thrown when TaxPeriod changes value. Databinding related.</summary>
		protected virtual void OnTaxPeriodChanged()
		{
			if(TaxPeriodChanged!=null)
			{
				TaxPeriodChanged(this, new EventArgs());
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
				switch((LocatorFieldIndex)fieldIndex)
				{
					default:
						break;
				}
				base.PostFieldValueSetAction(toReturn);
				switch((LocatorFieldIndex)fieldIndex)
				{
					case LocatorFieldIndex.Product_Year:
						OnProduct_YearChanged();
						break;
					case LocatorFieldIndex.Locator_ID:
						OnLocator_IDChanged();
						break;
					case LocatorFieldIndex.Locator_Name:
						OnLocator_NameChanged();
						break;
					case LocatorFieldIndex.TaxPeriod:
						OnTaxPeriodChanged();
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
			LocatorDAO dao = (LocatorDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_clientLocator.ActiveContext = base.ActiveContext;
			_locatorNodeComputedValue.ActiveContext = base.ActiveContext;
			_locatorObjectRecord.ActiveContext = base.ActiveContext;
			_locatorRollover.ActiveContext = base.ActiveContext;
			_locatorRollover_.ActiveContext = base.ActiveContext;
			_clientCollectionViaClientLocator.ActiveContext = base.ActiveContext;
			_enum_DataSourceCollectionViaLocatorObjectRecord.ActiveContext = base.ActiveContext;
			_enum_DataTypeCollectionViaLocatorObjectRecord.ActiveContext = base.ActiveContext;



		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			LocatorDAO dao = (LocatorDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			LocatorDAO dao = (LocatorDAO)CreateDAOInstance();
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
			OnLocator_NameChanged();
			OnTaxPeriodChanged();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorEntity);
		}

		/// <summary>Creates field validator object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IValidator CreateValidator()
		{
			return new LocatorValidator();
		}


		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="propertyDescriptorFactoryToUse">PropertyDescriptor factory to use in GetItemProperties method of contained collections. Complex databinding related.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="validator">The validator object for this LocatorEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int16 product_Year, System.Int32 locator_ID, IValidator validator, IPropertyDescriptorFactory propertyDescriptorFactoryToUse, IEntityFactory entityFactoryToUse, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers(propertyDescriptorFactoryToUse, entityFactoryToUse);

			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(product_Year, locator_ID, prefetchPathToUse, null);
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
			_clientLocator = new TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection(propertyDescriptorFactoryToUse, new ClientLocatorEntityFactory());
			_clientLocator.SetContainingEntityInfo(this, "Locator");
			_alwaysFetchClientLocator = false;
			_alreadyFetchedClientLocator = false;
			_locatorNodeComputedValue = new TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection(propertyDescriptorFactoryToUse, new LocatorNodeComputedValueEntityFactory());
			_locatorNodeComputedValue.SetContainingEntityInfo(this, "Locator");
			_alwaysFetchLocatorNodeComputedValue = false;
			_alreadyFetchedLocatorNodeComputedValue = false;
			_locatorObjectRecord = new TestHarness.DataObjects.CollectionClasses.LocatorObjectRecordCollection(propertyDescriptorFactoryToUse, new LocatorObjectRecordEntityFactory());
			_locatorObjectRecord.SetContainingEntityInfo(this, "Locator");
			_alwaysFetchLocatorObjectRecord = false;
			_alreadyFetchedLocatorObjectRecord = false;
			_locatorRollover = new TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection(propertyDescriptorFactoryToUse, new LocatorRolloverEntityFactory());
			_locatorRollover.SetContainingEntityInfo(this, "Locator");
			_alwaysFetchLocatorRollover = false;
			_alreadyFetchedLocatorRollover = false;
			_locatorRollover_ = new TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection(propertyDescriptorFactoryToUse, new LocatorRolloverEntityFactory());
			_locatorRollover_.SetContainingEntityInfo(this, "Locator_");
			_alwaysFetchLocatorRollover_ = false;
			_alreadyFetchedLocatorRollover_ = false;
			_clientCollectionViaClientLocator = new TestHarness.DataObjects.CollectionClasses.ClientCollection(propertyDescriptorFactoryToUse, new ClientEntityFactory());
			_alwaysFetchClientCollectionViaClientLocator = false;
			_alreadyFetchedClientCollectionViaClientLocator = false;
			_enum_DataSourceCollectionViaLocatorObjectRecord = new TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection(propertyDescriptorFactoryToUse, new Enum_DataSourceEntityFactory());
			_alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord = false;
			_alreadyFetchedEnum_DataSourceCollectionViaLocatorObjectRecord = false;
			_enum_DataTypeCollectionViaLocatorObjectRecord = new TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection(propertyDescriptorFactoryToUse, new Enum_DataTypeEntityFactory());
			_alwaysFetchEnum_DataTypeCollectionViaLocatorObjectRecord = false;
			_alreadyFetchedEnum_DataTypeCollectionViaLocatorObjectRecord = false;


			
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

			_fieldsCustomProperties.Add("Locator_Name", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("TaxPeriod", fieldHashtable);
		}
		#endregion




		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="product_Year">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="locator_ID">PK value for Locator which data should be fetched into this Locator object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int16 product_Year, System.Int32 locator_ID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)LocatorFieldIndex.Product_Year].ForcedCurrentValueWrite(product_Year);
				base.Fields[(int)LocatorFieldIndex.Locator_ID].ForcedCurrentValueWrite(locator_ID);
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
			return DAOFactory.CreateLocatorDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactoryInstance()
		{
			return new LocatorEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static LocatorRelations Relations
		{
			get	{ return new LocatorRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ClientLocator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathClientLocator
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.ClientLocatorCollection(),
					LocatorEntity.Relations.ClientLocatorEntityUsingProduct_YearLocator_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.ClientLocatorEntity, 0, null, null, null, "ClientLocator", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorNodeComputedValue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorNodeComputedValue
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection(),
					LocatorEntity.Relations.LocatorNodeComputedValueEntityUsingProduct_YearLocator_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.LocatorNodeComputedValueEntity, 0, null, null, null, "LocatorNodeComputedValue", RelationType.OneToMany);
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
					LocatorEntity.Relations.LocatorObjectRecordEntityUsingProduct_YearLocator_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity, 0, null, null, null, "LocatorObjectRecord", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorRollover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorRollover
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection(),
					LocatorEntity.Relations.LocatorRolloverEntityUsingProduct_YearTarget_Locator_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.LocatorRolloverEntity, 0, null, null, null, "LocatorRollover", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LocatorRollover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocatorRollover_
		{
			get
			{
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection(),
					LocatorEntity.Relations.LocatorRolloverEntityUsingProduct_YearSource_Locator_ID, 
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.LocatorRolloverEntity, 0, null, null, null, "LocatorRollover_", RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Client' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathClientCollectionViaClientLocator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(LocatorEntity.Relations.ClientLocatorEntityUsingProduct_YearLocator_ID);
				relations.Add(ClientLocatorEntity.Relations.ClientEntityUsingProduct_YearClient_ID);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.ClientCollection(),
					LocatorEntity.Relations.ClientLocatorEntityUsingProduct_YearLocator_ID,
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.ClientEntity, 0, null, null, relations, "ClientCollectionViaClientLocator", RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Enum_DataSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEnum_DataSourceCollectionViaLocatorObjectRecord
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				relations.Add(LocatorEntity.Relations.LocatorObjectRecordEntityUsingProduct_YearLocator_ID);
				relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataSourceEntityUsingDatasourceUsed);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection(),
					LocatorEntity.Relations.LocatorObjectRecordEntityUsingProduct_YearLocator_ID,
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.Enum_DataSourceEntity, 0, null, null, relations, "Enum_DataSourceCollectionViaLocatorObjectRecord", RelationType.ManyToMany);
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
				relations.Add(LocatorEntity.Relations.LocatorObjectRecordEntityUsingProduct_YearLocator_ID);
				relations.Add(LocatorObjectRecordEntity.Relations.Enum_DataTypeEntityUsingDataType_EnumValue);
				return new PrefetchPathElement(new TestHarness.DataObjects.CollectionClasses.Enum_DataTypeCollection(),
					LocatorEntity.Relations.LocatorObjectRecordEntityUsingProduct_YearLocator_ID,
					(int)TestHarness.DataObjects.EntityType.LocatorEntity, (int)TestHarness.DataObjects.EntityType.Enum_DataTypeEntity, 0, null, null, relations, "Enum_DataTypeCollectionViaLocatorObjectRecord", RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return LocatorEntity.CustomProperties;}
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
			get { return LocatorEntity.FieldsCustomProperties;}
		}

		/// <summary> The Product_Year property of the Entity Locator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Locator"."Product_Year"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int16 Product_Year
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorFieldIndex.Product_Year);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int16));
				}
				return (System.Int16)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorFieldIndex.Product_Year, value); }
		}
		/// <summary> The Locator_ID property of the Entity Locator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Locator"."Locator_ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Locator_ID
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorFieldIndex.Locator_ID);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				return (System.Int32)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorFieldIndex.Locator_ID, value); }
		}
		/// <summary> The Locator_Name property of the Entity Locator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Locator"."Locator_Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Locator_Name
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorFieldIndex.Locator_Name);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorFieldIndex.Locator_Name, value); }
		}
		/// <summary> The TaxPeriod property of the Entity Locator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Locator"."TaxPeriod"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TaxPeriod
		{
			get
			{
				object valueToReturn = base.GetCurrentFieldValue((int)LocatorFieldIndex.TaxPeriod);
				if(valueToReturn == null)
				{
					valueToReturn = TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				return (System.String)valueToReturn;
			}
			set	{ SetNewFieldValue((int)LocatorFieldIndex.TaxPeriod, value); }
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
		/// <summary> Retrieves all related entities of type 'LocatorNodeComputedValueEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorNodeComputedValue()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorNodeComputedValueCollection LocatorNodeComputedValue
		{
			get	{ return GetMultiLocatorNodeComputedValue(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorNodeComputedValue. When set to true, LocatorNodeComputedValue is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorNodeComputedValue is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorNodeComputedValue(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorNodeComputedValue
		{
			get	{ return _alwaysFetchLocatorNodeComputedValue; }
			set	{ _alwaysFetchLocatorNodeComputedValue = value; }	
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
		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorRollover()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection LocatorRollover
		{
			get	{ return GetMultiLocatorRollover(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorRollover. When set to true, LocatorRollover is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorRollover is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorRollover(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorRollover
		{
			get	{ return _alwaysFetchLocatorRollover; }
			set	{ _alwaysFetchLocatorRollover = value; }	
		}
		/// <summary> Retrieves all related entities of type 'LocatorRolloverEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocatorRollover_()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.LocatorRolloverCollection LocatorRollover_
		{
			get	{ return GetMultiLocatorRollover_(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LocatorRollover_. When set to true, LocatorRollover_ is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LocatorRollover_ is accessed. You can always execute
		/// a forced fetch by calling GetMultiLocatorRollover_(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocatorRollover_
		{
			get	{ return _alwaysFetchLocatorRollover_; }
			set	{ _alwaysFetchLocatorRollover_ = value; }	
		}

		/// <summary> Retrieves all related entities of type 'ClientEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiClientCollectionViaClientLocator()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.ClientCollection ClientCollectionViaClientLocator
		{
			get { return GetMultiClientCollectionViaClientLocator(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ClientCollectionViaClientLocator. When set to true, ClientCollectionViaClientLocator is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ClientCollectionViaClientLocator is accessed. You can always execute
		/// a forced fetch by calling GetMultiClientCollectionViaClientLocator(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchClientCollectionViaClientLocator
		{
			get	{ return _alwaysFetchClientCollectionViaClientLocator; }
			set	{ _alwaysFetchClientCollectionViaClientLocator = value; }	
		}
		/// <summary> Retrieves all related entities of type 'Enum_DataSourceEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiEnum_DataSourceCollectionViaLocatorObjectRecord()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual TestHarness.DataObjects.CollectionClasses.Enum_DataSourceCollection Enum_DataSourceCollectionViaLocatorObjectRecord
		{
			get { return GetMultiEnum_DataSourceCollectionViaLocatorObjectRecord(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Enum_DataSourceCollectionViaLocatorObjectRecord. When set to true, Enum_DataSourceCollectionViaLocatorObjectRecord is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Enum_DataSourceCollectionViaLocatorObjectRecord is accessed. You can always execute
		/// a forced fetch by calling GetMultiEnum_DataSourceCollectionViaLocatorObjectRecord(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord
		{
			get	{ return _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord; }
			set	{ _alwaysFetchEnum_DataSourceCollectionViaLocatorObjectRecord = value; }	
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
			get { return (int)TestHarness.DataObjects.EntityType.LocatorEntity; }
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
