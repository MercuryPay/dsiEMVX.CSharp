using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public class EMVSaleProcessor : IEMVTransactionProcessor
    {
        string _request;
        string _response;
        Dictionary<string,string> _responseDictionary;

        public string Request
        {
            get { return _request; }
            set { _request = value; }
        }

        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }

        public Dictionary<string, string> ResponseDictionary
        {
            get { return _responseDictionary; }
            set { _responseDictionary = value; }
        }

        public void Process(DSIEMVXLib.DsiEMVX dsiEMVX, ConfigurationData configData, TransactionData transData)
        {
            var tempRequest = string.Empty;

            tempRequest = EMVRequest.GetEMVPadResetRequest(configData, transData);
            _response = dsiEMVX.ProcessTransaction(tempRequest);
            _responseDictionary = XMLHelper.ParseXMLResponse(_response);

            if (_responseDictionary["CmdStatus"].ToLower() == "success")
            {
                _response = dsiEMVX.ProcessTransaction(_request);
                _responseDictionary = XMLHelper.ParseXMLResponse(_response);

                tempRequest = EMVRequest.GetEMVPadResetRequest(configData, transData);
                dsiEMVX.ProcessTransaction(tempRequest);
                XMLHelper.ParseXMLResponse(_response);
            }
        }
    }
}
