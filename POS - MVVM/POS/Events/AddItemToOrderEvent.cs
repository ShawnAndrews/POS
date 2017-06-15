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
}
