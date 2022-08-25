using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.ViewModels.Core;

namespace Agenda.Application.ViewModels.User
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public EnumerationViewModel UserRole { get; set; }
    }
}