using AutoMapper;
using CarService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.ConsumesProfile
{
    internal class ConsumesUpdateProfile : Profile
    {
        public ConsumesUpdateProfile()
        {
            CreateMap<ConsumesEntity, ConsumesUpdateProfile>().ReverseMap();
        }
    }
}
