using CarService.Shared.Models.ConsumesModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    internal interface IConsumesApiClient : IGenericApiClient<ConsumesCreateModel, ConsumesDetailModel, ConsumesListModel, ConsumesUpdateModel>
    {
    }
}
