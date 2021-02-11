using AutoMapper;
using el.localiza.reservas.api.netcore.Application;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.Extensions;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Application
{
    [Collection("Mapper")]
    public class AcessoApplicationTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository;

        public AcessoApplicationTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
        }

        [Theory]
        [InlineData("151515", "password123")]
        [InlineData("12345678900", "password123")]
        public async Task ValidarDadosAcesso_Sucesso(string usuario, string senha)
        {
            var loginModel = new LoginModel() { Usuario = usuario, Senha = senha };

            //cria os hashs de teste
            var hash = CriptografiaService.Create(senha, Salt.SALT_DEFAULT);

            //setup
            _mockUsuarioRepository.SetupSequence(x => x.ObterPorLogin(loginModel.Usuario))
                .ReturnsAsync(new Usuario(loginModel.Usuario, hash, new Nome("Jose Silva"), loginModel.Usuario, new Email("operador@localiza.com"), PerfilUsuarioEnum.Operador))
                .ReturnsAsync(new Usuario(loginModel.Usuario, hash, new Nome("Jose", "Silva"), new CPF(loginModel.Usuario), new Email("cliente@gmail.com"), PerfilUsuarioEnum.Cliente));


            //application           
            var applicationCandidato = new AcessoApplication(_mockMapper.Object, _mockUsuarioRepository.Object);
            var response = await applicationCandidato.ValidarDadosAcesso(loginModel);

            Assert.IsType<Result<Usuario>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Theory]
        [InlineData("12345678900", "password123")]
        public async Task ValidarDadosAcesso_UsuarioInexistente(string usuario, string senha)
        {
            var loginModel = new LoginModel() { Usuario = usuario, Senha = senha };

            //setup
            _mockUsuarioRepository.Setup(x => x.ObterPorLogin(loginModel.Usuario))
                .ReturnsAsync(null as Usuario);

            //application           
            var applicationCandidato = new AcessoApplication(_mockMapper.Object, _mockUsuarioRepository.Object);
            var response = await applicationCandidato.ValidarDadosAcesso(loginModel);

            Assert.IsType<Result<Usuario>>(response);
            Assert.False(response.Valid);
            Assert.Null(response.Object);
            Assert.True(response.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("12345678900", "password123")]
        public async Task ValidarDadosAcesso_UsuarioInvalido(string usuario, string senha)
        {
            var loginModel = new LoginModel() { Usuario = usuario, Senha = senha };

            //cria os hashs de teste
            var hash = "hashcriadoinvalido";

            //setup
            _mockUsuarioRepository.SetupSequence(x => x.ObterPorLogin(loginModel.Usuario))
                .ReturnsAsync(new Usuario(loginModel.Usuario, hash, new Nome("Jose", "Silva"), new CPF(loginModel.Usuario), new Email("cliente@gmail.com"), PerfilUsuarioEnum.Cliente));

            //application           
            var applicationCandidato = new AcessoApplication(_mockMapper.Object, _mockUsuarioRepository.Object);
            var response = await applicationCandidato.ValidarDadosAcesso(loginModel);

            Assert.IsType<Result<Usuario>>(response);
            Assert.False(response.Valid);
            Assert.Null(response.Object);
            Assert.True(response.Notifications.Count > 0);
        }
    }
}
