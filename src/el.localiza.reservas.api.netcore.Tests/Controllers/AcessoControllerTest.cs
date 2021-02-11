using AutoMapper;
using el.localiza.reservas.api.netcore.Api.Controllers;
using el.localiza.reservas.api.netcore.Application;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;
using el.localiza.reservas.api.netcore.Tests.Fixtures;
using el.localiza.reservas.api.netcore.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Controllers
{
    [Collection("Mapper")]
    public class AcessoControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly Mock<IAcessoApplication> _mockAcessoApplication;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IMapper> _mockMapper;

        public AcessoControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _mockMapper = new Mock<IMapper>();
            _mockAcessoApplication = new Mock<IAcessoApplication>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
        }

        [Theory]
        [MemberData(nameof(FakeLogin.GetLoginOKDataGenerator), MemberType = typeof(FakeLogin))]
        public async Task ValidarDadosAcessoUsuario_Sucesso(LoginModel clienteLogin, LoginModel operadorLogin)
        {
            //login cliente
            var cliente = new Usuario(clienteLogin.Usuario, clienteLogin.Senha, new Nome("Jose", "Silva"), new CPF(clienteLogin.Usuario), new Email("cliente@gmail.com"), PerfilUsuarioEnum.Cliente);

            //login operador
            var operador = new Usuario(operadorLogin.Usuario, operadorLogin.Senha, new Nome("Jose", "Silva"), operadorLogin.Usuario, new Email("operador@localiza.com"), PerfilUsuarioEnum.Operador);

            //mapping
            _mockMapper.SetupSequence(m => m.Map<Usuario>(It.IsAny<UsuarioModel>()))
                .Returns(cliente)
                .Returns(operador);

            //setup
            _mockAcessoApplication.SetupSequence(x => x.ValidarDadosAcesso(It.IsAny<LoginModel>()))
                .ReturnsAsync(Result<Usuario>.Ok(cliente))
                .ReturnsAsync(Result<Usuario>.Ok(operador));

            //controller
            var acessoController = new AcessoController(_mapperFixture.Mapper, _mockAcessoApplication.Object);
            var response = await acessoController.ValidaAcessoUsuario(It.IsAny<LoginModel>());

            Assert.IsType<OkObjectResult>(response);     
        }

        [Theory]
        [InlineData("12345678", "password123")]
        [InlineData("000000", "password123")]
        [InlineData("", "password123")]
        [InlineData("04183319988", "")]
        public async Task ValidarDadosAcessoUsuario_UsuarioInvalido(string usuario, string senha)
        {
            var loginModel = new LoginModel() { Usuario = usuario, Senha = senha };

            //setup
            _mockAcessoApplication.SetupSequence(x => x.ValidarDadosAcesso(loginModel))
                .ReturnsAsync(Result<Usuario>.Error(new Usuario(loginModel.Usuario, loginModel.Senha, new Nome("Jose", "Silva"), new CPF(loginModel.Usuario), new Email("cliente@gmail.com"), PerfilUsuarioEnum.Cliente).Notifications))
                .ReturnsAsync(Result<Usuario>.Error(new Usuario(loginModel.Usuario, loginModel.Senha, new Nome("Jose", "Silva"), new CPF(loginModel.Usuario), new Email("cliente@gmail.com"), PerfilUsuarioEnum.Operador).Notifications))
                .ReturnsAsync(Result<Usuario>.Error(new Usuario(loginModel.Usuario, loginModel.Senha, new Nome("Jose", "Silva"), new CPF(loginModel.Usuario), new Email("cliente@gmail.com"), PerfilUsuarioEnum.Cliente).Notifications))
                .ReturnsAsync(Result<Usuario>.Error(new Usuario(loginModel.Usuario, loginModel.Senha, new Nome("Jose", "Silva"), new CPF(loginModel.Usuario), new Email("cliente@gmail.com"), PerfilUsuarioEnum.Cliente).Notifications));

            //controller
            var acessoController = new AcessoController(_mapperFixture.Mapper, _mockAcessoApplication.Object);
            var response = await acessoController.ValidaAcessoUsuario(loginModel);

            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Theory]
        [InlineData("12345678900", "password123")]
        public async Task ValidarDadosAcessoUsuario_Exception(string usuario, string senha)
        {
            var loginModel = new LoginModel() { Usuario = usuario, Senha = senha };

            //setup
            _mockAcessoApplication.Setup(x => x.ValidarDadosAcesso(loginModel)).ThrowsAsync(new Exception());

            //controller
            var acessoController = new AcessoController(_mapperFixture.Mapper, _mockAcessoApplication.Object);
            var response = await acessoController.ValidaAcessoUsuario(loginModel);

            Assert.Equal(500, ((ObjectResult)response).StatusCode);
            Assert.Contains("Ocorreu um erro interno.", ((ObjectResult)response).Value.ToString());
        }

        [Theory]        
        [InlineData("04183319988", "pass123")]
        public async Task ValidarDadosAcessoUsuario_UsuarioNaoEncontrado(string usuario, string senha)
        {
            var loginModel = new LoginModel() { Usuario = usuario, Senha = senha };

            var usuarioError = new Usuario();
            usuarioError.AddNotification("404", "Usuário Invalido");

            //setup
            _mockAcessoApplication.Setup(x => x.ValidarDadosAcesso(loginModel))
                .ReturnsAsync(Result<Usuario>.Error(usuarioError.Notifications));

            //controller
            var acessoController = new AcessoController(_mapperFixture.Mapper, _mockAcessoApplication.Object);
            var response = await acessoController.ValidaAcessoUsuario(loginModel);

            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}
