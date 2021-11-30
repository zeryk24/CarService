using CarService.Shared.Models.MechanicModel;
using CarService.Shared.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.RepairModel
{
    public class RepairDetailModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public OrderDetailModel Order { get; set; }
        public ICollection<OrderListModel> Activities { get; set; }
        public int MechanicId { get; set; }
        public MechanicDetailModel Mechanic { get; set; }
    }
}
