using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.ConsumesModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;
using CarService.DAL.Repositories.Interfaces;
namespace CarService.BL.Fasades
{
    public class ConsumesFasade : EntityFacade<ConsumesEntity, ConsumesDetailModel, ConsumesCreateModel, ConsumesListModel, ConsumesUpdateModel>
    {
        public ConsumesFasade(IConsumesRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
