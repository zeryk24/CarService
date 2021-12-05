using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarService.WpfClient.ApiClients.Base
{
    public abstract class GenericApiClient<TCreateModel, TDetailModel, TListModel, TUpdateModel> :
    IGenericApiClient<TCreateModel, TDetailModel, TListModel, TUpdateModel>
    {
        protected HttpClient client;

        public GenericApiClient(HttpClient httpClient, string apiUrl = null)
        {
            client = httpClient;
            this.apiUrl = apiUrl;
        }

        protected readonly string apiUrl;
        public async Task<TDetailModel> Create(TCreateModel item)
        {
            var jsonData = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiUrl, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<TDetailModel>(responseBody);
            return responseObject;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await client.DeleteAsync($"{apiUrl}/{id}");
            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<ICollection<TListModel>> GetAll()
        {
            var response = await client.GetAsync(apiUrl);
            var body = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ICollection<TListModel>>(body);
            return list;
        }

        public async Task<TDetailModel> GetById(int id)
        {
            var response = await client.GetAsync($"{apiUrl}/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<TDetailModel>(responseBody);
            return responseObject;
        }
        public async Task<bool> Update(TUpdateModel item)
        {
            var jsonData = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(apiUrl, content);
            return response.StatusCode == HttpStatusCode.OK;
        }

    }
}
