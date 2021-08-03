using DesafioFULL.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.ApplicationDTO.DTO
{
    public class TituloFrontDTO
    {
        public int Id { get; set; }
        public long Numero { get; set; }
        public string NomeDevedor { get; set; }
        public string CpfDevedor { get; set; }
        public string PorcentagemJuros { get; set; }
        public string PorcentagemMulta { get; set; }
        public int DiasAtraso { get; set; }
        public string ValorAtualizado { get; set; }
        public string ValorTotal { get; set; }
        public List<ParcelaFrontDTO> Parcela { get; set; } = Array.Empty<ParcelaFrontDTO>().ToList();

        public TituloFrontDTO(TituloDTO titulo)
        {
            Id = titulo.Id.HasValue ? titulo.Id.Value : 0;
            Numero = titulo.Numero;
            NomeDevedor = titulo.NomeDevedor;
            CpfDevedor = titulo.CpfDevedor;
            PorcentagemJuros = titulo.PorcentagemJuros.ToString("N2");
            PorcentagemMulta = titulo.PorcentagemMulta.ToString("N2");

            IEnumerable<ParcelaDTO> parcelasAtraso = titulo.Parcela.Where(x => x.DataVencimento < DateTime.Now);

            if (parcelasAtraso != null && parcelasAtraso.Count() > 0)
                DiasAtraso = DateTime.Now.Subtract(parcelasAtraso
                    .OrderBy(x => x.DataVencimento).ElementAt(0).DataVencimento).Days;
            else
                DiasAtraso = 0;

            decimal valorOriginal = titulo.Parcela.Sum(x => x.Valor);
            ValorTotal = valorOriginal.ToString("N2");
            decimal totalJuros = 0;

            foreach (ParcelaDTO p in titulo.Parcela)
            {
                if (DateTime.Now > p.DataVencimento)
                    totalJuros += ((titulo.PorcentagemJuros / 100) / 30) * DateTime.Now.Subtract(p.DataVencimento).Days * p.Valor;

                Parcela.Add(new ParcelaFrontDTO(p.Id.HasValue ? p.Id.Value : 0,
                    p.Numero,
                    p.DataVencimento.ToString("dd/MM/yyyy"),
                    p.Valor.ToString("N2")));
            }
            decimal valorMulta = DiasAtraso > 0 ? ((valorOriginal * titulo.PorcentagemMulta) / 100) : 0;
            ValorAtualizado = (valorOriginal + valorMulta + totalJuros).ToString("N2");
        }
    }

    public class ParcelaFrontDTO
    {
        public ParcelaFrontDTO(int id, int numero, string dataVencimento, string valor)
        {
            Id = id;
            Numero = numero;
            DataVencimento = dataVencimento;
            Valor = valor;
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public string DataVencimento { get; set; }
        public string Valor { get; set; }
    }
}
