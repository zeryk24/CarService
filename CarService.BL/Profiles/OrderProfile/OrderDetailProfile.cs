// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.OrderProfile
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderEntity, OrderDetailModel>();
        }
    }
}
