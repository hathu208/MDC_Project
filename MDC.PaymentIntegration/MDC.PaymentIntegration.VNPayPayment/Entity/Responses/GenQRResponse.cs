using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    public class GenQRResponse : Response
    {
        public DataGenQRResponse data { get; set; }
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
    }

    public class DataGenQRResponse
    {
        public string qrcontent { get; set; }
        public string message { get; set; }
        public string psTransactionCode { get; set; }
    }
}
