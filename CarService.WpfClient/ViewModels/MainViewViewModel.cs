using CarService.Shared.Models.MechanicModel;
using CarService.Shared.Models.OrderModel;
using CarService.WpfClient.ApiClients;
using CarService.WpfClient.ApiClients.Interfaces;
using CarService.WpfClient.Services;
using CarService.WpfClient.ViewModels.Base;
using Microsoft.Xaml.Behaviors.Core;
using Splat;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CarService.WpfClient.ViewModels
{

    public class MainViewViewModel : ViewModelBase
    {
        private IOrderApiClient _orderApiClient;
        private IMechanicApiClient _mechanicApiClient;
        private NavigationService _navigationService;
        private readonly CurrentListModelProvider currentListModelProvider;
        private ObservableCollection<OrderListModel> _orders;

        private ICommand _customersCommand;
        public ICommand CustomersCommand
        {
            get
            {
                return _customersCommand ??= new ActionCommand(() => _navigationService.GoTo("customer"));
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

        private ICommand _orderCommand;
        public ICommand OrderCommand
        {
            get
            {
                return _orderCommand ??= new ActionCommand(() => _navigationService.GoTo("order"));
            }
        }

        private ICommand _addCustomerCommand;
        public ICommand AddCustomerCommand
        {
            get
            {
                return _addCustomerCommand ??= new ActionCommand(() => _navigationService.GoTo("addCustomer"));
            }
        }

        private ICommand _addOrderCommand;
        public ICommand AddOrderCommand
        {
            get
            {
                return _addOrderCommand ??= new ActionCommand(() => _navigationService.GoTo("addOrder"));
            }
        }

        public ObservableCollection<OrderListModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private ObservableCollection<MechanicListModel> _mechanics;
        public ObservableCollection<MechanicListModel> Mechanics
        {
            get { return _mechanics; }
            set
            {
                _mechanics = value;
                OnPropertyChanged(nameof(Mechanics));
            }
        }

        private int _width;
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public async void GetDoneOrders()
        {
            try
            {
                Orders.Clear();
                foreach (var order in (ICollection)await _orderApiClient.GetFinished())
                {
                    Orders.Add((OrderListModel)order);
                }
            }
            catch (Exception)
            {
            }
        }

        public async void GetFreeMechanics()
        {
            try
            {
                Mechanics.Clear();
                foreach (var mechanic in (ICollection)await _mechanicApiClient.GetWithoutWork())
                {
                    Mechanics.Add((MechanicListModel)mechanic);
                }
            }
            catch (Exception)
            {
            }
        }

        public MainViewViewModel(IOrderApiClient orderApiClient, IMechanicApiClient mechanicApiClient, NavigationService navigationService, CurrentListModelProvider currentListModelProvider)
        {
            ScreenParameters.Instance.WindowSizeChangedEvent += WindowSizeChangedEvent;
            Width = 200;

            _orderApiClient = orderApiClient;
            _mechanicApiClient = mechanicApiClient;
            _navigationService = navigationService;
            this.currentListModelProvider = currentListModelProvider;
            Orders = new ObservableCollection<OrderListModel>();
            Mechanics = new ObservableCollection<MechanicListModel>();

            GetDoneOrders();
            GetFreeMechanics();
        }

        private void WindowSizeChangedEvent(object sender, EventArgs e)
        {
            Width = (int)(ScreenParameters.Instance.WindowWidth / 6);
        }
    }
}
