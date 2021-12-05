using CarService.Shared.Models.InvoiceModel;
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
    internal class InvoiceApiClient : GenericApiClient<InvoiceCreateModel, InvoiceDetailModel, InvoiceListModel, InvoiceUpdateModel>, IInvoiceApiClient
    {
        public InvoiceApiClient(HttpClient client) : base(client, "/api/Invoice")
        {
        }
        public async Task<ICollection<InvoiceListModel>> GetByCustomer(int customer_id)
        {
            var response = await client.GetAsync(apiUrl + "/getbycustomer/"+ customer_id);
            var body = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ICollection<InvoiceListModel>>(body);
            return list;
        }
    }
}
