using CarService.Shared.Models.MechanicModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.WpfClient.ApiClients
{
    internal class MechanicApiClient : GenericApiClient<MechanicCreateModel, MechanicDetailModel, MechanicListModel, MechanicUpdateModel>, IMechanicApiClient
    {
        public MechanicApiClient(HttpClient client) : base(client, "/api/Mechanic")
        {
        }
    }
}
