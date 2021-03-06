using CarService.Shared.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.OrderModel
{
    public class OrderListModel : IListModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CarSpz { get; set; }
        public int CustomerId { get; set; }
        public CustomerListModel Customer { get; set; }
    }
}
