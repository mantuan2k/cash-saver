using CashSaver.Helper;
using CashSaver.Repositories.Interfaces;

namespace CashSaver.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        void Save();
        new void Dispose();
    }
}
