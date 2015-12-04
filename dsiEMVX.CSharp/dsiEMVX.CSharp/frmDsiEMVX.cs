using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsiEMVX.CSharp
{
    public partial class frmDsiEMVX : Form
    {
        private ConfigurationData configData = null;
        private DSIEMVXLib.DsiEMVX dsiEMVX = null;
        private EMVTransactions emvTransaction = EMVTransactions.Unknown;    

        public frmDsiEMVX()
        {
            InitializeComponent();
            configData = new ConfigurationData();
            dsiEMVX = new DSIEMVXLib.DsiEMVX();
            emvTransaction = EMVTransactions.Unknown;

            lblAmount.Text = AmountGenerator.GenerateAmount(0.01, 10.00);

            lblInvoice.Text = InvoiceGenerator.GenerateInvoice();
        }



        private void btnSendTransaction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtResponse.Text = string.Empty;

            DateTime startTime = DateTime.Now;

            var transactionProcessFactory = new TransactionProcessFactory();
            var emvTxnProcessor = transactionProcessFactory.GetObject(emvTransaction);
            emvTxnProcessor.Request = txtRequest.Text;
            emvTxnProcessor.Process(dsiEMVX, configData, GetTransData());

            TimeSpan ts = DateTime.Now.Subtract(startTime);
            this.lblClock.Text = string.Format("{0}:{1}:{2}.{3}", ts.Hours.ToString("0#"), ts.Minutes.ToString("0#"), ts.Seconds.ToString("0#"), ts.Milliseconds.ToString("#"));

            txtResponse.Text = emvTxnProcessor.Response;

            Cursor.Current = Cursors.Arrow;
        }

        private TransactionData GetTransData()
        {
            var transData = new TransactionData();
            transData.Amount = lblAmount.Text;
            transData.InvoiceNo = lblInvoice.Text;
            return transData;
        }

        private void btnParamDownload_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.EMVParamDownload;

            txtRequest.Text = EMVRequest.GetEMVParamDownloadRequest(configData, GetTransData());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            emvTransaction = EMVTransactions.Unknown;

            txtRequest.Text = string.Empty;
            txtResponse.Text = string.Empty;
            lblClock.Text = "00:00:00";
        }

        private void btnPADReset_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.EMVPadReset;

            txtRequest.Text = EMVRequest.GetEMVPadResetRequest(configData, GetTransData());
        }

        private void btnEMVSale_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.EMVSale;

            txtRequest.Text = EMVRequest.GetEMVSaleRequest(configData, GetTransData());
        }

        private void btnEMVReturn_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.EMVReturn;

            txtRequest.Text = EMVRequest.GetEMVReturnRequest(configData, GetTransData());
        }

        private void btnRandomAmount_Click(object sender, EventArgs e)
        {
            lblAmount.Text = AmountGenerator.GenerateAmount(0.01, 10.00);
        }

        private void btnServerVersion_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.ServerVersion;

            txtRequest.Text = EMVRequest.GetServerVersionRequest(configData, GetTransData());
        }
    }
}
