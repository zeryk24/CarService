using AutoMapper;
using CarService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.ConsumesProfile
{
    internal class ConsumesListProfile : Profile
    {
        public ConsumesListProfile()
        {
            CreateMap<ConsumesEntity, ConsumesListProfile>();
        }
    }
}
