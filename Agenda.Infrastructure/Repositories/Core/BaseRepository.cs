using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Agenda.Infrastructure.Repositories.Core
{
    public class BaseRepository<T> : IBaseRepository<T>
    where T : Register
    {
        private AgendaDbContext _agendaDbContext { get; set; }
        private DbSet<T> _dbSet{ get; set; }
        public IQueryable<T> _preQuery { get; set; }

        public BaseRepository(AgendaDbContext agendaDbContext )
        {
            _agendaDbContext=agendaDbContext;
            _dbSet = _agendaDbContext.Set<T>();
            _preQuery = _dbSet.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int skip, int take, Expression<Func<T, bool>> filter = null, bool asNoTracking = true)
        {
            return await GetQueryable(skip,take,filter,asNoTracking).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Query().FirstOrDefaultAsync(mo=> mo.Id == id);
        }

        public Task<T> RegisterAsync(T model)
        {
            
            EntityEntry<T> entityEntry = _dbSet.Add(model);
            return Task.FromResult(entityEntry.Entity);
        }
        public Task<T> UpdateAsync(T model)
        {
            EntityEntry<T> entityEntry = _dbSet.Update(model);
            return Task.FromResult(entityEntry.Entity);
        }
        public Task<T> DeleteAsync(T model)
        {
            EntityEntry<T> entityEntry = _dbSet.Remove(model);
            return Task.FromResult(entityEntry.Entity);        
        }

        public async Task<int> TotalCountAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true)
        {
            return (await GetQueryable(null, null, filter, asNoTracking).ToListAsync()).Count();
        }

        public void AddPreQuery(Func<IQueryable<T>, IQueryable<T>> query)
        {
            _preQuery = query.Invoke(_preQuery);
        }
    
        public IQueryable<T> Query()
        {
            return _preQuery;
        }
        protected IQueryable<T> GetQueryable
        (
            int? skip,
            int? take,
            Expression<Func<T, bool>> filter,
             bool asNoTracking
        )
        {
            IQueryable<T> query = Query();
            if (filter is not null)
                query = query.Where(filter);
            if (asNoTracking)
                query = query.AsNoTracking();
                
            if (skip.HasValue)
                query = query.Skip((int)skip);

            if (take.HasValue)
                query = query.Take((int)take);
            
            return query;
        }
    }
}