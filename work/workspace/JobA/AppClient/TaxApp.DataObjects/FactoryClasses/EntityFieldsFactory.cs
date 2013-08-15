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
using TestHarness.DataObjects;
using TestHarness.DataObjects.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.FactoryClasses
{
	/// <summary>
	/// Generates IEntityFields instances for different kind of Entities. 
	/// This class is generated. Do not modify.
	/// </summary>
	public partial class EntityFieldsFactory
	{
		/// <summary>
		/// Private CTor, no instantiation possible.
		/// </summary>
		private EntityFieldsFactory()
		{
		}


		/// <summary>General factory entrance method which will return an EntityFields object with the format generated by the factory specified</summary>
		/// <param name="relatedEntityType">The type of entity the fields are for</param>
		/// <returns>The IEntityFields instance requested</returns>
		public static IEntityFields CreateEntityFieldsObject(EntityType relatedEntityType)
		{
			IEntityFields fieldsToReturn=null;
			switch(relatedEntityType)
			{
				case TestHarness.DataObjects.EntityType.ClientEntity:
					fieldsToReturn = CreateClientEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.ClientCustomerEntity:
					fieldsToReturn = CreateClientCustomerEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.ClientLocatorEntity:
					fieldsToReturn = CreateClientLocatorEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.CustomerLocatorAuthorizationEntity:
					fieldsToReturn = CreateCustomerLocatorAuthorizationEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.CustomerNameEntity:
					fieldsToReturn = CreateCustomerNameEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.CustomerNamespaceAuthorizationEntity:
					fieldsToReturn = CreateCustomerNamespaceAuthorizationEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.Enterprise_InformationEntity:
					fieldsToReturn = CreateEnterprise_InformationEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.Enum_AuthorizationTypeEntity:
					fieldsToReturn = CreateEnum_AuthorizationTypeEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.Enum_DataSourceEntity:
					fieldsToReturn = CreateEnum_DataSourceEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.Enum_DataTypeEntity:
					fieldsToReturn = CreateEnum_DataTypeEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.FirmEntity:
					fieldsToReturn = CreateFirmEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.LocatorEntity:
					fieldsToReturn = CreateLocatorEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.LocatorGridRowEntity:
					fieldsToReturn = CreateLocatorGridRowEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.LocatorNodeComputedValueEntity:
					fieldsToReturn = CreateLocatorNodeComputedValueEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.LocatorObjectRecordEntity:
					fieldsToReturn = CreateLocatorObjectRecordEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.LocatorObjectValueEntity:
					fieldsToReturn = CreateLocatorObjectValueEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.LocatorRolloverEntity:
					fieldsToReturn = CreateLocatorRolloverEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.TempComputedResultsEntity:
					fieldsToReturn = CreateTempComputedResultsEntityFields();
					break;
				case TestHarness.DataObjects.EntityType.TempComputeFieldsEntity:
					fieldsToReturn = CreateTempComputeFieldsEntityFields();
					break;
			}
			return fieldsToReturn;
		}
		
		/// <summary>General method which will return an array of IEntityFieldCore objects, used by the InheritanceInfoProvider. Only the fields defined in the entity are returned, no inherited fields.</summary>
		/// <param name="entityName">the name of the entity to get the fields for. Example: "CustomerEntity"</param>
		/// <returns>array of IEntityFieldCore fields, defined in the entity with the name specified</returns>
		internal static IEntityFieldCore[] CreateFields(string entityName)
		{
			IEntityFieldCore[] toReturn = null;
			switch(entityName)
			{
				default:
					break;
			}
			return toReturn;
		}


		/// <summary>Creates a complete EntityFields instance for the ClientEntity.</summary>
		private static IEntityFields CreateClientEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)ClientFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)ClientFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((ClientFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the ClientCustomerEntity.</summary>
		private static IEntityFields CreateClientCustomerEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)ClientCustomerFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)ClientCustomerFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((ClientCustomerFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the ClientLocatorEntity.</summary>
		private static IEntityFields CreateClientLocatorEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)ClientLocatorFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)ClientLocatorFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((ClientLocatorFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the CustomerLocatorAuthorizationEntity.</summary>
		private static IEntityFields CreateCustomerLocatorAuthorizationEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)CustomerLocatorAuthorizationFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)CustomerLocatorAuthorizationFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((CustomerLocatorAuthorizationFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the CustomerNameEntity.</summary>
		private static IEntityFields CreateCustomerNameEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)CustomerNameFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)CustomerNameFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((CustomerNameFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the CustomerNamespaceAuthorizationEntity.</summary>
		private static IEntityFields CreateCustomerNamespaceAuthorizationEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)CustomerNamespaceAuthorizationFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)CustomerNamespaceAuthorizationFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((CustomerNamespaceAuthorizationFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the Enterprise_InformationEntity.</summary>
		private static IEntityFields CreateEnterprise_InformationEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)Enterprise_InformationFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)Enterprise_InformationFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((Enterprise_InformationFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the Enum_AuthorizationTypeEntity.</summary>
		private static IEntityFields CreateEnum_AuthorizationTypeEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)Enum_AuthorizationTypeFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)Enum_AuthorizationTypeFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((Enum_AuthorizationTypeFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the Enum_DataSourceEntity.</summary>
		private static IEntityFields CreateEnum_DataSourceEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)Enum_DataSourceFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)Enum_DataSourceFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((Enum_DataSourceFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the Enum_DataTypeEntity.</summary>
		private static IEntityFields CreateEnum_DataTypeEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)Enum_DataTypeFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)Enum_DataTypeFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((Enum_DataTypeFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the FirmEntity.</summary>
		private static IEntityFields CreateFirmEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)FirmFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)FirmFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((FirmFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the LocatorEntity.</summary>
		private static IEntityFields CreateLocatorEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)LocatorFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)LocatorFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((LocatorFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the LocatorGridRowEntity.</summary>
		private static IEntityFields CreateLocatorGridRowEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)LocatorGridRowFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)LocatorGridRowFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((LocatorGridRowFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the LocatorNodeComputedValueEntity.</summary>
		private static IEntityFields CreateLocatorNodeComputedValueEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)LocatorNodeComputedValueFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)LocatorNodeComputedValueFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((LocatorNodeComputedValueFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the LocatorObjectRecordEntity.</summary>
		private static IEntityFields CreateLocatorObjectRecordEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)LocatorObjectRecordFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)LocatorObjectRecordFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((LocatorObjectRecordFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the LocatorObjectValueEntity.</summary>
		private static IEntityFields CreateLocatorObjectValueEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)LocatorObjectValueFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)LocatorObjectValueFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((LocatorObjectValueFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the LocatorRolloverEntity.</summary>
		private static IEntityFields CreateLocatorRolloverEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)LocatorRolloverFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)LocatorRolloverFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((LocatorRolloverFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the TempComputedResultsEntity.</summary>
		private static IEntityFields CreateTempComputedResultsEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)TempComputedResultsFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)TempComputedResultsFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((TempComputedResultsFieldIndex)i);
			}
			return fieldsToReturn;
		}
	

		/// <summary>Creates a complete EntityFields instance for the TempComputeFieldsEntity.</summary>
		private static IEntityFields CreateTempComputeFieldsEntityFields()
		{

			IEntityFields fieldsToReturn = new EntityFields((int)TempComputeFieldsFieldIndex.AmountOfFields, InheritanceInfoProviderSingleton.GetInstance());
			for(int i=0;i<(int)TempComputeFieldsFieldIndex.AmountOfFields;i++)
			{
				fieldsToReturn[i] = EntityFieldFactory.Create((TempComputeFieldsFieldIndex)i);
			}
			return fieldsToReturn;
		}
	


		#region Included Code

		#endregion
	}
}
