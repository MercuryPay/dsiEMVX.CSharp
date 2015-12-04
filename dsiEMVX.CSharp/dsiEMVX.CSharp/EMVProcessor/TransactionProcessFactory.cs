using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public class TransactionProcessFactory
    {
        public IEMVTransactionProcessor GetObject(EMVTransactions emvTransaction)
        {
            if (emvTransaction == EMVTransactions.EMVPadReset)
            {
                return new EMVPadResetProcessor();
            }
            else if (emvTransaction == EMVTransactions.EMVSale)
            {
                return new EMVSaleProcessor();
            }
            else if (emvTransaction == EMVTransactions.EMVReturn)
            {
                return new EMVReturnProcessor();
            }
            else if (emvTransaction == EMVTransactions.EMVParamDownload)
            {
                return new EMVParamDownloadProcessor();
            }
            else if (emvTransaction == EMVTransactions.ServerVersion)
            {
                return new ServerVersionProcessor();
            }
            else
            {
                return null;
            }
        }
    }
}
