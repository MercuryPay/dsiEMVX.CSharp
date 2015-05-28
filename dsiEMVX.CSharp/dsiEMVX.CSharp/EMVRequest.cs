using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public class EMVRequest
    {
        public static string GetEMVParamDownloadRequest(ConfigurationData configData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", "9000");
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVParamDownload");
            requestDictionary.Add("SecureDevice", "EMV_VX805_MERCURY");
            requestDictionary.Add("ComPort", "9");
            requestDictionary.Add("InvoiceNo", "1");
            requestDictionary.Add("RefNo", "1");
            requestDictionary.Add("SequenceNo", "0010010000");


            return XMLHelper.BuildXMLRequest(requestDictionary, "Admin").ToString();
        }

        public static string GetEMVPadResetRequest(ConfigurationData configData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", "9000");
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVPadReset");
            requestDictionary.Add("SecureDevice", "EMV_VX805_MERCURY");
            requestDictionary.Add("ComPort", "9");
            requestDictionary.Add("InvoiceNo", "1");
            requestDictionary.Add("RefNo", "1");
            requestDictionary.Add("SequenceNo", "0010010000");


            return XMLHelper.BuildXMLRequest(requestDictionary, "Transaction").ToString();

        }

        public static string GetEMVSaleRequest(ConfigurationData configData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", "9000");
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVSale");
            requestDictionary.Add("SecureDevice", "EMV_VX805_MERCURY");
            requestDictionary.Add("ComPort", "9");
            requestDictionary.Add("InvoiceNo", "1");
            requestDictionary.Add("RefNo", "1");
            requestDictionary.Add("Purchase", "1.11");
            requestDictionary.Add("SequenceNo", "0010010000");

            return XMLHelper.BuildXMLRequest(requestDictionary, "Transaction").ToString();
        }

        public static string GetEMVReturnRequest(ConfigurationData configData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", "9000");
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVReturn");
            requestDictionary.Add("SecureDevice", "EMV_VX805_MERCURY");
            requestDictionary.Add("ComPort", "9");
            requestDictionary.Add("InvoiceNo", "1");
            requestDictionary.Add("RefNo", "1");
            requestDictionary.Add("Purchase", "1.11");
            requestDictionary.Add("SequenceNo", "0010010000");


            return XMLHelper.BuildXMLRequest(requestDictionary, "Transaction").ToString();
        }

    }
}
