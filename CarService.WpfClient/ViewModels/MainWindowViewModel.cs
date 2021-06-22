using CarService.WpfClient.ViewModels.Base;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public MainWindowViewModel()
        {
            SelectedViewModel = Locator.Current.GetService<MainViewViewModel>();
        }
    }
}
