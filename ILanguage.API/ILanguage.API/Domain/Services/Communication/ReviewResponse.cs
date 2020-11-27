using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Services.Communication
{
    public class ReviewResponse : BaseResponse<Review>
    {
        public ReviewResponse(Review resource) : base(resource)
        {

        }

        public ReviewResponse(string message) : base(message)
        {
        }

    }

}

