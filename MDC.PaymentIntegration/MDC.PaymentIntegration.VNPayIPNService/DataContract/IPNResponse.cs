using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MDC.PaymentIntegration.VNPayIPNService
{
    [DataContract]
    public class IPNResponse
    {
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string message { get; set; }
    }
}
