using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class MechanicEntity : BaseEntity
    {
        public string Name { get; set; }
        public string ResidencePlace { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<RepairEntity> Repairs { get; set; }
    }
}
