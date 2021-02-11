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
    public class VeiculoControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly Mock<IVeiculoApplication> _entidadeApplication;
        private readonly Mock<IVeiculoRepository> _entidadeRepository;
        private readonly Mock<IMapper> _mockMapper;

        public VeiculoControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _mockMapper = new Mock<IMapper>();
            _entidadeApplication = new Mock<IVeiculoApplication>();
            _entidadeRepository = new Mock<IVeiculoRepository>();
        }

        [Fact]
        public async Task CriarVeiculo_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Veiculo>(It.IsAny<VeiculoModel>()))
                .Returns(FakeVeiculo.ObtemVeiculoDefault());

            _entidadeApplication.Setup(x => x.SalvarAsync(It.IsAny<VeiculoModelRequest>()))
                .ReturnsAsync(Result<Veiculo>.Ok(FakeVeiculo.ObtemVeiculoDefault()));

            var controller = new VeiculoController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.CriarVeiculo(It.IsAny<VeiculoModelRequest>());

            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task ObterVeiculoPorId_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Veiculo>(It.IsAny<VeiculoModel>()))
                .Returns(FakeVeiculo.ObtemVeiculoDefault());

            _entidadeApplication.Setup(x => x.ObterVeiculoPorIdAsync(It.IsAny<string>()))
                .ReturnsAsync(Result<Veiculo>.Ok(FakeVeiculo.ObtemVeiculoDefault()));

            var controller = new VeiculoController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.ObterVeiculoPorId(It.IsAny<string>());

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task ObterVeiculoPorCategoria_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Veiculo>(It.IsAny<VeiculoModel>()))
                .Returns(FakeVeiculo.ObtemVeiculoDefault());

            _entidadeApplication.Setup(x => x.ObterVeiculosPorCategoriaAsync(It.IsAny<int>()))
                .ReturnsAsync(Result<IList<Veiculo>>.Ok(new List<Veiculo>() { FakeVeiculo.ObtemVeiculoDefault() }));

            var controller = new VeiculoController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.ObterVeiculosPorCategoria(It.IsAny<int>());

            Assert.IsType<OkObjectResult>(response);
        }
    }
}
