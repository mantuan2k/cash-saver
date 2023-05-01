using CashSaver.Helper;
using CashSaver.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CashSaver.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private readonly Hashtable repositories = new Hashtable();

        private bool disposed = false;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (!repositories.Contains(typeof(T)))
            {
                repositories.Add(typeof(T), new Repository<T>(_context));
            }

            return (IRepository<T>)repositories[typeof(T)]!;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
