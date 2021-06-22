using CarService.DAL.Database;
using CarService.DAL.Entities.Interfaces;
using CarService.DAL.Repositories.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarService.DAL.Repositories.Generic
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext context;

        public EntityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().First(e => e.Id == id);
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            TEntity deletedEntity = GetById(id);
            context.Set<TEntity>().Remove(deletedEntity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
