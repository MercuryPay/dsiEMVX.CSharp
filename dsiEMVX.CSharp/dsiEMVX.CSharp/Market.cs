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
    public partial class Market : Form
    {
        public Market()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private TransactionData GetTransData()
        {
            var transData = new TransactionData();

            transData.Amount = AmountGenerator.GenerateAmount(0.01, 10.00);
            transData.InvoiceNo = InvoiceGenerator.GenerateInvoice();
            return transData;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dsiEMVX = new DSIEMVXLib.DsiEMVX();
                var emvTransaction = EMVTransactions.EMVSale;
                var configData = new ConfigurationData();

                var request = EMVRequest.GetEMVSaleRequest(configData, GetTransData());

                MessageBox.Show(request);

                DateTime startTime = DateTime.Now;

                var transactionProcessFactory = new TransactionProcessFactory();
                var emvTxnProcessor = transactionProcessFactory.GetObject(emvTransaction);
                emvTxnProcessor.Request = request;
                emvTxnProcessor.Process(dsiEMVX, configData, GetTransData());

                TimeSpan ts = DateTime.Now.Subtract(startTime);
                //this.lblClock.Text = string.Format("{0}:{1}:{2}.{3}", ts.Hours.ToString("0#"), ts.Minutes.ToString("0#"), ts.Seconds.ToString("0#"), ts.Milliseconds.ToString("#"));
                MessageBox.Show(emvTxnProcessor.Response);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dsiEMVX = new DSIEMVXLib.DsiEMVX();
                var emvTransaction = EMVTransactions.EMVParamDownload;
                var configData = new ConfigurationData();

                var request = EMVRequest.GetEMVParamDownloadRequest(configData, GetTransData());

                MessageBox.Show(request);

                DateTime startTime = DateTime.Now;

                var transactionProcessFactory = new TransactionProcessFactory();
                var emvTxnProcessor = transactionProcessFactory.GetObject(emvTransaction);
                emvTxnProcessor.Request = request;
                emvTxnProcessor.Process(dsiEMVX, configData, GetTransData());

                TimeSpan ts = DateTime.Now.Subtract(startTime);
                //this.lblClock.Text = string.Format("{0}:{1}:{2}.{3}", ts.Hours.ToString("0#"), ts.Minutes.ToString("0#"), ts.Seconds.ToString("0#"), ts.Milliseconds.ToString("#"));
                MessageBox.Show(emvTxnProcessor.Response);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
    }
}
