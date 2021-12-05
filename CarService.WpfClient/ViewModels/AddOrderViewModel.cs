using CarService.Shared.Models.CustomerModel;
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
    internal class AddOrderViewModel : ViewModelBase
    {
        private IOrderApiClient _orderApiClient;
        private ICustomerApiClient _customerApiClient;
        private NavigationService _navigationService;

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => _navigationService.GoHome());
            }
        }

        private ObservableCollection<CustomerListModel> _customers;
        public ObservableCollection<CustomerListModel> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ??= new ActionCommand(Create);
            }
        }

        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                OnPropertyChanged();
            }
        }

        private string _carSpz;
        public string CarSpz
        {
            get { return _carSpz; }
            set
            {
                _carSpz = value;
                OnPropertyChanged();
            }
        }

        private CustomerListModel _customer;
        public CustomerListModel Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        public AddOrderViewModel(IOrderApiClient orderApiClient, ICustomerApiClient customerApiClient, NavigationService navigationService)
        {
            _orderApiClient = orderApiClient;
            _customerApiClient = customerApiClient;
            _navigationService = navigationService;

            Customers = new ObservableCollection<CustomerListModel>();

            GetCustomers();
        }

        private async void GetCustomers()
        {
            try
            {
                Customers.Clear();
                foreach (var customer in (ICollection)await _customerApiClient.GetAll())
                {
                    Customers.Add((CustomerListModel)customer);
                }
            }
            catch (Exception)
            {
            }
        }

        private async void Create()
        {
            OrderCreateModel order = new OrderCreateModel()
            {
                CreationDate = CreationDate,
                CarSpz = CarSpz,
                CustomerId = Customer.Id
            };
            try
            {
                await _orderApiClient.Create(order);
            }
            catch (Exception)
            {
                //TODO: error message
            }
            _navigationService.GoTo("order");
        }
    }
}
