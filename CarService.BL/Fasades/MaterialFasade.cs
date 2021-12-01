using CarService.BL.Fasades.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models.MaterialModel;
using CarService.DAL.Entities;
using CarService.DAL.Repositories;
using AutoMapper;
using CarService.DAL.Repositories.Interfaces;
namespace CarService.BL.Fasades
{
    public class MaterialFasade : EntityFacade<MaterialEntity, MaterialDetailModel, MaterialCreateModel, MaterialListModel, MaterialUpdateModel>
    {
        public MaterialFasade(IMaterialRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
