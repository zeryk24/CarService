using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarService.WpfClient.ApiClients.Base
{
    public interface IGenericApiClient<TCreateModel,TDetailModel, TListModel, TUpdateModel>
	{
		public Task<ICollection<TListModel>> GetAll();
		public Task<TDetailModel> GetById(int id);
		public Task<TDetailModel> Create(TCreateModel item);
		public Task<bool> Update(TUpdateModel item);
		public Task<bool> Delete(int id);
	}
}
