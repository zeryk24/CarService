// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.ActivityModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using CarService.DAL.Repositories.Interfaces;
using AutoMapper;

namespace CarService.BL.Fasades
{
    public class ActivityFasade : EntityFacade<ActivityEntity, ActivityDetailModel, ActivityCreateModel, ActivityListModel, ActivityUpdateModel>
    {
        public ActivityFasade(IActivityRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
        public DateTime GetActivityDate(int id)
        {
            var activity = GetById(id);
            return activity.Repair.Date;
        }
    }
}
