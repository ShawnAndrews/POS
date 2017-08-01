using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSServiceNS
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class POSServiceAPI : IPOSServiceAPI
    {

        public POSServiceAPI()
        {
            
        }

        /* Return all menu items in XML format */
        public string GetMenu()
        {
            // return menu data in XML format
            return ConvertToXML<List<POSSQLMenuItem>>(sqlReceiveMenu());
        }

        /* Return all orders in XML format */
        public string GetAllOrders()
        {
            // return order data in XML format
            return ConvertToXML<List<POSSQLOrder>>(sqlReceiveAllOrders());
        }

        /* Convert object to XML string */
        private string ConvertToXML<T>(T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

        /* Get menu from database and return this data in XML format */
        private List<POSSQLMenuItem> sqlReceiveMenu()
        {
            List<POSSQLMenuItem> listOfMenuItems = new List<POSSQLMenuItem>();
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
                lSQLCmd.CommandType = CommandType.Text;
                lSQLCmd.CommandText = "SELECT COUNT(*) FROM dbo.menuitems";
                lSQLCmd.Connection = lSQLConn;

                // get num of rows
                int numOfRows = (int)lSQLCmd.ExecuteScalar();

                // return if empty result
                if (numOfRows == -1)
                    return null;

                // iterate all rows
                lSQLCmd.CommandText = "SELECT * FROM dbo.menuitems";
                SqlDataReader reader = lSQLCmd.ExecuteReader();
                for (int i = 0; i < numOfRows; i++)
                {
                    POSSQLMenuItem order = new POSSQLMenuItem();

                    // read next row
                    reader.Read();

                    // read columns into order
                    order.ListIndex = (int)reader["ListIndex"];
                    order.Product = (string)reader["Product"];
                    order.Price = (string)reader["Price"];
                    order.ProductType = (string)reader["ProductType"];

                    // add order to list
                    listOfMenuItems.Add(order);

                }

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

            return listOfMenuItems;

        }

        /* Get all orders from database and return this data in XML format */
        private List<POSSQLOrder> sqlReceiveAllOrders()
        {
            List<POSSQLOrder> listOfOrders = new List<POSSQLOrder>();
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
                lSQLCmd.CommandType = CommandType.Text;
                lSQLCmd.CommandText = "SELECT COUNT(*) FROM dbo.orders";
                lSQLCmd.Connection = lSQLConn;

                // get num of rows
                int numOfRows = (int) lSQLCmd.ExecuteScalar();

                // return if empty result
                if (numOfRows == -1)
                    return null;

                // iterate all rows
                lSQLCmd.CommandText = "SELECT * FROM dbo.orders";
                SqlDataReader reader = lSQLCmd.ExecuteReader();
                for (int i = 0; i < numOfRows; i++)
                {
                    POSSQLOrder order = new POSSQLOrder();

                    // read next row
                    reader.Read();

                    // read columns into order
                    order.Prices = (string) reader["Prices"];
                    order.Products = (string) reader["Products"];
                    order.ProductTypes = (string) reader["ProductTypes"];
                    order.Quantities = (string) reader["Quantities"];
                    order.Subtotal = (float) (double) reader["Subtotal"];
                    order.Total = (float) (double) reader["Total"];
                    order.Date = (DateTime) reader["Date"];

                    // add order to list
                    listOfOrders.Add(order);

                }

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

            return listOfOrders;

        }

    }

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

        /* Send menu to client */
        public List<POSSQLMenuItem> GetMenu()
        {
            List<POSSQLMenuItem> menu = new List<POSSQLMenuItem>();
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
                lSQLCmd.CommandType = CommandType.Text;
                lSQLCmd.CommandText = "SELECT COUNT(*) FROM dbo.menuitems";
                lSQLCmd.Connection = lSQLConn;

                // get num of rows
                int numOfRows = (int)lSQLCmd.ExecuteScalar();

                // return if empty result
                if (numOfRows == -1)
                    return null;

                // iterate all rows
                lSQLCmd.CommandText = "SELECT * FROM dbo.menuitems";
                SqlDataReader reader = lSQLCmd.ExecuteReader();
                for (int i = 0; i < numOfRows; i++)
                {
                    POSSQLMenuItem order = new POSSQLMenuItem();

                    // read next row
                    reader.Read();

                    // read columns into order
                    order.ListIndex = (int)reader["ListIndex"];
                    order.Product = (string)reader["Product"];
                    order.Price = (string)reader["Price"];
                    order.ProductType = (string)reader["ProductType"];

                    // add order to list
                    menu.Add(order);

                }

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

            // return menu
            return menu;

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
