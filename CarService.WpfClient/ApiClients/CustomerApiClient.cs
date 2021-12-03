using CarService.Shared.Models.CustomerModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.WpfClient.ApiClients
{
    internal class CustomerApiClient : GenericApiClient<CustomerCreateModel, CustomerDetailModel, CustomerListModel, CustomerUpdateModel>, ICustomerApiClient
    {
        public CustomerApiClient(HttpClient client) : base(client, "/api/Customer")
        {
        }
    }
}
