using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public static class Common
    {
        public static string VNPAY_RESPONSE_CODE_SUCCESS = "881";
        public enum PaymentType
        {
            VNPAY = 0
        }

        public static class VNPayMethodCode
        {
            public static string CTT = "CTT";
            public static string QRCODE = "QRCODE";
            public static string SPOSCARD = "SPOSCARD";
        }

        public static class VNPayLang
        {
            public static string Vietnamese = "vi";
            public static string English = "en";
        }
    }
}
