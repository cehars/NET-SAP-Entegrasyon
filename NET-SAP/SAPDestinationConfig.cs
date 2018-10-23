using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Configuration;

namespace SAPLibrary
{
    public class SAPDestinationConfig : IDestinationConfiguration
    {

        public string SAPLanguage { get; set; }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public SAPDestinationConfig()
        {
        }

        public SAPDestinationConfig(string Language)
        {
            this.SAPLanguage = Language;
        }

        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters parms = new RfcConfigParameters();
            parms.Add(RfcConfigParameters.Name, destinationName);
            parms.Add(RfcConfigParameters.AppServerHost, ConfigurationManager.AppSettings["SAP_APPSERVERASHOST"]);
            parms.Add(RfcConfigParameters.User, ConfigurationManager.AppSettings["SAP_USERNAME"]);
            parms.Add(RfcConfigParameters.Password, ConfigurationManager.AppSettings["SAP_PASSWORD"]);
            parms.Add(RfcConfigParameters.SystemNumber, ConfigurationManager.AppSettings["SAP_SYSTEMNUM"]);
            parms.Add(RfcConfigParameters.SystemID, ConfigurationManager.AppSettings["SAP_CLIENT"]);
            parms.Add(RfcConfigParameters.Client, ConfigurationManager.AppSettings["SAP_CLIENT"]);
            if (string.IsNullOrEmpty(this.SAPLanguage))
                parms.Add(RfcConfigParameters.Language, ConfigurationManager.AppSettings["SAP_LANGUAGE"]);
            else
                parms.Add(RfcConfigParameters.PoolSize, this.SAPLanguage);

            if (ConfigurationManager.AppSettings["SAP_ROUTER"] != null)
            {
                parms.Add(RfcConfigParameters.SAPRouter, ConfigurationManager.AppSettings["SAP_ROUTER"]);
            }
            return parms;
        }
    }
}
