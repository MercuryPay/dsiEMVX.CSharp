namespace dsiEMVX.CSharp
{
    partial class frmDsiEMVX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEMVSale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEMVReturn = new System.Windows.Forms.Button();
            this.btnPADReset = new System.Windows.Forms.Button();
            this.btnParamDownload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendTransaction = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEMVSale
            // 
            this.btnEMVSale.Location = new System.Drawing.Point(12, 12);
            this.btnEMVSale.Name = "btnEMVSale";
            this.btnEMVSale.Size = new System.Drawing.Size(117, 42);
            this.btnEMVSale.TabIndex = 0;
            this.btnEMVSale.Text = "EMV SALE";
            this.btnEMVSale.UseVisualStyleBackColor = true;
            this.btnEMVSale.Click += new System.EventHandler(this.btnEMVSale_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request:";
            // 
            // btnEMVReturn
            // 
            this.btnEMVReturn.Location = new System.Drawing.Point(135, 12);
            this.btnEMVReturn.Name = "btnEMVReturn";
            this.btnEMVReturn.Size = new System.Drawing.Size(117, 42);
            this.btnEMVReturn.TabIndex = 2;
            this.btnEMVReturn.Text = "EMV RETURN";
            this.btnEMVReturn.UseVisualStyleBackColor = true;
            this.btnEMVReturn.Click += new System.EventHandler(this.btnEMVReturn_Click);
            // 
            // btnPADReset
            // 
            this.btnPADReset.Location = new System.Drawing.Point(258, 12);
            this.btnPADReset.Name = "btnPADReset";
            this.btnPADReset.Size = new System.Drawing.Size(117, 42);
            this.btnPADReset.TabIndex = 3;
            this.btnPADReset.Text = "EMV PADRESET";
            this.btnPADReset.UseVisualStyleBackColor = true;
            this.btnPADReset.Click += new System.EventHandler(this.btnPADReset_Click);
            // 
            // btnParamDownload
            // 
            this.btnParamDownload.Location = new System.Drawing.Point(381, 12);
            this.btnParamDownload.Name = "btnParamDownload";
            this.btnParamDownload.Size = new System.Drawing.Size(117, 42);
            this.btnParamDownload.TabIndex = 4;
            this.btnParamDownload.Text = "EMV PARAMDOWNLOAD";
            this.btnParamDownload.UseVisualStyleBackColor = true;
            this.btnParamDownload.Click += new System.EventHandler(this.btnParamDownload_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(505, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 42);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(15, 176);
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequest.Size = new System.Drawing.Size(607, 140);
            this.txtRequest.TabIndex = 6;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(15, 360);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(607, 140);
            this.txtResponse.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Response:";
            // 
            // btnSendTransaction
            // 
            this.btnSendTransaction.Location = new System.Drawing.Point(15, 70);
            this.btnSendTransaction.Name = "btnSendTransaction";
            this.btnSendTransaction.Size = new System.Drawing.Size(607, 42);
            this.btnSendTransaction.TabIndex = 9;
            this.btnSendTransaction.Text = "SEND TRANSACTION";
            this.btnSendTransaction.UseVisualStyleBackColor = true;
            this.btnSendTransaction.Click += new System.EventHandler(this.btnSendTransaction_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Location = new System.Drawing.Point(285, 127);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(49, 13);
            this.lblClock.TabIndex = 10;
            this.lblClock.Text = "00:00:00";
            // 
            // frmDsiEMVX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 525);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.btnSendTransaction);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnParamDownload);
            this.Controls.Add(this.btnPADReset);
            this.Controls.Add(this.btnEMVReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEMVSale);
            this.Name = "frmDsiEMVX";
            this.Text = "dsiEMVX.CSharp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEMVSale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEMVReturn;
        private System.Windows.Forms.Button btnPADReset;
        private System.Windows.Forms.Button btnParamDownload;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSendTransaction;
        private System.Windows.Forms.Label lblClock;
    }
}

