using DesafioFULL.Domain.Interfaces.Repositorys;
using DesafioFULL.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DesafioFULL.Domain.Service
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }

        public virtual TEntity Add(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }


        public virtual void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetByProperty(string property, object id)
        {
            return _repository.GetByProperty(property, id);
        }
    }
}
