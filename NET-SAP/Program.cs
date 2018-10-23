using NET_SAP.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_SAP
{
    class Program
    {
        static void Main(string[] args)
        {
            SAPClass SAPClass = new SAPClass();

            string MATNR = "000000000000000021";
            string MAKTX = SAPClass.TestFunction(MATNR);
        }
    }
}
