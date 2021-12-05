// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.OrderModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;
using CarService.DAL.Repositories.Interfaces;
namespace CarService.BL.Fasades
{
    public class OrderFasade : EntityFacade<OrderEntity, OrderDetailModel, OrderCreateModel, OrderListModel, OrderUpdateModel>
    {
        IOrderRepository order_repository;
        public OrderFasade(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
            order_repository = repository; 
        }
        public ICollection<OrderListModel> GetFinishedOrders()
        {
            return mapper.Map<ICollection<OrderListModel>>( order_repository.GetFinishedOrders());
        }
    }
}
