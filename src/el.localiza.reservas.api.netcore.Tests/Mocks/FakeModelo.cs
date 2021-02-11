using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public static class FakeModelo
    {
        public static ModeloModel ObtemModeloModelDefault()
        {
            return new ModeloModel()
            {
                ModeloId = Guid.NewGuid(),
                Nome = "Ford Ka Sedan",
                MarcaId = Guid.NewGuid(),
                DataCriacao = DateTime.Now,
                ImagePath = "/images/KSND.png",
                Marca = FakeMarca.ObterMarcaModelDefault()
            };
        }

        public static Modelo ObtemModeloDefault()
        {
            return new Modelo("Ford Ka Sedan", Guid.NewGuid().ToString(), "/images/KSND.png");           
        }



    }
}
