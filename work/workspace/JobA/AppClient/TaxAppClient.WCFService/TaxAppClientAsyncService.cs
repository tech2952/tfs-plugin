using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using log4net;
using NUnit.Framework;

namespace TaxAppClient.WCFService
{
    [ServiceContract
        (
            SessionMode = SessionMode.Required, 
            CallbackContract = typeof(ITACCallback)
        )
    ]
    public interface ITaxAppClientAsyncService
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Join(string name);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Leave(string name);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void UpdatePages(List<int> updatedPages);
    }
     
    public interface ITACCallback
    {
        [OperationContract(IsOneWay = true)]
        void PageUpdate(List<int> updatedPages);

        [OperationContract(IsOneWay = true)]
        void ServerDisconnected();

    }

    [ServiceBehavior
        (
            InstanceContextMode = InstanceContextMode.PerSession, 
            ConcurrencyMode = ConcurrencyMode.Multiple
        )
    ]
    public class TaxAppClientAsyncService : ITaxAppClientAsyncService
    {
        private static readonly ILog theLogger = LogManager.GetLogger("TaxAppClientService");
        private static Object syncObj = new Object();
        public static Dictionary<string, ITACCallback> myDictUsersToCallback = new Dictionary<string, ITACCallback>();
        
        public TaxAppClientAsyncService ()
	    {

	    }
       
        public void Join(string clientName)
        {
            theLogger.Debug("Join called.  ClientName: " + clientName);
            if (OperationContext.Current != null)
            {
                ITACCallback clientCallBack = OperationContext.Current.GetCallbackChannel<ITACCallback>();

                if (!myDictUsersToCallback.ContainsKey(clientName))
                {
                    myDictUsersToCallback.Add(clientName, clientCallBack);
                }
                theLogger.Debug("Calling PageUpdate on ClientCallBack");
                clientCallBack.PageUpdate(new List<int>());
            }

            return;
        }

        public void Leave(string clientName)
        {
            theLogger.Debug("Leave called.  ClientName: " + clientName);
            if (myDictUsersToCallback.ContainsKey(clientName))
            {
                myDictUsersToCallback.Remove(clientName);
            }
        }

        public void UpdatePages(List<int> pageIDs)
        {
            theLogger.Debug("Update pages.  PageID Count: " + pageIDs.Count);
            foreach (ITACCallback callBack in myDictUsersToCallback.Values)
            {
                callBack.PageUpdate(pageIDs);
            }
        }

        public static void SendUpdatePagesCall(List<int> pageIDs)
        {
            theLogger.Debug("Update pages.  PageID Count: " + pageIDs.Count);
            foreach (ITACCallback callBack in myDictUsersToCallback.Values)
            {
                try
                {
                    callBack.PageUpdate(pageIDs);
                }
                catch (Exception ex)
                {
                    theLogger.Error("Error calling back client with page update information.", ex);
                    //throw;
                }
                
            }
        }
    
    }
    namespace Tests
    {
        [TestFixture] public class TaxAppClientAsyncServiceTests : ITACCallback
        {
            [Test]
            public void ObjectCD()
            {
                //these tests make no sense - how to test this in here?
                TaxAppClientAsyncService o = new TaxAppClientAsyncService();
                o.Join("testClient");

                List<int> pageIDs = new List<int>() { 1, 5, 10};
                o.UpdatePages(pageIDs);
            }




            #region ITACCallback Members

            public void PageUpdate(List<int> updatedPages)
            {
                throw new NotImplementedException();
            }

            public void ServerDisconnected()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }



}
