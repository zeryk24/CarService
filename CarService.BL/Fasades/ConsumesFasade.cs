using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.ConsumesModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;

namespace CarService.BL.Fasades
{
    class ConsumesFasade : EntityFacade<ConsumesEntity, ConsumesDetailModel, ConsumesCreateModel, ConsumesListModel, ConsumesUpdateModel>
    {
        public ConsumesFasade(ConsumesRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
