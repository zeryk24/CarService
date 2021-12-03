using AutoMapper;
using CarService.DAL.Entities;
using CarService.Shared.Models.RepairModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.RepairProfile
{
    public class RepairDetailProfile : Profile
    {
        public RepairDetailProfile()
        {
            CreateMap<RepairEntity, RepairDetailModel>();
        }
    }
}
