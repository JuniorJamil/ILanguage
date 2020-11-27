using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Repositories
{
    public interface IOutcomeReportRepository
    {
        Task<IEnumerable<OutcomeReport>> ListAsync();
        Task<IEnumerable<OutcomeReport>> ListBySessionIdAsync(int sessionId);

        Task AddAsync(OutcomeReport outcomeReport);

        Task<OutcomeReport> FindById(int id);

        void Update(OutcomeReport outcomeReport);

        void Remove(OutcomeReport outcomeReport);
    }
}
