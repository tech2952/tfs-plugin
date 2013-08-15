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
using System.ComponentModel;

#if CF
using System.Reflection;
#endif

using TestHarness.DataObjects.EntityClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.FactoryClasses
{
	/// <summary>
	/// class which creates different sets of property descriptor sets. Required for complex databinding.  
	/// </summary>
	[Serializable]
	public partial class PropertyDescriptorFactory : IPropertyDescriptorFactory
	{
		/// <summary>
		/// CTor
		/// </summary>
		public PropertyDescriptorFactory()
		{
		}


		/// <summary>
		/// Creates a new propertydescriptorcollection using the specialized methods of the types stored INSIDE the type specified.
		/// </summary>
		/// <param name="typeOfCollection">type which contains other types which properties we're interested in.</param>
		/// <returns>filled propertydescriptorcollection of type inside the type specified.</returns>
		public virtual PropertyDescriptorCollection GetItemProperties(Type typeOfCollection)
		{
			PropertyDescriptorCollection toReturn = null;
			switch(typeOfCollection.UnderlyingSystemType.Name)
			{
				
				case "ClientCollection":
					toReturn = GetPropertyDescriptors(new ClientEntity(), typeof(ClientEntity));
					break;

				case "ClientCustomerCollection":
					toReturn = GetPropertyDescriptors(new ClientCustomerEntity(), typeof(ClientCustomerEntity));
					break;

				case "ClientLocatorCollection":
					toReturn = GetPropertyDescriptors(new ClientLocatorEntity(), typeof(ClientLocatorEntity));
					break;

				case "CustomerLocatorAuthorizationCollection":
					toReturn = GetPropertyDescriptors(new CustomerLocatorAuthorizationEntity(), typeof(CustomerLocatorAuthorizationEntity));
					break;

				case "CustomerNameCollection":
					toReturn = GetPropertyDescriptors(new CustomerNameEntity(), typeof(CustomerNameEntity));
					break;

				case "CustomerNamespaceAuthorizationCollection":
					toReturn = GetPropertyDescriptors(new CustomerNamespaceAuthorizationEntity(), typeof(CustomerNamespaceAuthorizationEntity));
					break;

				case "Enterprise_InformationCollection":
					toReturn = GetPropertyDescriptors(new Enterprise_InformationEntity(), typeof(Enterprise_InformationEntity));
					break;

				case "Enum_AuthorizationTypeCollection":
					toReturn = GetPropertyDescriptors(new Enum_AuthorizationTypeEntity(), typeof(Enum_AuthorizationTypeEntity));
					break;

				case "Enum_DataSourceCollection":
					toReturn = GetPropertyDescriptors(new Enum_DataSourceEntity(), typeof(Enum_DataSourceEntity));
					break;

				case "Enum_DataTypeCollection":
					toReturn = GetPropertyDescriptors(new Enum_DataTypeEntity(), typeof(Enum_DataTypeEntity));
					break;

				case "FirmCollection":
					toReturn = GetPropertyDescriptors(new FirmEntity(), typeof(FirmEntity));
					break;

				case "LocatorCollection":
					toReturn = GetPropertyDescriptors(new LocatorEntity(), typeof(LocatorEntity));
					break;

				case "LocatorGridRowCollection":
					toReturn = GetPropertyDescriptors(new LocatorGridRowEntity(), typeof(LocatorGridRowEntity));
					break;

				case "LocatorNodeComputedValueCollection":
					toReturn = GetPropertyDescriptors(new LocatorNodeComputedValueEntity(), typeof(LocatorNodeComputedValueEntity));
					break;

				case "LocatorObjectRecordCollection":
					toReturn = GetPropertyDescriptors(new LocatorObjectRecordEntity(), typeof(LocatorObjectRecordEntity));
					break;

				case "LocatorObjectValueCollection":
					toReturn = GetPropertyDescriptors(new LocatorObjectValueEntity(), typeof(LocatorObjectValueEntity));
					break;

				case "LocatorRolloverCollection":
					toReturn = GetPropertyDescriptors(new LocatorRolloverEntity(), typeof(LocatorRolloverEntity));
					break;

				case "TempComputedResultsCollection":
					toReturn = GetPropertyDescriptors(new TempComputedResultsEntity(), typeof(TempComputedResultsEntity));
					break;

				case "TempComputeFieldsCollection":
					toReturn = GetPropertyDescriptors(new TempComputeFieldsEntity(), typeof(TempComputeFieldsEntity));
					break;
				default:
					toReturn = new PropertyDescriptorCollection(null);
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Constructs the actual property descriptor collection.
		/// </summary>
		/// <param name="entityToCheck">entity instance which properties should be included in the collection</param>
		/// <param name="typeOfEntity">full type of the entity</param>
		/// <returns>filled in property descriptor collection</returns>
		public PropertyDescriptorCollection GetPropertyDescriptors(IEntity entityToCheck, Type typeOfEntity)
		{
			// get the descriptors of this instance
			PropertyDescriptorCollection instancePropertiesCollection = TypeDescriptor.GetProperties(typeOfEntity);
			ArrayList instanceProperties = new ArrayList();
			Hashtable namesAdded = new Hashtable();

			foreach(IEntityField currentField in (EntityFields)entityToCheck.Fields)
			{
				EntityPropertyDescriptor newDescriptor = new EntityPropertyDescriptor(currentField, typeOfEntity);
				// check if the field is overriden. If so, replace it with THIS field. 
				if(namesAdded.ContainsKey(currentField.Name))
				{
					// replace
					instanceProperties.Remove( (EntityPropertyDescriptor)namesAdded[currentField.Name]);
					instanceProperties.Add(newDescriptor);
					namesAdded[currentField.Name] = newDescriptor;
				}
				else
				{
					// add
					instanceProperties.Add(newDescriptor);
					namesAdded.Add(currentField.Name, newDescriptor);
				}
			}
#if CF
			// grab the propery info's. As the CF can't read the attributes from property descriptors, we have to use these. 
			PropertyInfo[] propertyInfos = this.GetType().GetProperties();

			// now walk all properties in the property descriptor collection. 
			foreach(PropertyInfo property in propertyInfos)
			{
				if(!namesAdded.ContainsKey(property.Name))
				{
					// check if the property has a BrowsableAttribute.
					object[] customAttributes = property.GetCustomAttributes(typeof(BrowsableAttribute), false);
					if(customAttributes.Length>0)
					{
						if(!((BrowsableAttribute)customAttributes[0]).Browsable)
						{
							continue;
						}
					}
					PropertyDescriptor toAdd = instancePropertiesCollection[property.Name];
					if(toAdd!=null)
					{
						instanceProperties.Add(toAdd);
					}
				}
			}
#else
			// now walk all properties in the property descriptor collection. Check if the name occurs in the hashtable. if not and if browsable, copy the descriptor over.
			foreach(PropertyDescriptor property in instancePropertiesCollection)
			{
				if(!namesAdded.ContainsKey(property.Name))
				{
					if(!property.IsBrowsable)
					{
						continue;
					}

					// add it
					instanceProperties.Add(property);
				}
			}
#endif
			return new PropertyDescriptorCollection((PropertyDescriptor[])instanceProperties.ToArray(typeof(PropertyDescriptor))); 
		}

		#region Included Code

		#endregion
	}
}
