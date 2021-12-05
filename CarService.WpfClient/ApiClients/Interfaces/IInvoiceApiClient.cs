using CarService.Shared.Models.InvoiceModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    internal interface IInvoiceApiClient : IGenericApiClient<InvoiceCreateModel, InvoiceDetailModel, InvoiceListModel, InvoiceUpdateModel>
    {
        public Task<ICollection<InvoiceListModel>> GetByCustomer(int customer_id);
    }
}
