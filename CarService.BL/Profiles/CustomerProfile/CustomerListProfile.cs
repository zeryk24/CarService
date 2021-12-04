// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.CustomerProfile
{
    public class CustomerListProfile : Profile
    {
        public CustomerListProfile()
        {
            CreateMap<CustomerEntity, CustomerListModel>();
        }
    }
}
