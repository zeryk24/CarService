using CarService.Shared.Models.OrderModel;
using CarService.WpfClient.ApiClients.Interfaces;
using CarService.WpfClient.Services;
using CarService.WpfClient.ViewModels.Base;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CarService.WpfClient.ViewModels
{
    internal class OrdersViewModel : ViewModelBase
    {
        private IOrderApiClient _orderApiClient;
        private NavigationService _navigationService;

        private ObservableCollection<OrderListModel> _orders;
        public ObservableCollection<OrderListModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => _navigationService.GoHome());
            }
        }

        public OrdersViewModel(IOrderApiClient orderApiClient, NavigationService navigationService)
        {
            _orderApiClient = orderApiClient;
            _navigationService = navigationService;

            Orders = new ObservableCollection<OrderListModel>();

            GetAllOrders();
            GetAllOrders();
            GetAllOrders();
            GetAllOrders();
            GetAllOrders();
            GetAllOrders();
            GetAllOrders();
        }

        public async void GetAllOrders()
        {
            try
            {
                //Customers.Clear();
                foreach (var order in (ICollection)await _orderApiClient.GetAll())
                {
                    Orders.Add((OrderListModel)order);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
