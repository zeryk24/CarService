using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class OrderEntity : BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public string CarSpz { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }
        public ICollection<InvoiceEntity> Invoices { get; set; }
        public ICollection<RepairEntity> Repairs { get; set; }
    }
}
