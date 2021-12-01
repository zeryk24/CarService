using AutoMapper;
using CarService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.CustomerProfile
{
    public class CustomerCreateProfile : Profile
    {
        public CustomerCreateProfile()
        {
            CreateMap<CustomerEntity, CustomerCreateProfile>().ReverseMap();
        }
    }
}
