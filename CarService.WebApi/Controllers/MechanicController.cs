// Author: Jan Škvařil (xskvar09) 
using CarService.BL.Fasades;
using CarService.Shared.Models.MechanicModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MechanicController : ControllerBase
    {
        private const string ApiOperationBaseName = "Mechanic";
        private readonly MechanicFasade MechanicFacade;
        public MechanicController(MechanicFasade MechanicFacade)
        {
            this.MechanicFacade = MechanicFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<MechanicListModel>> GetAll()
        {
            return MechanicFacade.GetAll().ToList();
        }
        [HttpGet("WithoutWork")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAllWithoutWork))]
        public ActionResult<List<MechanicListModel>> GetAllWithoutWork()
        {
            return MechanicFacade.GetAllWithouWork().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<MechanicDetailModel> GetById(int id)
        {
            return MechanicFacade.GetById(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<MechanicDetailModel> Create(MechanicCreateModel Mechanic)
        {
            return MechanicFacade.Create(Mechanic);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(MechanicUpdateModel Mechanic)
        {
            try
            {
                MechanicFacade.Update(Mechanic);
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
                MechanicFacade.Delete(id);
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
