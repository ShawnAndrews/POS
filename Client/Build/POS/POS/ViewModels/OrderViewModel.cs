using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.Globalization;
using System.Windows;
using Prism.Events;
using Prism.Commands;
using POS.POSServiceReference;

namespace POS
{

    public class OrderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<Object> removeOrderItemBtnICommand { get; private set; }
        public DelegateCommand<Object> takeOrderBtnICommand { get; private set; }
        public DelegateCommand<Object> selectedItemChangedICommand { get; private set; }
        public DelegateCommand<Object> mouseMoveICommand { get; private set; }
        public DelegateCommand<Object> exitApplicationICommand { get; private set; }
        public DelegateCommand<Object> dialogBoxAcceptICommand { get; private set; }
        public DelegateCommand<Object> dialogBoxRejectICommand { get; private set; }
        public int[] menuOrderListsSelectedIndex { get; private set; }
        public Visibility takeOrderGrayOverlay { get; private set; }
        public String numOrders { get { return _numOrders + " orders"; } }
        private int _numOrders { get; set; }
        private int selectedOrderListBox { get; set; }
        private int selectedOrderListBoxItem { get; set; }
        private Point oldMousePosition { get; set; }
        private OrderModel orderModel { get; set; }
        private IEventAggregator eventAggregator { get; set; }

        public OrderViewModel(IEventAggregator eventAggregator)
        {

            // set prism's event aggregator
            this.eventAggregator = eventAggregator;

            // listen for menu's request to add items to list
            eventAggregator.GetEvent<AddItemToOrderEvent>().Subscribe(AddMenuItem);

            // listen for service's change in number of orders
            eventAggregator.GetEvent<UpdateNumOrdersEvent>().Subscribe(UpdateNumOrders);

            // set ICommands
            removeOrderItemBtnICommand = new DelegateCommand<Object>(RemoveOrderItemBtnExecute, RemoveOrderItemBtnCanExecute);
            takeOrderBtnICommand = new DelegateCommand<Object>(TakeOrderBtnExecute);
            selectedItemChangedICommand = new DelegateCommand<Object>(SelectedOrderItemChangedExecute);
            mouseMoveICommand = new DelegateCommand<Object>(MouseMoveOrderExecute);
            exitApplicationICommand = new DelegateCommand<Object>(ExitApplicationExecute);
            dialogBoxAcceptICommand = new DelegateCommand<Object>(DialogBoxAcceptExecute);
            dialogBoxRejectICommand = new DelegateCommand<Object>(DialogBoxRejectExecute);

            // set default selected list items
            menuOrderListsSelectedIndex = new int[POSConstants.NUM_MENU_ORDER_TYPES];
            for (int i = 0; i < POSConstants.NUM_MENU_ORDER_TYPES; i++)
                menuOrderListsSelectedIndex[i] = -1;
            
            // hide overlay
            takeOrderGrayOverlay = Visibility.Hidden;

            // set old mouse position
            oldMousePosition = new Point(0,0);

            // create empty order
            orderModel = new OrderModel();

            // set default number of orders
            _numOrders = 0;

            // recieve property changed notifications from model
            orderModel.PropertyChanged += new PropertyChangedEventHandler(modelPropertyChanged);

        }

        /* Exit application peacefully */
        private void ExitApplicationExecute(object parameter)
        {

            // notify service of client disconnection
            eventAggregator.GetEvent<ClientDisconnectionEvent>().Publish(0);

            // exit application
            Application.Current.Shutdown();

        }

        /* Update the number of orders received from service */
        private void UpdateNumOrders(int _numOrders) 
        {
            this._numOrders = _numOrders;
            OnPropertyChanged("numOrders");
        }

