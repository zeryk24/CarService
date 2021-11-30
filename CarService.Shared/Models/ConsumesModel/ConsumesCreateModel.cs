using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.ConsumesModel
{
    public class ConsumesCreateModel
    {
        public int Amount { get; set; }
        public int RepairId { get; set; }
        public int MaterialId { get; set; }
    }
}
