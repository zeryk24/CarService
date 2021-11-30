using CarService.DAL.Database;
using CarService.DAL.Entities;
using CarService.DAL.Repositories.Generic;
using CarService.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Repositories
{
    public class MaterialRepository : EntityRepository<MaterialEntity>, IMaterialRepository
    {
        public MaterialRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
