using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Application.Exceptions
{
    public class NotAuthorizedException:Exception
    {
        public NotAuthorizedException() : base("O usuario nao tem permissao")
        {}
    }
}