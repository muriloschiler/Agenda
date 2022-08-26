using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;

namespace Agenda.Infrastructure.Unity
{
    public class UnitOfWork : IUnityOfWork
    {
        public AgendaDbContext _agendaDbContext { get; set; }
        public UnitOfWork(AgendaDbContext agendaDbContext)
        {
            this._agendaDbContext = agendaDbContext;

        }

        public async Task<bool> CommitChanges()
        {
            return await _agendaDbContext.SaveChangesAsync() > 0;
        }
    }
}