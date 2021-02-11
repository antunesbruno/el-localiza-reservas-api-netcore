using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Reserva : Entity, IAggregateRoot
    {
        public Reserva() { }

        public Reserva(string idCliente, string idUsuario, string idVeiculo, int totalHoras, double valorTotalReserva, bool simulacao, bool efetivada, bool agendamento, DateTime dataSimulacao,
            DateTime dataPrevisaoRetirada, DateTime dataPrevisaoDevolucao, DateTime dataRetiradaReal, DateTime dataDevolucaoReal, double valorTotalPosChecklist)
        {
            IdCliente = idCliente;
            IdUsuario = idUsuario;
            IdVeiculo = idVeiculo;
            TotalHoras = totalHoras;
            ValorTotalReserva = valorTotalReserva;
            Simulacao = simulacao;
            Efetivada = efetivada;
            Agendamento = agendamento;
            DataSimulacao = dataSimulacao;
            DataPrevisaoRetirada = dataPrevisaoRetirada;
            DataPrevisaoDevolucao = dataPrevisaoDevolucao;
            DataRetiradaReal = dataRetiradaReal;
            DataDevolucaoReal = dataDevolucaoReal;
            ValorTotalPosChecklist = valorTotalPosChecklist;
            DataCriacao = DateTime.Now;
        }

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
        public DateTime DataCriacao { get; set; }
        public double ValorTotalPosChecklist { get; set; }


    }
}
