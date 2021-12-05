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
    public class InvoiceRepository : EntityRepository<InvoiceEntity>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
            Includes.Add(e => e.Order);
        }
        public ICollection<InvoiceEntity> GetCustomerInvoices(int customer_id)
        {
            var invoise_set = context.Set<InvoiceEntity>().AsQueryable().AsNoTracking();
            invoise_set = invoise_set.Include(e => e.Order);
            return invoise_set.Where(e => e.Order.CustomerId == customer_id).ToList();
        }
    }
}
