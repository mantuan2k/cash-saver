using CashSaver.Domain;
using CashSaver.Helper;
using CashSaver.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CashSaver.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll() => _dbSet;

        public virtual IQueryable<T> GetAllAsNoTracking() => _dbSet.AsNoTracking();

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter) => _dbSet.Where(filter);

        public virtual T? GetById(Guid id) => _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return GetAll().Where(filter).AsQueryable();
        }

        public virtual IQueryable<T> QueryAsNoTracking(Expression<Func<T, bool>> filter)
        {
            return GetAllAsNoTracking().Where(filter).AsQueryable();
        }

        public bool Exists(Guid id) => _dbSet.Any((T e) => e.Id == id);

        public virtual bool Exists(Expression<Func<T, bool>> filter) => GetAllAsNoTracking().Where(filter).Any();

        public virtual void Add(T entity) => _dbSet.Add(entity);

        public virtual void AddMany(IEnumerable<T> entities) => _dbSet.AddRange(entities);

        public virtual IEnumerable<T> DeleteMany(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return entities;
        }

        public virtual void Remove(Guid id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(T? entityToDelete)
        {
            if (entityToDelete == null)
                return;

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Upsert(T entityToUpsert) => _dbSet.Update(entityToUpsert);

        public virtual bool Save() => _context.SaveChanges() > 0;
    }
}
