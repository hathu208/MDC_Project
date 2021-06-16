using AR.Eftpos.Provider.PaymentIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AR.Eftpos.Provider.VNPaySPos
{
    public class EftPosSPos : EftPosX
    {
        public EftPosSPos() : base()
        {
            this.VNPayMethod = Common.VNPayMethodCode.SPOSCARD;
        }

    }
}
