using CarService.BL.Fasades;
using CarService.Shared.Models.ActivityModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private const string ApiOperationBaseName = "Activity";
        private readonly ActivityFasade ActivityFacade;
        public ActivityController(ActivityFasade ActivityFacade)
        {
            this.ActivityFacade = ActivityFacade;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<ActivityListModel>> GetAll()
        {
            return ActivityFacade.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<ActivityDetailModel> GetById(int id)
        {
            return ActivityFacade.GetById(id);
        }
        [HttpGet("GetDate/{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetDate))]
        public ActionResult<DateTime> GetDate(int id)
        {
            try
            {
                return ActivityFacade.GetActivityDate(id);
            }
            catch (Exception)
            {
                return ValidationProblem();
            }
           
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<ActivityDetailModel> Create(ActivityCreateModel Activity)
        {
            return ActivityFacade.Create(Activity);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public IActionResult Update(ActivityUpdateModel Activity)
        {
            try
            {
                ActivityFacade.Update(Activity);
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
                ActivityFacade.Delete(id);
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
