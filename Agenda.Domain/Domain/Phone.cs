using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Agenda.Domain.Domain.Enumerations;

namespace Agenda.Domain.Domain
{
    public class Phone : Register
    {
        public string FormattedNumber { get; set; }
        public int DDD { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

    }
}