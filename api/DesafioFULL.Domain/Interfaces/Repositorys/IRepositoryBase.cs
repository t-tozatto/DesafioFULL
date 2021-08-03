using System;
using System.Collections.Generic;

namespace DesafioFULL.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetByProperty(string property, dynamic value);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
