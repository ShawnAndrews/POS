using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace POSServiceNS
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class POSService : IPOSService
    {
        List<IPOSServiceCallback> clients;
        int numOrders;

        public POSService()
        {
            // initialize
            numOrders = 0;
            clients = new List<IPOSServiceCallback>();
        }

        /* Join connection to list of callbacks */
        public void Join()
        {

            // add channel to client list
            clients.Add(OperationContext.Current.GetCallbackChannel<IPOSServiceCallback>());

            // update number of orders on all clients
            OperationContext.Current.GetCallbackChannel<IPOSServiceCallback>().NotifyNumOrders(numOrders);

        }

        /* Leave connection from list of callbacks */
        public void Leave()
        {

            // remove client from client list
            clients.Remove(OperationContext.Current.GetCallbackChannel<IPOSServiceCallback>());

        }

        /* Submit an order for database storage */
        public void SubmitOrder(POSOrder order)
        {
            IPOSServiceCallback callback;
            List<string> serializedMenuItems = null;
            float serializedSubtotal = 0;
            float serializedTotal = 0;

            // store order information in database
            serializedMenuItems = SerializeList(order.menuItems);
            serializedSubtotal = order.SubTotal;
            serializedTotal = order.Total;

            //Console.WriteLine("Received order:");
            //Console.WriteLine("Product: {0}\nPrice: {1}\nQuantity: {2}\nProduct Type: {3}", serializedMenuItems[0], serializedMenuItems[1], serializedMenuItems[2], serializedMenuItems[3]);
            //Console.WriteLine("Order subtotal = {0}", serializedSubtotal);
            //Console.WriteLine("Order total = {0}\n", serializedTotal);

            // send order for database storage
            sqlStoreOrder(serializedMenuItems, serializedSubtotal, serializedTotal);

            // increase number of orders
            numOrders++;

            // get callback channel
            callback = OperationContext.Current.GetCallbackChannel<IPOSServiceCallback>();

            // update number of orders on all clients
            foreach (IPOSServiceCallback cb in clients)
                cb.NotifyNumOrders(numOrders);

        }

        /* Serialize order data in a comma-deliminated format suitable for database storage */
        private List<string> SerializeList(List<POSMenuItem> listOfItems)
        {

            const char comma = ',';
            List<string> serializedList = new List<string>();

            // add an element for each menu item property
            serializedList.Add("");
            serializedList.Add("");
            serializedList.Add("");
            serializedList.Add("");

            // concatenate all menu items into a single serialized, comma-deliminated string
            foreach (POSMenuItem item in listOfItems)
            {
                serializedList[0] = serializedList[0] + comma + item.Product + comma;
                serializedList[1] = serializedList[1] + comma + item.Price.Substring(1, item.Price.Length - 1).ToString() + comma;
                serializedList[2] = serializedList[2] + comma + item.Quantity.ToString() + comma;
                serializedList[3] = serializedList[3] + comma + item.ProductType + comma;
            }

            return serializedList;
        }

        /* Call database's stored procedure to store order details */
        private void sqlStoreOrder(List<string> serializedMenuItems, float serializedSubtotal, float serializedTotal)
        {
            SqlConnection lSQLConn = null;
            SqlCommand lSQLCmd = new SqlCommand();
            string connStr = "";

            connStr = ConfigurationManager.ConnectionStrings["POSConnectionString"].ConnectionString;

            // call stored procedure to store order
            try
            {
                // create and open a connection object
                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();

                // prepare procedure's parameters
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "spRecordOrder";
                lSQLCmd.Parameters.Add(new SqlParameter("@Products", serializedMenuItems[0]));
                lSQLCmd.Parameters.Add(new SqlParameter("@Prices", serializedMenuItems[1]));
                lSQLCmd.Parameters.Add(new SqlParameter("@Quantities", serializedMenuItems[2]));
                lSQLCmd.Parameters.Add(new SqlParameter("@ProductTypes", serializedMenuItems[3]));
                lSQLCmd.Parameters.Add(new SqlParameter("@Subtotal", serializedSubtotal));
                lSQLCmd.Parameters.Add(new SqlParameter("@Total", serializedTotal));
                lSQLCmd.Connection = lSQLConn;

                // execute query
                lSQLCmd.ExecuteScalar();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Failed call to SQL Server Procedure. Exception Message: {0}", Ex.Message);
            }
            finally
            {
                lSQLCmd.Dispose();
                lSQLConn.Close();
            }

        }

    }
}
