using CarService.Shared.Models.InvoiceModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    internal interface IInvoiceApiClient : IGenericApiClient<InvoiceCreateModel, InvoiceDetailModel, InvoiceListModel, InvoiceUpdateModel>
    {
    }
}
