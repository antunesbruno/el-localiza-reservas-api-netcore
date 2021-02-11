using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    [ExcludeFromCodeCoverage]
    public class VeiculoModel
    {        
        public string IdVeiculo { get; set; }        
        public string MarcaId { get; set; }
        public string ModeloId { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public double ValorHora { get; set; }
        public int CodigoCombustivel { get; set; }
        public string DescricaoCombustivel { get; set; }
        public int LimitePortaMalas { get; set; }
        public int CodigoCategoria { get; set; }
        public string DescricaoCategoria { get; set; }
        public MarcaModel Marca { get; set; }
        public ModeloModel Modelo { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class VeiculoModelRequest
    {
        public string MarcaId { get; set; }
        public string ModeloId { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public double ValorHora { get; set; }
        public int CodigoCombustivel { get; set; }
        public int LimitePortaMalas { get; set; }
        public int CodigoCategoria { get; set; }
    }
}
