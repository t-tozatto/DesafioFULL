using Data;
using DesafioFULL.Domain.Interfaces.Repositorys;
using DesafioFULL.Domain.Models;
using System.Collections.Generic;
using System.Linq;

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

        public void RemoveByTitulo(int titulo)
        {
            try
            {
                IEnumerable<Parcela> parcelas = GetAll().Where(x => x.Titulo == titulo);
                if (parcelas.Count() > 0)
                {
                    foreach (Parcela parcela in parcelas)
                        _context.Set<Parcela>().Remove(parcela);

                    _context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
