using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class ConsumesEntity : BaseEntity
    {
        public int Amount { get; set; }
        public int ActivityId { get; set; }
        public ActivityEntity Activity { get; set; }
        public int MaterialId { get; set; }
        public MaterialEntity Material { get; set; }
    }
}
