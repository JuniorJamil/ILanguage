using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> ListAsync();
        Task<ReviewResponse> SaveAsync(Review review);

        Task<ReviewResponse> UpdateAsync(int id, Review review);

        Task<ReviewResponse> DeleteAsync(int id);

    }

}
