using CashSaver.Domain;
using CashSaver.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CashSaver.Repositories
{
    public class BillRepository : IService<Bill>
    {
        protected readonly DbContext _context;
        protected DbSet<Bill> _dbSet;

        public BillRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Bill>();
        }

        public virtual IQueryable<Bill> GetAll() => _dbSet;

        public virtual IQueryable<Bill> GetAllAsNoTracking() => _dbSet.AsNoTracking();

        public virtual IEnumerable<Bill> Get(Expression<Func<Bill, bool>> filter) => _dbSet.Where(filter);

        public virtual Bill? GetById(Guid id) => _dbSet.FirstOrDefault(x => x.Id == id);

        public virtual IQueryable<Bill> Query(Expression<Func<Bill, bool>> filter)
        {
            return GetAll().Where(filter).AsQueryable();
        }

        public virtual IQueryable<Bill> QueryAsNoTracking(Expression<Func<Bill, bool>> filter)
        {
            return GetAllAsNoTracking().Where(filter).AsQueryable();
        }

        public bool Exists(Guid id) => _dbSet.Any((Bill e) => e.Id == id);

        public virtual bool Exists(Expression<Func<Bill, bool>> filter) => GetAllAsNoTracking().Where(filter).Any();

        public virtual void Add(Bill entity) => _dbSet.Add(entity);

        public virtual void AddMany(IEnumerable<Bill> entities) => _dbSet.AddRange(entities);

        public virtual IEnumerable<Bill> DeleteMany(IEnumerable<Bill> entities)
        {
            _dbSet.RemoveRange(entities);
            return entities;
        }

        public virtual void Remove(Guid id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(Bill? entityToDelete)
        {
            if (entityToDelete == null)
                return;

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(Bill entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Upsert(Bill entityToUpsert) => _dbSet.Update(entityToUpsert);

        public virtual bool Save() => _context.SaveChanges() > 0;
    }
}
