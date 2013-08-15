using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using TaxBuilder.GraphicObjects;
using TaxApp.IntrinsicFunctions;

namespace TaxApp.InterfacesAndConstants
{
    /// <summary>
    /// This interface describes any functions needed by a client GUI to request application information.  
    /// Navigation trees, page and graphics, value lists, and datalinks.
    /// </summary>
    public interface ITaxAppInfo
    {
        /// <summary>
        /// run the initialize of the implementor - useful for confirming paths, objects, internal state etc.
        /// </summary>
        /// <param name="userConfigurationItems"></param>
        void Initialize(UserConfigurationItems userConfigurationItems);
        /// <summary>
        /// Gets all currently available applications that the implementor can provide support for, given the userConfigurationItems
        /// </summary>
        /// <returns>An array of application names which are unique</returns>
        List<string> GetApplicationNamesCurrentlyAvailable();
        /// <summary>
        /// Returns an application's RunTimeNode which provides all the information to display the node on a tree.
        /// </summary>
        /// <param name="ApplicationName"></param>
        /// <returns></returns>
        RunTimeNode GetApplicationRootRunTimeNode(string ApplicationName, AppTypeEnum TreeType, short Year);
        /// <summary>
        /// Given a runtimeNode it'll return that nodes array of children as RunTimeNodes
        /// </summary>
        /// <param name="RunTimeNode"></param>
        /// <returns></returns>
        SortedList<int, RunTimeNode> GetRunTimeNodesChildren(RunTimeNode RunTimeNode);
        /// <summary>
        /// Given a RunTimeNode, it'll return the RunTimePage object that represents the page, it's graphics, etc...
        /// </summary>
        /// <param name="RunTimeNode"></param>
        /// <returns></returns>
        RunTimePage GetPage(RunTimeNode RunTimeNode);
        /// <summary>
        /// Returns an image object 
        /// </summary>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        Image GetImage(int ImageID);

        Stack<int> GetParentNodeChainForPageID(int PageID);

    }
    /// <summary>
    /// This interface describes any functions needed by a client GUI to request information about the client.
    /// ClientID, locator list.  Also allows for the management of the locators (adding and deleting).
    /// </summary>
    public interface ITaxAppClientData
    {
        void Initialize(UserConfigurationItems configItems);
        List<ClientIDAndNameWithLocatorDictionary> GetAllClientNames();
        int GetClientByNameAddIfNew(string clientName, short year);
        int AddNewLocatorToListForClient(int clientID, string locatorName, short year);
        void DeleteLocator(int locatorID, int productYear);
    }

    /// <summary>
    /// This interface represents a data access point into the customer's data.
	/// Init:
    ///     Requires the locator Name (string), ID (int), and Year(short)
    ///     a UserConfigurationItem class - 
    ///     ITaxAppInfo implementor
	/// </summary>
	public interface ITaxAppData 
	{
        /// <summary>
        /// Initialize code for the Implementor
        /// usually load up graphic info matrix, confirm connections to database, etc.
        /// </summary>
        /// <param name="LocatorName"></param>
        /// <param name="LocatorID"></param>
        /// <param name="Year"></param>
        /// <param name="configItems"></param>
        void Initialize(string LocatorName, int LocatorID, short Year, UserConfigurationItems configItems);
        /// <summary>
        /// Current locator ID
        /// </summary>
		int LocatorID{get;}
        /// <summary>
        /// Current Year
        /// </summary>
		short Year{get;}
        /// <summary>
        /// Locator Name
        /// </summary>
        string LocatorName { get;}

        /// <summary>
        /// Process a set of RunTimeNodes for this locator's data.  It does the work of figuring out
        /// looping graphics.
        /// </summary>
        /// <param name="parentNode">the parent node, the node that was clicked</param>
        /// <param name="rtns">the sorted list of RunTimeNodes by display order</param>
        /// <returns>sorted list of runtimenodes</returns>
        SortedList<int, RunTimeNode> ProcessRunTimeNodeCollection(RunTimeNode parentNode, SortedList<int, RunTimeNode> rtns);
        /// <summary>
		///GETTERS of Values
		///even simple values aren't simple - a single record can have x number of values (each corresponding to a diff datasource)
		///All records have a single value that is designated as TheValue (so all values essentially get 2 representations in the database)
		///all other datasources are kept on other DataSources for informational purposes and the UI will be able to "switch out" which value is being used as "TheValue"
        ///Furthermore, all records sets can be sliced by a RecordLineage
		///This getter is for retrieving the datasource: TheValue -  for a single record  
        ///</summary>
        ValueWithDataSources GetSingleValue(int PageID, int RuntimeGraphicID, int RecordLineage);
        /// <summary>
        /// This getter is for retrieving a grid of data
        /// </summary>
        /// <param name="PageID"></param>
        /// <param name="RuntimeGraphicID"></param>
        /// <param name="RecordLineage"></param>
        /// <returns></returns>
        DataTable GetGridDataTable(int PageID, int RuntimeGraphicID, int RecordLineage);

        /// <summary>
        /// general updater - the value is a DataTable for grid's updating, otherwise I believe it is a basetype
        /// </summary>
        /// <param name="PageID"></param>
        /// <param name="RuntimeGraphicID"></param>
        /// <param name="value"></param>
        /// <param name="dataSource"></param>
        /// <param name="RecordLineage"></param>
        /// <returns>true if the value was updated</returns>
        bool SetValue(int PageID, int RuntimeGraphicID, object value, DataSourceEnum dataSource, int RecordLineage);        
        
        //given a RecordID (normally from a RecordLineage parm - return its RecordLineage
        int GetRecordLineageForThisRecordID(int RecordID);
        //given a RecordID / RecordLineage - return all values for the same graphic for that RL
        IDictionary<int, string> GetSetofRecordIDandValueForSameGraphicAndLineage(int RecordID);
        
        /// <summary>
        /// This is used currently by the click event and needs to be factored out if can be...
        /// </summary>
        /// <param name="PageID"></param>
        /// <param name="GraphicID"></param>
        /// <param name="RecordLineage"></param>
        /// <param name="DisplayOrder"></param>
        /// <returns></returns>
        int GetRecordIDForThisGraphicByDisplayOrder(int PageID, int GraphicID, int RecordLineage, int DisplayOrder);

		//BaseType interface methods might not be needed
		//this is required because the incoming values will be IntrinsicFunction types - and will need to be handled
        void SetBasetypeValue(int PageID, int RuntimeGraphicID, IBaseType value, DataSourceEnum dataSource, int RecordLineage);
        //This getter is for retrieving a BaseType (multi-row /single-row) for calculation
        IBaseType GetValueAsBaseType(int PageID, int RuntimeGraphicID, int RecordLineage);
        // need to move this functionality into the process nodes call - should not have to recall.
        bool GetNodeConstraintIsThisNodeIDEnabled(int NavigationNodeID);


        //this is for constraint results - which are a BOOL (BaseType) and are processed and stored seperately
        void SetValueFromConstraint(int NavigationNodeID, bool value);
        
        //used to update a specific record from a detail compute         
        void UpdateValue(int RecordID, object value, DataSourceEnum datasource);
        //used to select a datasource value from the data source value list
        void SelectDataSource(bool bClearOverride, int PageID, int RuntimeGraphicID, DataSourceEnum dataSource, int RecordLineage, int RowInd);
        
        /// <summary>
        /// This needs to be qualified, as in, the Interface to the tax app data needs to be able to know how to compute.  Dynamics should be done always
        /// </summary>
        void PerformFullCompute();

        event PageUpdatedEventHandler PageUpdatedEvent;

	}
}
