using AutoMapper;
using el.localiza.reservas.api.netcore.Application;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Application
{
    public class ClienteApplicationTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IClienteRepository> _mockRepository;

        public ClienteApplicationTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IClienteRepository>();
        }

        [Fact]
        public async Task ObterClientePorId_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.ListarPorId(It.IsAny<Guid>()))
                .ReturnsAsync(FakeCliente.ObtemClienteDefault());

            //application           
            var application = new ClienteApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ObterClientePorId(It.IsAny<Guid>());

            Assert.IsType<Result<Cliente>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task SalvarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<ClienteModel, Cliente>(It.IsAny<ClienteModel>()))
                .Returns(FakeCliente.ObtemClienteDefault());                

            //setup
            _mockRepository.Setup(x => x.ListarPorId(It.IsAny<Guid>()))
                .ReturnsAsync(FakeCliente.ObtemClienteDefault());

            //application           
            var application = new ClienteApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.SalvarAsync(It.IsAny<ClienteModel>());

            Assert.IsType<Result<Cliente>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task AtualizarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<ClienteModel, Cliente>(It.IsAny<ClienteModel>()))
                .Returns(FakeCliente.ObtemClienteDefault());

            //setup
            _mockRepository.Setup(x => x.Atualizar(It.IsAny<Cliente>()));

            //application           
            var application = new ClienteApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.AtualizarAsync(It.IsAny<ClienteModel>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

        [Fact]
        public async Task ExcluirrAsync_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.Excluir(It.IsAny<Guid>()));

            //application           
            var application = new ClienteApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ExcluirAsync(It.IsAny<Guid>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

    }
}