        /* Add a given menu item to order list */
        private void AddMenuItem(MenuItem item)
        {
            bool itemFoundInList = false;
            ObservableCollection<MenuItem> listToAddItem = null;

            // find appropriate order list of menu item under which to add
            if (item.ProductType == menuItemType.Drinks)
                listToAddItem = menuOrderLists[0];
            else if (item.ProductType == menuItemType.Sandwiches)
                listToAddItem = menuOrderLists[1];
            else if (item.ProductType == menuItemType.Hamburgers)
                listToAddItem = menuOrderLists[2];
            else if (item.ProductType == menuItemType.Deserts)
                listToAddItem = menuOrderLists[3];
            
            // if item is already in list, update quantity
            for (int i = 0; i < POSConstants.NUM_MENU_ORDER_TYPES; i++)
            {
                for (int j = 0; j < menuOrderLists[i].Count; j++)
                {
                    if (menuOrderLists[i][j].Product.Equals(item.Product))
                    {
                        menuOrderLists[i][j].Quantity++;
                        itemFoundInList = true;
                    }
                }
            }

            // if item not in list, add to list
            if (!itemFoundInList)
                listToAddItem.Add(item);

            // recalculate new order price
            calcOrderPrice();

        }

        /* On model's property changed, propogate notification to viewmodel to notify view */
        public void modelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        /* Order model property delegates */
        public ObservableCollection<MenuItem>[] menuOrderLists
        {
            get { return orderModel.menuOrderLists; }
            set { orderModel.menuOrderLists = value; }
        }
        public string Subtotal
        {
            get { return orderModel.Subtotal; }
            set { orderModel.Subtotal = value; }
        }
        public string Total
        {
            get { return orderModel.Total; }
            set { orderModel.Total = value; }
        }

        /* On order mouse movement, track mouse delta position to scroll order panel vertically */
        private void MouseMoveOrderExecute(object parameter)
        {
            var values = (object[])parameter;

            ScrollViewer sv = values[0] as ScrollViewer;
            StackPanel sp = values[1] as StackPanel;

            // get current mouse position within stackpanel
            Point newMousePosition = Mouse.GetPosition(sp);

            // if either mouse button is presssed
            if ((Mouse.LeftButton == MouseButtonState.Pressed) || (Mouse.RightButton == MouseButtonState.Pressed))
            {
                // scroll order up or down 
                if (newMousePosition.Y < oldMousePosition.Y)
                    sv.ScrollToVerticalOffset(sv.VerticalOffset + 1);
                if (newMousePosition.Y > oldMousePosition.Y)
                    sv.ScrollToVerticalOffset(sv.VerticalOffset - 1);
            }                  
            else
            {
                oldMousePosition = newMousePosition;
            }
        }

        /* On change of selected order item, update selected item flags */
        void SelectedOrderItemChangedExecute(object parameter)
        {
            var values = (object[])parameter;

            // unpack parameters
            selectedOrderListBox = (Int32)values[0];
            selectedOrderListBoxItem = (int)values[1];

            // reset selected item on all order lists
            for (int i = 0; i < POSConstants.NUM_MENU_ORDER_TYPES; i++)
                menuOrderListsSelectedIndex[i] = -1;

            // set selected item
            menuOrderListsSelectedIndex[selectedOrderListBox] = selectedOrderListBoxItem;

            // update selected items
            OnPropertyChanged("menuOrderListsSelectedIndex");

            // recheck if an item in order is selected
            removeOrderItemBtnICommand.RaiseCanExecuteChanged();

        }

        /* Check if an item is selected in any order list */
        private bool RemoveOrderItemBtnCanExecute(object parameter)
        {
            bool anyItemSelected = false;

            // determine if an item is selected in order
            for (int i = 0; i < POSConstants.NUM_MENU_ORDER_TYPES; i++)
                if (menuOrderListsSelectedIndex[i] != -1)
                    anyItemSelected = true;

            return anyItemSelected;
        }

        /* Remove item from order list and update order price accordingly */
        private void RemoveOrderItemBtnExecute(object parameter)
        {
            MenuItem selectedItem = null;

            // exit if selection not found, else find selected item in order list
            if (selectedOrderListBox == -1)
                return;
            else
                selectedItem = orderModel.menuOrderLists[selectedOrderListBox][selectedOrderListBoxItem];

            // clone index and item
            Debug.Assert(selectedOrderListBox >= 0 && selectedOrderListBox < orderModel.menuOrderLists.Length);
            int prevIndex = orderModel.menuOrderLists[selectedOrderListBox].IndexOf(selectedItem);
            MenuItem clonedItem = selectedItem;

            // remove item
            Debug.Assert(prevIndex >= 0 && prevIndex < orderModel.menuOrderLists[selectedOrderListBox].Count);
            orderModel.menuOrderLists[selectedOrderListBox].RemoveAt(prevIndex);

            // remove item  last quantity in list, else reduce quantity
            if (clonedItem.Quantity != 1)
            {
                // add item back with decremented quantity
                clonedItem.Quantity = clonedItem.Quantity - 1;

                // insert at original position in list
                orderModel.menuOrderLists[selectedOrderListBox].Insert(prevIndex, clonedItem);

            }

            // recalculate new order price
            calcOrderPrice();

        }

