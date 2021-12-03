using CarService.Shared.Models.MaterialModel;
using CarService.WpfClient.ApiClients.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ApiClients.Interfaces
{
    internal interface IMaterialApiClient : IGenericApiClient<MaterialCreateModel, MaterialDetailModel, MaterialListModel, MaterialUpdateModel>
    {
    }
}
