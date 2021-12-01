using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.InvoiceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.InvoiceProfile
{
    public class InvoiceCreateProfile : Profile
    {
        public InvoiceCreateProfile()
        {
            CreateMap<InvoiceEntity, InvoiceCreateModel>().ReverseMap();
        }
    }
}
