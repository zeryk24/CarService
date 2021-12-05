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
    internal class AddOrderViewModel : ViewModelBase
    {
        private IOrderApiClient _orderApiClient;
        private NavigationService _navigationService;

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => _navigationService.GoHome());
            }
        }

        public AddOrderViewModel(IOrderApiClient orderApiClient, NavigationService navigationService)
        {
            _orderApiClient = orderApiClient;
            _navigationService = navigationService;
        }
    }
}
