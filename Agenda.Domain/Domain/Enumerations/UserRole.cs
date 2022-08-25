using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Core;

namespace Agenda.Domain.Domain.Enumerations
{
    public class UserRole : Enumeration
    {

        public static UserRole Admin = new UserRole(1,nameof(Admin));
        public static UserRole Common = new UserRole(2,nameof(Common));        
        protected UserRole(){}
        public UserRole(int id, string name)=> (Id,Name) = (id,name);
    }
}