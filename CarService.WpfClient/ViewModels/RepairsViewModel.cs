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

        public RepairsViewModel(IRepairApiClient repairApiClient, NavigationService navigationService, CurrentListModelProvider currentListModelProvider)
        {
            this.repairApiClient = repairApiClient;
            this.navigationService = navigationService;
            this.currentListModelProvider = currentListModelProvider;

            Repairs = new ObservableCollection<RepairListModel>();

            GetOrdersRepairs();
            GetOrdersRepairs();
            GetOrdersRepairs();

        }

        public async void GetOrdersRepairs()
        {
            try
            {
                //Customers.Clear();
                foreach (var repair in (ICollection)await repairApiClient.GetAll())
                {
                    Repairs.Add((RepairListModel)repair);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
