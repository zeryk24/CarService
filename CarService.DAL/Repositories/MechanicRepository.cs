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
    public class MechanicRepository : EntityRepository<MechanicEntity>, IMechanicRepository
    {
        public MechanicRepository(ApplicationDbContext context) : base(context)
        {
            Includes.Add(e => e.Repairs);
        }
        public  ICollection<MechanicEntity> GetAllWithoutWork()
        {
            var set = context.Set<MechanicEntity>().AsQueryable().AsNoTracking();
            foreach (var include in Includes)
            {
                set = set.Include(include);
            }
            return set.Where(x => x.Repairs.All(i=>i.State == Shared.Enums.State.Hotovo)).ToList();
        }
    }
}
