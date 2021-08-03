using System.Collections.Generic;

namespace DesafioFULL.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetByProperty(string property, dynamic value);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
