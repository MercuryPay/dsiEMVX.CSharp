using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public class EMVPadResetProcessor : IEMVTransactionProcessor
    {
        string _request;
        string _response;
        Dictionary<string,string> _responseDictionary;

        public void Process(DSIEMVXLib.DsiEMVX dsiEMVX, ConfigurationData configData, TransactionData transData)
        {
            string txnResponse = string.Empty;

            _request = EMVRequest.GetEMVPadResetRequest(configData, transData);
            _response = dsiEMVX.ProcessTransaction(_request);
            _responseDictionary = XMLHelper.ParseXMLResponse(_response);
        }

        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }

        public string Request
        {
            get{return _request;}
            set{_request = value;}
        }

        public Dictionary<string, string> ResponseDictionary
        {
            get { return _responseDictionary; }
            set { _responseDictionary = value; }
        }
    }
}
