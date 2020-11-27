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
    public class OutcomeReportRepository : BaseRepository, IOutcomeReportRepository
    {
        public OutcomeReportRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<OutcomeReport>> ListAsync()
        {
            return await _context.OutcomeReports.Include(p => p.Session).ToListAsync();
        }

        public async Task<IEnumerable<OutcomeReport>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.OutcomeReports
                .Where(p => p.SessionId == sessionId)
                .Include(p => p.Session)
                .ToListAsync();

        }

        public async Task AddAsync(OutcomeReport progress)
        {
            await _context.OutcomeReports.AddAsync(progress);
        }

        public async Task<OutcomeReport> FindById(int id)
        {
            return await _context.OutcomeReports.FindAsync(id);
        }


        public void Remove(OutcomeReport progress)
        {
            _context.OutcomeReports.Remove(progress);
        }

        public void Update(OutcomeReport progress)
        {
            _context.OutcomeReports.Update(progress);
        }
    }
}
