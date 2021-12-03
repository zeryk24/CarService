using CarService.Shared.Models.OrderModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    public interface IOrderApiClient : IGenericApiClient<OrderCreateModel, OrderDetailModel, OrderListModel, OrderUpdateModel>
    {
    }
}
