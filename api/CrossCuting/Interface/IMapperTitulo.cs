using DesafioFULL.Application.DTO;
using DesafioFULL.Domain.Models;
using System.Collections.Generic;

namespace DesafioFULL.CrossCuting.Interface
{
    public interface IMapperTitulo
    {
        Titulo MapperToEntity(TituloDTO tituloDTO);
        IEnumerable<TituloDTO> MapperToDTO(IEnumerable<Titulo> titulo);
        TituloDTO MapperToDTO(Titulo titulo);
    }
}
