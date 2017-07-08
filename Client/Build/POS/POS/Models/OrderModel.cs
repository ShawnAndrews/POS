using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class OrderModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MenuItem>[] menuOrderLists { get; set; }
        public String Total {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }
        public String Subtotal
        {
            get
            {
                return _subtotal;
            }
            set
            {
                _subtotal = value;
                OnPropertyChanged("Subtotal");
            }
        }
        private String _total { get; set; }
        private String _subtotal { get; set; }

        public OrderModel()
        {

            // default model
            menuOrderLists = new ObservableCollection<MenuItem>[POSConstants.NUM_MENU_ORDER_TYPES];
            for (int i = 0; i < POSConstants.NUM_MENU_ORDER_TYPES; i++)
                menuOrderLists[i] = new ObservableCollection<MenuItem>();
            Total = "$0.00";
            Subtotal = "$0.00";

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
