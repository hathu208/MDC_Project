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
            this.btnManual = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateResult = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblManualComplete = new System.Windows.Forms.Label();
            this.lblTransactionRef = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblTransRef = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnManual
            // 
            this.btnManual.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnManual.Enabled = false;
            this.btnManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManual.Location = new System.Drawing.Point(262, 188);
            this.btnManual.Margin = new System.Windows.Forms.Padding(2);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(107, 34);
            this.btnManual.TabIndex = 4;
            this.btnManual.Text = "[&M]anual Update";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Response message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(22, 12);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(62, 20);
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "VNPay";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "VNPay transaction ref.";
            // 
            // btnUpdateResult
            // 
            this.btnUpdateResult.Enabled = false;
            this.btnUpdateResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateResult.Location = new System.Drawing.Point(141, 188);
            this.btnUpdateResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateResult.Name = "btnUpdateResult";
            this.btnUpdateResult.Size = new System.Drawing.Size(104, 34);
            this.btnUpdateResult.TabIndex = 13;
            this.btnUpdateResult.Text = "[&U]pdate Result";
            this.btnUpdateResult.UseVisualStyleBackColor = true;
            this.btnUpdateResult.Click += new System.EventHandler(this.btnUpdateResult_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Transaction ref.";
            // 
            // lblResponse
            // 
            this.lblResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponse.Location = new System.Drawing.Point(152, 152);
            this.lblResponse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(326, 15);
            this.lblResponse.TabIndex = 16;
            this.lblResponse.Text = "Response";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(22, 36);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(45, 13);
            this.lblSubTitle.TabIndex = 17;
            this.lblSubTitle.Text = "Sub title";
            // 
            // lblManualComplete
            // 
            this.lblManualComplete.AutoSize = true;
            this.lblManualComplete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblManualComplete.Location = new System.Drawing.Point(5, 230);
            this.lblManualComplete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManualComplete.Name = "lblManualComplete";
            this.lblManualComplete.Size = new System.Drawing.Size(96, 13);
            this.lblManualComplete.TabIndex = 18;
            this.lblManualComplete.Text = "lblManualComplete";
            this.lblManualComplete.Visible = false;
            // 
            // lblTransactionRef
            // 
            this.lblTransactionRef.AutoSize = true;
            this.lblTransactionRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionRef.Location = new System.Drawing.Point(152, 74);
            this.lblTransactionRef.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransactionRef.Name = "lblTransactionRef";
            this.lblTransactionRef.Size = new System.Drawing.Size(77, 15);
            this.lblTransactionRef.TabIndex = 19;
            this.lblTransactionRef.Text = "0000000000";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(152, 100);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(35, 15);
            this.lblAmount.TabIndex = 20;
            this.lblAmount.Text = "1000";
            // 
            // lblTransRef
            // 
            this.lblTransRef.AutoSize = true;
            this.lblTransRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransRef.Location = new System.Drawing.Point(152, 126);
            this.lblTransRef.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransRef.Name = "lblTransRef";
            this.lblTransRef.Size = new System.Drawing.Size(77, 15);
            this.lblTransRef.TabIndex = 21;
            this.lblTransRef.Text = "0000000000";
            // 
            // VNPayPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(489, 274);
            this.Controls.Add(this.lblTransRef);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTransactionRef);
            this.Controls.Add(this.lblManualComplete);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdateResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnManual);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VNPayPayment";
            this.Text = "VNPay Integration";
            this.Load += new System.EventHandler(this.VNPayPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdateResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblManualComplete;
        private System.Windows.Forms.Label lblTransactionRef;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTransRef;
    }
}

