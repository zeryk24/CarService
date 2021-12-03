using CarService.Shared.Models.InvoiceModel;
using CarService.WpfClient.ApiClients.Base;
using CarService.WpfClient.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.WpfClient.ApiClients
{
    internal class InvoiceApiClient : GenericApiClient<InvoiceCreateModel, InvoiceDetailModel, InvoiceListModel, InvoiceUpdateModel>, IInvoiceApiClient
    {
        public InvoiceApiClient(HttpClient client) : base(client, "/api/Invoice")
        {
        }
    }
}
