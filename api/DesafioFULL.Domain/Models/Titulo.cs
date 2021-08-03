using System;
using System.Collections.Generic;

namespace DesafioFULL.Domain.Models
{
    public class Titulo: Base
    {
        public Titulo(int? id, long numero, string nomeDevedor, string cpfdevedor, decimal porcentagemJuros, decimal porcentagemMulta)
            : base (id)
        {
            Numero = numero;
            NomeDevedor = nomeDevedor;
            CpfDevedor = cpfdevedor;
            PorcentagemJuros = porcentagemJuros;
            PorcentagemMulta = porcentagemMulta;
        }

        public Titulo()
        {

        }

        public long Numero { get; set;  }
        public string NomeDevedor { get; set; }
        public string CpfDevedor { get; set; }
        public decimal PorcentagemJuros { get; set; }
        public decimal PorcentagemMulta { get; set; }
    }
}
