using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services
{
    public interface IOutcomeReportService
    {
        Task<IEnumerable<OutcomeReport>> ListAsync();
        Task<IEnumerable<OutcomeReport>> ListBySessionIdAsync(int sessionId);

        Task<OutcomeReportResponse> GetByIdAsync(int id);
        Task<OutcomeReportResponse> SaveAsync(OutcomeReport outcomeReport);
        Task<OutcomeReportResponse> UpdateAsync(int id, OutcomeReport outcomeReport);

        Task<OutcomeReportResponse> DeleteAsync(int id);
    }
}
