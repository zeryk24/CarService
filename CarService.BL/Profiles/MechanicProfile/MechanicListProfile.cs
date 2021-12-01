using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.MechanicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.MechanicProfile
{
    public class MechanicListProfile : Profile
    {
        public MechanicListProfile()
        {
            CreateMap<MechanicEntity, MechanicListModel>();
        }
    }
}
