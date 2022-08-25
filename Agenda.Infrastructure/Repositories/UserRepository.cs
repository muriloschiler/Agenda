using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Domain;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Data;
using Agenda.Infrastructure.Repositories.Core;

namespace Agenda.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AgendaDbContext agendaDbContext) : base(agendaDbContext)
        {}
    }
}