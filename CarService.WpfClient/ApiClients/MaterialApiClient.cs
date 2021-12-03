using CarService.Shared.Models.MaterialModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.WpfClient.ApiClients
{
    internal class MaterialApiClient : GenericApiClient<MaterialCreateModel, MaterialDetailModel, MaterialListModel, MaterialUpdateModel>, IMaterialApiClient
    {
        public MaterialApiClient(HttpClient client) : base(client, "/api/Material")
        {

        }
    }
}
