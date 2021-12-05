using CarService.Shared.Models.MechanicModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarService.WpfClient.ApiClients
{
    internal class MechanicApiClient : GenericApiClient<MechanicCreateModel, MechanicDetailModel, MechanicListModel, MechanicUpdateModel>, IMechanicApiClient
    {
        public MechanicApiClient(HttpClient client) : base(client, "/api/Mechanic")
        {
        }
        public async Task<ICollection<MechanicListModel>> GetWithoutWork()
        {
            var response = await client.GetAsync(apiUrl + "/WithoutWork");
            var body = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ICollection<MechanicListModel>>(body);
            return list;
        }
    }
}
