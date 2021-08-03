using Data;
using DesafioFULL.Domain.Interfaces.Repositorys;
using DesafioFULL.Domain.Models;

namespace DesafioFULL.Data.Repository
{
    public class RepositoryParcela : RepositoryBase<Parcela>, IRepositoryParcela
    {
        private readonly SqlContext _context;
        public RepositoryParcela(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
