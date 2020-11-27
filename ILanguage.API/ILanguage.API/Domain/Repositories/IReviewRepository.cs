using ILanguage.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILanguage.API
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> ListAsync();
        Task AddAsync(Review review);

        Task<Review> FindById(int id);

        void Update(Review review);
        void Remove(Review review);

    }
}