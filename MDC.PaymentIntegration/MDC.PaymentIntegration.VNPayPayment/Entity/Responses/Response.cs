using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    public class Response
    {
        public int code { get; }

        public bool success { get; }

        public string message { get; }

        public ErrorResponse errors { get; set; }

        public virtual string psTransactionCode { get ; }
        public virtual string psResponseCode { get; }
        public virtual string psResponseMessage { get; }

    }
}
