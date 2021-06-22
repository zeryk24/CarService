using CarService.DAL.Entities;
using CarService.DAL.Repositories.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DAL.Repositories.Interfaces
{
    interface IOrderRepository : IEntityRepository<OrderEntity>
    {
    }
}
