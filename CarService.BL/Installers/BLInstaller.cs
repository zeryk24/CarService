using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.BL.Fasades;
using AutoMapper;
namespace CarService.BL.Installers
{
    public static class BLInstaller
    {
        public static IServiceCollection BlInstall(this IServiceCollection services)
        {

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(BLInstaller));


            services.AddScoped< ActivityFasade > ();
            services.AddScoped<ConsumesFasade>();
            services.AddScoped<CustomerFasade>();
            services.AddScoped<InvoiceFasade>();
            services.AddScoped<MaterialFasade>();
            services.AddScoped<MechanicFasade>();
            services.AddScoped<OrderFasade>();
            services.AddScoped<RepairFasade>();
            return services;
        }
    }
}
