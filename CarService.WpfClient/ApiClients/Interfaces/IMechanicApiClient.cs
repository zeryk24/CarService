using CarService.Shared.Models.MechanicModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    public interface IMechanicApiClient : IGenericApiClient<MechanicCreateModel, MechanicDetailModel, MechanicListModel, MechanicUpdateModel>
    {
    }
}
