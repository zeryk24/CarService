using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.ConsumesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.ConsumesProfile
{
    public class ConsumesListProfile : Profile
    {
        public ConsumesListProfile()
        {
            CreateMap<ConsumesEntity, ConsumesListModel>();
        }
    }
}
