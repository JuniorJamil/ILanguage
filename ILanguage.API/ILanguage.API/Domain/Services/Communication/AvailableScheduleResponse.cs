using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services.Communication
{
    public class AvailableScheduleResponse : BaseResponse<AvailableSchedule>
    {
        public AvailableScheduleResponse(AvailableSchedule resource) : base(resource)
        {
        }

        public AvailableScheduleResponse(string message) : base(message)
        {
        }

    }
}
