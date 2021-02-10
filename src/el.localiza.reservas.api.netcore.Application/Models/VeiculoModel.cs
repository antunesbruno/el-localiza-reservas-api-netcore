using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    public class VeiculoModel
    {
        public string IdVeiculo { get; set; }
        public string Placa { get; set; }        
        public int Ano { get; set; }
        public double ValorHora { get; set; }
        public int CodigoCombustivel { get; set; }
        public int DescricaoCombustivel { get; set; }
        public int LimitePortaMalas { get; set; }
        public int CodigoCategoria { get; set; }
        public int DescricaoCategoria { get; set; }        
        public MarcaModel Marca { get; set; }
        public ModeloModel Modelo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
