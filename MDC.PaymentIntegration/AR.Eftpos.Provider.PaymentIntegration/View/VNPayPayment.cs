using AR.Eftpos.Bus.Managers;
using MDC.PaymentIntegration.VNPayPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public partial class VNPayPayment : Form
    {
        public log4net.ILog Log;

        private string transactionType;

        public string TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

        private string transactionId;

        public string TransactionId
        {
            get { return transactionId; }
            set { transactionId = value; }
        }

        private string transactionRef;

        public string TransactionRef
        {
            get { return transactionRef; }
            set { transactionRef = value; }
        }

        private string posWrkStationNo;

        public string PosWrkStationNo
        {
            get { return posWrkStationNo; }
            set { posWrkStationNo = value; }
        }

        private string posBranchNo;

        public string PosBranchNo
        {
            get { return posBranchNo; }
            set { posBranchNo = value; }
        }

        private long amount = 0;

        public long Amount
        {
            get
            {
                long.TryParse(this.lblAmount.Text, out amount);
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

        private string vNPayMethod = "QRCODE";

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

        private string responseStatus = "";

        public string ResponseStatus
        {
            get { return responseStatus; }
            set { responseStatus = value; }
        }

        private bool isManualUpdate;

        public bool IsManualUpdate
        {
            get { return isManualUpdate; }
            set { isManualUpdate = value; }
        }


        public VNPayPayment()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            this.Log = log4net.LogManager.GetLogger(typeof(EftPosX));
            lblManualComplete.Text = Resource.ManualUpdate;

            if (vNPayMethod == Common.VNPayMethodCode.QRCODE)
            {
                lblHeader.Text = Resource.QRHeader;
                lblSubTitle.Text = Resource.QRSubTitle;
            }
            else if(vNPayMethod == Common.VNPayMethodCode.SPOSCARD)
            {
                lblHeader.Text = Resource.BankCardHeader;
                lblSubTitle.Text = Resource.BankCardSubTitle;
            }


            /*transactionType = "Purchase";
            transactionId = "1000017154125";
            posWrkStationNo = "1000017154125";
            vNPayMethod = Common.VNPayMethodCode.SPOSCARD;
            amount = 100000;*/
        }

        private void VNPayPayment_Load(object sender, EventArgs e)
        {
            this.Log.Debug("Initialize VNPAY transaction...");
            //init value
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   
            lblAmount.Text = this.amount.ToString("#,###", cul.NumberFormat);
            lblTransactionId.Text = this.TransactionId;

            //gen vnpay payment transaction
            bool result = VNPayClient.InitializeTrans(this);
            //bool result = true;
            if (result)
            {
                lblTransRef.Text = this.vnPayTransRef;
                lblResponse.Text = Resource.InitSuccess;
                btnUpdateResult.Enabled = true;
            }
            else
            {
                lblResponse.Text = this.responseMessage;
                MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void LoadingForm(bool isLoading)
        {
            this.btnManual.Enabled = !isLoading;
            this.btnUpdateResult.Enabled = !isLoading;
            this.UseWaitCursor = isLoading;
        }

        private void StatusForm(bool isEnable)
        {
            btnManual.Enabled = !isEnable;
            lblManualComplete.Visible = !isEnable;
        }

        private void btnUpdateResult_Click(object sender, EventArgs e)
        {
            this.Log.Debug("Get transaction result...");
            bool result;

            int countRetry = 0;
            this.StatusForm(true);
            this.LoadingForm(true);

            while (countRetry < 3)
            {
                result = VNPayClient.GetResultTrans(this);//, out this.responseCode, out this.responseMessage);
                lblResponse.Text = this.responseMessage;
                
                if (result && (this.responseStatus == Common.VNPayResponseStatus.FAILURE || this.responseStatus == Common.VNPayResponseStatus.SUCCESS))
                {
                    MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    countRetry++;
                    Thread.Sleep(5000);
                }
            }

            MessageBox.Show(this, this.responseMessage, "VNpay payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.StatusForm(false);
            this.LoadingForm(false);
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            this.isManualUpdate = true;
            this.responseCode = Common.VNPAY_FILTER_RESPONSE_CODE_SUCCESS;
            this.responseMessage = "Manual completed";
            this.DialogResult = DialogResult.OK;
        }
    }
}
