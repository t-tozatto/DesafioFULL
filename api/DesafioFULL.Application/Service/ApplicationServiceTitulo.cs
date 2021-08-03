using DesafioFULL.Application.DTO;
using DesafioFULL.Application.Interface;
using DesafioFULL.CrossCuting.Interface;
using DesafioFULL.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace DesafioFULL.Application.Service
{
    public class ApplicationServiceTitulo : IApplicationServiceTitulo
    {
        private readonly IServiceTitulo _serviceTitulo;
        private readonly IMapperTitulo _mapperTitulo;

        public ApplicationServiceTitulo(IServiceTitulo ServiceTitulo,
            IMapperTitulo MapperTitulo)

        {
            _serviceTitulo = ServiceTitulo;
            _mapperTitulo = MapperTitulo;
        }


        public int? Add(TituloDTO titulo)
        {
            return _serviceTitulo.Add(_mapperTitulo.MapperToEntity(titulo)).Id;
        }

        public void Dispose()
        {
            _serviceTitulo.Dispose();
        }

        public IEnumerable<TituloDTO> GetAll()
        {
            return _mapperTitulo.MapperToDTO(_serviceTitulo.GetAll());
        }

        public TituloDTO GetById(int id)
        {
            return _mapperTitulo.MapperToDTO(_serviceTitulo.GetById(id));
        }

        public void Remove(TituloDTO titulo)
        {
            _serviceTitulo.Remove(_mapperTitulo.MapperToEntity(titulo));
        }

        public void Update(TituloDTO titulo)
        {
            _serviceTitulo.Update(_mapperTitulo.MapperToEntity(titulo));
        }
    }
}
