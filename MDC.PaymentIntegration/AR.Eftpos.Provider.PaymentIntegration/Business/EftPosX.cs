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

        /// <summary>
        /// log4net - Logger
        /// </summary>
        private log4net.ILog log;

        public EftPosX() : base()
        {
            this.log = log4net.LogManager.GetLogger(typeof(EftPosX));
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
            TransactionResponseType response = new TransactionResponseType(); 

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
                            if (dialog.Subscriber.ipnResponseCode == "200")
                                result = TransactionResultType.Success;
                            else
                                result = TransactionResultType.Failed;

                            response = (TransactionResponseType)EftposHelper.QuickResponse(request, result, dialog.Subscriber.ipnMessage);
                            response.RequestMessageID = this.requestMessageID;
                            response.CardTypeRaw = dialog.Subscriber.ipnCardType;
                            response.EftposTransactionReference = dialog.VNPayTransRef;
                            response.Amount = request.Amount;
                            response.Attributes = new List<AttributeType>()
                            {
                                new AttributeType()
                                {
                                    Name = "BankCode",
                                    Value = dialog.Subscriber.ipnBankCode
                                },
                                new AttributeType()
                                {
                                    Name = "VNPayResponseCode",
                                    Value = dialog.Subscriber.ipnResponseCode
                                }
                            }.ToArray();
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
