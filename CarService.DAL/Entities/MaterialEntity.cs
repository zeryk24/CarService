using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class MaterialEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float StockQuantity { get; set; }
        public ICollection<ConsumesEntity> Consumes { get; set; }
    }
}
