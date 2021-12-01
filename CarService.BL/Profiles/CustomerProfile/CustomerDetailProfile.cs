using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.CustomerProfile
{
    public class CustomerDetailProfile : Profile
    {
        public CustomerDetailProfile()
        {
            CreateMap<CustomerEntity, CustomerDetailModel>();
        }
    }
}
