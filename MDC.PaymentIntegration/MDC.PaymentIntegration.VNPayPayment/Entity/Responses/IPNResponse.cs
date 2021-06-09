using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    internal class IPNResponse
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}
