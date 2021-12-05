using CarService.Shared.Models.MechanicModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    public interface IMechanicApiClient : IGenericApiClient<MechanicCreateModel, MechanicDetailModel, MechanicListModel, MechanicUpdateModel>
    {
        public Task<ICollection<MechanicListModel>> GetWithoutWork();
    }
}
