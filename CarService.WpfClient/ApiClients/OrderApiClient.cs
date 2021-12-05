using CarService.Shared.Models.OrderModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarService.WpfClient.ApiClients
{
    internal class OrderApiClient : GenericApiClient<OrderCreateModel, OrderDetailModel, OrderListModel, OrderUpdateModel>, IOrderApiClient
    {
        public OrderApiClient(HttpClient client) : base(client, "/api/Order")
        {
        }
        public async Task<ICollection<OrderListModel>> GetFinished()
        {
            var response = await client.GetAsync(apiUrl + "/finished");
            var body = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ICollection<OrderListModel>>(body);
            return list;
        }
    }
}
