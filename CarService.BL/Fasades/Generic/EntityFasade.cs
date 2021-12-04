// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities.Interfaces;
using CarService.DAL.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Fasades.Generic
{
    public class EntityFacade<TEntity, TDetailModel, TCreateModel, TListModel, TUpdateModel>
    where TEntity : class, IEntity
    {
        protected readonly IEntityRepository<TEntity> repository;
        protected readonly IMapper mapper;
        public EntityFacade(IEntityRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public TDetailModel Create(TCreateModel item)
        {
            TEntity entity = mapper.Map<TEntity>(item);
            repository.Insert(entity);
            repository.Save();
            return mapper.Map<TDetailModel>(entity);
        }

        public void Delete(int id)
        {
            repository.Remove(id);
            repository.Save();
        }

        public ICollection<TListModel> GetAll()
        {
            ICollection<TEntity> entities = repository.GetAll();
            return mapper.Map<ICollection<TListModel>>(entities);
        }

        public TDetailModel GetById(int id)
        {
            TEntity entity = repository.GetById(id);
            return mapper.Map<TDetailModel>(entity);
        }

        public void Update(TUpdateModel item)
        {
            TEntity updateEntity = mapper.Map<TEntity>(item);
            repository.Update(updateEntity);
            repository.Save();
        }
    }
}
