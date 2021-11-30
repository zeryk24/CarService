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
        public int RepairId { get; set; }
        public RepairDetailModel Repair { get; set; }
        public int MaterialId { get; set; }
        public MaterialDetailModel Material { get; set; }
    }
}
