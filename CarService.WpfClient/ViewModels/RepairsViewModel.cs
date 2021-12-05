using CarService.Shared.Models.OrderModel;
using CarService.Shared.Models.RepairModel;
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
    internal class RepairsViewModel : ViewModelBase
    {
        private IRepairApiClient repairApiClient;
        private readonly IOrderApiClient orderApiClient;
        private NavigationService navigationService;
        private CurrentListModelProvider currentListModelProvider;

        private ObservableCollection<RepairListModel> _repairs;
        public ObservableCollection<RepairListModel> Repairs
        {
            get { return _repairs; }
            set
            {
                _repairs = value;
                OnPropertyChanged(nameof(_repairs));
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

        private ICommand _addRepairCommand;
        public ICommand AddRepairCommand
        {
            get
            {
                return _addRepairCommand ??= new ActionCommand(() => navigationService.GoTo("addRepair"));
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

        public RepairsViewModel(IRepairApiClient repairApiClient, IOrderApiClient orderApiClient, NavigationService navigationService, CurrentListModelProvider currentListModelProvider)
        {
            this.repairApiClient = repairApiClient;
            this.orderApiClient = orderApiClient;
            this.navigationService = navigationService;
            this.currentListModelProvider = currentListModelProvider;

            Repairs = new ObservableCollection<RepairListModel>();

            GetOrdersRepairs();

        }

        public async void GetOrdersRepairs()
        {
            try
            {
                var a = await orderApiClient.GetById(((OrderListModel)currentListModelProvider.CurrentListModel).Id);
                Repairs.Clear();
                foreach (var repair in a.Repairs)
                {
                    Repairs.Add((RepairListModel)repair);
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
                var x = (RepairListModel)sender;
                repairApiClient.Delete(x.Id);
            }
            catch (Exception)
            {
            }

            GetOrdersRepairs();
        }
    }
}
