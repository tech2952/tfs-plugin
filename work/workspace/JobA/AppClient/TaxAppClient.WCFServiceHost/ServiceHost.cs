using System;
using System.ServiceModel;
using TaxAppClient.WCFService;
using log4net;
       
namespace TaxAppClient.WCFServiceHost
{
    internal class TACServiceHost
    {
        internal static ServiceHost myServiceHost = null;
        internal static ServiceHost myServiceHostMTOM = null;
        internal static ServiceHost myServiceHostAsync = null;
        static ILog theLog = LogManager.GetLogger("TACServiceHost");
        internal static void StartService()
        {
            theLog.Info("Tax App Client Service starting.");
            //Consider putting the baseAddress in the configuration system
            //and getting it here with AppSettings
            System.Configuration.AppSettingsReader asr = new System.Configuration.AppSettingsReader();
            string baseAddy = string.Empty;
            string baseAddyForAsync = string.Empty;
            try
            {
                baseAddy = asr.GetValue("baseAddress", typeof(string)).ToString();
                baseAddyForAsync = asr.GetValue("AsyncBaseAddress", typeof(string)).ToString();
            }
            catch
            {
                theLog.Error("Base Address not found in app.config key= 'baseAddress'");
                theLog.Error("Base Address not found in app.config key= 'AsyncBaseAddress'");
                return;
            }

            try
            {
                //Instantiate new ServiceHost 
                Uri baseAddress = new Uri(baseAddy);
                myServiceHost = new ServiceHost(typeof(TaxAppClient.WCFService.TaxAppClientService), baseAddress);
                myServiceHost.Opened += new EventHandler(myServiceHost_Opened);
                myServiceHost.Closed += new EventHandler(myServiceHost_Closed);

                //Instantiate new ServiceHostMTOM
                Uri baseAddressMTOM = new Uri(baseAddy + "MTOM");
                myServiceHostMTOM = new ServiceHost(typeof(TaxAppClient.WCFService.TaxAppClientServiceMTOM), baseAddressMTOM);

                //Instantiate new ServiceHostAsync
                Uri baseAddressAsync = new Uri(baseAddyForAsync);
                myServiceHostAsync = new ServiceHost(typeof(TaxAppClient.WCFService.TaxAppClientAsyncService), baseAddressAsync);

                //Open myServiceHost
                myServiceHost.Open();
                myServiceHostMTOM.Open();
                myServiceHostAsync.Open();
            }
            catch (Exception ex)
            {
                theLog.Error("Error starting TAC WCF Service", ex);
            }
        }

        static void myServiceHost_Closed(object sender, EventArgs e)
        {
            theLog.Info("Tax App Client Service closed.");
        }

        static void myServiceHost_Opened(object sender, EventArgs e)
        {
            theLog.Info("Tax App Client Service open for communication.");
        }

        internal static void StopService()
        {
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
            if (myServiceHostMTOM.State != CommunicationState.Closed)
                myServiceHostMTOM.Close();
            if (myServiceHostAsync.State != CommunicationState.Closed)
                myServiceHostAsync.Close();
        }
    }
}
