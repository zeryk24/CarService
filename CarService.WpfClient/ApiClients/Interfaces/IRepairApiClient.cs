using CarService.Shared.Models.RepairModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    internal interface IRepairApiClient : IGenericApiClient<RepairCreateModel, RepairDetailModel, RepairListModel, RepairUpdateModel>
    {
    }
}
