using System.Linq.Expressions;
using Agenda.Domain.Core;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> 
    where T: Register
    {
        Task<IEnumerable<T>> GetAllAsync(int skip, int take, Expression<Func<T,bool>> filter=null, bool asNoTracking=true);
        Task<T> GetByIdAsync(int id);
        Task<T> RegisterAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> DeleteAsync(T model);
        void AddPreQuery(Func<IQueryable<T>,IQueryable<T>> query);
        IQueryable<T> Query();
        Task<int> TotalCountAsync(Expression<Func<T,bool>> filter, bool asNoTracking=true );
    }
}