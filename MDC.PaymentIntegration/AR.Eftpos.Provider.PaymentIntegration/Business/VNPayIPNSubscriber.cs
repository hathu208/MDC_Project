using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using MDC.PaymentIntegration.VNPayIPNService;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public class VNPayIPNSubscriber: IVNPayIPNPublishServiceCallback
    {
        private VNPayIPNPublishServiceClient myClient;
        private readonly Thread workerThread;
        private readonly ManualResetEvent stopEvent = new ManualResetEvent(false);
        //log
        private log4net.ILog log;
        //eft trans
        public string VnPayTransRef;
        public string EftPosTransactionId;
        //Result from IPN
        public string ipnCardType;
        public string ipnBankCode;
        public string ipnPsTransactionCode = "";
        public string ipnResponseCode = "";
        public string ipnMessage = "";

        public VNPayIPNSubscriber(log4net.ILog _log)
        {
            this.log = _log;
            workerThread = new Thread(ReceiveData);
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        public void Stop()
        {
            stopEvent.Set();
            myClient.Unsubscribe();
            myClient.Close();
            log.Debug("Stoping subscriber.");
            workerThread.Join();
        }

        private void ReceiveData()
        {
            while (!stopEvent.WaitOne(0))
            {
                if (string.IsNullOrEmpty(ipnMessage))
                    continue;

                this.Stop();
            }
        }

        public void AddSubscriber()
        {
            try
            {
                // always create an instance context to associate the service with            
                InstanceContext siteHostContext = new InstanceContext(null, this);

                myClient = new VNPayIPNPublishServiceClient(siteHostContext);
                //myClient.ClientCredentials.UserName.UserName = @"vnpay_ipn";
                //myClient.ClientCredentials.UserName.Password = "ipn123@";

                // create a unique callback address (if you want multiple subscribers to run on the same machine)
                WSDualHttpBinding binding = (WSDualHttpBinding)myClient.Endpoint.Binding;
                string uniqueCallbackAddress = binding.ClientBaseAddress.AbsoluteUri;

                uniqueCallbackAddress += Guid.NewGuid().ToString();
                binding.ClientBaseAddress = new Uri(uniqueCallbackAddress);

                // Subcribe
                myClient.Subscribe();
            }
            catch (Exception e)
            {
                log.Error("AddSubscriber Failed", e);
                MessageBox.Show(string.Format("{0}\r\nMessage: {1}\r\n{2}: {3}", e.GetType().ToString(), e.Message, e.InnerException.GetType().ToString(), e.InnerException.Message), "Add subscriber");
                throw new Exception("Subscriber VNPay service đang bị lỗi. Thử 'Recall' để gọi lại kết quả.");
            }
        }

        void IVNPayIPNPublishServiceCallback.SubscribeResultTransChange(IPNRequest request)
        {
            if (request.responseCode == Common.VNPAY_RESPONSE_CODE_SUCCESS)
            {
                if (request.psTransactionCode == this.VnPayTransRef && request.clientTransactionCode == this.EftPosTransactionId)
                {
                    ipnCardType = request.cardType;
                    ipnBankCode = request.bankCode;
                    ipnPsTransactionCode = request.psTransactionCode;
                    ipnResponseCode = request.responseCode;
                    ipnMessage = request.responseMessage;
                }
                else
                {
                    ipnMessage = "Kết quả trả về không tương thích. Thử 'Recall' để gọi lại kết quả.";
                }
            }
            else
            {
                ipnMessage = string.Format("{0} - {1}", request.responseCode, request.responseMessage);
            }
            log.Debug(string.Format("SubscribeResultTransChange Code: {0} - Message: {1}", request.responseCode, request.responseMessage));
        }
    }
}
