using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public enum EMVTransactions
    {
        Unknown,
        EMVParamDownload,
        EMVPadReset,
        EMVSale,
        EMVReturn,
    }
}
