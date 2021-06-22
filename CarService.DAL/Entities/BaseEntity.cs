using CarService.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
