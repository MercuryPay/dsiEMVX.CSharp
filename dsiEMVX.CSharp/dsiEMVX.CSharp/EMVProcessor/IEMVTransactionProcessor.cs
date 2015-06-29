using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public interface IEMVTransactionProcessor
    {
        string Request {get;set;}
        Dictionary<string,string> ResponseDictionary { get; set; }
        string Response { get; set; }
        void Process(DSIEMVXLib.DsiEMVX dsiEMVX, ConfigurationData configData, TransactionData transData);
    }
}
