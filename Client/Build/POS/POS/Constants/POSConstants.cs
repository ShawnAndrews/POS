using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace POS
{
    public enum menuItemType { Drinks, Sandwiches, Hamburgers, Deserts };

    public class MenuItem : INotifyPropertyChanged
    {
        public MenuItem()
        {
            Quantity = 1;
        }
        private int _quantity;
        private string _product;
        private string _price;
        private menuItemType _productType;

        public int Quantity {
            get {
                return _quantity;
            }
            set {
                _quantity = value;
                OnPropertyChanged();
            }
        }
        public string Product {
            get {
                return _product;
            }
            set {
                _product = value;
                OnPropertyChanged();
            }
        }
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
        public menuItemType ProductType {
            get {
                return _productType;
            }
            set {
                _productType = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class multiBindCloneConverter : IMultiValueConverter
    {
        public object Convert(object[] values)
        {
            return values.Clone();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class POSConstants
    {
        public static readonly int NUM_MENU_ORDER_TYPES = 4;
        public static readonly int NUM_MENU_ITEMS_TYPES = 7;
        public static readonly double TAX_RATE = 1.10;

        public static double getScreenWidth
        {
            get { return System.Windows.SystemParameters.PrimaryScreenWidth; }
        }

        public static double getScreenHeight
        {
            get { return System.Windows.SystemParameters.PrimaryScreenHeight; }
        }

        public static double getTitleHeight
        {
            get { return getScreenHeight * 0.1; }
        }

        public static double getTitleLogoHeight
        {
            get { return getTitleHeight * 0.9; }
        }

        public static double getTitleWidth
        {
            get { return getScreenWidth * 1.0; }
        }

        public static double getMenuHeight
        {
            get { return getScreenHeight * 0.9; }
        }

        public static double getMenuWidth
        {
            get { return getScreenWidth * 1.0; }
        }

        public static double getMenuOrderHeight
        {
            get { return getMenuHeight * 0.95; }
        }

        public static double getMenuOrderWidth
        {
            get { return getMenuWidth * 0.3; }
        }

        public static double getMenuOrderItemQuantityWidth
        {
            get { return getMenuOrderWidth * 0.15; }
        }

        public static Thickness getMenuOrderItemQuantityMargin
        {
            get { return new Thickness(getMenuOrderItemQuantityWidth * 0.45, 0, 0, 0); }
        }

        public static double getMenuOrderItemProductWidth
        {
            get { return getMenuOrderWidth * 0.55; }
        }

        public static double getMenuOrderItemPriceWidth
        {
            get { return getMenuOrderWidth * 0.20; }
        }

        public static Thickness getMenuOrderMargin
        {
            get { return new Thickness(getMenuWidth * 0.01, 0, getMenuWidth * 0.01, 0); }
        }

        public static double getMenuItemsHeight
        {
            get { return getMenuHeight * 0.95; }
        }

        public static double getMenuItemsWidth
        {
            get { return getMenuWidth * 0.67; }
        }

        public static Thickness getMenuItemsMargin
        {
            get { return new Thickness(getMenuWidth * 0.01, 0, getMenuWidth * 0.01, 0); }
        }

        public static double getMenuOrderHeaderHeight
        {
            get { return getMenuOrderHeight * 0.20; }
        }

        public static double getMenuOrderTotalHeight
        {
            get { return getMenuOrderHeight * 0.12; }
        }

        public static double getMenuOrderHeaderDiscardAndTakeOrderHeight
        {
            get { return getMenuOrderHeaderHeight * 0.40; }
        }

        public static double getMenuOrderHeaderDiscardAndTakeOrderWidth
        {
            get { return getMenuOrderWidth * 0.5; }
        }

        public static double getMenuOrderTotalAndSubtotalWidth
        {
            get { return getMenuOrderWidth * 0.5; }
        }

        public static Thickness getMenuOrderTotalAndSubtotalMargin
        {
            get { return new Thickness(getMenuOrderTotalAndSubtotalWidth, 0, 0, 0); }
        }

        public static double getMenuOrderCheckoutHeight
        {
            get { return getMenuOrderHeight * 0.68; }
        }

        public static double getMenuCatalogTabWidth
        {
            get { return (getMenuItemsWidth / 7) - 1; }
        }

        public static double getMenuCatalogTabHeight
        {
            get { return getMenuItemsWidth * 0.05; }
        }

        public static double menuItemTabBottomStripHeight
        {
            get { return getMenuCatalogTabHeight * 0.10; }
        }

        public static double menuItemTabBottomConstantStripHeight
        {
            get { return getMenuCatalogTabHeight * 0.03; }
        }

        public static double getMenuCatalogItemWidth
        {
            get { return getMenuItemsWidth * (1 / 4.5); }
        }

        public static double getMenuCatalogItemHeight
        {
            get { return getMenuItemsWidth * (1 / 3.5); }
        }

        public static double getMenuCatalogItemHalfHeight
        {
            get { return getMenuCatalogItemHeight * 0.5; }
        }

        public static Thickness getMenuCatalogItemMargin
        {
            get { return new Thickness(getMenuItemsWidth * 0.012, getMenuItemsWidth * 0.012, getMenuItemsWidth * 0.012, getMenuItemsWidth * 0.012); }
        }

        public static double getDialogBoxHeight
        {
            get { return getScreenHeight * 0.3333; }
        }

        public static double getDialogBoxWidth
        {
            get { return getScreenWidth * 0.3125; }
        }

        public static double getDialogBoxTextAreaHeight
        {
            get { return getScreenHeight * 0.2222; }
        }

        public static double getDialogBoxTextAreaWidth
        {
            get { return getScreenWidth * 0.3125; }
        }

        public static double getDialogBoxBtnAreaHeight
        {
            get { return getScreenHeight * 0.1111; }
        }

        public static double getDialogBoxBtnAreaWidth
        {
            get { return getScreenWidth * 0.1562; }
        }
    }


}
