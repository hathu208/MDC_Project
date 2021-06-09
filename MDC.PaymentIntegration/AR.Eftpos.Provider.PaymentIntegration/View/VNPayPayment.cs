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

        public VNPayPayment()
        {
            InitializeComponent();
            transactionType = "Purchase";
            eftPosTransactionId = "1111111115";
            eftPosOrderId = "Ord1111111111";
            amount = 1000;
        }

        private void VNPayPayment_Load(object sender, EventArgs e)
        {
            //init value
            txtAmount.Text = this.amount.ToString();
            txtTransactionId.Text = this.EftPosTransactionId;
            //gen qr
            IPayment qrPay = new Payment();
            bool result = qrPay.genQR(eftPosTransactionId, eftPosOrderId, eftPosOrderId, string.Format("{0} {1}", transactionType, eftPosTransactionId), amount, Common.VNPayMethodCode.QRCODE);
            txtRequest.Text = (qrPay as Payment).stringRequest;
            if(result)
            {
                this.vnPayTransRef = qrPay.APIResponse.psTransactionCode;
                txtTransRef.Text = this.vnPayTransRef;
                txtResponse.Text = "Khởi tạo thành công";
                this.RunSubscriber();
            }
            else
            {
                txtResponse.Text = string.Format("{0} - {1}", qrPay.APIResponse.errors.code, qrPay.APIResponse.errors.message);
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
            this.button1.Enabled = !isLoading;
        }

        private void RunSubscriber()
        {
            try
            {
                Subscriber = new VNPayIPNSubscriber();
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
            }
        }
       
    }
}
