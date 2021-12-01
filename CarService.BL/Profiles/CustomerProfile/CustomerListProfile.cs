using AutoMapper;
using CarService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.CustomerProfile
{
    public class CustomerListProfile : Profile
    {
        public CustomerListProfile()
        {
            CreateMap<CustomerEntity, CustomerListProfile>();
        }
    }
}