        /* Show confirmation screen overlay */
        private void TakeOrderBtnExecute(object parameter)
        {
            // show gray overlay
            takeOrderGrayOverlay = Visibility.Visible;
            OnPropertyChanged("takeOrderGrayOverlay");

        }

        /* Send order to kitchen and subsequently clear order data */
        private void DialogBoxAcceptExecute(object parameter)
        {

            POSOrder order = new POSOrder();
            int numOfOrderItems = 0;
            int iterationCounter = 0;

            // prepare order for submission to service
            for (int i = 0; i < Enum.GetNames(typeof(menuItemType)).Length; i++)
                foreach (MenuItem item in menuOrderLists[i])
                    numOfOrderItems++;
            order.menuItems = new POSMenuItem[numOfOrderItems];
            for (int i = 0; i < Enum.GetNames(typeof(menuItemType)).Length; i++)
            {
                for (int j = 0; j < menuOrderLists[i].Count; j++)
                {
                    POSMenuItem item = new POSMenuItem();
                    item.Price = menuOrderLists[i][j].Price;
                    item.Product = menuOrderLists[i][j].Product;
                    item.ProductType = (POSMenuItemEnum)menuOrderLists[i][j].ProductType;
                    item.Quantity = menuOrderLists[i][j].Quantity;
                    order.menuItems[iterationCounter++] = item;
                }
            }
            order.SubTotal = float.Parse(Subtotal.Substring(1, Subtotal.Length - 1), CultureInfo.InvariantCulture.NumberFormat);
            order.Total = float.Parse(Total.Substring(1, Total.Length - 1), CultureInfo.InvariantCulture.NumberFormat);

            // send order information to service
            eventAggregator.GetEvent<PlaceOrderEvent>().Publish(order);

            // delete all items in current order
            foreach (ObservableCollection<MenuItem> list in orderModel.menuOrderLists)
                list.Clear();

            // reset selected indices
            for (int i = 0; i < POSConstants.NUM_MENU_ORDER_TYPES; i++)
                menuOrderListsSelectedIndex[i] = -1;

            // recalculate new order price
            calcOrderPrice();

            // increment number of orders
            incrementOrder();

            // recheck order data
            removeOrderItemBtnICommand.RaiseCanExecuteChanged();

            // hide gray overlay
            takeOrderGrayOverlay = Visibility.Hidden;
            OnPropertyChanged("takeOrderGrayOverlay");

        }

        /* Do nothing and exit confirmation overlay screen */
        private void DialogBoxRejectExecute(object parameter)
        {
            // hide gray overlay
            takeOrderGrayOverlay = Visibility.Hidden;
            OnPropertyChanged("takeOrderGrayOverlay");
        }

        /* Increase order count by one */
        public void incrementOrder()
        {
            _numOrders = _numOrders + 1;
            OnPropertyChanged("numOrders");
        }

        /* Recalculate current order price */
        public void calcOrderPrice()
        {
            double tax = POSConstants.TAX_RATE;
            double subtotalInt = 0;
            double totalInt = 0;

            // for all order list categories
            foreach (ObservableCollection<MenuItem> list in orderModel.menuOrderLists)
                foreach (MenuItem item in list)
                    subtotalInt += item.Quantity * Convert.ToDouble(item.Price.Substring(1, item.Price.Length - 1));

            // set total
            totalInt = subtotalInt * tax;

            // round to two decimal places
            subtotalInt = Math.Round(subtotalInt, 2);
            totalInt = Math.Round(totalInt, 2);

            // convert double->string
            orderModel.Subtotal = "$" + subtotalInt.ToString();
            orderModel.Total = "$" + totalInt.ToString();

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }


}
