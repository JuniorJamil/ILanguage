using AutoMapper;
using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services;
using ILanguage.API.Extensions;
using ILanguage.API.Resources;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    
    [Route("api/[controller]")]
    public class AvailableSchedulesController : ControllerBase
    {

        private readonly IAvailableScheduleService _availableScheduleService;
        private readonly IMapper _mapper;

        public AvailableSchedulesController(IAvailableScheduleService availableScheduleService, IMapper mapper)
        {
            _availableScheduleService = availableScheduleService;
            _mapper = mapper;
        }


        [SwaggerOperation(
               Summary = "Add availableSchedule",
               Description = "Add new availableSchedule",
               OperationId = "AddAvailableSchedule",
               Tags = new[] { "AvailableSchedules" })]
        [SwaggerResponse(200, "Add AvailableSchedules", typeof(IEnumerable<AvailableScheduleResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<AvailableScheduleResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAvailableScheduleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var availableSchedule = _mapper.Map<SaveAvailableScheduleResource, AvailableSchedule>(resource);
            var result = await _availableScheduleService.SaveAsync(availableSchedule);

            if (!result.Success)
                return BadRequest(result.Message);

            var availableScheduleResource = _mapper.Map<AvailableSchedule, AvailableScheduleResource>(result.Resource);
            return Ok(availableScheduleResource);
        }



        [SwaggerOperation(
             Summary = "Update availableSchedule by User",
             Description = "Update a availableSchedule by User",
             OperationId = "UpdateAvailableSchedulebyUser",
             Tags = new[] { "AvailableSchedules" })]
        [SwaggerResponse(200, "Update AvailableSchedules by User", typeof(IEnumerable<AvailableScheduleResource>))]
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<AvailableScheduleResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveAvailableScheduleResource resource)
        {
            var availableSchedule = _mapper.Map<SaveAvailableScheduleResource, AvailableSchedule>(resource);
            var result = await _availableScheduleService.UpdateAsync(userId, availableSchedule);

            if (!result.Success)
                return BadRequest(result.Message);
            var availableScheduleResource = _mapper.Map<AvailableSchedule, AvailableScheduleResource>(result.Resource);
            return Ok(availableScheduleResource);
        }


    }
}
