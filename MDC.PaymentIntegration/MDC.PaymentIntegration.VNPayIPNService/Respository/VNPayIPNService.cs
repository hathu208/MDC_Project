using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MDC.PaymentIntegration.VNPayIPNService
{
    public class ResultTransChangeEvent : EventArgs
    {
        public IPNRequest request;
    }
    public class VNPayIPNService : IVNPayIPNService, IVNPayIPNPublishService, IVNPayIPNPublishServiceCallback
    {
        public static event ResultTransChangeEventHandler ResultTransChangeEvent;
        public delegate void ResultTransChangeEventHandler(object sender, ResultTransChangeEvent e);

        IVNPayIPNClient callback = null;

        ResultTransChangeEventHandler resultTransChangeHandler = null;

        //Clients call this service operation to subscribe.  
        //A price change event handler is registered for this client instance.  

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<IVNPayIPNClient>();
            resultTransChangeHandler = new ResultTransChangeEventHandler(ResultTransChangeHandler);
            ResultTransChangeEvent += resultTransChangeHandler;
        }

        //Clients call this service operation to unsubscribe.  
        //The previous price change event handler is unregistered.  

        public void Unsubscribe()
        {
            ResultTransChangeEvent -= resultTransChangeHandler;
        }

        //Information source clients call this service operation to report a price change.  
        //A price change event is raised. The price change event handlers for each subscriber will execute.  

        public IPNResponse ResultTransChange(IPNRequest request)
        {
            IPNResponse response = new IPNResponse();
            try
            {
                ResultTransChangeEvent e = new ResultTransChangeEvent();
                e.request = request;
                ResultTransChangeEvent(this, e);
                response.code = request.responseCode;
                response.message = request.responseMessage;
            }
            catch(Exception e)
            {
                response.code = "499";
                response.message = e.Message;
            }

            return response;
        }

        //This event handler runs when a PriceChange event is raised.  
        //The client's PriceChange service operation is invoked to provide notification about the price change.  

        public void ResultTransChangeHandler(object sender, ResultTransChangeEvent e)
        {
            callback.SubscribeResultTransChange(e.request);
        }

        public IPNResponse GetResultTrans(IPNRequest request)
        {
            VNPayIPNPublishServiceClient myClient = null;
            IPNResponse result = new IPNResponse();

            try
            {
                InstanceContext siteHostContext = new InstanceContext(null, new VNPayIPNService());
                myClient = new VNPayIPNPublishServiceClient(siteHostContext);

                result = myClient.ResultTransChange(request);


                //Closing the client gracefully closes the connection and cleans up resources
                myClient.Close();

                result.code = request.responseCode;
                result.message = request.responseMessage;
            }
            catch (FaultException e)
            {
                myClient.Abort();
                result.code = "999";
                result.message = e.Message;
            }
            catch (Exception e)
            {
                myClient.Abort();
                result.code = "999";
                result.message = e.Message;
            }

            return result;
        }

        public void SubscribeResultTransChange(IPNRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
