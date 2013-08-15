using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using log4net;

namespace TaxAppClient.BusinessObjects
{
    public class TACCallBack : ITaxAppClientAsyncServiceCallback
    {
        private static readonly ILog theLogger = LogManager.GetLogger("TACCallback");
        public static TACCallBack Instance;

        public delegate void PageUpdateEvent(List<int> pageIDs);
        public event PageUpdateEvent pageUpdateEvent = null;
        
        public TACCallBack ()
	    {

	    }

        public void PageUpdate(int[] updatedPages)
        {
            theLogger.Debug("Page Update event from server.  Page count: " + updatedPages.Length);
            List<int> updatedPagesColl = new List<int>(updatedPages);
            if (pageUpdateEvent != null)
            {
                pageUpdateEvent(updatedPagesColl);
            }
        }

        public IAsyncResult BeginPageUpdate(int[] updatedPages, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndPageUpdate(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void ServerDisconnected()
        {
            theLogger.Debug("Server Disconnected");
        }

        public IAsyncResult BeginServerDisconnected(AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndServerDisconnected(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

    }
}
