using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    public class Response
    {
        public int code { get; set; }

        public bool success { get; set; }

        public string message { get; set; }

        public ErrorResponse errors { get; set; }

        public virtual string psTransactionCode { get ; }
        public virtual string psResponseCode { get; }
        public virtual string psResponseMessage { get; }

    }
}
