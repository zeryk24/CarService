using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.OrderModel
{
    public class OrderCreateModel
    {
        public DateTime CreationDate { get; set; }
        public string CarSpz { get; set; }
        public int CustomerId { get; set; }
    }
}
