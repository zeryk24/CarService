// Author: Jan Škvařil (xskvar09) 
using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.MaterialModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.Material
{
    public class MaterialDetailProfile : Profile
    {
        public MaterialDetailProfile()
        {
            CreateMap<MaterialEntity, MaterialDetailModel>();
        }
    }
}
