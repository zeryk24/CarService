using CarService.BL.Fasades;
using CarService.Shared.Models.MaterialModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private const string ApiOperationBaseName = "Material";
        private readonly MaterialFasade MaterialFacade;
        public MaterialController(MaterialFasade MaterialFacade)
        {
            this.MaterialFacade = MaterialFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<MaterialListModel>> GetAll()
        {
            return MaterialFacade.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<MaterialDetailModel> GetById(int id)
        {
            return MaterialFacade.GetById(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<MaterialDetailModel> Create(MaterialCreateModel Material)
        {
            return MaterialFacade.Create(Material);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(MaterialUpdateModel Material)
        {
            try
            {
                MaterialFacade.Update(Material);
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
                MaterialFacade.Delete(id);
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
