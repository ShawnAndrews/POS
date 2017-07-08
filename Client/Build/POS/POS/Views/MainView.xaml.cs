using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Diagnostics;
using Prism.Events;
using POS.Services;

namespace POS
{
    
    public partial class MainView : Window
    {

        public IEventAggregator eventAggregator { get; set; }
        public OrderViewModel order { get; set; }
        public MenuViewModel menu { get; set; }
        public POSClient service { get; set; }

        public MainView()
        {
            InitializeComponent();
            this.DataContext = this;

            eventAggregator = new EventAggregator();

            // order
            order = new OrderViewModel(eventAggregator);

            // menu
            menu = new MenuViewModel(eventAggregator);

            // service
            service = new POSClient(eventAggregator);

        }

    }

}
