﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.CustomerModel
{
    public class CustomerListModel : IListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
