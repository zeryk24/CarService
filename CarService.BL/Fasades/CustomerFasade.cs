// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.CustomerModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;
using CarService.DAL.Repositories.Interfaces;
namespace CarService.BL.Fasades
{
    public class CustomerFasade : EntityFacade<CustomerEntity, CustomerDetailModel, CustomerCreateModel, CustomerListModel, CustomerUpdateModel>
    {
        public CustomerFasade(ICustomerRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
