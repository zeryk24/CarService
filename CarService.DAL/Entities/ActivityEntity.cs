using CarService.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class ActivityEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public int RepairId { get; set; }
        public RepairEntity Repair { get; set; }
        public ICollection<ConsumesEntity> Consumes { get; set; }
    }
}
