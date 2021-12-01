using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.CustomerProfile
{
    public class CustomerUpdateProfile : Profile
    {
        public CustomerUpdateProfile()
        {
            CreateMap<CustomerEntity, CustomerUpdateModel>().ReverseMap();
        }
    }
}
