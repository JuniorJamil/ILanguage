using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services.Communication
{
    public class OutcomeReportResponse : BaseResponse<OutcomeReport>
    {
        public OutcomeReportResponse(OutcomeReport resource) : base(resource)
        {
        }

        public OutcomeReportResponse(string message) : base(message)
        {
        }
    }
}
