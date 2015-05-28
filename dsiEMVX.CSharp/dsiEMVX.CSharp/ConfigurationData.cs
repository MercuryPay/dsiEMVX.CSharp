using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace dsiEMVX.CSharp
{
    public class ConfigurationData
    {
        public string NetEPayServer = string.Empty;
        public string MerchantId = string.Empty;

        public ConfigurationData()
        {
            NetEPayServer = ConfigurationManager.AppSettings["NETePay"];
            MerchantId = ConfigurationManager.AppSettings["MerchantId"];
        }
    }
}
