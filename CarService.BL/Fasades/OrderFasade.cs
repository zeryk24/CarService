using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.OrderModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;

namespace CarService.BL.Fasades
{
    class OrderFasade : EntityFacade<OrderEntity, OrderDetailModel, OrderCreateModel, OrderListModel, OrderUpdateModel>
    {
        public OrderFasade(OrderRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
