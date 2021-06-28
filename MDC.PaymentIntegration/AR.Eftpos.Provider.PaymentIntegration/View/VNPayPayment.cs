using AR.Eftpos.Bus.Managers;
using MDC.PaymentIntegration.VNPayIPNService;
using MDC.PaymentIntegration.VNPayPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public partial class VNPayPayment : Form
    {
        public log4net.ILog Log;

        private bool isSubscribing = false;

        public  VNPayIPNSubscriber Subscriber;

        private string transactionType;

        public string TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

        private string eftPosTransactionId;

        public string EftPosTransactionId
        {
            get { return eftPosTransactionId; }
            set { eftPosTransactionId = value; }
        }

        private string eftPosOrderId;

        public string EftPosOrderId
        {
            get { return eftPosOrderId; }
            set { eftPosOrderId = value; }
        }

        private long amount = 0;

        public long Amount
        {
            get
            {
                long.TryParse(this.txtAmount.Text, out amount);
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        private string vnPayTransRef;

        public string VNPayTransRef
        {
            get { return vnPayTransRef; }
            set { vnPayTransRef = value; }
        }

        private string vNPayMethod;

        public string VNPayMethod
        {
            get { return vNPayMethod; }
            set { vNPayMethod = value; }
        }

        //Result from service
        private string responseCode = "";

        public string ResponseCode
        {
            get { return responseCode; }
            set { responseCode = value; }
        }

        private string responseMessage = "";

        public string ResponseMessage
        {
            get { return responseMessage; }
            set { responseMessage = value; }
        }

        public VNPayPayment()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            this.Log = log4net.LogManager.GetLogger(typeof(EftPosX));


            transactionType = "Purchase";
            eftPosTransactionId = "1000017154125";
            eftPosOrderId = "1000017154125";
            vNPayMethod = Common.VNPayMethodCode.SPOSCARD;
            amount = 1000;
        }

        private void VNPayPayment_Load(object sender, EventArgs e)
        {
            //init value
            txtAmount.Text = this.amount.ToString();
            txtTransactionId.Text = this.EftPosTransactionId;

            //gen vnpay payment transaction
            /*bool result = VNPayClient.InitializeTrans(this);
            //bool result = true;
            if (result)
            {
                txtTransRef.Text = this.vnPayTransRef;
                lblResponse.Text = "Khởi tạo thành công";
                this.RunSubscriber();
            }
            else
            {
                lblResponse.Text = this.responseMessage;
            }*/
            this.RunSubscriber();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var message = Subscriber.ipnMessage;
            if (isSubscribing && !string.IsNullOrEmpty(message))
            {
                this.responseCode = Subscriber.ipnResponseCode;
                this.responseMessage = message;
                
                isSubscribing = false;
                progressBar1.Visible = false;
                this.LoadingForm(false);

                if (this.responseCode == Common.VNPAY_RESPONSE_CODE_SUCCESS)
                {
                    MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.lblResponse.Text = this.responseMessage;
                    MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void WaitingSubcriber()
        {
            var message = Subscriber.ipnMessage;
            if (isSubscribing && !string.IsNullOrEmpty(message))
            {
                this.responseCode = Subscriber.ipnResponseCode;
                this.responseMessage = message;

                isSubscribing = false;
                progressBar1.Visible = false;
                this.LoadingForm(false);

                if (this.responseCode == Common.VNPAY_RESPONSE_CODE_SUCCESS)
                {
                    MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.lblResponse.Text = this.responseMessage;
                    MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void LoadingForm(bool isLoading)
        {
            this.txtAmount.Enabled = !isLoading;
            //this.txtTransRef.Enabled = !isLoading;
            this.btnQRPay.Enabled = !isLoading;
            this.btnRecall.Enabled = !isLoading;
            this.UseWaitCursor = isLoading;
        }

        private void RunSubscriber()
        {
            try
            {
                this.Log.Debug("Starting subscriber...");
                Subscriber = new VNPayIPNSubscriber(this.Log);
                Subscriber.VnPayTransRef = this.vnPayTransRef;
                Subscriber.EftPosTransactionId = this.eftPosTransactionId;

                Subscriber.AddSubscriber();

                isSubscribing = true;
                progressBar1.Visible = true;
                this.LoadingForm(true);

                timer1.Start();
                if (!isSubscribing)
                {
                    timer1.Stop();
                }
            }
            catch(Exception e)
            {
                this.responseMessage = e.Message;
                this.Log.Error("RunSubscriber Failed", e);
            }
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            bool result;
            result = VNPayClient.RecallResultTrans(this);//, out this.responseCode, out this.responseMessage);
            lblResponse.Text = this.responseMessage;
            if (result)
            {
                MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
