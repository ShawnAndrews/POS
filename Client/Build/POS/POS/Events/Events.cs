using POS.POSServiceReference;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    /* Event to add a menu item to order */
    public class AddItemToOrderEvent : PubSubEvent<MenuItem>
    {

    }

    /* Event to add a menu item to order */
    public class UpdateNumOrdersEvent : PubSubEvent<int>
    {

    }

    /* Event for placing an order */
    public class PlaceOrderEvent : PubSubEvent<POSOrder>
    {

    }

    /* Event for requesting menu */
    public class RequestMenuEvent : PubSubEvent<List<POSSQLMenuItem>>
    {

    }

    /* Event for client disconnection */
    public class ClientDisconnectionEvent : PubSubEvent<int>
    {

    }

}
