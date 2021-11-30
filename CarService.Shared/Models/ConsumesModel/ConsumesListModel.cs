using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.ConsumesModel
{
    public class ConsumesListModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int RepairId { get; set; }
        public int MaterialId { get; set; }
    }
}
