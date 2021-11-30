using CarService.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.ActivityModel
{
    public class ActivityUpdateModel
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
    }
}
