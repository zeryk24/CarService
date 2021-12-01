using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.MechanicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.MechanicProfile
{
    public class MechanicUpdateProfile : Profile
    {
        public MechanicUpdateProfile()
        {
            CreateMap<MechanicEntity, MechanicUpdateModel>().ReverseMap();
        }
    }
}
