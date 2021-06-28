using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    public class SPOSResponse : Response
    {
        public DataSPOSResponse data { get; set; }

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

    public class DataSPOSResponse
    {
        public string merchantPartnerCode { get; set; }
        public string psTransactionCode { get; set; }
    }

}
