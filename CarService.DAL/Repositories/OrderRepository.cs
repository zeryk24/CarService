using CarService.DAL.Database;
using CarService.DAL.Entities;
using CarService.DAL.Repositories.Generic;
using CarService.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Repositories
{
    public class OrderRepository : EntityRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            Includes.Add(e => e.Customer);
            Includes.Add(e => e.Invoices);
            Includes.Add(e => e.Repairs);
        }
    }
}
