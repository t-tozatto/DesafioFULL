using DesafioFULL.Application.DTO;
using System.Collections.Generic;

namespace DesafioFULL.Application.Interface
{
    public interface IApplicationServiceParcela
    {
        void Add(ParcelaDTO obj);

        ParcelaDTO GetById(int id);

        IEnumerable<ParcelaDTO> GetByProperty(string property, dynamic value);

        IEnumerable<ParcelaDTO> GetAll();

        void Update(ParcelaDTO obj);

        void Remove(ParcelaDTO obj);
        
        void RemoveByTitulo(int titulo);

        void Dispose();
    }
}
