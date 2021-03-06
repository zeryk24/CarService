using CarService.WpfClient.Services;
using CarService.WpfClient.ViewModels.Base;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CarService.WpfClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public MainWindowViewModel()
        {
            UpdateViewModel("main"); ;
        }

        public void Init()
        {
            var mainWindow = Application.Current.MainWindow;
            mainWindow.SizeChanged += MainWindow_SizeChanged;
        }

        public void UpdateViewModel(string par)
        {
            Dictionary<string, Type> viewModels = new Dictionary<string, Type> {
                { "main", typeof(MainViewViewModel) },
                { "customer", typeof(CustomersViewModel) },
                { "addCustomer", typeof(AddCustomerViewModel) },
                { "addOrder", typeof(AddOrderViewModel) },
                { "orderDetailModel", typeof(OrderDetailViewModel) },
                { "customerDetailModel", typeof(CustomerDetailViewModel) },
                { "repair", typeof(RepairsViewModel) },
                { "addRepair", typeof(AddRepairViewModel) },
                { "order", typeof(OrdersViewModel) }};

            SelectedViewModel = (ViewModelBase)Locator.Current.GetService(viewModels[par]);
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is Window window)
                ScreenParameters.Instance.WindowSizeChanged(window, e);
        }
    }
}
