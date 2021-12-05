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
        private readonly CurrentListModelProvider currentListModelProvider;
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

        private OrderListModel _selectedOrder;
        public OrderListModel SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                currentListModelProvider.CurrentListModel = value;
                _navigationService.GoTo("orderDetailModel");
                OnPropertyChanged(nameof(SelectedOrder));
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

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new ActionCommand(Delete);
            }
        }

        public OrdersViewModel(IOrderApiClient orderApiClient, NavigationService navigationService, CurrentListModelProvider currentListModelProvider)
        {
            _orderApiClient = orderApiClient;
            _navigationService = navigationService;
            this.currentListModelProvider = currentListModelProvider;
            Orders = new ObservableCollection<OrderListModel>();

            GetAllOrders();
        }

        public async void GetAllOrders()
        {
            try
            {
                Orders.Clear();
                foreach (var order in (ICollection)await _orderApiClient.GetAll())
                {
                    Orders.Add((OrderListModel)order);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Delete(object sender)
        {
            try
            {
                var x = (OrderListModel)sender;
                _orderApiClient.Delete(x.Id);
            }
            catch (Exception e)
            {
            }

            GetAllOrders();
        }
    }
}
