﻿using System;
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
    public interface IVNPayIPNService
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();
        [OperationContract(IsOneWay = true)]
        void PublishPriceChange(string item, double price,
                                         double change);
    }

    public interface IVNPayIPNClient
    {
        [OperationContract(IsOneWay = true)]
        void SubscribePriceChange(string item, double price, double change);
    }

  
}
