using CarService.Shared.Models.ConsumesModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.WpfClient.ApiClients
{
    internal class ConsumesApiClient : GenericApiClient<ConsumesCreateModel, ConsumesDetailModel, ConsumesListModel, ConsumesUpdateModel>, IConsumesApiClient
    {
        public ConsumesApiClient(HttpClient client) : base(client, "/api/Consumes")
        {
        }
    }
}
