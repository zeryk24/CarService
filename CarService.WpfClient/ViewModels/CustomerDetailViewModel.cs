using CarService.Shared.Models.CustomerModel;
using CarService.WpfClient.ApiClients.Interfaces;
using CarService.WpfClient.Services;
using CarService.WpfClient.ViewModels.Base;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CarService.WpfClient.ViewModels
{
    internal class CustomerDetailViewModel : ViewModelBase
    {
        private ICustomerApiClient customerApiClient;
        private readonly NavigationService navigationService;
        private readonly CurrentListModelProvider currentListModelProvider;
        private CustomerDetailModel _customer;
        public CustomerDetailModel Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => navigationService.GoTo("customer"));
            }
        }

        public CustomerDetailViewModel(ICustomerApiClient customerApiClient, NavigationService navigationService, CurrentListModelProvider currentListModelProvider)
        {
            this.customerApiClient = customerApiClient;
            this.navigationService = navigationService;
            this.currentListModelProvider = currentListModelProvider;

            GetCustomerDetail();
        }

        private async void GetCustomerDetail()
        {
            Customer = await customerApiClient.GetById(((CustomerListModel)currentListModelProvider.CurrentListModel).Id);

        }
    }
}
