using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public class EMVRequest
    {
        public static string GetEMVParamDownloadRequest(ConfigurationData configData, TransactionData transData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", configData.IpPort);
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVParamDownload");
            requestDictionary.Add("SecureDevice", configData.SecureDevice);
            requestDictionary.Add("ComPort", configData.ComPort);
            requestDictionary.Add("InvoiceNo", "1");
            requestDictionary.Add("RefNo", "1");
            requestDictionary.Add("SequenceNo", "0010010000");


            return XMLHelper.BuildXMLRequest(requestDictionary, "Admin").ToString();
        }

        public static string GetEMVPadResetRequest(ConfigurationData configData, TransactionData transData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", configData.IpPort);
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVPadReset");
            requestDictionary.Add("SecureDevice", configData.SecureDevice);
            requestDictionary.Add("ComPort", configData.ComPort);
            requestDictionary.Add("InvoiceNo", "1");
            requestDictionary.Add("RefNo", "1");
            requestDictionary.Add("SequenceNo", "0010010000");


            return XMLHelper.BuildXMLRequest(requestDictionary, "Transaction").ToString();

        }

        public static string GetEMVSaleRequest(ConfigurationData configData, TransactionData transData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", configData.IpPort);
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVSale");
            requestDictionary.Add("SecureDevice", configData.SecureDevice);
            requestDictionary.Add("ComPort", configData.ComPort);
            requestDictionary.Add("InvoiceNo", transData.InvoiceNo);
            requestDictionary.Add("RefNo", transData.InvoiceNo);
            requestDictionary.Add("Purchase", transData.Amount);
            requestDictionary.Add("OperatorID", "test");
            requestDictionary.Add("SequenceNo", "0010010000");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("Frequency", "OneTime");

            return XMLHelper.BuildXMLRequest(requestDictionary, "Transaction").ToString();
        }

        public static string GetEMVReturnRequest(ConfigurationData configData, TransactionData transData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", configData.IpPort);
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "EMVReturn");
            requestDictionary.Add("SecureDevice", configData.SecureDevice);
            requestDictionary.Add("ComPort", configData.ComPort);
            requestDictionary.Add("InvoiceNo", transData.InvoiceNo);
            requestDictionary.Add("RefNo", transData.InvoiceNo);
            requestDictionary.Add("Purchase", transData.Amount);
            requestDictionary.Add("SequenceNo", "0010010000");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("Frequency", "OneTime");


            return XMLHelper.BuildXMLRequest(requestDictionary, "Transaction").ToString();
        }

        public static string GetServerVersionRequest(ConfigurationData configData, TransactionData transData)
        {
            var requestDictionary = new Dictionary<string, object>();

            requestDictionary.Add("HostOrIP", configData.NetEPayServer);
            requestDictionary.Add("IpPort", configData.IpPort);
            requestDictionary.Add("MerchantID", configData.MerchantId);
            requestDictionary.Add("TranCode", "ServerVersion");
            requestDictionary.Add("SecureDevice", configData.SecureDevice);
            requestDictionary.Add("ComPort", configData.ComPort);
            requestDictionary.Add("SequenceNo", "0010010000");

            return XMLHelper.BuildXMLRequest(requestDictionary, "Admin").ToString();
        }

    }
}
