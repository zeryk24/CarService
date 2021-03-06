// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.MechanicModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;
using CarService.DAL.Repositories.Interfaces;
namespace CarService.BL.Fasades
{
    public class MechanicFasade : EntityFacade<MechanicEntity, MechanicDetailModel, MechanicCreateModel, MechanicListModel, MechanicUpdateModel>
    {
        private IMechanicRepository mechanicRepository;
        public MechanicFasade(IMechanicRepository repository, IMapper mapper) : base(repository, mapper)
        {
            mechanicRepository = repository;
        }
        public ICollection<MechanicListModel> GetAllWithouWork()
        {
            var all = mechanicRepository.GetAllWithoutWork();
            return mapper.Map<ICollection<MechanicListModel>>(all);
        }

    }
}
