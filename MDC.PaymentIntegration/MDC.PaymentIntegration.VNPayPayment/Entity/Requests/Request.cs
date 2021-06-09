using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    internal class Request
    {
        public string clientCode { get; set; }
        public string terminalCode { get; set; }
        public string serviceCode { get; set; }
        public string clientTransactionCode { get; set; }
        public string orderId { get; set; }
        public string orderCode { get; set; }
        public string orderDescription { get; set; }
        public long amount { get; set; }
        public string methodCode { get; set; }
        public string partnerCode { get; set; }
        public string checksum { get; set; }
        /*public string locale { get; set; }
        public long grandTotal { get; set; }*/
        public MetadataRequest metadata { get; set; }

    }

    
}
