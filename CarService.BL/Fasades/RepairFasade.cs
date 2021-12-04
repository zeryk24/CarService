// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.RepairModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;
using CarService.DAL.Repositories.Interfaces;
namespace CarService.BL.Fasades
{
    public class RepairFasade : EntityFacade<RepairEntity, RepairDetailModel, RepairCreateModel, RepairListModel, RepairUpdateModel>
    {
        public RepairFasade(IRepairRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
