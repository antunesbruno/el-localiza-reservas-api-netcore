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
    public class UsuarioControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly Mock<IUsuarioApplication> _entidadeApplication;
        private readonly Mock<IUsuarioRepository> _entidadeRepository;
        private readonly Mock<IMapper> _mockMapper;

        public UsuarioControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _mockMapper = new Mock<IMapper>();
            _entidadeApplication = new Mock<IUsuarioApplication>();
            _entidadeRepository = new Mock<IUsuarioRepository>();
        }

        [Fact]
        public async Task CriarUsuarioCliente_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Usuario>(It.IsAny<UsuarioModel>()))
                .Returns(FakeUsuario.ObtemUsuarioCpfDefault());

            _entidadeApplication.Setup(x => x.SalvarAsync(It.IsAny<UsuarioModel>()))
                .ReturnsAsync(Result<Usuario>.Ok(FakeUsuario.ObtemUsuarioCpfDefault()));

            var controller = new UsuarioController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.CriarUsuario(It.IsAny<UsuarioModel>());

            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task CriarUsuarioOperador_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Usuario>(It.IsAny<UsuarioModel>()))
                .Returns(FakeUsuario.ObtemUsuarioMatriculaDefault());

            _entidadeApplication.Setup(x => x.SalvarAsync(It.IsAny<UsuarioModel>()))
                .ReturnsAsync(Result<Usuario>.Ok(FakeUsuario.ObtemUsuarioMatriculaDefault()));

            var controller = new UsuarioController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.CriarUsuario(It.IsAny<UsuarioModel>());

            Assert.IsType<CreatedResult>(response);
        }

    }
}
