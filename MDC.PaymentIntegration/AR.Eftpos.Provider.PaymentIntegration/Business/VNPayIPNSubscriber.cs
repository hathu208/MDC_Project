﻿using System;
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
            workerThread.Start();
        }

        public void Stop()
        {
            stopEvent.Set();
            myClient.Unsubscribe();
            myClient.Close();
            log.Info("Stoping subscriber.");
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
                throw new Exception("Subscriber VNPay service đang bị lỗi. Thử 'Recall' để gọi lại kết quả.");
            }
        }

        void IVNPayIPNPublishServiceCallback.SubscribeResultTransChange(IPNRequest request)
        {
            if (request.responseCode == "200")
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
            log.Info(string.Format("SubscribeResultTransChange Code: {0} - Message: {1}", request.responseCode, request.responseMessage));
        }
    }
}
