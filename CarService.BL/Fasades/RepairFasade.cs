using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.RepairModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;

namespace CarService.BL.Fasades
{
    class RepairFasade : EntityFacade<RepairEntity, RepairDetailModel, RepairCreateModel, RepairListModel, RepairUpdateModel>
    {
        public RepairFasade(RepairRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
