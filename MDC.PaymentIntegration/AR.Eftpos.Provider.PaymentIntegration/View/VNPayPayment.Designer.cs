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
            this.btnQRPay = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransactionId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTransRef = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRecall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnQRPay
            // 
            this.btnQRPay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQRPay.Enabled = false;
            this.btnQRPay.Location = new System.Drawing.Point(143, 172);
            this.btnQRPay.Margin = new System.Windows.Forms.Padding(2);
            this.btnQRPay.Name = "btnQRPay";
            this.btnQRPay.Size = new System.Drawing.Size(100, 22);
            this.btnQRPay.TabIndex = 4;
            this.btnQRPay.Text = "&OK";
            this.btnQRPay.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(143, 57);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(110, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Response message";
            // 
            // txtTransactionId
            // 
            this.txtTransactionId.Location = new System.Drawing.Point(113, 237);
            this.txtTransactionId.Margin = new System.Windows.Forms.Padding(2);
            this.txtTransactionId.Name = "txtTransactionId";
            this.txtTransactionId.Size = new System.Drawing.Size(110, 20);
            this.txtTransactionId.TabIndex = 7;
            this.txtTransactionId.Text = "1111111111";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(22, 15);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(69, 20);
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "QR Pay";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "VNPay transaction ref.";
            // 
            // txtTransRef
            // 
            this.txtTransRef.Location = new System.Drawing.Point(143, 89);
            this.txtTransRef.Margin = new System.Windows.Forms.Padding(2);
            this.txtTransRef.Name = "txtTransRef";
            this.txtTransRef.Size = new System.Drawing.Size(341, 20);
            this.txtTransRef.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRecall
            // 
            this.btnRecall.Location = new System.Drawing.Point(280, 172);
            this.btnRecall.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecall.Name = "btnRecall";
            this.btnRecall.Size = new System.Drawing.Size(104, 23);
            this.btnRecall.TabIndex = 13;
            this.btnRecall.Text = "Recall";
            this.btnRecall.UseVisualStyleBackColor = true;
            this.btnRecall.Click += new System.EventHandler(this.btnRecall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 244);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "AR Trans ID";
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(143, 124);
            this.lblResponse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(55, 13);
            this.lblResponse.TabIndex = 16;
            this.lblResponse.Text = "Response";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 215);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(457, 18);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 14;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // VNPayPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(544, 366);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRecall);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTransRef);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTransactionId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnQRPay);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VNPayPayment";
            this.Text = "VNPay Integration";
            this.Load += new System.EventHandler(this.VNPayPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnQRPay;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransactionId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTransRef;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRecall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

