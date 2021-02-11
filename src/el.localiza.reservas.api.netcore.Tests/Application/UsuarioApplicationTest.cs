using AutoMapper;
using el.localiza.reservas.api.netcore.Application;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Application
{
    public class UsuarioApplicationTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUsuarioRepository> _mockRepository;

        public UsuarioApplicationTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IUsuarioRepository>();
        }
        [Fact]
        public async Task SalvarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<UsuarioModel, Usuario>(It.IsAny<UsuarioModel>()))
                .Returns(FakeUsuario.ObtemUsuarioMatriculaDefault());

            //setup
            _mockRepository.Setup(x => x.Incluir(It.IsAny<Usuario>()));

            //application           
            var application = new UsuarioApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.SalvarAsync(It.IsAny<UsuarioModel>());

            Assert.IsType<Result<Usuario>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task AtualizarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<UsuarioModel, Usuario>(It.IsAny<UsuarioModel>()))
                .Returns(FakeUsuario.ObtemUsuarioCpfDefault());

            //setup
            _mockRepository.Setup(x => x.Atualizar(It.IsAny<Usuario>()));

            //application           
            var application = new UsuarioApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.AtualizarAsync(It.IsAny<UsuarioModel>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

        [Fact]
        public async Task ExcluirrAsync_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.Excluir(It.IsAny<Guid>()));

            //application           
            var application = new UsuarioApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ExcluirAsync(It.IsAny<Guid>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

        [Fact]
        public async Task ObtemListaReservasIdCliente_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.ObterListaPorPerfil(It.IsAny<PerfilUsuarioEnum>()))
                .ReturnsAsync(new List<Usuario>() { FakeUsuario.ObtemUsuarioMatriculaDefault() });

            //application           
            var application = new UsuarioApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ObterListaPorPerfilAsync(It.IsAny<PerfilUsuarioEnum>());

            Assert.IsType<Result<IList<Usuario>>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

    }
}
