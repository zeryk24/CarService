﻿using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.CustomerModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;

namespace CarService.BL.Fasades
{
    class CustomerFasade : EntityFacade<CustomerEntity, CustomerDetailModel, CustomerCreateModel, CustomerListModel, CustomerUpdateModel>
    {
        public CustomerFasade(CustomerRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
