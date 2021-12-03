using CarService.WpfClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CarService.WpfClient.Services
{
    public class NavigationService
    {
        public void GoHome()
        {
            GoTo("main");
        }

        public void GoTo(string destination)
        {
            var vm = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            vm.UpdateViewModel(destination);
        }
    }
}
