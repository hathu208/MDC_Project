using System;
using System.ServiceModel;
using System.Threading;
using MDC.PaymentIntegration.VNPayIPNService;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public class VNPayIPNSubscriber: IVNPayIPNPublishServiceCallback
    {
        private VNPayIPNPublishServiceClient myClient;
        private readonly Thread workerThread;
        private readonly ManualResetEvent stopEvent = new ManualResetEvent(false);
        //private readonly object locker = new object();
        //private readonly Queue<string> queue = new Queue<string>();

        //Result from IPN
        public string ipnCardType;
        public string ipnBankCode;
        public string ipnPsTransactionCode = "";
        public string ipnResponseCode = "";
        public string ipnMessage = "";

        public VNPayIPNSubscriber()
        {
            workerThread = new Thread(ReceiveData);
            workerThread.Start();
        }

        public void Stop()
        {
            stopEvent.Set();
            myClient.Unsubscribe();
            myClient.Close();
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
            // always create an instance context to associate the service with            
            InstanceContext siteHostContext = new InstanceContext(null, this);

            myClient = new VNPayIPNPublishServiceClient(siteHostContext);

            // create a unique callback address (if you want multiple subscribers to run on the same machine)
            WSDualHttpBinding binding = (WSDualHttpBinding)myClient.Endpoint.Binding;
            string uniqueCallbackAddress = binding.ClientBaseAddress.AbsoluteUri;

            uniqueCallbackAddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(uniqueCallbackAddress);

            // Subcribe
            myClient.Subscribe();
        }

        void IVNPayIPNPublishServiceCallback.SubscribeResultTransChange(IPNRequest request)
        {
            if (request.responseCode == "200")
            {
                /*if (ipnrequest.psTransactionCode == this.vnPayTransRef && ipnrequest.clientTransactionCode == this.EftPosTransactionId)
                {
                    ipnCardType = ipnrequest.cardType;
                    ipnBankCode = ipnrequest.bankCode;
                    ipnPsTransactionCode = ipnrequest.psTransactionCode;
                }
                else
                {
                    ipnMessage = "Kết quả trả về không tương thích. Thử 'Recall' để gọi lại kết quả.";
                }*/
                ipnCardType = request.cardType;
                ipnBankCode = request.bankCode;
                ipnPsTransactionCode = request.psTransactionCode;
                ipnResponseCode = request.responseCode;
                ipnMessage = request.responseMessage;
            }
            else
            {
                ipnMessage = string.Format("{0} - {1}", request.responseCode, request.responseMessage);
            }
        }
    }
}
