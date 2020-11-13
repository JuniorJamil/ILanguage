using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Repositories
{
    public interface ISessionDetailRepository
    {
        Task<IEnumerable<SessionDetails>> ListAsync();
        Task<IEnumerable<SessionDetails>> ListByUserIdAsync(int userId);
        Task<IEnumerable<SessionDetails>> ListBySessionIdAsync(int sesssionId);

        Task AddAsync(SessionDetails sessionDetail);

        Task<SessionDetails> FindById(int userId);
        Task<SessionDetails> FindByyId(int sessionId);

        void Update(SessionDetails sessionDetail);

        void Remove(SessionDetails sessionDetail);
    }
}
