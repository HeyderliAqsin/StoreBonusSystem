using BonusSystem.Core.Exceptions;
using BonusSystem.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BonusSystem.Core.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        protected DbContext DbContext { get => _dbContext; }
        protected DbSet<T> DbSet { get => _dbSet; }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            var queryDb = _dbSet.AsQueryable();

            if (expression is not null)
                queryDb = queryDb.Where(expression);
            return queryDb;
        }
        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression = null, bool throwException = true)
        {
            var queryDb = _dbSet.AsQueryable();

            if (expression is not null)
                queryDb = queryDb.Where(expression);
            var entity = queryDb.FirstOrDefault();
            if (entity is null && throwException)
                throw new NotFoundException($"{typeof(T).Name} : RECORD_NOT_FOUND");
            return entity;
        }
        public async Task<T> EditAsync(T entity, Action<EntityEntry<T>> rules = null)
        {
            var entry = _dbContext.Entry(entity);
            if (rules is null)
            {
                entry.State = EntityState.Modified;
                return entity;
            }
            var editableProperties = typeof(T)
                                    .GetProperties()
                                    .Where(m => m.IsEditable())
                                    .ToList();
            foreach (var propertyInfo in editableProperties)
            {
                entry.Property(propertyInfo.Name).IsModified = false;
            }
            rules(entry);
            entry.State = EntityState.Modified;
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<int> SaveAsync()
        {
            return _dbContext.SaveChanges();
        }
    }
}
