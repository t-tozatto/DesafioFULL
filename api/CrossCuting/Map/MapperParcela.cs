using DesafioFULL.Application.DTO;
using DesafioFULL.CrossCuting.Interface;
using DesafioFULL.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.CrossCuting.Map
{
    public class MapperParcela : IMapperParcela
    {
        public Parcela MapperToEntity(ParcelaDTO parcelaDTO)
        {
            return new Parcela(parcelaDTO.Id,
                parcelaDTO.Numero,
                parcelaDTO.DataVencimento,
                parcelaDTO.Valor,
                parcelaDTO.Titulo.Value);

        }

        public IEnumerable<ParcelaDTO> MapperListParcelas(IEnumerable<Parcela> parcelas)
        {
            return parcelas.Select(parcela => MapperToDTO(parcela));
        }

        public ParcelaDTO MapperToDTO(Parcela parcela)
        {
            return new ParcelaDTO
            {
                Id = parcela.Id,
                DataVencimento = parcela.DataVencimento,
                Numero = parcela.Numero,
                Valor = parcela.Valor
            };
        }

        public IEnumerable<Parcela> MapperToEntity(IEnumerable<ParcelaDTO> parcelaDTO)
        {
            return parcelaDTO.Select(dto => MapperToEntity(dto));
        }

        public IEnumerable<ParcelaDTO> MapperToDTO(IEnumerable<Parcela> parcela)
        {
            return parcela.Select(parcela => MapperToDTO(parcela));
        }
    }
}
