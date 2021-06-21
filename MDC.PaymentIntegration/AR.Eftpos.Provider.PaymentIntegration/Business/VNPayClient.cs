using MDC.PaymentIntegration.VNPayPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public class VNPayClient
    {
        public static bool InitializeTrans(VNPayPayment formPayment)
        {
            IPayment vnpay = new Payment();
            bool result = false;
            try
            {
                if (formPayment.VNPayMethod == Common.VNPayMethodCode.QRCODE)
                {
                    result = vnpay.genQR(
                        formPayment.EftPosTransactionId,
                        formPayment.EftPosOrderId,
                        formPayment.EftPosOrderId,
                        string.Format("{0} {1}", formPayment.TransactionType, formPayment.EftPosTransactionId),
                        formPayment.Amount,
                        formPayment.VNPayMethod);
                }
                else if (formPayment.VNPayMethod == Common.VNPayMethodCode.SPOSCARD)
                {
                    result = vnpay.sPosTransaction(
                        formPayment.EftPosTransactionId,
                        formPayment.EftPosOrderId,
                        formPayment.EftPosOrderId,
                        string.Format("{0} {1}", formPayment.TransactionType, formPayment.EftPosTransactionId),
                        formPayment.Amount,
                        formPayment.VNPayMethod);
                }
                formPayment.Log.Info((vnpay as Payment).stringRequest);
                formPayment.Log.Info((vnpay as Payment).stringResponse);

                if (result)
                {
                    formPayment.VNPayTransRef = vnpay.APIResponse.psTransactionCode;
                }
                else
                {
                    formPayment.ResponseMessage = string.Format("{0} - {1}", vnpay.APIResponse.errors.code, vnpay.APIResponse.errors.message);
                }
            }
            catch (Exception e)
            {
                result = false;
                formPayment.ResponseMessage = e.Message;
                formPayment.Log.Error("InitializeTrans Failed", e);
            }

            return result;
        }
        public static bool RecallResultTrans(VNPayPayment formPayment)//, out string responseCode, out string responseMessage)
        {
            IPayment payment = new Payment();
            bool result = false;

            try
            {
                result = payment.filterTransaction(formPayment.EftPosTransactionId, formPayment.VNPayTransRef);
                formPayment.Log.Info((payment as Payment).stringResponse);
                if (result)
                {
                    if (payment.APIResponse.psResponseCode != Common.VNPAY_RESPONSE_CODE_SUCCESS)
                        result = false;

                    formPayment.ResponseCode = payment.APIResponse.psResponseCode;
                    formPayment.ResponseMessage = payment.APIResponse.psResponseMessage;
                }
                else
                {
                    formPayment.ResponseMessage = payment.APIResponse.message;
                }
                
            }
            catch(Exception e)
            {
                result = false;
                formPayment.ResponseMessage = e.Message;
                formPayment.Log.Error("RecallResultTrans Failed", e);
            }

            return result;
        }
    }
}
