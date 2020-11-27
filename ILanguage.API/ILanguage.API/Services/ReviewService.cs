using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Repositories;
using ILanguage.API.Domain.Services;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;

        }


        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _reviewRepository.ListAsync();
        }

        public async Task<ReviewResponse> SaveAsync(Review review)
        {
            try
            {
                await _reviewRepository.AddAsync(review);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(review);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while saving review:{ ex.Message}");
            }

        }

        public async Task<ReviewResponse> UpdateAsync(int id, Review review)
        {
            var existingReview = await _reviewRepository.FindById(id);

            if (existingReview == null)
                return new ReviewResponse("Complaint not found");

            existingReview.Description = review.Description;

            try
            {
                _reviewRepository.Update(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while updating review: {ex.Message}");
            }

        }

        public async Task<ReviewResponse> DeleteAsync(int id)
        {
            var existingReview = await _reviewRepository.FindById(id);

            if (existingReview == null)
                return new ReviewResponse("Review not found");

            try
            {
                _reviewRepository.Remove(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while deleting review:{ex.Message}");
            }

        }

    }


}
