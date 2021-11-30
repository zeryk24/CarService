using CarService.DAL.Database;
using CarService.DAL.Entities;
using CarService.DAL.Repositories.Generic;
using CarService.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Repositories
{
    public class MechanicRepository : EntityRepository<MechanicEntity>, IMechanicRepository
    {
        public MechanicRepository(ApplicationDbContext context) : base(context)
        {
            Includes.Add(e => e.Repairs);
        }
    }
}
