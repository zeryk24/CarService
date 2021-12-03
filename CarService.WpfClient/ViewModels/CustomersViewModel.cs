using CarService.Shared.Models.CustomerModel;
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
    internal class CustomersViewModel : ViewModelBase
    {
        private ICustomerApiClient _customerApiClient;
        private  NavigationService _navigationService;

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

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => _navigationService.GoHome());
            }
        }

        public CustomersViewModel(ICustomerApiClient customerApiClient, NavigationService navigationService)
        {
            _customerApiClient = customerApiClient;
            _navigationService = navigationService;

            Customers = new ObservableCollection<CustomerListModel>();

            GetAllCustomers();
            GetAllCustomers();
            GetAllCustomers();
            GetAllCustomers();
            GetAllCustomers();
            GetAllCustomers();
            GetAllCustomers();
        }

        public async void GetAllCustomers()
        {
            try
            {
                //Customers.Clear();
                foreach (var customer in (ICollection)await _customerApiClient.GetAll())
                {
                    Customers.Add((CustomerListModel)customer);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
