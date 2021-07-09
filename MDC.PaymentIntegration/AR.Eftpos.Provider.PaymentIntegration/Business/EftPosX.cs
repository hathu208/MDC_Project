using AR.Eftpos.Bus.Extensions;
using AR.Eftpos.Bus.Managers;
using AR.Eftpos.Interface;
using AR.Eftpos.Interface.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static AR.Eftpos.Provider.PaymentIntegration.Common;

namespace AR.Eftpos.Provider.PaymentIntegration
{
    public class EftPosX : EftposLoanManager// IEftposLoanProvider, IDisposable
    {
        private string requestMessageID;

        private string vNPayMethod;

        public string VNPayMethod
        {
            get { return vNPayMethod; }
            set { vNPayMethod = value; }
        }

        /// <summary>
        /// log4net - Logger
        /// </summary>
        private log4net.ILog log;

        public EftPosX() : base()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.log = log4net.LogManager.GetLogger(typeof(EftPosX).Name);
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
                    if (vNPayMethod == Common.VNPayMethodCode.QRCODE || vNPayMethod == Common.VNPayMethodCode.SPOSCARD)
                    {
                        using (var dialog = new VNPayPayment())
                        {
                            requestMessageID = request.RequestMessageID;
                            dialog.VNPayMethod = this.vNPayMethod;
                            dialog.TransactionType = request.TransactionType.ToString();
                            dialog.TransactionRef = request.TransactionReference;
                            dialog.TransactionId = this.Basket.TransactionNumber.ToString();
                            dialog.PosWrkStationNo = this.Basket.WorkstationNo.ToString();
                            dialog.PosBranchNo = this.Basket.BranchNo.ToString();
                            dialog.Amount = Convert.ToInt64(request.Amount);

                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                if (dialog.ResponseCode == Common.VNPAY_FILTER_RESPONSE_CODE_SUCCESS || dialog.IsManualUpdate)
                                    result = TransactionResultType.Success;
                                else
                                    result = TransactionResultType.Failed;

                                log.Info("EftposTransaction success - " + dialog.ResponseMessage);

                                response = (TransactionResponseType)EftposHelper.QuickResponse(request, result, dialog.ResponseMessage);
                                response.RequestMessageID = this.requestMessageID;
                                //response.CardTypeRaw = dialog.Subscriber.ipnCardType;
                                response.EftposTransactionReference = dialog.TransactionRef;
                                response.Amount = request.Amount;
                                response.Attributes = new List<AttributeType>()
                            {
                                new AttributeType()
                                {
                                    Name = "ManualComplete",
                                    Value = dialog.IsManualUpdate.ToString()
                                },
                                new AttributeType()
                                {
                                    Name = "VnpayTransactionCode",
                                    Value = dialog.VNPayTransRef
                                }
                            }.ToArray();
                            }
                            else
                            {
                                log.Error("EftposTransaction - Process with VNPay is failed.");
                                response = (TransactionResponseType)EftposHelper.QuickResponse(request, TransactionResultType.Failed, "Process with VNPay is failed.");
                            }
                        }
                    }
                }
                #endregion EftposTransaction
            }
            catch (Exception ex)
            {
                log.Error("EftposTransaction Failed", ex);
                return (TransactionResponseType)EftposHelper.QuickResponse(request, TransactionResultType.Failed, "DoTransaction - Provider Error, See log for details");
            }

             
            return response;
        }

        public override void Dispose()
        {
            this.log.Info(new String('=', 100));
        }
    }
}
