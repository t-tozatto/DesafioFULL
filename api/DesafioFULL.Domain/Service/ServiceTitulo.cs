using DesafioFULL.Domain.Interfaces.Repositorys;
using DesafioFULL.Domain.Interfaces.Services;
using DesafioFULL.Domain.Models;

namespace DesafioFULL.Domain.Service
{
    public class ServiceTitulo : ServiceBase<Titulo>, IServiceTitulo
    {
        public readonly IRepositoryTitulo _repositoryTitulo;

        public ServiceTitulo(IRepositoryTitulo repositoryTitulo)
            : base(repositoryTitulo)
        {
            _repositoryTitulo = repositoryTitulo;
        }
    }
}
