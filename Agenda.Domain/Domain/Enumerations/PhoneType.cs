using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Core;

namespace Agenda.Domain.Domain.Enumerations
{
    public class PhoneType: Enumeration
    {
        public static PhoneType Residencial = new PhoneType(1,nameof(Residencial));
        public static PhoneType Cellphone = new PhoneType(2,nameof(Cellphone));
        public static PhoneType Commercial = new PhoneType(3,nameof(Commercial));

        public PhoneType(){}
        public PhoneType(int id,string name) => (Id,Name) = (id,name);
    }
}