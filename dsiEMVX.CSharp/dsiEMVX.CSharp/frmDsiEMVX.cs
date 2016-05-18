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
            var signatureData = "<Signature>50,40:48,41:45,42:43,43:42,44:40,45:38,46:36,47:34,48:32,49:30,49:28,50:23,50:21,49:19,49:17,48:16,47:14,45:13,44:12,42:11,40:10,37:10,32:11,31:12,29:14,27:17,27:18,26:19,27:21,27:22,28:23,29:25,30:26,31:28,33:29,35:30,37:32,39:33,42:34,45:34,49:35,52:36,56:36,68:35,73:35,77:34,81:33,85:#,#:10,85:11,80:13,76:15,72:17,69:19,66:22,63:24,61:26,59:29,58:31,57:34,56:38,56:40,57:42,57:44,58:45,59:47,60:48,61:49,62:50,64:51,66:#,#:70,37:69,38:68,40:67,42:66,44:66,45:65,47:65,55:66,57:68,58:70,57:70,49:69,48:68,46:67,45:66,44:65,43:63,43:64,45:65,46:69,46:71,45:73,45:74,44:76,43:78,42:80,41:81,40:83,39:84,38:85,37:86,36:87,35:87,34:86,35:85,36:84,38:83,40:81,42:80,44:79,46:78,48:77,50:77,56:78,57:79,59:80,60:82,61:84,62:86,63:93,63:#,#:129,35:128,34:128,31:127,30:127,23:128,22:129,21:130,22:131,23:132,25:133,27:133,29:134,31:134,33:135,36:135,56:134,58:134,64:135,62:136,61:137,59:138,57:139,54:140,51:142,48:143,45:145,41:147,37:149,33:151,30:152,27:154,24:155,22:157,20:158,18:159,17:161,16:162,18:#,#:168,40:166,41:165,42:164,43:163,44:161,45:160,47:159,49:157,50:156,52:155,54:154,55:153,57:152,58:151,59:151,62:153,61:155,60:156,59:157,58:159,57:160,55:162,54:163,52:164,51:166,49:167,48:168,46:169,44:170,43:171,42:170,43:169,45:168,46:167,47:166,48:165,50:165,51:164,53:163,55:163,57:162,59:163,61:163,63:167,63:168,62:170,61:171,59:173,57:174,56:175,55:176,53:177,51:178,50:179,48:180,46:179,47:179,51:180,52:180,54:181,55:182,56:183,57:187,57:188,55:190,54:191,53:192,52:193,51:195,50:197,50:198,51:199,53:200,54:201,56:204,56:205,54:#,#:229,10:229,12:228,13:228,15:227,17:227,18:226,20:225,23:225,25:224,27:223,30:223,32:222,35:222,37:221,40:221,44:220,46:220,55:218,55:#,#:200,42:202,41:204,40:206,39:208,38:210,38:213,37:215,36:218,35:221,35:224,34:227,33:229,33:232,32:242,32:#,#:248,35:247,37:246,39:245,41:244,43:244,45:243,46:242,47:242,50:241,51:241,55:243,54:244,53:245,52:246,51:247,49:248,48:249,46:251,45:252,43:253,42:254,41:255,39:256,38:257,37:257,39:256,40:256,42:255,44:254,46:254,54:255,56:256,57:257,58:258,59:262,59:264,58:266,57:268,56:270,55:271,54:272,52:274,51:275,50:276,49:277,48:278,47:279,46:280,45:281,44:282,43:283,42:284,40:285,38:#,#:257,10:255,10:254,10:#,#:</Signature>";
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
