// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades;
using CarService.Shared.Models.ConsumesModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumesController : ControllerBase
    {
        private const string ApiOperationBaseName = "Consumes";
        private readonly ConsumesFasade ConsumesFacade;
        public ConsumesController(ConsumesFasade ConsumesFacade)
        {
            this.ConsumesFacade = ConsumesFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<ConsumesListModel>> GetAll()
        {
            return ConsumesFacade.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<ConsumesDetailModel> GetById(int id)
        {
            return ConsumesFacade.GetById(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<ConsumesDetailModel> Create(ConsumesCreateModel Consumes)
        {
            return ConsumesFacade.Create(Consumes);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(ConsumesUpdateModel Consumes)
        {
            try
            {
                ConsumesFacade.Update(Consumes);
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
                ConsumesFacade.Delete(id);
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
