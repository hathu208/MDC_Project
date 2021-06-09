namespace AR.Eftpos.Provider.PaymentIntegration
{
    partial class VNPayPayment
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
            this.components = new System.ComponentModel.Container();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnQRPay = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransactionId = new System.Windows.Forms.TextBox();
            this.btnSPOS = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTransRef = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(132, 347);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(453, 22);
            this.txtRequest.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(191, 148);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(453, 22);
            this.txtResponse.TabIndex = 2;
            // 
            // btnQRPay
            // 
            this.btnQRPay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQRPay.Location = new System.Drawing.Point(191, 212);
            this.btnQRPay.Name = "btnQRPay";
            this.btnQRPay.Size = new System.Drawing.Size(134, 27);
            this.btnQRPay.TabIndex = 4;
            this.btnQRPay.Text = "&OK";
            this.btnQRPay.UseVisualStyleBackColor = true;
            this.btnQRPay.Click += new System.EventHandler(this.btnQRPay_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(191, 70);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(146, 22);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Response message";
            // 
            // txtTransactionId
            // 
            this.txtTransactionId.Location = new System.Drawing.Point(132, 391);
            this.txtTransactionId.Name = "txtTransactionId";
            this.txtTransactionId.Size = new System.Drawing.Size(146, 22);
            this.txtTransactionId.TabIndex = 7;
            this.txtTransactionId.Text = "1111111111";
            // 
            // btnSPOS
            // 
            this.btnSPOS.Location = new System.Drawing.Point(331, 212);
            this.btnSPOS.Name = "btnSPOS";
            this.btnSPOS.Size = new System.Drawing.Size(138, 28);
            this.btnSPOS.TabIndex = 9;
            this.btnSPOS.Text = "OK";
            this.btnSPOS.UseVisualStyleBackColor = true;
            this.btnSPOS.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(30, 19);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(86, 25);
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "QR Pay";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "VNPay transaction ref.";
            // 
            // txtTransRef
            // 
            this.txtTransRef.Location = new System.Drawing.Point(191, 109);
            this.txtTransRef.Name = "txtTransRef";
            this.txtTransRef.Size = new System.Drawing.Size(453, 22);
            this.txtTransRef.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 265);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(609, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 14;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "Recall";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.UseWaitCursor = true;
            // 
            // VNPayPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTransRef);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnSPOS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTransactionId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnQRPay);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRequest);
            this.Name = "VNPayPayment";
            this.Text = "VNPay Integration";
            this.Load += new System.EventHandler(this.VNPayPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnQRPay;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransactionId;
        private System.Windows.Forms.Button btnSPOS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTransRef;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
    }
}

