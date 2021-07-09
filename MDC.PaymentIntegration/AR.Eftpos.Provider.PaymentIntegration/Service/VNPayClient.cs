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
                        formPayment.TransactionRef,
                        formPayment.TransactionId,
                        formPayment.TransactionRef,
                        string.Format("Workstation {0} - Branch {1}", formPayment.PosWrkStationNo, formPayment.PosBranchNo),
                        formPayment.Amount,
                        formPayment.VNPayMethod);
                }
                else if (formPayment.VNPayMethod == Common.VNPayMethodCode.SPOSCARD)
                {
                    result = vnpay.sPosTransaction(
                        formPayment.TransactionRef,
                        formPayment.TransactionId,
                        formPayment.TransactionRef,
                        string.Format("Workstation {0} - Branch {1}", formPayment.PosWrkStationNo, formPayment.PosBranchNo),
                        formPayment.Amount,
                        formPayment.VNPayMethod);
                }
                formPayment.Log.Info("Init request: " + (vnpay as Payment).stringRequest);
                formPayment.Log.Info("Init response: " + (vnpay as Payment).stringResponse);

                if (result)
                {
                    formPayment.VNPayTransRef = vnpay.APIResponse.psTransactionCode;
                }
                else
                {
                    if(vnpay.APIResponse.errors != null)
                        formPayment.ResponseMessage = string.Format("{0} - {1}", vnpay.APIResponse.errors.code, vnpay.APIResponse.errors.message);
                    else
                        formPayment.ResponseMessage = string.Format("{0} - {1}", vnpay.APIResponse.code, vnpay.APIResponse.message);
                }
            }
            catch (Exception e)
            {
                result = false;
                formPayment.ResponseMessage = "Call service initializing transaction is failed.";
                formPayment.Log.Error("InitializeTrans Failed", e);
            }

            return result;
        }
        public static bool GetResultTrans(VNPayPayment formPayment)//, out string responseCode, out string responseMessage)
        {
            IPayment payment = new Payment();
            bool result = false;

            try
            {
                result = payment.filterTransaction(formPayment.TransactionRef, formPayment.VNPayTransRef);
                formPayment.Log.Info("Get result response: " + (payment as Payment).stringResponse);
                if (result)
                {
                    formPayment.ResponseCode = payment.APIResponse.psResponseCode;
                    formPayment.ResponseMessage = payment.APIResponse.psResponseMessage;
                    formPayment.ResponseStatus = payment.APIResponse.status;
                }
                else
                {
                    formPayment.ResponseMessage = payment.APIResponse.message;
                }

            }
            catch (Exception e)
            {
                result = false;
                formPayment.ResponseMessage = "Call service get result is failed.";
                formPayment.Log.Error("GetResultTrans Failed", e);
            }

            return result;
        }
    }
}
