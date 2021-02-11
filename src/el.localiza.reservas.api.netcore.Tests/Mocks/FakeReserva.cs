using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public static class FakeReserva
    {
        public static ReservaModelRequest ObtemReservaRequestModelDefault()
        {
            return new ReservaModelRequest()
            {
                IdCliente = Guid.NewGuid().ToString(),
                IdUsuario = Guid.NewGuid().ToString(),
                IdVeiculo = Guid.NewGuid().ToString(),
                TotalHoras = 100,
                ValorTotalReserva = 250,
                Simulacao = true,
                Efetivada = false,
                Agendamento = true,
                DataSimulacao = DateTime.Now,
                DataPrevisaoRetirada = DateTime.Now,
                DataPrevisaoDevolucao = DateTime.Now,
                DataRetiradaReal = DateTime.Now,
                DataDevolucaoReal = DateTime.Now,
                ValorTotalPosChecklist = 500
            };
        }

        public static Reserva ObtemReservaDefault()
        {
            return new Reserva(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 100, 250,
                true, false, true, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, 500);

        }
    }
}
