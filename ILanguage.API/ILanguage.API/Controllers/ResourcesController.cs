using AutoMapper;
using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services;
using ILanguage.API.Domain.Services.Communication;
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
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly IMapper _mapper;

        public ResourcesController(IResourceService resourceService, IMapper mapper)
        {
            _resourceService = resourceService;
            _mapper = mapper;
        }

        [SwaggerOperation(
         Summary = "List all resources",
         Description = "List of resources",
         OperationId = "ListAllResources",
         Tags = new[] { "Resources" })]
        [SwaggerResponse(200, "List of Resources", typeof(IEnumerable<ResourceResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResourceResource>), 200)]
        public async Task<IEnumerable<ResourceResource>> GetAllAsync()
        {
            var resources1 = await _resourceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Resource>, IEnumerable<ResourceResource>>(resources1);
            return resources;
        }


        [SwaggerOperation(
              Summary = "Add Resources",
              Description = "Add new Resource",
              OperationId = "AddResource",
              Tags = new[] { "Resources" })]
        [SwaggerResponse(200, "Add Resource", typeof(IEnumerable<ResourceResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ResourceResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveResourceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var resources = _mapper.Map<SaveResourceResource, Resource>(resource);
            var result = await _resourceService.SaveAsync(resources);

            if (!result.Success)
                return BadRequest(result.Message);

            var resourceResource = _mapper.Map<Resource, ResourceResource>(result.Resource);
            return Ok(resourceResource);
        }



        [SwaggerOperation(
            Summary = "Update resource",
            Description = "Update a resource",
            OperationId = "UpdateResource",
            Tags = new[] { "Resources" })]
        [SwaggerResponse(200, "Update Sessions", typeof(IEnumerable<ResourceResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ResourceResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveResourceResource resource)
        {
            var resource1 = _mapper.Map<SaveResourceResource, Resource>(resource);
            var result = await _resourceService.UpdateAsync(userId, resource1);

            if (!result.Success)
                return BadRequest(result.Message);
            var resourceResource = _mapper.Map<Resource, ResourceResource>(result.Resource);
            return Ok(resourceResource);
        }

        [SwaggerOperation(
         Summary = "Delete Resource",
         Description = "Delete a Resource",
         OperationId = "DeleteResource",
         Tags = new[] { "Resources" })]
        [SwaggerResponse(200, "Delete Resources", typeof(IEnumerable<ResourceResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ResourceResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _resourceService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var resourceResource = _mapper.Map<Resource, ResourceResource>(result.Resource);
            return Ok(resourceResource);
        }

        [SwaggerOperation(
            Summary = "List resources by session",
            Description = "List of resources for an specific Session",
            OperationId = "ListResourceBySession",
            Tags = new[] { "Resources" })]
        [HttpGet("{sessionId}")]
        [ProducesResponseType(typeof(IEnumerable<ResourceResource>), 200)]
        public async Task<IEnumerable<ResourceResource>> GetResourcesBySessionId(int sessionId)
        {
            var resources1 = await _resourceService.ListBySessionIdAsync(sessionId);
            var resources = _mapper
                .Map<IEnumerable<Resource>, IEnumerable<ResourceResource>>(resources1);
            return resources;
        }

    }
}
