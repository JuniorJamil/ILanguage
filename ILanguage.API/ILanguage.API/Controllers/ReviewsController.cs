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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;


        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [SwaggerOperation(
        Summary = "List all reviews",
        Description = "List of expriences",
        OperationId = "ListAllReviews",
        Tags = new[] { "Reviews" })]
        [SwaggerResponse(200, "List of reviews", typeof(IEnumerable<ReviewResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
        public async Task<IEnumerable<ReviewResource>> GetAllAsync()
        {
            var review = await _reviewService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(review);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add review",
               Description = "Add new review",
               OperationId = "AddReview",
               Tags = new[] { "Reviews" })]
        [SwaggerResponse(200, "Add Review", typeof(IEnumerable<ReviewResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());

            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.SaveAsync(review);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);

        }

        [SwaggerOperation(
            Summary = "Update Review",
            Description = "Update a review",
            OperationId = "UpdateReview",
            Tags = new[] { "Reviews" })]
        [SwaggerResponse(200, "Update Review", typeof(IEnumerable<ReviewResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReviewResource resource)
        {
            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.UpdateAsync(id, review);

            if (!result.Success)
                return BadRequest(result.Message);
            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }


        [SwaggerOperation(
        Summary = "Delete review",
        Description = "Delete a review",
        OperationId = "DeleteReview",
        Tags = new[] { "Reviews" })]
        [SwaggerResponse(200, "Delete Review", typeof(IEnumerable<ReviewResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _reviewService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }



    }


}
