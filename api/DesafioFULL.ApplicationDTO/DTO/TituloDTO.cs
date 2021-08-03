using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Application.DTO
{
    public class TituloDTO
    {
        public TituloDTO(int? id, long numero, string nomeDevedor, string cpfDevedor, decimal porcentagemJuros, decimal porcentagemMulta)
        {
            Id = id;
            Numero = numero;
            NomeDevedor = nomeDevedor;
            CpfDevedor = cpfDevedor;
            PorcentagemJuros = porcentagemJuros;
            PorcentagemMulta = porcentagemMulta;
        }

        public TituloDTO(int? id, long numero, string nomeDevedor, string cpfDevedor, decimal porcentagemJuros, decimal porcentagemMulta, IReadOnlyCollection<ParcelaDTO> parcela)
        {
            Id = id;
            Numero = numero;
            NomeDevedor = nomeDevedor;
            CpfDevedor = cpfDevedor;
            PorcentagemJuros = porcentagemJuros;
            PorcentagemMulta = porcentagemMulta;
            Parcela = parcela;
        }

        public TituloDTO()
        {

        }

        public int? Id { get; set; }
        public long Numero { get; set; }
        public string NomeDevedor { get; set; }
        public string CpfDevedor { get; set; }
        public decimal PorcentagemJuros { get; set; }
        public decimal PorcentagemMulta { get; set; }
        public IReadOnlyCollection<ParcelaDTO> Parcela { get; set; } = Array.Empty<ParcelaDTO>();

        public void setId(int id)
        {
            Id = id;
            foreach (ParcelaDTO p in Parcela)
                p.Titulo = id;
        }
    }
}
