using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Persistence.Contexts;
using ILanguage.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Persistence.Repositories
{
    public class ResourceRepository : BaseRepository, IResourceRepository
    {
        public ResourceRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Resource>> ListAsync()
        {
            return await _context.Resources.Include(p => p.Session).ToListAsync();
        }

        public async Task<IEnumerable<Resource>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.Resources
                .Where(p => p.SessionId == sessionId)
                .Include(p => p.Session)
                .ToListAsync();

        }

        public async Task AddAsync(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
        }

        public async Task<Resource> FindById(int id)
        {
            return await _context.Resources.FindAsync(id);
        }


        public void Remove(Resource resource)
        {
            _context.Resources.Remove(resource);
        }

        public void Update(Resource resource)
        {
            _context.Resources.Update(resource);
        }
    }
}
