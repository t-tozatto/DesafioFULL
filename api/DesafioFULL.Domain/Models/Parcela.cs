using System;

namespace DesafioFULL.Domain.Models
{
    public class Parcela: Base
    {
        public Parcela(int? id, int numero, DateTime dataVencimento, decimal valor, int titulo)
            : base(id)
        {
            Numero = numero;
            DataVencimento = dataVencimento;
            Valor = valor;
            Titulo = titulo;
        }

        public Parcela()
        {

        }

        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public int Titulo { get; set; }
    }
}
