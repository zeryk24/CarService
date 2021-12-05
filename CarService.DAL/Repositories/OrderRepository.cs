using CarService.DAL.Database;
using CarService.DAL.Entities;
using CarService.DAL.Repositories.Generic;
using CarService.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ICollection<OrderEntity> GetFinishedOrders()
        {
            var set = context.Set<OrderEntity>().AsQueryable().AsNoTracking();
            foreach (var include in Includes)
            {
                set = set.Include(include);
            }
            return set.Where(e => e.Repairs.All(i => i.State == Shared.Enums.State.Hotovo)).ToList();
        }
    }
}
