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
    public class CustomerRepository : EntityRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            Includes.Add(e => e.Orders);
        }
    }
}
