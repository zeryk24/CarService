using CarService.Shared.Models.CustomerModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    internal interface ICustomerApiClient : IGenericApiClient<CustomerCreateModel, CustomerDetailModel, CustomerListModel, CustomerUpdateModel>
    {
    }
}
