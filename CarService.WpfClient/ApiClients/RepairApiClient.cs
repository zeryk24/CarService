using CarService.Shared.Models.RepairModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.WpfClient.ApiClients
{
    internal class RepairApiClient : GenericApiClient<RepairCreateModel, RepairDetailModel, RepairListModel, RepairUpdateModel>, IRepairApiClient
    {
        public RepairApiClient(HttpClient client) : base(client, "/api/Repair")
        {
        }
    }
}
