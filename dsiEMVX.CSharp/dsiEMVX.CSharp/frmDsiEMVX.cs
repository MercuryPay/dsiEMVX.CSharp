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

        private void btnDemoSig_Click(object sender, EventArgs e)
        {
            var signatureData = "<Signature>79,27:79,27:79,26:79,26:79,26:79,27:79,28:77,30:73,33:69,38:66,44:62,52:56,62:48,72:42,79:39,82:39,81:#,#:79,29:79,29:78,28:80,26:82,26:81,30:77,36:75,40:74,44:75,47:76,50:78,51:84,48:92,41:101,33:108,27:110,26:109,26:109,28:109,30:109,31:109,34:107,40:103,49:97,58:93,65:88,71:87,74:#,#:133,38:133,38:133,38:132,40:129,47:124,54:121,59:117,65:114,70:#,#:130,39:130,39:130,39:135,35:145,29:157,24:166,23:#,#:125,52:125,52:122,53:125,52:136,48:147,47:152,48:#,#:114,69:114,69:112,69:117,68:129,65:139,63:147,62:#,#:199,30:199,30:197,31:196,35:195,40:195,45:191,54:182,63:174,72:171,76:173,76:182,72:198,69:216,67:231,66:239,66:240,67:238,68:#,#:</Signature>";
            signatureData = signatureData.Replace("<Signature>", "");
            signatureData = signatureData.Replace("</Signature>", "");
            var stringOfPoints = signatureData.Split(':');

            var beginStroke = true;

            using (Graphics g = pbSignature.CreateGraphics())
            {
                g.Clear(Color.White);

                var keepx = "";
                var keepy = "";

                foreach (var pointval in stringOfPoints)
                {
                    if (!String.IsNullOrEmpty(pointval))
                    {
                        var point = pointval.Split(',');
                        var x = point[0];
                        var y = point[1];

                        if (x == "#" && y == "#")
                        {
                            beginStroke = true;
                        }
                        else
                        {
                            if (beginStroke)
                            {
                                beginStroke = false;
                            }
                            else
                            {
                                g.DrawLine(new Pen(Color.Red), new Point(Convert.ToInt32(keepx), Convert.ToInt32(keepy)), new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
                            }
                        }
                        keepx = x;
                        keepy = y;
                    }
                }
            }
        }
    }
}
