using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.MechanicActivityModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;

namespace CarService.BL.Fasades
{
    class MechanicActivityFasade : EntityFacade<MechanicActivityEntity, MechanicActivityDetailModel, MechanicActivityCreateModel, MechanicActivityListModel, MechanicActivityUpdateModel>
    {
        public MechanicActivityFasade(MechanicActivityRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
