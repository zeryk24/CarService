using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class InvoiceEntity : BaseEntity
    {
        public DateTime ExposeDate { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
    }
}
