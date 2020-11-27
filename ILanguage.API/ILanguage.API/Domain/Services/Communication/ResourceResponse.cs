using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services.Communication
{
    public class ResourceResponse : BaseResponse<Resource>
    {
        public ResourceResponse(Resource resource) : base(resource)
        {
        }

        public ResourceResponse(string message) : base(message)
        {
        }
    }
}
