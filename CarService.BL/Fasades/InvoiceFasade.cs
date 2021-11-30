using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.InvoiceModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;

namespace CarService.BL.Fasades
{
    class InvoiceFasade : EntityFacade<InvoiceEntity, InvoiceDetailModel, InvoiceCreateModel, InvoiceListModel, InvoiceUpdateModel>
    {
        public InvoiceFasade(InvoiceRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
