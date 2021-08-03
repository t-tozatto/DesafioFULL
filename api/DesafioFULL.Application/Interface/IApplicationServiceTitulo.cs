using DesafioFULL.Application.DTO;
using System.Collections.Generic;

namespace DesafioFULL.Application.Interface
{
    public interface IApplicationServiceTitulo
    {
        int? Add(TituloDTO obj);

        TituloDTO GetById(int id);

        IEnumerable<TituloDTO> GetAll();

        void Update(TituloDTO obj);

        void Remove(TituloDTO obj);

        void Dispose();
    }
}
