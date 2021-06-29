using AR.Eftpos.Provider.PaymentIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public class EftPosQRCode : EftPosX
    {
        public EftPosQRCode() : base()
        {
            this.VNPayMethod = Common.VNPayMethodCode.QRCODE;
        }
    }
}
