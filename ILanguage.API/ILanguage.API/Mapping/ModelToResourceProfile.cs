﻿using AutoMapper;
using ILanguage.API.Domain.Models;
using ILanguage.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Role, RoleResource>();
            CreateMap<User, UserResource>();
            CreateMap<Session, SessionResource>();
            CreateMap<AvailableSchedule, AvailableScheduleResource>();
            CreateMap<SessionDetails, SessionDetailResource>();

        }
    }
}
