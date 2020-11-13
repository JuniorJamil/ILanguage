using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ILanguage.API.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;
using ILanguage.API.Resources;
using ILanguage.API.Domain.Models;
using ILanguage.API.Extensions;

namespace EasyNutrition.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SessionDatailsController : ControllerBase
    {
        private readonly ISessionDetailService _sessionDatailService;
        private readonly IMapper _mapper;

        public SessionDatailsController(ISessionDetailService sessionDetailService, IMapper mapper)
        {
            _sessionDatailService = sessionDetailService;
            _mapper = mapper;
        }


        [SwaggerOperation(
       Summary = "List all sessionDetail",
       Description = "List of sessionDetail",
       OperationId = "ListAllSessionDetails",
       Tags = new[] { "SessionDetails" })]
        [SwaggerResponse(200, "List of SessionDetail", typeof(IEnumerable<SessionDetailResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionDetailResource>), 200)]
        public async Task<IEnumerable<SessionDetailResource>> GetAllAsync()
        {
            var sessionDetails = await _sessionDatailService.ListAsync();
            var resources = _mapper.Map<IEnumerable<SessionDetails>, IEnumerable<SessionDetailResource>>(sessionDetails);
            return resources;
        }


        [SwaggerOperation(
            Summary = "Add SessionDetails",
            Description = "Add new Sessiondetails",
            OperationId = "AaddSessiondetail",
            Tags = new[] { "SessionDetails" })]
        [SwaggerResponse(200, "Add SessionDetail", typeof(IEnumerable<SessionDetailResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<SessionDetailResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSessionDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var sessions = _mapper.Map<SaveSessionDetailResource, SessionDetails>(resource);
            var result = await _sessionDatailService.SaveAsync(sessions);

            if (!result.Success)
                return BadRequest(result.Message);

            var sessionDetailResource = _mapper.Map<SessionDetails, SessionDetailResource>(result.Resource);
            return Ok(sessionDetailResource);
        }

        [SwaggerOperation(
           Summary = "Update sessionDetail by User",
           Description = "Update a sessionDetail by User",
           OperationId = "UpdateSessionDetailUser",
           Tags = new[] { "SessionDetails" })]
        [SwaggerResponse(200, "Update SessionDetails by User", typeof(IEnumerable<SessionDetailResource>))]
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<SessionDetailResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveSessionDetailResource resource)
        {
            var sessionDetail = _mapper.Map<SaveSessionDetailResource, SessionDetails>(resource);
            var result = await _sessionDatailService.UpdateAsync(userId, sessionDetail);

            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<SessionDetails, SessionDetailResource>(result.Resource);
            return Ok(subscriptionResource);
        }

        [SwaggerOperation(
      Summary = "Delete SessionDetails",
      Description = "Delete a SessionDetails",
      OperationId = "Deletesessiondetail",
      Tags = new[] { "SessionDetails" })]
        [SwaggerResponse(200, "Delete SessionDetails", typeof(IEnumerable<SessionDetailResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SessionDetailResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sessionDatailService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var sessionDetailResource = _mapper.Map<SessionDetails, SessionDetailResource>(result.Resource);
            return Ok(sessionDetailResource);
        }
    }

}
