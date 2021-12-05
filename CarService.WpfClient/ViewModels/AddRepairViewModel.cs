using CarService.Shared.Models.CustomerModel;
using CarService.Shared.Models.MechanicModel;
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
    internal class AddRepairViewModel : ViewModelBase
    {
        private IRepairApiClient _repairApiClient;
        private IMechanicApiClient _mechanicApiClient;
        private NavigationService _navigationService;
        private CurrentListModelProvider _currentListModelProvider;
        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??= new ActionCommand(() => _navigationService.GoTo("repair"));
            }
        }

        private ObservableCollection<MechanicListModel> _mechanics;
        public ObservableCollection<MechanicListModel> Mechanics
        {
            get { return _mechanics; }
            set
            {
                _mechanics = value;
                OnPropertyChanged(nameof(Mechanics));
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private MechanicListModel _mechanic;
        public MechanicListModel Mechanic
        {
            get { return _mechanic; }
            set
            {
                _mechanic = value;
                OnPropertyChanged();
            }
        }

        public AddRepairViewModel(IRepairApiClient repairApiClient, IMechanicApiClient mechanicApiClient, NavigationService navigationService, CurrentListModelProvider currentListModelProvider)
        {
            _repairApiClient = repairApiClient;
            _mechanicApiClient = mechanicApiClient;
            _navigationService = navigationService;
            _currentListModelProvider = currentListModelProvider;
            Mechanics = new ObservableCollection<MechanicListModel>();

            GetMechanics();
        }

        private async void GetMechanics()
        {
            try
            {
                Mechanics.Clear();
                foreach (var mechanic in (ICollection)await _mechanicApiClient.GetAll())
                {
                    Mechanics.Add((MechanicListModel)mechanic);
                }
            }
            catch (Exception)
            {
            }
        }

        private async void Create()
        {
            RepairCreateModel repair = new RepairCreateModel()
            {
                Description = Description,
                Date = Date,
                OrderId = ((OrderListModel)_currentListModelProvider.CurrentListModel).Id,
                MechanicId = Mechanic.Id,
                State = 0
            };
            try
            {
                await _repairApiClient.Create(repair);
            }
            catch (Exception)
            {
                //TODO: error message
            }
            _navigationService.GoTo("repair");
        }
    }
}
