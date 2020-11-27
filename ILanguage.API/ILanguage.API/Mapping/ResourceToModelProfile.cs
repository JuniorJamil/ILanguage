using AutoMapper;
using ILanguage.API.Domain.Models;
using ILanguage.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveRoleResource, Role>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveSessionResource, Session>();
            CreateMap<SaveSessionDetailResource, SessionDetails>();
            CreateMap<SaveComplaintResource, Complaint>();
            CreateMap<SaveSubscriptionResource, Subscription>();
            CreateMap<SaveScheduleResource, Schedule>();
            CreateMap<SaveResourceResource, Resource>();
            CreateMap<SaveReviewResource, Review>();


        }


    }
}
