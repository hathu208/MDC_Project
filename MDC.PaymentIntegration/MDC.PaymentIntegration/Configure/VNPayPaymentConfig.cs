using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.PaymentIntegration.Configure
{
    public class VNPayPaymentConfig
    {
        private string methodGenQR = "";

        public string MethodGenQR
        {
            get { return methodGenQR; }
            set { methodGenQR = value; }
        }

        private string methodSpos = "";

        public string MethodSPOS
        {
            get { return methodSpos; }
            set { methodSpos = value; }
        }
        private string methodFilterTrans = "";

        public string MethodFilterTrans
        {
            get { return methodFilterTrans; }
            set { methodFilterTrans = value; }
        }

        private string clientCode = "";
        public string ClientCode
        {
            get { return clientCode; }
            set { clientCode = value; }
        }

        private string serviceCode = "RETAIL";

        public string ServiceCode
        {
            get { return serviceCode; }
            set { serviceCode = value; }
        }

        private string partnerCode = "VNPay";

        public string PartnerCode
        {
            get { return partnerCode; }
            set { partnerCode = value; }
        }

        private string terminalCode = "";

        public string TerminalCode
        {
            get { return terminalCode; }
            set { terminalCode = value; }
        }

        private string secretKeyName = "";

        public string SecretKeyName
        {
            get { return secretKeyName; }
            set { secretKeyName = value; }
        }

        private string secretKey = "";

        public string SecretKey
        {
            get { return secretKey; }
            set { secretKey = value; }
        }

        


    }
}
