using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    [ExcludeFromCodeCoverage]
    public class ReservaModel
    {
        public VeiculoModel Veiculo { get; set; }
        public UsuarioModel Usuario { get; set; }
        public ClienteModel Cliente { get; set; }
        public int TotalHoras { get; set; }
        public double ValorTotalReserva { get; set; }
        public bool Simulacao { get; set; }
        public bool Efetivada { get; set; }
        public bool Agendamento { get; set; }
        public DateTime DataSimulacao { get; set; }
        public DateTime DataPrevisaoRetirada { get; set; }
        public DateTime DataPrevisaoDevolucao { get; set; }
        public DateTime DataRetiradaReal { get; set; }
        public DateTime DataDevolucaoReal { get; set; }
        public double ValorTotalPosChecklist { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReservaModelRequest
    {
        public string IdCliente { get; set; }
        public string IdUsuario { get; set; }
        public string IdVeiculo { get; set; }
        public int TotalHoras { get; set; }
        public double ValorTotalReserva { get; set; }
        public bool Simulacao { get; set; }
        public bool Efetivada { get; set; }
        public bool Agendamento { get; set; }
        public DateTime DataSimulacao { get; set; }
        public DateTime DataPrevisaoRetirada { get; set; }
        public DateTime DataPrevisaoDevolucao { get; set; }
        public DateTime DataRetiradaReal { get; set; }
        public DateTime DataDevolucaoReal { get; set; }
        public double ValorTotalPosChecklist { get; set; }

    }
}


