using DesafioFULL.Domain.Interfaces.Repositorys;
using DesafioFULL.Domain.Interfaces.Services;
using DesafioFULL.Domain.Models;

namespace DesafioFULL.Domain.Service
{
    public class ServiceParcela : ServiceBase<Parcela>, IServiceParcela
    {
        public readonly IRepositoryParcela _repositoryParcela;

        public ServiceParcela(IRepositoryParcela repositoryParcela)
            : base(repositoryParcela)
        {
            _repositoryParcela = repositoryParcela;
        }

        public void RemoveByTitulo(int titulo)
        {
            _repositoryParcela.RemoveByTitulo(titulo);
        }
    }
}
