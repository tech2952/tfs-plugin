using System;
using System.Collections.Generic;
using System.Text;


    partial class TaxAppClientAsyncServiceClient
    {
        public static TaxAppClientAsyncServiceClient Instance = null;
        public string ClientName { get; set; }

        public TaxAppClientAsyncServiceClient(string clientName, System.ServiceModel.InstanceContext callbackInstance, string endPointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            : base(callbackInstance, endPointConfigurationName, remoteAddress)
        {
            ClientName = clientName;

        }
    }

