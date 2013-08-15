///////////////////////////////////////////////////////////////
// This is generated code. If you modify this code, be aware
// of the fact that when you re-generate the code, your changes
// are lost. If you want to keep your changes, make this file read-only
// when you have finished your changes, however it is recommended that
// you inherit from this class to extend the functionality of this generated
// class or you modify / extend the templates used to generate this code.
//
// Do not try to run this code on another version of the database than the database
// which was used to generate this code. This means that when you used f.e. SqlServer 2000
// to generate this code, it is likely that you will not be able to use that code on
// SqlServer 7 due to SQL syntax mismatches. Most code is generic code which will work
// with any database, but some code relies on a specific database type/vendor/version used. 
// This code is located in the DaoClasses which target a specific specified database. Also all
// classes target a specific specified Dynamic Query Engine (DQE) in the using/imports
// directives. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 1.0.2005.1
// Code is generated on: Wednesday, August 13, 2008 10:50:44 AM
// Code is generated using templates: C# template set for SqlServer (1.0.2005.1)
// Templates vendor: Solutions Design.
// Templates version: 1.0.2005.1.102305
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlClient;

using TestHarness.DataObjects.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.StoredProcedureCallerClasses
{
	/// <summary>
	/// Class which contains the static logic to execute retrieval stored procedures in the database.
	/// </summary>
	public partial class RetrievalProcedures
	{
		/// <summary>
		/// private CTor so no instance can be created.
		/// </summary>
		private RetrievalProcedures()
		{
		}

	
		/// <summary>
		/// Calls stored procedure 'spReturnCurrentValues'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="lOCATORID">Input parameter of stored procedure</param>
		/// <param name="pRODUCTYEAR">Input parameter of stored procedure</param>
		/// <param name="sTARTTIME">Input parameter of stored procedure</param>
		/// <param name="oUTPUTERROR">InputOutput parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SpReturnCurrentValues(System.Int32 lOCATORID, System.Int16 pRODUCTYEAR, System.DateTime sTARTTIME, ref System.Int32 oUTPUTERROR)
		{
			// create parameters
			SqlParameter[] parameters = new SqlParameter[4];
			parameters[0] = new SqlParameter("@LOCATORID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, lOCATORID);
			parameters[1] = new SqlParameter("@PRODUCTYEAR", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 5, 0, "",  DataRowVersion.Current, pRODUCTYEAR);
			parameters[2] = new SqlParameter("@STARTTIME", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, sTARTTIME);
			parameters[3] = new SqlParameter("@OUTPUTERROR", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, oUTPUTERROR);
			// Call the stored proc.
			DataTable toReturn = new DataTable("SpReturnCurrentValues");
			bool hasSucceeded = DbUtils.CallRetrievalStoredProcedure("[dbo].[spReturnCurrentValues]", parameters, toReturn, null);
			if(parameters[3].Value!=System.DBNull.Value)
			{
				oUTPUTERROR = (System.Int32)parameters[3].Value;
			}
			return toReturn;
		}

	
		/// <summary>
		/// Calls stored procedure 'spReturnCurrentValues'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="lOCATORID">Input parameter of stored procedure</param>
		/// <param name="pRODUCTYEAR">Input parameter of stored procedure</param>
		/// <param name="sTARTTIME">Input parameter of stored procedure</param>
		/// <param name="oUTPUTERROR">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SpReturnCurrentValues(System.Int32 lOCATORID, System.Int16 pRODUCTYEAR, System.DateTime sTARTTIME, ref System.Int32 oUTPUTERROR, ref System.Int32 returnValue)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[4 + 1];
			parameters[0] = new SqlParameter("@LOCATORID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, lOCATORID);
			parameters[1] = new SqlParameter("@PRODUCTYEAR", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 5, 0, "",  DataRowVersion.Current, pRODUCTYEAR);
			parameters[2] = new SqlParameter("@STARTTIME", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, sTARTTIME);
			parameters[3] = new SqlParameter("@OUTPUTERROR", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, oUTPUTERROR);
			// return value parameter
			parameters[4] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			
			// Call the stored proc.
			DataTable toReturn = new DataTable("SpReturnCurrentValues");
			bool hasSucceeded = DbUtils.CallRetrievalStoredProcedure("[dbo].[spReturnCurrentValues]", parameters, toReturn, null);
			if(parameters[3].Value!=System.DBNull.Value)
			{
				oUTPUTERROR = (System.Int32)parameters[3].Value;
			}

			returnValue = (int)parameters[4].Value;
			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'spReturnCurrentValues'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="lOCATORID">Input parameter of stored procedure</param>
		/// <param name="pRODUCTYEAR">Input parameter of stored procedure</param>
		/// <param name="sTARTTIME">Input parameter of stored procedure</param>
		/// <param name="oUTPUTERROR">InputOutput parameter of stored procedure</param>
		/// <param name="transactionToUse">the transaction to use, or null if no transaction is available.</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SpReturnCurrentValues(System.Int32 lOCATORID, System.Int16 pRODUCTYEAR, System.DateTime sTARTTIME, ref System.Int32 oUTPUTERROR,  ITransaction transactionToUse)
		{
			// create parameters
			SqlParameter[] parameters = new SqlParameter[4];
			parameters[0] = new SqlParameter("@LOCATORID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, lOCATORID);
			parameters[1] = new SqlParameter("@PRODUCTYEAR", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 5, 0, "",  DataRowVersion.Current, pRODUCTYEAR);
			parameters[2] = new SqlParameter("@STARTTIME", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, sTARTTIME);
			parameters[3] = new SqlParameter("@OUTPUTERROR", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, oUTPUTERROR);
			// Call the stored proc.
			DataTable toReturn = new DataTable("SpReturnCurrentValues");
			bool hasSucceeded = DbUtils.CallRetrievalStoredProcedure("[dbo].[spReturnCurrentValues]", parameters, toReturn, transactionToUse);
			if(parameters[3].Value!=System.DBNull.Value)
			{
				oUTPUTERROR = (System.Int32)parameters[3].Value;
			}
			return toReturn;
		}

	
		/// <summary>
		/// Calls stored procedure 'spReturnCurrentValues'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="lOCATORID">Input parameter of stored procedure</param>
		/// <param name="pRODUCTYEAR">Input parameter of stored procedure</param>
		/// <param name="sTARTTIME">Input parameter of stored procedure</param>
		/// <param name="oUTPUTERROR">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="transactionToUse">the transaction to use, or null if no transaction is available.</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SpReturnCurrentValues(System.Int32 lOCATORID, System.Int16 pRODUCTYEAR, System.DateTime sTARTTIME, ref System.Int32 oUTPUTERROR, ref System.Int32 returnValue, ITransaction transactionToUse)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[4 + 1];
			parameters[0] = new SqlParameter("@LOCATORID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, lOCATORID);
			parameters[1] = new SqlParameter("@PRODUCTYEAR", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 5, 0, "",  DataRowVersion.Current, pRODUCTYEAR);
			parameters[2] = new SqlParameter("@STARTTIME", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, sTARTTIME);
			parameters[3] = new SqlParameter("@OUTPUTERROR", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, oUTPUTERROR);
			// return value parameter
			parameters[4] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			
			// Call the stored proc.
			DataTable toReturn = new DataTable("SpReturnCurrentValues");
			bool hasSucceeded = DbUtils.CallRetrievalStoredProcedure("[dbo].[spReturnCurrentValues]", parameters, toReturn, transactionToUse);
			if(parameters[3].Value!=System.DBNull.Value)
			{
				oUTPUTERROR = (System.Int32)parameters[3].Value;
			}

			returnValue = (int)parameters[4].Value;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
