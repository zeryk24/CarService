using CarService.WpfClient.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.Services
{
    public static class Bootstrapper
    {
        public static void RegisterDependencies(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.Register(() => new MainWindow(
                resolver.GetService<MainWindowViewModel>()));

            services.Register(() => new MainWindowViewModel());
            services.Register(() => new MainViewViewModel());
        }
    }
}
