﻿using CarService.Shared.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.RepairModel
{
    public class RepairListModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public OrderListModel Order { get; set; }
    }
}