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
    internal class AddCustomerViewModel : ViewModelBase
    {
        private  ICustomerApiClient _customerApiClient;
        private  NavigationService _navigationService;

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => _navigationService.GoHome());
            }
        }

        public AddCustomerViewModel(ICustomerApiClient customerApiClient, NavigationService navigationService)
        {
            _customerApiClient = customerApiClient;
            _navigationService = navigationService;
        }
    }
}
