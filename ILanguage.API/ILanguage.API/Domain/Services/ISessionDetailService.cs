using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services
{
    public interface ISessionDetailService
    {
        Task<IEnumerable<SessionDetails>> ListAsync();
        Task<IEnumerable<SessionDetails>> ListByUserIdAsync(int userId);
        Task<IEnumerable<SessionDetails>> ListBySessionIdAsync(int sessionId);

        Task<SessionDetailResponse> GetByIdAsync(int id);
        Task<SessionDetailResponse> SaveAsync(SessionDetails sessionDetail);
        Task<SessionDetailResponse> UpdateAsync(int id, SessionDetails sessionDetail);
        Task<SessionDetailResponse> DeleteAsync(int id);
    }
}
