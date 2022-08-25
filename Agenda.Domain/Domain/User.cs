using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Agenda.Domain.Domain.Enumerations;

namespace Agenda.Domain.Domain
{
    public class User : Register
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public IEnumerable<Interaction> Interactions { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    
    }
}