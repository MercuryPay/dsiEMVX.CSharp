using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public class InvoiceGenerator
    {
        public static string GenerateInvoice()
        {
            return DateTime.Now.ToString("MMddyyyyhhmmssfff");
        }
    }
}
