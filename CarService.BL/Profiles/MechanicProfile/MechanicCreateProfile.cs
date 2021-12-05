// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.MechanicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.MechanicProfile
{
    public class MechanicCreateProfile : Profile
    {
        public MechanicCreateProfile()
        {
            CreateMap<MechanicEntity, MechanicCreateModel>().ReverseMap();
        }
    }
}
