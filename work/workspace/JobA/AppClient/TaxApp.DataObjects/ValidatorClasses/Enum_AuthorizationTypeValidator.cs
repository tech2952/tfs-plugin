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

using TestHarness.DataObjects;
using TestHarness.DataObjects.EntityClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.ValidatorClasses
{
	/// <summary>
	/// Implementation of the Enum_AuthorizationType Validator class. This class formulates validation rules for the
	/// Enum_AuthorizationTypeEntity class. It is plugged into an instance of the Enum_AuthorizationTypeEntity class using the Strategy
	/// Pattern [GoF]. This class is generated. 
	/// </summary>
	/// <remarks>
	/// If you want to add additional business logic to this class, derive from this
	/// class, override the validate method and pass an instance of that class to the
	/// Enum_AuthorizationTypeEntity class instead of an instance of this class. The Enum_AuthorizationTypeEntity code will then call your
	/// override methods when available and will use the method in this class.
	/// You can also adjust this class with validator rules. Be sure to add the rules between the user region start/end markers.
	/// You can also add your rules to the template bound to the template ID SD_EntityValidatorIncludeTemplate or bind that
	/// template ID to a different template.
	/// </remarks>
	[Serializable]
	public partial class Enum_AuthorizationTypeValidator : IValidator
	{
		/// <summary>
		/// CTor
		/// </summary>
		public Enum_AuthorizationTypeValidator()
		{
		}

		
		/// <summary>
		/// Validation method which is called when a field value changes. When a value fails the test, this method will return false
		/// and the field will keep its current value. When true is returned, the field will receive value as its new value.
		/// </summary>
		/// <param name="fieldIndex">Index of the field which value is changed</param>
		/// <param name="value">new value of the field. This value should be validated</param>
		/// <returns>true, if value is a valid value for the field with index fieldIndex, false otherwise.</returns>
		public virtual bool Validate(int fieldIndex, object value)
		{
			
			// __LLBLGENPRO_USER_CODE_REGION_START ValidationLogic
			// TODO:  Add Enum_AuthorizationTypeValidator.Validate implementation
			return true ;

			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		#region Included Code

		#endregion
	}
}

