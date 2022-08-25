using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.ViewModels.User;
using Agenda.Domain.Domain;
using AutoMapper;

namespace Agenda.Application.Mappers
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<UserRequest,User>().ReverseMap();
        }
    }
}