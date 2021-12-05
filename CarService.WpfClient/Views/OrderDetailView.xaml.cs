﻿using CarService.WpfClient.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarService.WpfClient.Views
{
    /// <summary>
    /// Interaction logic for OrderDetailView.xaml
    /// </summary>
    public partial class OrderDetailView : UserControl
    {
        public OrderDetailView()
        {
            InitializeComponent();
            DataContext = Locator.Current.GetService<OrderDetailViewModel>();
        }
    }
}
