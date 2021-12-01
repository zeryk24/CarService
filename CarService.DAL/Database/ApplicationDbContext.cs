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
                optionsBuilder.UseSqlServer(@"Data Source=tcp:auctioniisdbserver.database.windows.net,1433;Initial Catalog=CarService.Api_db;User Id=iisadmin@auctioniisdbserver;Password=Jahoda123");
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<ConsumesEntity> Consumes { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<MechanicEntity> Mechanics { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<RepairEntity> Repaires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // activity
            modelBuilder.Entity<ActivityEntity>()
                .HasMany(i => i.Consumes)
                .WithOne(i => i.Activity)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityEntity>()
              .HasOne(i => i.Repair)
              .WithMany(i => i.Activities)
              .HasForeignKey(i => i.RepairId)
              .OnDelete(DeleteBehavior.Cascade);

            // consumes
            modelBuilder.Entity<ConsumesEntity>()
               .HasOne(i => i.Activity)
               .WithMany(i => i.Consumes)
               .HasForeignKey(i => i.ActivityId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ConsumesEntity>()
              .HasOne(i => i.Material)
              .WithMany(i => i.Consumes)
              .HasForeignKey(i => i.MaterialId)
              .OnDelete(DeleteBehavior.Cascade);

            // customer
            modelBuilder.Entity<CustomerEntity>()
                .HasMany(i => i.Orders)
                .WithOne(i => i.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            // invoice
            modelBuilder.Entity<InvoiceEntity>()
               .HasOne(i => i.Order)
               .WithMany(i => i.Invoices)
               .HasForeignKey(i => i.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
            // material
            modelBuilder.Entity<MaterialEntity>()
                .HasMany(i => i.Consumes)
                .WithOne(i => i.Material)
                .OnDelete(DeleteBehavior.Cascade);

            // mechanic
            modelBuilder.Entity<MechanicEntity>()
                .HasMany(i => i.Repairs)
                .WithOne(i => i.Mechanic)
                .OnDelete(DeleteBehavior.Cascade);

            // Order
            modelBuilder.Entity<OrderEntity>()
               .HasOne(i => i.Customer)
               .WithMany(i => i.Orders)
               .HasForeignKey(i => i.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderEntity>()
               .HasMany(i => i.Invoices)
               .WithOne(i => i.Order)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderEntity>()
               .HasMany(i => i.Repairs)
               .WithOne(i => i.Order)
               .OnDelete(DeleteBehavior.Cascade);
            // Repair
            modelBuilder.Entity<RepairEntity>()
               .HasOne(i => i.Order)
               .WithMany(i => i.Repairs)
               .HasForeignKey(i => i.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RepairEntity>()
              .HasOne(i => i.Mechanic)
              .WithMany(i => i.Repairs)
              .HasForeignKey(i => i.MechanicId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RepairEntity>()
              .HasMany(i => i.Activities)
              .WithOne(i => i.Repair)
              .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }

}
