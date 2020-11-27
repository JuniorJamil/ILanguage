using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Repositories
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> ListAsync();
        Task<IEnumerable<Resource>> ListBySessionIdAsync(int sessionId);

        Task AddAsync(Resource resource);

        Task<Resource> FindById(int id);

        void Update(Resource resource);

        void Remove(Resource resource);
    }
}
