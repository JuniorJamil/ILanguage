using AutoMapper;
using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services;
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
    [EnableCors("AnotherPolicy")]
    [Route("/api/users/{userId}/availableSchedule")]
    public class UserAvailableSchedulesController : ControllerBase
    {
        private readonly IAvailableScheduleService _availableScheduleService;
        private readonly IMapper _mapper;

        public UserAvailableSchedulesController(IAvailableScheduleService availableScheduleService, IMapper mapper)
        {
            _availableScheduleService = availableScheduleService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List AvailableSchedule by User",
          Description = "List of AvailableSchedule by User",
          OperationId = "ListAvailableScheduleByUser",
          Tags = new[] { "AvailableSchedules" })]
        [SwaggerResponse(200, "List of Users", typeof(IEnumerable<AvailableScheduleResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AvailableScheduleResource>), 200)]
        public async Task<IEnumerable<AvailableScheduleResource>> GetAllByAvailableScheduleAsync(int userId)
        {
            var availableSchedules = await _availableScheduleService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<AvailableSchedule>, IEnumerable<AvailableScheduleResource>>(availableSchedules);
            return resources;
        }




    }
}