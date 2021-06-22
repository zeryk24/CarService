using CarService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //only for migrations
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=carservicedb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<ConsumesEntity> Consumes { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<MechanicActivityEntity> MechanicActivities { get; set; }
        public DbSet<MechanicEntity> Mechanics { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<RepairEntity> Repaires { get; set; }

    }
}
