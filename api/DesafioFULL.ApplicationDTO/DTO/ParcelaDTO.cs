using System;
using System.Text.Json.Serialization;

namespace DesafioFULL.Application.DTO
{
    public class ParcelaDTO
    {
        public int? Id { get; set; }
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }

        [JsonIgnore]
        public int? Titulo { get; set; }
    }
}
