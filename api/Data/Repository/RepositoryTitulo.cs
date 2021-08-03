using Data;
using DesafioFULL.Domain.Interfaces.Repositorys;
using DesafioFULL.Domain.Models;

namespace DesafioFULL.Data.Repository
{
    public class RepositoryTitulo : RepositoryBase<Titulo>, IRepositoryTitulo
    {
        private readonly SqlContext _context;
        public RepositoryTitulo(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
