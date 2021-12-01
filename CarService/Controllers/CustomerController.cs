using Microsoft.AspNetCore.Mvc;
using CarService.BL.Fasades;
using NSwag.Annotations;
using CarService.Shared.Models.CustomerModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private const string ApiOperationBaseName = "Customer";
        private readonly CustomerFasade CustomerFacade;
        public CustomerController(CustomerFasade CustomerFacade)
        {
            this.CustomerFacade = CustomerFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<CustomerListModel>> GetAll()
        {
            return CustomerFacade.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<CustomerDetailModel> GetById(int id)
        {
            return CustomerFacade.GetById(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<CustomerDetailModel> Create(CustomerCreateModel Customer)
        {
            return CustomerFacade.Create(Customer);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(CustomerUpdateModel Customer)
        {
            try
            {
                CustomerFacade.Update(Customer);
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
                CustomerFacade.Delete(id);
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