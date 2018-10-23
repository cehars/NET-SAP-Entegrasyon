using SAP.Middleware.Connector;
using SAPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_SAP.SAP
{
    public class SAPClass : SAPManager
    {
        public SAPClass()
            : base()
        {
            this.InitializeConnection();
        }

        public SAPClass(string ConfigName)
            : base(ConfigName)
        {
            this.InitializeConnection();
        }

        public string TestFunction(string MATNR)
        {
            IRfcFunction rfcSurvey = this.RfcDestination.Repository.CreateFunction("Z_FEEDBACK_TEST");

            rfcSurvey.SetValue("I_MATNR", MATNR);

            rfcSurvey.Invoke(this.RfcDestination);

            string E_MAKTX = rfcSurvey.GetValue("E_MAKTX").ToString();

            return E_MAKTX;
        }

    }
}
