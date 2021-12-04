// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.InvoiceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.InvoiceProfile
{
    public class InvoiceUpdateProfile : Profile
    {
        public InvoiceUpdateProfile()
        {
            CreateMap<InvoiceEntity, InvoiceUpdateModel>().ReverseMap();
        }
    }
}
