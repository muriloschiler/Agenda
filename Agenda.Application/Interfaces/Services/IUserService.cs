using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.ViewModels.User;

namespace Agenda.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetById(int id);
    }
}