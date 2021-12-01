using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.OrderProfile
{
    public class OrderListProfile : Profile
    {
        public OrderListProfile()
        {
            CreateMap<OrderEntity, OrderListModel>();
        }
    }
}
