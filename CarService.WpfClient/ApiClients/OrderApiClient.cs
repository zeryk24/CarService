using CarService.Shared.Models.OrderModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.WpfClient.ApiClients
{
    internal class OrderApiClient : GenericApiClient<OrderCreateModel, OrderDetailModel, OrderListModel, OrderUpdateModel>, IOrderApiClient
    {
        public OrderApiClient(HttpClient client) : base(client, "/api/Order")
        {
        }
    }
}
