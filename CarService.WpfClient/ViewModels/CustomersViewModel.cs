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
        private readonly CurrentListModelProvider currentListModelProvider;
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

        private CustomerListModel _selectedCustomer;
        public CustomerListModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                currentListModelProvider.CurrentListModel = value;
                _navigationService.GoTo("customerDetailModel");
                OnPropertyChanged(nameof(_selectedCustomer));
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

        public CustomersViewModel(ICustomerApiClient customerApiClient, CurrentListModelProvider currentListModelProvider, NavigationService navigationService)
        {
            _customerApiClient = customerApiClient;
            this.currentListModelProvider = currentListModelProvider;
            _navigationService = navigationService;

            Customers = new ObservableCollection<CustomerListModel>();

            GetAllCustomers();
        }

        public async void GetAllCustomers()
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

        private void Delete(object sender)
        {
            try
            {
                var x = (CustomerListModel)sender;
                _customerApiClient.Delete(x.Id);
            }
            catch (Exception e)
            {
            }

            GetAllCustomers();
        }
    }
}
