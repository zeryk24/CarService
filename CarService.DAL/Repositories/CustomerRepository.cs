using CarService.DAL.Database;
using CarService.DAL.Entities;
using CarService.DAL.Repositories.Generic;
using CarService.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Repositories
{
    class CustomerRepository : EntityRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
