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
    internal class AddCustomerViewModel : ViewModelBase
    {
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

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ??= new ActionCommand(AddChange);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public AddCustomerViewModel(ICustomerApiClient customerApiClient, NavigationService navigationService)
        {
            _customerApiClient = customerApiClient;
            _navigationService = navigationService;
        }

        private void AddChange()
        {
            //if (update)
            //    Update();
            //else
            Create();
        }

        private async void Create()
        {
            CustomerCreateModel customer = new CustomerCreateModel()
            {
                Name = Name,
                PhoneNumber = PhoneNumber,
                Email = Email
            };
            try
            {
                await _customerApiClient.Create(customer);
            }
            catch (Exception)
            {
                //TODO: error message
            }
            _navigationService.GoTo("customer");
        }
    }
}
