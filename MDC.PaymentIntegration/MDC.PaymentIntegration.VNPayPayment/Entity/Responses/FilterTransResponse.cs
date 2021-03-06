using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    public class FilterTransResponse : Response
    {
        public DataFilterTransResponse data { get; set; }
        public override string psTransactionCode
        {
            get
            {
                if (data != null)
                {
                    return data.psTransactionCode;
                }
                return null;
            }
        }

        public override string psResponseCode => data.psResponseCode;

        public override string psResponseMessage
        {
            get
            {
                if(string.IsNullOrEmpty(data.psResponseMessage))
                {
                    return string.Format("Code: {0} - {1} {2}", data.code, data.status, data.statusName);
                }
                return data.psResponseMessage;
            }
        }

        public override string status => data.status;

    }

    public class DataFilterTransResponse
    {
        public string psTransactionCode { get; set; }
        public string clientTransactionCode { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public string psResponseCode { get; set; }
        public string psResponseMessage { get; set; }
        public string orderId { get; set; }
        public string orderCode { get; set; }
        public string terminalCode { get; set; }
        public string methodCode { get; set; }
        public string partnerCode { get; set; }
        public int code { get; set; }
        public string statusName { get; set; }
    }

}
