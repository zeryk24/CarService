// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.ActivityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.ActivityProfile
{
    public class ActivityDetailProfile : Profile
    {
        public ActivityDetailProfile()
        {
            CreateMap<ActivityEntity, ActivityDetailModel>();
        }
    }
}
