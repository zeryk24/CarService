using CarService.Shared.Models.OrderModel;
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
    internal class OrderDetailViewModel : ViewModelBase
    {
        private IOrderApiClient orderApiClient;
        private NavigationService navigationService;
        private CurrentListModelProvider currentListModelProvider;

        private OrderDetailModel _order;
        public OrderDetailModel Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private ICommand _repairCommand;
        public ICommand RepairCommand
        {
            get
            {
                return _repairCommand ??= new ActionCommand(() => navigationService.GoTo("repair"));
            }
        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => navigationService.GoTo("order"));
            }
        }

        public OrderDetailViewModel(IOrderApiClient orderApiClient, NavigationService navigationService, CurrentListModelProvider currentListModelProvider)
        {
            this.orderApiClient = orderApiClient;
            this.navigationService = navigationService;
            this.currentListModelProvider = currentListModelProvider;

            GetOrderDetail();
        }

        public async void GetOrderDetail()
        {
            Order = await orderApiClient.GetById(((OrderListModel)currentListModelProvider.CurrentListModel).Id);
        }
    }
}
