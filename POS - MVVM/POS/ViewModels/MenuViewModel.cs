using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<Object> mouseMoveMenuICommand { get; private set; }
        public DelegateCommand<Object> addMenuItemICommand { get; private set; }
        public DelegateCommand<Object> selectedItemChangedICommand { get; private set; }
        public ObservableCollection<MenuItem> menuListsSelectedItem { get; private set; }
        public int selectedTabIndex { get; set; }
        private Point oldMousePosition { get; set; }
        private MenuModel menuModel { get; set; }
        private IEventAggregator eventAggregator { get; set; }

        public MenuViewModel(IEventAggregator eventAggregator)
        {

            // set prism's event aggregator
            this.eventAggregator = eventAggregator;

            // create menu model
            menuModel = new MenuModel();

            // set ICommands
            mouseMoveMenuICommand = new DelegateCommand<Object>(MouseMoveMenuExecute);
            addMenuItemICommand = new DelegateCommand<Object>(DelegateAddMenuItemExecute);

            // set default selected menu items
            menuListsSelectedItem = new ObservableCollection<MenuItem>();
            for (int i = 0; i < POSConstants.NUM_MENU_ITEMS_TYPES; i++)
                menuListsSelectedItem.Add(null);
        }

        /* Menu model property delegates */
        public ObservableCollection<MenuItem>[] menuItemsLists
        {
            get { return menuModel.menuItemsLists; }
        }

        /* On menu mouse movement, track mouse delta position to scroll order panel vertically */
        private void MouseMoveMenuExecute(object parameter)
        {
            var values = (object[])parameter;

            ScrollViewer sv = values[0] as ScrollViewer;
            StackPanel sp = values[1] as StackPanel;

            // get current mouse position within stackpanel
            Point newMousePosition = Mouse.GetPosition(sp);

            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
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

        /* Delegate the adding of a menu item to the order to the order viewmodel */
        private void DelegateAddMenuItemExecute(object parameter)
        {

            // return on null reference
            if (menuListsSelectedItem[selectedTabIndex] == null)
                return;

            // publish add item event on order view model
            eventAggregator.GetEvent<AddItemToOrderEvent>().Publish(menuListsSelectedItem[selectedTabIndex]);

            // reset all selected items in menu
            for (int i = 0; i < POSConstants.NUM_MENU_ITEMS_TYPES; i++)
                menuListsSelectedItem[i] = null;

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
