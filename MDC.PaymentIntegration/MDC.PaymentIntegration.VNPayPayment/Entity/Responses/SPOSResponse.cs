using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment.Entity
{
    public class SPOSResponse : Response
    {
        public DataSPOSResponse data { get; set; }

        public override string psTransactionCode => data.psTransactionCode;
    }

    public class DataSPOSResponse
    {
        public string merchantPartnerCode { get; set; }
        public string psTransactionCode { get; set; }
    }

}
