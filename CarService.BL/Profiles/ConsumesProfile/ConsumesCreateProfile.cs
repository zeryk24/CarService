// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.ConsumesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.ConsumesProfile
{
    public class ActivityCreateProfile : Profile
    {
        public ActivityCreateProfile()
        {
            CreateMap<ConsumesEntity, ConsumesCreateModel>().ReverseMap();
        }
    }
}
