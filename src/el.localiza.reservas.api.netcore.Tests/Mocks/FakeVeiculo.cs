using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public static class FakeVeiculo
    {
        public static VeiculoModelRequest ObtemVeiculoModelRequestDefault()
        {
            return new VeiculoModelRequest()
            {
                MarcaId = Guid.NewGuid().ToString(),
                ModeloId = Guid.NewGuid().ToString(),
                Placa = "OXS1122",
                Ano = 2020,
                ValorHora = 50,
                CodigoCombustivel = 0,
                LimitePortaMalas = 550,
                CodigoCategoria = 0
            };
        }

        public static Veiculo ObtemVeiculoDefault()
        {
            return new Veiculo("OXS1122", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 2020, 50, 0, 550, 0);
        }
    }
}
