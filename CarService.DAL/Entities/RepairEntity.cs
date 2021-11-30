using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class RepairEntity : BaseEntity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public ICollection<ActivityEntity> Activities { get; set; }
        public int MechanicId { get; set; }
        public MechanicEntity Mechanic { get; set; }
    }
}
