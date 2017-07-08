using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class MenuModel
    {
        public ObservableCollection<MenuItem>[] menuItemsLists { get; private set; }

        public MenuModel()
        {
            // create filled menu
            menuItemsLists = new ObservableCollection<MenuItem>[POSConstants.NUM_MENU_ITEMS_TYPES];

            // Hamburgers
            menuItemsLists[0] = new ObservableCollection<MenuItem>();
            menuItemsLists[0].Add(new MenuItem() { Product = "Cheeseburger", Price = "$5.40", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Chili Cheeseburger", Price = "$9.20", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Bacon Burger", Price = "$7.50", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Angus Burger", Price = "$7.50", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Turkey Burger", Price = "$6.30", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Chicken Caesar Burger", Price = "$7.25", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Taco Burger", Price = "$3.90", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Cheddar Chicken Burger", Price = "$4.20", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Mushroom Cheeseburger", Price = "$7.10", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Spicy Bean Burger", Price = "$6.35", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Paul Bunyan Burger", Price = "$5.85", ProductType = menuItemType.Hamburgers });
            menuItemsLists[0].Add(new MenuItem() { Product = "Sweet Potato burger", Price = "$10.20", ProductType = menuItemType.Hamburgers });

            // Mexican
            menuItemsLists[1] = new ObservableCollection<MenuItem>();
            menuItemsLists[1].Add(new MenuItem() { Product = "Spicy Margarita", Price = "$4.50", ProductType = menuItemType.Drinks });
            menuItemsLists[1].Add(new MenuItem() { Product = "Burrito", Price = "$7.50", ProductType = menuItemType.Sandwiches });
            menuItemsLists[1].Add(new MenuItem() { Product = "Chalupa", Price = "$5.95", ProductType = menuItemType.Sandwiches });
            menuItemsLists[1].Add(new MenuItem() { Product = "Agua Fresca", Price = "$8.95", ProductType = menuItemType.Drinks });
            menuItemsLists[1].Add(new MenuItem() { Product = "Mexican Cinnamon Brownies", Price = "$10.65", ProductType = menuItemType.Deserts });

            // Sandwiches
            menuItemsLists[2] = new ObservableCollection<MenuItem>();
            menuItemsLists[2].Add(new MenuItem() { Product = "Turkey Sandwich", Price = "$5.40", ProductType = menuItemType.Sandwiches });
            menuItemsLists[2].Add(new MenuItem() { Product = "Ham Sandwich", Price = "$3.80", ProductType = menuItemType.Sandwiches });

            // Croissant
            menuItemsLists[3] = new ObservableCollection<MenuItem>();
            menuItemsLists[3].Add(new MenuItem() { Product = "Loafer bread", Price = "$4.55", ProductType = menuItemType.Sandwiches });
            menuItemsLists[3].Add(new MenuItem() { Product = "Parisian Patisserie", Price = "$3.20", ProductType = menuItemType.Sandwiches });
            menuItemsLists[3].Add(new MenuItem() { Product = "Le Croissant", Price = "$4.95", ProductType = menuItemType.Sandwiches });

            // Panini
            menuItemsLists[4] = new ObservableCollection<MenuItem>();
            menuItemsLists[4].Add(new MenuItem() { Product = "Turkey Pesto Panini", Price = "$11.75", ProductType = menuItemType.Sandwiches });
            menuItemsLists[4].Add(new MenuItem() { Product = "Spicy Italian Panini", Price = "$8.90", ProductType = menuItemType.Sandwiches });
            menuItemsLists[4].Add(new MenuItem() { Product = "Apple Pie Panini", Price = "$7.25", ProductType = menuItemType.Sandwiches });

            // Meat
            menuItemsLists[5] = new ObservableCollection<MenuItem>();
            menuItemsLists[5].Add(new MenuItem() { Product = "Sirloin steak sandwich", Price = "$15.10", ProductType = menuItemType.Sandwiches });
            menuItemsLists[5].Add(new MenuItem() { Product = "NY steak sandwich", Price = "$20.20", ProductType = menuItemType.Sandwiches });

            // Kids
            menuItemsLists[6] = new ObservableCollection<MenuItem>();
            menuItemsLists[6].Add(new MenuItem() { Product = "Orange juice", Price = "$2.20", ProductType = menuItemType.Drinks });
            menuItemsLists[6].Add(new MenuItem() { Product = "Chocolate milk", Price = "$3.50", ProductType = menuItemType.Drinks });
            menuItemsLists[6].Add(new MenuItem() { Product = "2% milk", Price = "$4.00", ProductType = menuItemType.Drinks });
            menuItemsLists[6].Add(new MenuItem() { Product = "Slice of cake", Price = "$5.65", ProductType = menuItemType.Deserts });
        }

    }
}
