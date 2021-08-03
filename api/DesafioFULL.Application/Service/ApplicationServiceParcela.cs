using DesafioFULL.Application.DTO;
using DesafioFULL.Application.Interface;
using DesafioFULL.CrossCuting.Interface;
using DesafioFULL.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace DesafioFULL.Application.Service
{
    public class ApplicationServiceParcela : IApplicationServiceParcela
    {
        private readonly IServiceParcela _serviceParcela;
        private readonly IMapperParcela _mapperParcela;

        public ApplicationServiceParcela(IServiceParcela ServiceParcela,
            IMapperParcela MapperParcela)

        {
            _serviceParcela = ServiceParcela;
            _mapperParcela = MapperParcela;
        }


        public void Add(ParcelaDTO parcela)
        {
            _serviceParcela.Add(_mapperParcela.MapperToEntity(parcela));
        }

        public void Dispose()
        {
            _serviceParcela.Dispose();
        }

        public IEnumerable<ParcelaDTO> GetAll()
        {
            return _mapperParcela.MapperToDTO(_serviceParcela.GetAll());
        }

        public ParcelaDTO GetById(int id)
        {
            return _mapperParcela.MapperToDTO(_serviceParcela.GetById(id));
        }

        public IEnumerable<ParcelaDTO> GetByProperty(string property, dynamic value)
        {
            return _mapperParcela.MapperToDTO(_serviceParcela.GetByProperty(property, value));
        }

        public void Remove(ParcelaDTO parcela)
        {
            _serviceParcela.Remove(_mapperParcela.MapperToEntity(parcela));
        }

        public void Update(ParcelaDTO parcela)
        {
            _serviceParcela.Update(_mapperParcela.MapperToEntity(parcela));
        }
    }
}
