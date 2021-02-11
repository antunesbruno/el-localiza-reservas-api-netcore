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
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Controllers
{
    [Collection("Mapper")]
    public class ModeloControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly Mock<IModeloApplication> _entidadeApplication;
        private readonly Mock<IModeloRepository> _entidadeRepository;
        private readonly Mock<IMapper> _mockMapper;

        public ModeloControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _mockMapper = new Mock<IMapper>();
            _entidadeApplication = new Mock<IModeloApplication>();
            _entidadeRepository = new Mock<IModeloRepository>();
        }

        [Fact]
        public async Task CriarModelo_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Modelo>(It.IsAny<ModeloModel>()))
                .Returns(FakeModelo.ObtemModeloDefault());

            _entidadeApplication.Setup(x => x.SalvarAsync(It.IsAny<ModeloModel>()))
                .ReturnsAsync(Result<Modelo>.Ok(FakeModelo.ObtemModeloDefault()));

            var controller = new ModeloController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.CriarModeloVeiculo(It.IsAny<ModeloModel>());

            Assert.IsType<CreatedResult>(response);
        }
    }
}
