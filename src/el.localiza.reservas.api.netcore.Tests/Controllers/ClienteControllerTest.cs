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
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Controllers
{
    [Collection("Mapper")]
    public class ClienteControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly Mock<IClienteApplication> _clienteApplication;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IMapper> _mockMapper;

        public ClienteControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _mockMapper = new Mock<IMapper>();
            _clienteApplication = new Mock<IClienteApplication>();
            _clienteRepository = new Mock<IClienteRepository>();
        }    

        [Fact]
        public async Task CriarClientes_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Cliente>(It.IsAny<ClienteModel>()))
                .Returns(FakeCliente.ObtemClienteDefault());                

            _clienteApplication.Setup(x => x.SalvarAsync(It.IsAny<ClienteModel>()))
                .ReturnsAsync(Result<Cliente>.Ok(FakeCliente.ObtemClienteDefault()));
           
            var controller = new ClienteController(_mockMapper.Object, _clienteApplication.Object);
            var response = await controller.CriarClientes(It.IsAny<ClienteModel>());

            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task ObterClientePorId_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Cliente>(It.IsAny<ClienteModel>()))
                .Returns(FakeCliente.ObtemClienteDefault());

            _clienteApplication.Setup(x => x.ObterClientePorId(It.IsAny<Guid>()))
                .ReturnsAsync(Result<Cliente>.Ok(FakeCliente.ObtemClienteDefault()));

            var controller = new ClienteController(_mockMapper.Object, _clienteApplication.Object);
            var response = await controller.ObterClientePorId(It.IsAny<Guid>());

            Assert.IsType<OkObjectResult>(response);
        }

    }
}
