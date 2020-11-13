using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Repositories
{
    public interface IAvailableScheduleRepository
    {
        Task<IEnumerable<AvailableSchedule>> ListByUserIdAsync(int userId);

        Task AddAsync(AvailableSchedule availableSchedule);
        Task<AvailableSchedule> FindById(int userId);
        void Update(AvailableSchedule availableSchedule);
        void Remove(AvailableSchedule availableSchedule);
    }
}
