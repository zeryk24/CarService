using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.InvoiceModel
{
    public class InvoiceCreateModel
    {
        public DateTime ExposeDate { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}
