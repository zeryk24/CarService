﻿using AutoMapper;
using CarService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.BL.Profiles.ConsumesProfile
{
    public class ConsumesDetailProfile : Profile
    {
        public ConsumesDetailProfile()
        {
            CreateMap<ConsumesEntity, ConsumesDetailProfile>();
        }
    }
}