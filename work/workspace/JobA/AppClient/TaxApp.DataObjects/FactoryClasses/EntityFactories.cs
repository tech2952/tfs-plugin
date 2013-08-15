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
using System.Collections;
using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.HelperClasses;

using TestHarness.DataObjects.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	

	
	/// <summary>Factory to create new, empty ClientEntity objects.</summary>
	[Serializable]
	public partial class ClientEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty ClientEntity object.</summary>
		/// <returns>A new, empty ClientEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new ClientEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClient
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new ClientEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClientUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.ClientEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new ClientCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "ClientEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ClientCustomerEntity objects.</summary>
	[Serializable]
	public partial class ClientCustomerEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty ClientCustomerEntity object.</summary>
		/// <returns>A new, empty ClientCustomerEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new ClientCustomerEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClientCustomer
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new ClientCustomerEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClientCustomerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.ClientCustomerEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new ClientCustomerCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "ClientCustomerEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ClientLocatorEntity objects.</summary>
	[Serializable]
	public partial class ClientLocatorEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty ClientLocatorEntity object.</summary>
		/// <returns>A new, empty ClientLocatorEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new ClientLocatorEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClientLocator
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new ClientLocatorEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClientLocatorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.ClientLocatorEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new ClientLocatorCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "ClientLocatorEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CustomerLocatorAuthorizationEntity objects.</summary>
	[Serializable]
	public partial class CustomerLocatorAuthorizationEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty CustomerLocatorAuthorizationEntity object.</summary>
		/// <returns>A new, empty CustomerLocatorAuthorizationEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new CustomerLocatorAuthorizationEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomerLocatorAuthorization
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new CustomerLocatorAuthorizationEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomerLocatorAuthorizationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new CustomerLocatorAuthorizationCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "CustomerLocatorAuthorizationEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CustomerNameEntity objects.</summary>
	[Serializable]
	public partial class CustomerNameEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty CustomerNameEntity object.</summary>
		/// <returns>A new, empty CustomerNameEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new CustomerNameEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomerName
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new CustomerNameEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomerNameUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.CustomerNameEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new CustomerNameCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "CustomerNameEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CustomerNamespaceAuthorizationEntity objects.</summary>
	[Serializable]
	public partial class CustomerNamespaceAuthorizationEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty CustomerNamespaceAuthorizationEntity object.</summary>
		/// <returns>A new, empty CustomerNamespaceAuthorizationEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new CustomerNamespaceAuthorizationEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomerNamespaceAuthorization
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new CustomerNamespaceAuthorizationEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomerNamespaceAuthorizationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.CustomerNamespaceAuthorizationEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new CustomerNamespaceAuthorizationCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "CustomerNamespaceAuthorizationEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty Enterprise_InformationEntity objects.</summary>
	[Serializable]
	public partial class Enterprise_InformationEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty Enterprise_InformationEntity object.</summary>
		/// <returns>A new, empty Enterprise_InformationEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new Enterprise_InformationEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnterprise_Information
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new Enterprise_InformationEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnterprise_InformationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enterprise_InformationEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new Enterprise_InformationCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "Enterprise_InformationEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty Enum_AuthorizationTypeEntity objects.</summary>
	[Serializable]
	public partial class Enum_AuthorizationTypeEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty Enum_AuthorizationTypeEntity object.</summary>
		/// <returns>A new, empty Enum_AuthorizationTypeEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new Enum_AuthorizationTypeEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnum_AuthorizationType
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new Enum_AuthorizationTypeEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnum_AuthorizationTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_AuthorizationTypeEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new Enum_AuthorizationTypeCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "Enum_AuthorizationTypeEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty Enum_DataSourceEntity objects.</summary>
	[Serializable]
	public partial class Enum_DataSourceEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty Enum_DataSourceEntity object.</summary>
		/// <returns>A new, empty Enum_DataSourceEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new Enum_DataSourceEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnum_DataSource
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new Enum_DataSourceEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnum_DataSourceUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataSourceEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new Enum_DataSourceCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "Enum_DataSourceEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty Enum_DataTypeEntity objects.</summary>
	[Serializable]
	public partial class Enum_DataTypeEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty Enum_DataTypeEntity object.</summary>
		/// <returns>A new, empty Enum_DataTypeEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new Enum_DataTypeEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnum_DataType
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new Enum_DataTypeEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEnum_DataTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.Enum_DataTypeEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new Enum_DataTypeCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "Enum_DataTypeEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty FirmEntity objects.</summary>
	[Serializable]
	public partial class FirmEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty FirmEntity object.</summary>
		/// <returns>A new, empty FirmEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new FirmEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFirm
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new FirmEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFirmUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.FirmEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new FirmCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "FirmEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LocatorEntity objects.</summary>
	[Serializable]
	public partial class LocatorEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty LocatorEntity object.</summary>
		/// <returns>A new, empty LocatorEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new LocatorEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocator
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new LocatorEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new LocatorCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "LocatorEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LocatorGridRowEntity objects.</summary>
	[Serializable]
	public partial class LocatorGridRowEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty LocatorGridRowEntity object.</summary>
		/// <returns>A new, empty LocatorGridRowEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new LocatorGridRowEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorGridRow
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new LocatorGridRowEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorGridRowUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorGridRowEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new LocatorGridRowCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "LocatorGridRowEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LocatorNodeComputedValueEntity objects.</summary>
	[Serializable]
	public partial class LocatorNodeComputedValueEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty LocatorNodeComputedValueEntity object.</summary>
		/// <returns>A new, empty LocatorNodeComputedValueEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new LocatorNodeComputedValueEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorNodeComputedValue
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new LocatorNodeComputedValueEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorNodeComputedValueUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorNodeComputedValueEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new LocatorNodeComputedValueCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "LocatorNodeComputedValueEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LocatorObjectRecordEntity objects.</summary>
	[Serializable]
	public partial class LocatorObjectRecordEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty LocatorObjectRecordEntity object.</summary>
		/// <returns>A new, empty LocatorObjectRecordEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new LocatorObjectRecordEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorObjectRecord
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new LocatorObjectRecordEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorObjectRecordUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new LocatorObjectRecordCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "LocatorObjectRecordEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LocatorObjectValueEntity objects.</summary>
	[Serializable]
	public partial class LocatorObjectValueEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty LocatorObjectValueEntity object.</summary>
		/// <returns>A new, empty LocatorObjectValueEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new LocatorObjectValueEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorObjectValue
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new LocatorObjectValueEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorObjectValueUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorObjectValueEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new LocatorObjectValueCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "LocatorObjectValueEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LocatorRolloverEntity objects.</summary>
	[Serializable]
	public partial class LocatorRolloverEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty LocatorRolloverEntity object.</summary>
		/// <returns>A new, empty LocatorRolloverEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new LocatorRolloverEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorRollover
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new LocatorRolloverEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocatorRolloverUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.LocatorRolloverEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new LocatorRolloverCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "LocatorRolloverEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty TempComputedResultsEntity objects.</summary>
	[Serializable]
	public partial class TempComputedResultsEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty TempComputedResultsEntity object.</summary>
		/// <returns>A new, empty TempComputedResultsEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new TempComputedResultsEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTempComputedResults
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new TempComputedResultsEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTempComputedResultsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.TempComputedResultsEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new TempComputedResultsCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "TempComputedResultsEntity"; }
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty TempComputeFieldsEntity objects.</summary>
	[Serializable]
	public partial class TempComputeFieldsEntityFactory : IEntityFactory
	{
		/// <summary>Creates a new, empty TempComputeFieldsEntity object.</summary>
		/// <returns>A new, empty TempComputeFieldsEntity object.</returns>
		public virtual IEntity Create()
		{
			IEntity toReturn = new TempComputeFieldsEntity(new PropertyDescriptorFactory(), this);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTempComputeFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;

		}
		
		/// <summary>Creates a new TempComputeFieldsEntity instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTempComputeFieldsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(TestHarness.DataObjects.EntityType.TempComputeFieldsEntity);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}
		
		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;			
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Hashtable entityFieldStartIndexesPerEntity)
		{
			return this;
		}
		
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return new TempComputeFieldsCollection();
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public virtual string ForEntityName 
		{ 
			get { return "TempComputeFieldsEntity"; }
		}

		#region Included Code

		#endregion
	}


	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses entity specific factory objects
	/// </summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity Create(EntityType entityTypeToCreate)
		{
			IEntityFactory factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case TestHarness.DataObjects.EntityType.ClientEntity:
					factoryToUse = new ClientEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.ClientCustomerEntity:
					factoryToUse = new ClientCustomerEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.ClientLocatorEntity:
					factoryToUse = new ClientLocatorEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity:
					factoryToUse = new CustomerLocatorAuthorizationEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.CustomerNameEntity:
					factoryToUse = new CustomerNameEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.CustomerNamespaceAuthorizationEntity:
					factoryToUse = new CustomerNamespaceAuthorizationEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.Enterprise_InformationEntity:
					factoryToUse = new Enterprise_InformationEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.Enum_AuthorizationTypeEntity:
					factoryToUse = new Enum_AuthorizationTypeEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.Enum_DataSourceEntity:
					factoryToUse = new Enum_DataSourceEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.Enum_DataTypeEntity:
					factoryToUse = new Enum_DataTypeEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.FirmEntity:
					factoryToUse = new FirmEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.LocatorEntity:
					factoryToUse = new LocatorEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.LocatorGridRowEntity:
					factoryToUse = new LocatorGridRowEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.LocatorNodeComputedValueEntity:
					factoryToUse = new LocatorNodeComputedValueEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity:
					factoryToUse = new LocatorObjectRecordEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.LocatorObjectValueEntity:
					factoryToUse = new LocatorObjectValueEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.LocatorRolloverEntity:
					factoryToUse = new LocatorRolloverEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.TempComputedResultsEntity:
					factoryToUse = new TempComputedResultsEntityFactory();
					break;
				case TestHarness.DataObjects.EntityType.TempComputeFieldsEntity:
					factoryToUse = new TempComputeFieldsEntityFactory();
					break;
			}
			return factoryToUse.Create();
		}		
	}
}
