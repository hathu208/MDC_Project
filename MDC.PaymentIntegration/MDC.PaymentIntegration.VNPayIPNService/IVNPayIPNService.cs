using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MDC.PaymentIntegration.VNPayIPNService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required,
      CallbackContract = typeof(IVNPayIPNClient))]
      //[ServiceContract]
    public interface IVNPayIPNPublishService
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();
        [OperationContract(IsOneWay = false)]
        IPNResponse ResultTransChange(IPNRequest request);
    }

    public interface IVNPayIPNClient
    {
        [OperationContract(IsOneWay = true)]
        void SubscribeResultTransChange(IPNRequest request);
    }

    [ServiceContract]
    public interface IVNPayIPNService
    {
        [OperationContract(IsOneWay = false)]
        [WebInvoke(Method = "POST", UriTemplate = "/spos/result",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        IPNResponse GetResultTrans(IPNRequest request);
    }


}
