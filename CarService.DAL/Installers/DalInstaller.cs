using CarService.DAL.Database;
using CarService.DAL.Repositories;
using CarService.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Installers
{
    public static class DalInstaller
    {
        public static IServiceCollection DalInstall(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IConsumesRepository, ConsumesRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMechanicActivityRepository, MechanicActivityRepository>();
            services.AddScoped<IMechanicRepository, MechanicRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRepairRepository, RepairRepository>();

            return services;
        }
    }
}
