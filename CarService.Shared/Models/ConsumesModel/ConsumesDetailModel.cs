using CarService.Shared.Models.ActivityModel;
using CarService.Shared.Models.MaterialModel;
using CarService.Shared.Models.RepairModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.ConsumesModel
{
    public class ConsumesDetailModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ActivityId { get; set; }
        public ActivityDetailModel Activity { get; set; }
        public int MaterialId { get; set; }
        public MaterialDetailModel Material { get; set; }
    }
}
