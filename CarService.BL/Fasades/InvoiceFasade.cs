// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.InvoiceModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;
using CarService.DAL.Repositories.Interfaces;
namespace CarService.BL.Fasades
{
    public class InvoiceFasade : EntityFacade<InvoiceEntity, InvoiceDetailModel, InvoiceCreateModel, InvoiceListModel, InvoiceUpdateModel>
    {
        public InvoiceFasade(IInvoiceRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
