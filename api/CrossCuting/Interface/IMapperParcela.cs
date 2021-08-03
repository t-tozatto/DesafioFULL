using DesafioFULL.Application.DTO;
using DesafioFULL.Domain.Models;
using System.Collections.Generic;

namespace DesafioFULL.CrossCuting.Interface
{
    public interface IMapperParcela
    {
        Parcela MapperToEntity(ParcelaDTO parcelaDTO);
        IEnumerable<Parcela> MapperToEntity(IEnumerable<ParcelaDTO> parcelaDTO);
        IEnumerable<ParcelaDTO> MapperToDTO(IEnumerable<Parcela> parcela);
        ParcelaDTO MapperToDTO(Parcela parcela);
    }
}
