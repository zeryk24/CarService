using CarService.Shared.Models.CustomerModel;
using CarService.Shared.Models.InvoiceModel;
using CarService.Shared.Models.RepairModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.OrderModel
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CarSpz { get; set; }
        public int CustomerId { get; set; }
        public CustomerDetailModel Customer { get; set; }
        public ICollection<InvoiceListModel> Invoices { get; set; }
        public ICollection<RepairListModel> Repairs { get; set; }
    }
}
