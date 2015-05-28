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
        }

        private void btnSendTransaction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtResponse.Text = string.Empty;

            DateTime startTime = DateTime.Now;
            var tempRequest = string.Empty;
            var response = string.Empty;
            var txnRespone = string.Empty;

            //if txn requires padreset wrapping create padreset request and send
            if (emvTransaction == EMVTransactions.EMVReturn ||
                emvTransaction == EMVTransactions.EMVSale)
            {
                tempRequest = EMVRequest.GetEMVPadResetRequest(configData);
                response = dsiEMVX.ProcessTransaction(tempRequest);
            }

            txnRespone = dsiEMVX.ProcessTransaction(txtRequest.Text);

            //if txn requires padreset wrapping create padreset request and send
            if (emvTransaction == EMVTransactions.EMVReturn ||
                emvTransaction == EMVTransactions.EMVSale)
            {
                tempRequest = EMVRequest.GetEMVPadResetRequest(configData);
                response = dsiEMVX.ProcessTransaction(tempRequest);
            }

            TimeSpan ts = DateTime.Now.Subtract(startTime);
            this.lblClock.Text = string.Format("{0}:{1}:{2}.{3}", ts.Hours.ToString("0#"), ts.Minutes.ToString("0#"), ts.Seconds.ToString("0#"), ts.Milliseconds.ToString("#"));

            txtResponse.Text = txnRespone;

            Cursor.Current = Cursors.Arrow;
        }

        private void btnParamDownload_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.EMVParamDownload;

            txtRequest.Text = EMVRequest.GetEMVParamDownloadRequest(configData);
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

            txtRequest.Text = EMVRequest.GetEMVPadResetRequest(configData);
        }

        private void btnEMVSale_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.EMVSale;

            txtRequest.Text = EMVRequest.GetEMVSaleRequest(configData);
        }

        private void btnEMVReturn_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;

            emvTransaction = EMVTransactions.EMVReturn;

            txtRequest.Text = EMVRequest.GetEMVReturnRequest(configData);
        }
    }
}
