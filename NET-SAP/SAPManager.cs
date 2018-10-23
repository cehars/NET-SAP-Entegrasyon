using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;
using System.Configuration;

namespace SAPLibrary
{
    public class SAPManager: IDisposable
    {
        public IDestinationConfiguration destinationConfig = null;
        public RfcDestination rfcDestination;
        public bool destinationIsInialised = false;

        public string  destinationConfigName { get; set; }

        public string saplogonlanguage { get; set; }
       
        public bool result = false;

        public void InitializeConnection()
        {
          
            destinationConfig = new SAPDestinationConfig(this.saplogonlanguage);
          
            //destinationConfig.GetParameters(destinationConfigName);

            if (RfcDestinationManager.TryGetDestination(destinationConfigName) == null)
            {
                RfcDestinationManager.RegisterDestinationConfiguration(destinationConfig);
                destinationIsInialised = true;
            }
        }

        public RfcDestination RfcDestination
        {
            get
            {
                if (rfcDestination == null)
                {
                    rfcDestination = RfcDestinationManager.GetDestination(destinationConfigName);
                }

                return rfcDestination;
            }
        }
 
        public SAPManager()
        {
            this.destinationConfigName = ConfigurationManager.AppSettings["SAP_SYSTEM_TN"];
        }

        public SAPManager(string Language, string ConfigName)
        {
            this.destinationConfigName = ConfigName;
            this.saplogonlanguage = Language;
        }

        public SAPManager(string ConfigName)
        {
            this.destinationConfigName = ConfigName;
        }

        public bool TestConnection()
        {
            result = false;
            try
            {


                if (this.RfcDestination != null)
                {
                    this.RfcDestination.Ping();
                    result = true;

                }

            }
            catch (Exception ex)
            {
                result = false;

                throw new Exception("Connection Failure Error : " + ex.Message);
                throw;
            }

            return result;
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
