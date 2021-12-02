using CarService.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.ActivityModel
{
    public class ActivityCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public int RepairId { get; set; }
    }
}
