using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.RepairModel
{
    public class RepairCreateModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public int MechanicId { get; set; }
    }
}
