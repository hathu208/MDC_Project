using AR.Eftpos.Bus.Extensions;
using AR.Eftpos.Bus.Managers;
using AR.Eftpos.Interface;
using AR.Eftpos.Interface.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public class EftPosX : EftposLoanManager// IEftposLoanProvider, IDisposable
    {
        private string requestMessageID;

        private string vnpayResponseCode;

        public string VnpayResponseCode
        {
            get { return vnpayResponseCode; }
            set { vnpayResponseCode = value; }
        }

        private string vnpayResponseMessage;

        public string VnpayResponseMessage
        {
            get { return vnpayResponseMessage; }
            set { vnpayResponseMessage = value; }
        }


        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        #region EftposTransaction
        /// <summary>
        /// EFTPOS Transaction (debit/credit/cash out transactions)
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <returns>
        /// Response Message
        /// </returns>
        public override TransactionResponseType EftposTransaction(TransactionRequestType request)
        {
            var result = TransactionResultType.Unknown;
            var description = "UNKNOWN";

            var cardNumber = string.Empty;
            var accountType = EftposAccountType.Unknown.DataValueInt16();
            // var cardType = EftposCardType.Unknown.DataValueInt16();
            var cardTypeRaw = string.Empty;
            var eftposTransactionReference = string.Empty;
            var settlementDate = DateTime.Now;
            var discount = (decimal)0;
            var includeAttribs = true;
            var responseAmountOverride = false;

            decimal amount = 0;
            decimal cashBack = 0;

            TransactionResponseType response = new TransactionResponseType(); 

            /*var sb = new StringBuilder();
            sb.AppendLine("EFTPOS Transaction");
            sb.AppendLine(string.Format("\tRequestMessageID: {0}", request.RequestMessageID));
            sb.AppendLine(string.Format("\tTransactionReference: {0}", request.TransactionReference));
            // Transaction Request properties
            if (request.TransactionType == EftposTransactionType.Purchase.DataValueInt16())
            {
                sb.AppendLine("Transaction Type: PURCHASE");
                sb.AppendLine(string.Format("\tAmount: {0}", request.Amount));
                if (request.CashBackSpecified)
                {
                    sb.AppendLine(string.Format("\tCashBack: {0}", request.CashBack));
                }
            }
            else if (request.TransactionType == EftposTransactionType.Refund.DataValueInt16())
            {
                sb.AppendLine("Transaction Type: REFUND");
                sb.AppendLine(string.Format("\tAmount: {0}", request.Amount));
            }
            else
            {
                sb.AppendLine("Transaction Type: NON-SALE");

                // Non sale - customer cash out transaction only
                if (request.CashBackSpecified)
                {
                    sb.AppendLine(string.Format("\tCashBack: {0}", request.CashBack));
                }
            }

            if (request.AllowCreditCardsSpecified)
            {
                // restrict the use of credit cards if the provider supports this feature
                sb.AppendLine(string.Format("\tAllowCreditCards: {0}", request.AllowCreditCards));
            }*/

            try
            {
                if (request.TransactionType == EftposTransactionType.Purchase.DataValueInt16())
                {
                    //// --------------------------------------
                    //// TODO: Perform the EFTPOS Transaction here
                    //// this.eftposComponent.DoTransaction();
                    //// this.LogEftposResponse();
                    //// --------------------------------------
                    // Simulate EFTPOS Transaction
                    using (var dialog = new VNPayPayment())
                    {
                        requestMessageID = request.RequestMessageID;
                        dialog.TransactionType = request.TransactionType.ToString();
                        dialog.EftPosTransactionId = request.TransactionReference;
                        dialog.EftPosOrderId = request.OrderId;
                        dialog.Amount = Convert.ToInt64(request.Amount);

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                        }
                    }
                }
                #endregion EftposTransaction
            }
            catch (Exception ex)
            {
                return (TransactionResponseType)EftposHelper.QuickResponse(request, TransactionResultType.Failed, "DoTransaction - Provider Error, See log for details");
            }

             
            return response;
        }
    }
}
