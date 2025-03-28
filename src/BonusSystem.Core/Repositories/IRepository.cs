using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BonusSystem.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression = null, bool throwException = true);
        Task<T> AddAsync(T entity);
        Task<T> EditAsync(T entity, Action<EntityEntry<T>> rules = null);
        Task DeleteAsync(T entity);
        Task<int> SaveAsync();
    }
}
