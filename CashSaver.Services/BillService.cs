using CashSaver.Domain;
using CashSaver.Domain.Services.Interfaces;
using CashSaver.Repositories.Interfaces;
using System.Linq.Expressions;

namespace CashSaver.Services
{
    public class BillService : Domain.Services.Interfaces.IService<Bill>
    {
        protected readonly IRepository<Bill> _billRepository;

        public BillService(IRepository<Bill> billRepository)
        {
            _billRepository = billRepository;
        }

        public void Add(Bill entity)
        {
            _billRepository.Add(entity);
        }

        public void AddMany(IEnumerable<Bill> entities)
        {
            _billRepository.AddMany(entities);
        }

        public IEnumerable<Bill> DeleteMany(IEnumerable<Bill> entities)
        {
            return _billRepository.DeleteMany(entities);
        }

        public bool Exists(Guid id)
        {
            return _billRepository.Exists(id);
        }

        public bool Exists(Expression<Func<Bill, bool>> filter)
        {
            return _billRepository.Exists(filter);
        }

        public IEnumerable<Bill> Get(Expression<Func<Bill, bool>> filter)
        {
            return _billRepository.Get(filter);
        }

        public IQueryable<Bill> GetAll()
        {
            return _billRepository.GetAll();
        }

        public IQueryable<Bill> GetAllAsNoTracking()
        {
            return _billRepository.GetAllAsNoTracking();
        }

        public Bill? GetById(Guid id)
        {
            return _billRepository.GetById(id);
        }

        public IQueryable<Bill> Query(Expression<Func<Bill, bool>> filter)
        {
            return _billRepository.Query(filter);
        }

        public IQueryable<Bill> QueryAsNoTracking(Expression<Func<Bill, bool>> filter)
        {
            return _billRepository.QueryAsNoTracking(filter);
        }

        public void Remove(Guid id)
        {
            _billRepository.Remove(id);
        }

        public void Remove(Bill? entityToDelete)
        {
            _billRepository.Remove(entityToDelete);
        }

        public bool Save()
        {
            return _billRepository.Save();
        }

        public void Update(Bill entityToUpdate)
        {
            _billRepository.Update(entityToUpdate);
        }

        public void Upsert(Bill entityToUpsert)
        {
            _billRepository.Upsert(entityToUpsert);
        }
    }
}
