using DesafioFULL.Application.DTO;
using DesafioFULL.CrossCuting.Interface;
using DesafioFULL.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.CrossCuting.Map
{
    public class MapperTitulo : IMapperTitulo
    {
        private readonly IMapperParcela _mapperParcela;

        public MapperTitulo(IMapperParcela mapperParcela)
        {
            _mapperParcela = mapperParcela;
        }

        public Titulo MapperToEntity(TituloDTO tituloDTO)
        {
            return new Titulo(tituloDTO.Id,
                tituloDTO.Numero,
                tituloDTO.NomeDevedor,
                tituloDTO.CpfDevedor,
                tituloDTO.PorcentagemJuros,
                tituloDTO.PorcentagemMulta);
        }

        public IEnumerable<TituloDTO> MapperToDTO(IEnumerable<Titulo> titulos)
        {
            return titulos.Select(titulo => MapperToDTO(titulo));
        }

        public TituloDTO MapperToDTO(Titulo titulo)
        {
            return new TituloDTO(titulo.Id,
                titulo.Numero,
                titulo.NomeDevedor,
                titulo.CpfDevedor,
                titulo.PorcentagemJuros,
                titulo.PorcentagemMulta
            );
        }
    }
}
