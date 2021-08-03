using DesafioFULL.Domain.Models;

namespace DesafioFULL.Domain.Interfaces.Repositorys
{
    public interface IRepositoryParcela : IRepositoryBase<Parcela>
    {
        void RemoveByTitulo(int titulo);
    }
}
