using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MDC.PaymentIntegration.VNPayIPNService
{
    public class PriceChangeEventArgs : EventArgs
    {
        public string Item;
        public double Price;
        public double Change;
    }
    public class VNPayIPNService : IVNPayIPNService
    {
        public static event PriceChangeEventHandler PriceChangeEvent;
        public delegate void PriceChangeEventHandler(object sender, PriceChangeEventArgs e);

        IVNPayIPNClient callback = null;

        PriceChangeEventHandler priceChangeHandler = null;

        //Clients call this service operation to subscribe.  
        //A price change event handler is registered for this client instance.  

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<IVNPayIPNClient>();
            priceChangeHandler = new PriceChangeEventHandler(PriceChangeHandler);
            PriceChangeEvent += priceChangeHandler;
        }

        //Clients call this service operation to unsubscribe.  
        //The previous price change event handler is unregistered.  

        public void Unsubscribe()
        {
            PriceChangeEvent -= priceChangeHandler;
        }

        //Information source clients call this service operation to report a price change.  
        //A price change event is raised. The price change event handlers for each subscriber will execute.  

        public void PublishPriceChange(string item, double price, double change)
        {
            PriceChangeEventArgs e = new PriceChangeEventArgs();
            e.Item = item;
            e.Price = price;
            e.Change = change;
            PriceChangeEvent(this, e);
        }

        //This event handler runs when a PriceChange event is raised.  
        //The client's PriceChange service operation is invoked to provide notification about the price change.  

        public void PriceChangeHandler(object sender, PriceChangeEventArgs e)
        {
            callback.SubscribePriceChange(e.Item, e.Price, e.Change);
        }
    }
}
