// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades;
using CarService.Shared.Models.OrderModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private const string ApiOperationBaseName = "Order";
        private readonly OrderFasade OrderFacade;
        public OrderController(OrderFasade OrderFacade)
        {
            this.OrderFacade = OrderFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<OrderListModel>> GetAll()
        {
            return OrderFacade.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<OrderDetailModel> GetById(int id)
        {
            return OrderFacade.GetById(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<OrderDetailModel> Create(OrderCreateModel Order)
        {
            return OrderFacade.Create(Order);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(OrderUpdateModel Order)
        {
            try
            {
                OrderFacade.Update(Order);
            }
            catch (Exception)
            {
                return ValidationProblem();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(Delete))]
        public IActionResult Delete(int id)
        {
            try
            {
                OrderFacade.Delete(id);
            }
            catch (InvalidOperationException)
            {
                return ValidationProblem();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
