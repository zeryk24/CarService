using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.ActivityModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;

namespace CarService.BL.Fasades
{
    class ActivityFasade : EntityFacade<ActivityEntity, ActivityDetailModel, ActivityCreateModel, ActivityListModel, ActivityUpdateModel>
    {
        public ActivityFasade(ActivityRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
