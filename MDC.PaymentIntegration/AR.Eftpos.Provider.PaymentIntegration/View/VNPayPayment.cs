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
            this.Log = log4net.LogManager.GetLogger(typeof(VNPayPayment));
            /*transactionType = "Purchase";
            eftPosTransactionId = "1111111115";
            eftPosOrderId = "Ord1111111111";
            vNPayMethod = Common.VNPayMethodCode.SPOSCARD;
            amount = 1000;*/
        }

        private void VNPayPayment_Load(object sender, EventArgs e)
        {
            //init value
            txtAmount.Text = this.amount.ToString();
            txtTransactionId.Text = this.EftPosTransactionId;

            //gen vnpay payment transaction
            bool result = VNPayClient.InitializeTrans(this);
            
            if (result)
            {
                txtTransRef.Text = this.vnPayTransRef;
                txtResponse.Text = "Khởi tạo thành công";
                this.RunSubscriber();

                if (this.responseCode == Common.VNPAY_RESPONSE_CODE_SUCCESS)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                txtResponse.Text = this.responseMessage;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var message = Subscriber.ipnMessage;
            if (!string.IsNullOrEmpty(message))
            {
                txtResponse.Text = message;
                isSubscribing = false;
                progressBar1.Visible = false;
                this.LoadingForm(false);
            }
        }

        private void LoadingForm(bool isLoading)
        {
            this.txtAmount.Enabled = !isLoading;
            this.txtResponse.Enabled = !isLoading;
            this.txtTransRef.Enabled = !isLoading;
            this.btnQRPay.Enabled = !isLoading;
            this.btnRecall.Enabled = !isLoading;
        }

        private void RunSubscriber()
        {
            try
            {
                this.Log.Info("Starting subscriber...");
                Subscriber = new VNPayIPNSubscriber(this.Log);
                Subscriber.VnPayTransRef = this.vnPayTransRef;
                Subscriber.EftPosTransactionId = this.eftPosTransactionId;

                Subscriber.AddSubscriber();

                isSubscribing = true;
                progressBar1.Visible = true;
                this.LoadingForm(true);

                timer1.Start();
                while (!isSubscribing)
                {
                    timer1.Stop();
                }
            }
            catch(Exception e)
            {
                this.txtResponse.Text = e.Message;
                this.Log.Error("RunSubscriber Failed", e);
            }
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            bool result;
            result = VNPayClient.RecallResultTrans(this);//, out this.responseCode, out this.responseMessage);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
