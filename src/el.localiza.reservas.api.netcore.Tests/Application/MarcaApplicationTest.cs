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
    public class MarcaApplicationTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IMarcaRepository> _mockRepository;

        public MarcaApplicationTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IMarcaRepository>();
        }

        [Fact]
        public async Task SalvarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<MarcaModel, Marca>(It.IsAny<MarcaModel>()))
                .Returns(FakeMarca.ObterMarcaDefault());

            //setup
            _mockRepository.Setup(x => x.ListarPorId(It.IsAny<Guid>()))
                .ReturnsAsync(FakeMarca.ObterMarcaDefault());

            //application           
            var application = new MarcaApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.SalvarAsync(It.IsAny<MarcaModel>());

            Assert.IsType<Result<Marca>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task AtualizarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<MarcaModel, Marca>(It.IsAny<MarcaModel>()))
                .Returns(FakeMarca.ObterMarcaDefault());

            //setup
            _mockRepository.Setup(x => x.Atualizar(It.IsAny<Marca>()));

            //application           
            var application = new MarcaApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.AtualizarAsync(It.IsAny<MarcaModel>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

        [Fact]
        public async Task ExcluirrAsync_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.Excluir(It.IsAny<Guid>()));

            //application           
            var application = new MarcaApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ExcluirAsync(It.IsAny<Guid>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }
    }
}
