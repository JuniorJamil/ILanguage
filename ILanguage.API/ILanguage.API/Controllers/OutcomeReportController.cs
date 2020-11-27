using AutoMapper;
using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services;
using ILanguage.API.Extensions;
using ILanguage.API.Resources;
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
    public class OutcomeReportController : ControllerBase
    {
        private readonly IOutcomeReportService _outcomeReportService;
        private readonly IMapper _mapper;

        public OutcomeReportController(IOutcomeReportService outcomeReportService, IMapper mapper)
        {
            _outcomeReportService = outcomeReportService;
            _mapper = mapper;
        }

        [SwaggerOperation(
         Summary = "List all outcomeReports",
         Description = "List of outcomeReports",
         OperationId = "ListAllOutcomeReports",
         Tags = new[] { "OutcomeReport" })]
        [SwaggerResponse(200, "List of OutcomeReports", typeof(IEnumerable<OutcomeReportResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OutcomeReportResource>), 200)]
        public async Task<IEnumerable<OutcomeReportResource>> GetAllAsync()
        {
            var outcomeReport = await _outcomeReportService.ListAsync();
            var resources = _mapper.Map<IEnumerable<OutcomeReport>, IEnumerable<OutcomeReportResource>>(outcomeReport);
            return resources;
        }


        [SwaggerOperation(
              Summary = "Add OutcomeReports",
              Description = "Add new OutcomeReport",
              OperationId = "AddOutcomeReport",
              Tags = new[] { "OutcomeReport" })]
        [SwaggerResponse(200, "Add OutcomeReport", typeof(IEnumerable<OutcomeReportResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<OutcomeReportResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveOutcomeReportResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var outcomeReport = _mapper.Map<SaveOutcomeReportResource, OutcomeReport>(resource);
            var result = await _outcomeReportService.SaveAsync(outcomeReport);

            if (!result.Success)
                return BadRequest(result.Message);

            var outcomeReportResource = _mapper.Map<OutcomeReport, OutcomeReportResource>(result.Resource);
            return Ok(outcomeReportResource);
        }



        [SwaggerOperation(
            Summary = "Update outcomeReport",
            Description = "Update a outcomeReport",
            OperationId = "UpdateOutcomeReport",
            Tags = new[] { "OutcomeReport" })]
        [SwaggerResponse(200, "Update OutcomeReport", typeof(IEnumerable<OutcomeReportResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<OutcomeReportResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOutcomeReportResource resource)
        {
            var outcomeReport = _mapper.Map<SaveOutcomeReportResource, OutcomeReport>(resource);
            var result = await _outcomeReportService.UpdateAsync(id, outcomeReport);

            if (!result.Success)
                return BadRequest(result.Message);
            var outcomeReportResource = _mapper.Map<OutcomeReport, OutcomeReportResource>(result.Resource);
            return Ok(outcomeReportResource);
        }

        [SwaggerOperation(
         Summary = "Delete OutcomeReport",
         Description = "Delete a OutcomeReport",
         OperationId = "DeleteOutcomeReport",
         Tags = new[] { "OutcomeReport" })]
        [SwaggerResponse(200, "Delete OutcomeReport", typeof(IEnumerable<OutcomeReportResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<OutcomeReportResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _outcomeReportService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var outcomeReportResource = _mapper.Map<OutcomeReport, OutcomeReportResource>(result.Resource);
            return Ok(outcomeReportResource);
        }
    }
}
