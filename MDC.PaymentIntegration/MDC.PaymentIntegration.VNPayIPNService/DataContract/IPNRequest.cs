using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MDC.PaymentIntegration.VNPayIPNService
{
    [DataContract]
    public class IPNRequest
    {
        [DataMember]
        public string clientCode { get; set; }
        [DataMember]
        public string terminalCode { get; set; }
        [DataMember]
        public string serviceCode { get; set; }
        [DataMember]
        public string clientTransactionCode { get; set; }
        [DataMember]
        public string orderId { get; set; }
        [DataMember]
        public string orderCode { get; set; }
        [DataMember]
        public string orderDescription { get; set; }
        [DataMember]
        public long amount { get; set; }
        [DataMember]
        public string methodCode { get; set; }
        [DataMember]
        public string partnerCode { get; set; }
        [DataMember]
        public string checksum { get; set; }
        [DataMember]
        public string merchantCode { get; set; }
        [DataMember]
        public string orderInfor { get; set; }
        [DataMember]
        public string psTransactionCode { get; set; }
        [DataMember]
        public string partnerTransactionCode { get; set; }
        [DataMember]
        public string clientRequestTime { get; set; }
        [DataMember]
        public string psResponseTime { get; set; }
        [DataMember]
        public string payDate { get; set; }
        [DataMember]
        public string responseCode { get; set; }
        [DataMember]
        public string responseMessage { get; set; }
        [DataMember]
        public string lang { get; set; }
        [DataMember]
        public string cardType { get; set; }
        [DataMember]
        public string bankCode { get; set; }
    }
}
