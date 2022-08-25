using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.ViewModels.Core;
using Agenda.Application.ViewModels.User;
using Agenda.Domain.Domain;
using Agenda.Domain.Domain.Enumerations;
using AutoMapper;

namespace Agenda.Application.Mappers
{
    public class DomainToResponseProfile: Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<User,UserResponse>();
            
            CreateMap<UserRole,EnumerationViewModel>().ReverseMap();
        }
        
    }
}