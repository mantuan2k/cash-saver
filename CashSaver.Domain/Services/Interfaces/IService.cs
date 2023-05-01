using System.Linq.Expressions;

namespace CashSaver.Domain.Services.Interfaces
{
    public interface IService<T>
    {
        void Add(T entity);
        void AddMany(IEnumerable<T> entities);
        IEnumerable<T> DeleteMany(IEnumerable<T> entities);
        bool Exists(Guid id);
        bool Exists(Expression<Func<T, bool>> filter);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllAsNoTracking();
        Bill? GetById(Guid id);
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        IQueryable<T> QueryAsNoTracking(Expression<Func<T, bool>> filter);
        void Remove(Guid id);
        void Remove(T? entityToDelete);
        bool Save();
        void Update(T entityToUpdate);
        void Update(Guid id);
        void Upsert(T entityToUpsert);
    }
}
