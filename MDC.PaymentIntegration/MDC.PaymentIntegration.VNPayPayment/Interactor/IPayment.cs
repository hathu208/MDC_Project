using MDC.PaymentIntegration.VNPayPayment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDC.PaymentIntegration.VNPayPayment
{
    public interface IPayment
    {
        Response APIResponse { get; }
        bool genQR(
            string clientTransCode, 
            string orderId, 
            string orderCode, 
            string orderDescription, 
            long amount, 
            string methodCode,            
            string customerName = null, 
            string language = null);

        bool sPosTransaction(
            string clientTransCode,
            string orderId,
            string orderCode,
            string orderDescription,
            long amount,
            string methodCode,
            string customerName = null,
            string language = null);

    }
}
