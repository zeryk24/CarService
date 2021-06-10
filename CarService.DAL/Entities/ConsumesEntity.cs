using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    class ConsumesEntity : BaseEntity
    {
        public int Amount { get; set; }
        public int RepairId { get; set; }
        public RepairEntity Repair { get; set; }
        public int MaterialId { get; set; }
        public MaterialEntity Material { get; set; }
    }
}
