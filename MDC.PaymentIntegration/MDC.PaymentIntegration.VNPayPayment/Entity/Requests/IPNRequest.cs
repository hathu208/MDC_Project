using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    internal class IPNRequest : Request
    {
        public string merchantCode;
        public string orderInfor;
        public string psTransactionCode;
        public string partnerTransactionCode;
        public string clientRequestTime;
        public string psResponseTime;
        public string payDate;
        public string responseCode;
        public string responseMessage;
        public string lang;
        public string cardType;
        public string bankCode;
    }
}
