// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades;
using CarService.Shared.Models.InvoiceModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private const string ApiOperationBaseName = "Invoice";
        private readonly InvoiceFasade InvoiceFacade;
        public InvoiceController(InvoiceFasade InvoiceFacade)
        {
            this.InvoiceFacade = InvoiceFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<InvoiceListModel>> GetAll()
        {
            return InvoiceFacade.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<InvoiceDetailModel> GetById(int id)
        {
            return InvoiceFacade.GetById(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<InvoiceDetailModel> Create(InvoiceCreateModel Invoice)
        {
            return InvoiceFacade.Create(Invoice);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(InvoiceUpdateModel Invoice)
        {
            try
            {
                InvoiceFacade.Update(Invoice);
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
                InvoiceFacade.Delete(id);
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
