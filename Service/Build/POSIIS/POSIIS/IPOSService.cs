using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace POSServiceNS
{

    [ServiceContract(CallbackContract = typeof(IPOSServiceCallback), SessionMode = SessionMode.Required)]
    public interface IPOSService
    {
        [OperationContract(IsOneWay = true)]
        void SubmitOrder(POSOrder order);

        [OperationContract(IsOneWay = true)]
        void Join();

        [OperationContract(IsOneWay = true)]
        void Leave();

    }

    public interface IPOSServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyNumOrders(int value);
    }

    [DataContract]
    public class POSOrder
    {
        [DataMember]
        public List<POSMenuItem> menuItems { get; set; }

        [DataMember]
        public float SubTotal { get; set; }

        [DataMember]
        public float Total { get; set; }
    }

    [DataContract]
    public class POSMenuItem
    {

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string Product { get; set; }

        [DataMember]
        public string Price { get; set; }

        [DataMember]
        public POSMenuItemEnum ProductType { get; set; }

    }

    [DataContract]
    public enum POSMenuItemEnum
    {
        [EnumMember]
        Drinks,
        [EnumMember]
        Sandwiches,
        [EnumMember]
        Hamburgers,
        [EnumMember]
        Deserts
    }

}
