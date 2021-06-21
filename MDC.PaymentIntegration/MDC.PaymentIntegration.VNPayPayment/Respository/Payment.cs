using MDC.PaymentIntegration.VNPayPayment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MDC.PaymentIntegration.PaymentIntegration;

namespace MDC.PaymentIntegration.VNPayPayment
{
    public class Payment : IPayment
    {
        public string apiKey;
        public string stringRequest;
        public string stringResponse;
        private Response response;
        public Response APIResponse
        {
            get
            {
                return response;
            }
        }
        public bool genQR(string clientTransCode, string orderId, string orderCode, string orderDescription, long amount, string methodCode, string customerName = null, string language = null)
        {
            PaymentIntegration.Configure.PaymentIntegrationConfig paymentConfig = PaymentIntegration.Configure.PaymentIntegrationConfig.PaymentConfig;

            string apikey = string.Format("{0} {1}", paymentConfig.VNPayPayment.SecretKeyName, paymentConfig.VNPayPayment.SecretKey);
            APIController apiController = new APIController(APIController.APIMethod.POST, paymentConfig.VNPayPayment.MethodGenQR, apikey);

            Request request = new Request();
            request.clientCode = paymentConfig.VNPayPayment.ClientCode;//"PV_ONLINE";
            request.terminalCode = paymentConfig.VNPayPayment.TerminalCode;//"PE1118CC50373";
            request.serviceCode = paymentConfig.VNPayPayment.ServiceCode;//"RETAIL";
            request.clientTransactionCode = clientTransCode;
            request.orderId = orderId;
            request.orderCode = orderCode;
            request.orderDescription = orderDescription;
            request.amount = amount;
            request.methodCode = methodCode;
            request.partnerCode = paymentConfig.VNPayPayment.PartnerCode;

            if (!string.IsNullOrEmpty(customerName) || !string.IsNullOrEmpty(language))
            {
                request.metadata = new MetadataRequest();
                request.metadata.language = language;
                request.metadata.payerName = customerName;
            }

            Checksum checksum = new Checksum();
            request.checksum = checksum.generateCheckSum(request, paymentConfig.VNPayPayment.SecretKey);

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            stringRequest = JsonConvert.SerializeObject(request, Formatting.None, jsonSettings);

            apiController.SendRequest(request);
            stringResponse = apiController.ResponseString;
            response = JsonConvert.DeserializeObject< GenQRResponse>(apiController.ResponseString);
            return response.success;
        }

        public bool sPosTransaction(string clientTransCode, string orderId, string orderCode, string orderDescription, long amount, string methodCode, string customerName = null, string language = null)
        {
            PaymentIntegration.Configure.PaymentIntegrationConfig paymentConfig = PaymentIntegration.Configure.PaymentIntegrationConfig.PaymentConfig;

            string apikey = string.Format("{0} {1}", paymentConfig.VNPayPayment.SecretKeyName, paymentConfig.VNPayPayment.SecretKey);
            APIController apiController = new APIController(APIController.APIMethod.POST, paymentConfig.VNPayPayment.MethodSPOS, apikey);

            Request request = new Request();
            request.clientCode = paymentConfig.VNPayPayment.ClientCode;//"PV_ONLINE";
            request.terminalCode = paymentConfig.VNPayPayment.TerminalCode;//"PE1118CC50373";
            request.serviceCode = paymentConfig.VNPayPayment.ServiceCode;//"RETAIL";
            request.clientTransactionCode = clientTransCode;
            request.orderId = orderId;
            request.orderCode = orderCode;
            request.orderDescription = orderDescription;
            request.amount = amount;
            request.methodCode = methodCode;
            request.partnerCode = paymentConfig.VNPayPayment.PartnerCode;

            if (!string.IsNullOrEmpty(customerName) || !string.IsNullOrEmpty(language))
            {
                request.metadata = new MetadataRequest();
                request.metadata.language = language;
                request.metadata.payerName = customerName;
            }

            Checksum checksum = new Checksum();
            request.checksum = checksum.generateCheckSum(request, paymentConfig.VNPayPayment.SecretKey);

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            stringRequest = JsonConvert.SerializeObject(request, Formatting.None, jsonSettings);

            apiController.SendRequest(request);
            response = JsonConvert.DeserializeObject<SPOSResponse>(apiController.ResponseString);
            stringResponse = apiController.ResponseString;
            return response.success;
        }

        public bool filterTransaction(string clientTransCode, string psTransactionCode)
        {
            PaymentIntegration.Configure.PaymentIntegrationConfig paymentConfig = PaymentIntegration.Configure.PaymentIntegrationConfig.PaymentConfig;

            string url = paymentConfig.VNPayPayment.MethodFilterTrans;
            string apikey = string.Format("{0} {1}", paymentConfig.VNPayPayment.SecretKeyName, paymentConfig.VNPayPayment.SecretKey);

            RequestFilterTrans request = new RequestFilterTrans();
            request.clientCode = paymentConfig.VNPayPayment.ClientCode;
            request.psTransactionCode = psTransactionCode;
            request.clientTransactionCode = clientTransCode;

            url += "?client_code=" + paymentConfig.VNPayPayment.ClientCode;
            url += "&client_transaction_code=" + clientTransCode;
            if (psTransactionCode != "")
            {
                url += "&ps_transaction_code=" + psTransactionCode;
            }


            Checksum checksum = new Checksum();
            string strChecksum = checksum.generateCheckSum(request, paymentConfig.VNPayPayment.SecretKey);
            url += "&checksum=" + strChecksum;

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            APIController apiController = new APIController(APIController.APIMethod.GET, url, apikey);

            apiController.SendRequest();
            stringResponse = apiController.ResponseString;
            response = JsonConvert.DeserializeObject<FilterTransResponse>(apiController.ResponseString);
            return response.success;
        }

    }
}
