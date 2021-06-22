using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
