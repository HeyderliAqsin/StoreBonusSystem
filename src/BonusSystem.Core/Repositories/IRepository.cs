using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BonusSystem.Core.Repositories
{
    public interface IRepository <T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T ,bool>> expression=null);
        T GetFirst(Expression<Func<T, bool>> expression=null,bool throwException=true);
        T Add(T entity);
        T Edit(T entity,Action<EntityEntry<T>> rules=null);
        void Delete(T entity);
        int Save();
    }
}
