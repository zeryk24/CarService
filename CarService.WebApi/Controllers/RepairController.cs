// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades;
using CarService.Shared.Models.RepairModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairController : ControllerBase
    {
        private const string ApiOperationBaseName = "Repair";
        private readonly RepairFasade RepairFacade;
        public RepairController(RepairFasade RepairFacade)
        {
            this.RepairFacade = RepairFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<RepairListModel>> GetAll()
        {
            return RepairFacade.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<RepairDetailModel> GetById(int id)
        {
            return RepairFacade.GetById(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<RepairDetailModel> Create(RepairCreateModel Repair)
        {
            return RepairFacade.Create(Repair);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(RepairUpdateModel Repair)
        {
            try
            {
                RepairFacade.Update(Repair);
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
                RepairFacade.Delete(id);
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
