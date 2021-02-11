using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public static class FakeMarca
    {
        public static MarcaModel ObterMarcaModelDefault()
        {
            return new MarcaModel()
            {
                MarcaId = Guid.NewGuid(),
                Nome = "Ford",
                DataCriacao = DateTime.Now
            };
        }

        public static Marca ObterMarcaDefault()
        {
            return new Marca("Ford");
        }
    }
}
