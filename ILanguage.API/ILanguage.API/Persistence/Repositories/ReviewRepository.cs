using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Persistence.Contexts;
using ILanguage.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILanguage.API
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Review.Include(p => p.User).ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _context.Review.AddAsync(review);
        }

        public async Task<Review> FindById(int id)
        {
            return await _context.Review.FindAsync();
        }

        public void Update(Review review)
        {
            _context.Review.Update(review);
        }

        public void Remove(Review review)
        {
            _context.Review.Remove(review);
        }

    }
}