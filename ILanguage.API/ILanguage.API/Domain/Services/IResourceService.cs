using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> ListAsync();
        Task<IEnumerable<Resource>> ListBySessionIdAsync(int sessionId);

        Task<ResourceResponse> GetByIdAsync(int id);
        Task<ResourceResponse> SaveAsync(Resource resource);
        Task<ResourceResponse> UpdateAsync(int id, Resource resource);

        Task<ResourceResponse> DeleteAsync(int id);
    }
}
