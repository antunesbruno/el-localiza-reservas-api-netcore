using AutoMapper;
using el.localiza.reservas.api.netcore.Api.Controllers;
using el.localiza.reservas.api.netcore.Application;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Tests.Fixtures;
using el.localiza.reservas.api.netcore.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Controllers
{
    [Collection("Mapper")]
    public class MarcaControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly Mock<IMarcaApplication> _marcaApplication;
        private readonly Mock<IMarcaRepository> _marcaRepository;
        private readonly Mock<IMapper> _mockMapper;

        public MarcaControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _mockMapper = new Mock<IMapper>();
            _marcaApplication = new Mock<IMarcaApplication>();
            _marcaRepository = new Mock<IMarcaRepository>();
        }

        [Fact]
        public async Task CriarMarca_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Marca>(It.IsAny<MarcaModel>()))
                .Returns(FakeMarca.ObterMarcaDefault());

            _marcaApplication.Setup(x => x.SalvarAsync(It.IsAny<MarcaModel>()))
                .ReturnsAsync(Result<Marca>.Ok(FakeMarca.ObterMarcaDefault()));

            var controller = new MarcaController(_mockMapper.Object, _marcaApplication.Object);
            var response = await controller.CriarMarcaVeiculo(It.IsAny<MarcaModel>());

            Assert.IsType<CreatedResult>(response);
        }
    }
}
