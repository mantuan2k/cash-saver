using CashSaver.Domain;
using CashSaver.Domain.Services.Interfaces;
using CashSaver.Repositories;
using CashSaver.Repositories.Interfaces;
using System.Linq.Expressions;

namespace CashSaver.Services
{
    public class BillService : IService<Bill>
    {
        protected readonly IRepository<Bill> _repository;

        public BillService(IRepository<Bill> billRepository, IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.GetRepository<Bill>();
        }

        public void Add(Bill entity)
        {
            _repository.Add(entity);
        }

        public void AddMany(IEnumerable<Bill> entities)
        {
            _repository.AddMany(entities);
        }

        public IEnumerable<Bill> DeleteMany(IEnumerable<Bill> entities)
        {
            return _repository.DeleteMany(entities);
        }

        public bool Exists(Guid id)
        {
            return _repository.Exists(id);
        }

        public bool Exists(Expression<Func<Bill, bool>> filter)
        {
            return _repository.Exists(filter);
        }

        public IEnumerable<Bill> Get(Expression<Func<Bill, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public IQueryable<Bill> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Bill> GetAllAsNoTracking()
        {
            return _repository.GetAllAsNoTracking();
        }

        public Bill? GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<Bill> Query(Expression<Func<Bill, bool>> filter)
        {
            return _repository.Query(filter);
        }

        public IQueryable<Bill> QueryAsNoTracking(Expression<Func<Bill, bool>> filter)
        {
            return _repository.QueryAsNoTracking(filter);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public void Remove(Bill? entityToDelete)
        {
            _repository.Remove(entityToDelete);
        }

        public bool Save()
        {
            return _repository.Save();
        }

        public void Update(Bill entityToUpdate)
        {
            _repository.Update(entityToUpdate);
        }

        public void Update(Guid id)
        {
            var entityToUpdate = _repository.GetById(id);
            if(entityToUpdate == null)
            {
                throw new NullReferenceException();
            }
            _repository.Update(entityToUpdate);
        }

        public void Upsert(Bill entityToUpsert)
        {
            _repository.Upsert(entityToUpsert);
        }
    }
}
