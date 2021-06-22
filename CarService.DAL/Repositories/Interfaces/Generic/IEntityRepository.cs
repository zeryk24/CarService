using CarService.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Repositories.Interfaces.Generic
{
    public interface IEntityRepository<TEntity>
        where TEntity : IEntity
    {
        ICollection<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
        void Save();
    }
}
