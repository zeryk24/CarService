using CarService.Shared.Enums;
using CarService.Shared.Models.MechanicActivityModel;
using CarService.Shared.Models.RepairModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.ActivityModel
{
    public class ActivityDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public int RepairId { get; set; }
        public RepairDetailModel Repair { get; set; }
        public ICollection<MechanicActivityListModel> MechanicActivities { get; set; }
    }
}
