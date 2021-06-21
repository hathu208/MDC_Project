using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    internal class RequestFilterTrans
    {
        [JsonProperty("client_code")]
        public string clientCode { get; set; }

        [JsonProperty("client_transaction_code")]
        public string clientTransactionCode { get; set; }

        [JsonProperty("ps_transaction_code")]
        public string psTransactionCode { get; set; }

        [JsonProperty("checksum")]
        public string checksum { get; set; }
    }

    
}
