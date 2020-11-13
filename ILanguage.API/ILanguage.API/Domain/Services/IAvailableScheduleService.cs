using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services
{
    public interface IAvailableScheduleService
    {

        Task<IEnumerable<AvailableSchedule>> ListByUserIdAsync(int userId);

        Task<AvailableScheduleResponse> GetByIdAsync(int id);
        Task<AvailableScheduleResponse> SaveAsync(AvailableSchedule availableSchedule);
        Task<AvailableScheduleResponse> UpdateAsync(int id, AvailableSchedule availableSchedule);
    }
}

