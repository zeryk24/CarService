using CarService.WpfClient.ApiClients;
using CarService.WpfClient.ApiClients.Interfaces;
using CarService.WpfClient.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            services.Register(() => new OrdersViewModel(
                resolver.GetService<IOrderApiClient>(),
                resolver.GetService<NavigationService>(),
                resolver.GetService<CurrentListModelProvider>()));
            services.Register(() => new RepairsViewModel(
                resolver.GetService<IRepairApiClient>(),
                resolver.GetService<NavigationService>(),
                resolver.GetService<CurrentListModelProvider>()));
            services.Register(() => new OrderDetailViewModel(
                resolver.GetService<IOrderApiClient>(),
                resolver.GetService<NavigationService>(),
                resolver.GetService<CurrentListModelProvider>()));
            services.Register(() => new CustomerDetailViewModel(
                resolver.GetService<ICustomerApiClient>(),
                resolver.GetService<NavigationService>(),
                resolver.GetService<CurrentListModelProvider>()));
            services.Register(() => new CustomersViewModel(
                resolver.GetService<ICustomerApiClient>(),
                resolver.GetService<CurrentListModelProvider>(),
                resolver.GetService<NavigationService>()));
            services.Register(() => new AddCustomerViewModel(
                resolver.GetService<ICustomerApiClient>(),
                resolver.GetService<NavigationService>()));
            services.Register(() => new AddRepairViewModel(
                resolver.GetService<IRepairApiClient>(),
                resolver.GetService<NavigationService>()));
            services.Register(() => new AddOrderViewModel(
                resolver.GetService<IOrderApiClient>(),
                resolver.GetService<NavigationService>()));
            services.Register(() => new MainViewViewModel(
                resolver.GetService<IOrderApiClient>(),
                resolver.GetService<IMechanicApiClient>(),
                resolver.GetService<NavigationService>()));

            services.Register(() => new NavigationService());
            services.RegisterLazySingleton(() => new CurrentListModelProvider());

            services.Register<IConsumesApiClient>(() => new ConsumesApiClient(
                resolver.GetService<HttpClient>()));
            services.Register<ICustomerApiClient>(() => new CustomerApiClient(
                resolver.GetService<HttpClient>()));
            services.Register<IInvoiceApiClient>(() => new InvoiceApiClient(
                resolver.GetService<HttpClient>()));
            services.Register<IMaterialApiClient>(() => new MaterialApiClient(
                resolver.GetService<HttpClient>()));
            services.Register<IMechanicApiClient>(() => new MechanicApiClient(
                resolver.GetService<HttpClient>()));
            services.Register<IOrderApiClient>(() => new OrderApiClient(
                resolver.GetService<HttpClient>()));
            services.Register<IRepairApiClient>(() => new RepairApiClient(
                resolver.GetService<HttpClient>()));

            services.Register(() =>
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri("https://carserviceapi20211201175316.azurewebsites.net")
                };
                return client;
            });
        }
    }
}
