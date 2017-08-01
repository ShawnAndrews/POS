using POS.POSServiceReference;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS.Services
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class POSClient : IPOSServiceCallback
    {
        public InstanceContext context;
        public POSServiceClient proxy;
        public IEventAggregator eventAggregator { get; set; }

        public POSClient(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            context = new InstanceContext(this);
            proxy = new POSServiceClient(context);

            // attempt to contact service
            try
            {
                // join client list on service
                proxy.Join();

                // publish menu received from service
                eventAggregator.GetEvent<RequestMenuEvent>().Publish(new List<POSSQLMenuItem>(proxy.GetMenu()));

            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("POS service is offline.\n" + "Exception message: " + ex.Message, "Service error");
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Service error");
                Application.Current.Shutdown();
            }

            // listen for orders to be placed
            eventAggregator.GetEvent<PlaceOrderEvent>().Subscribe(SendOrderToService);

            // listen for client disconnection
            eventAggregator.GetEvent<ClientDisconnectionEvent>().Subscribe(SendClientDisconnection);

        }

        /* Send order details to service */
        public void SendOrderToService(POSOrder order)
        {
            // send order info to service
            proxy.SubmitOrder(order);
        }

        /* Send client disconnection notification to service */
        public void SendClientDisconnection(int order)
        {
            // send leave notification to service
            proxy.Leave();

            // close service channel
            proxy.Close();
        }

        /* Send update notification to view-model for number of orders */
        public void NotifyNumOrders(int value)
        {
            // publish event
            eventAggregator.GetEvent<UpdateNumOrdersEvent>().Publish(value);
        }

    }
}
