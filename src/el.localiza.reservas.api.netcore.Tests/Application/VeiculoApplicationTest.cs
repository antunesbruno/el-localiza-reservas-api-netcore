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
   public class VeiculoApplicationTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IVeiculoRepository> _mockRepository;

        public VeiculoApplicationTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IVeiculoRepository>();
        }

        [Fact]
        public async Task SalvarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<VeiculoModelRequest, Veiculo>(It.IsAny<VeiculoModelRequest>()))
                .Returns(FakeVeiculo.ObtemVeiculoDefault());

            //setup
            _mockRepository.Setup(x => x.Incluir(It.IsAny<Veiculo>()));

            //application           
            var application = new VeiculoApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.SalvarAsync(It.IsAny<VeiculoModelRequest>());

            Assert.IsType<Result<Veiculo>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task AtualizarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<VeiculoModel, Veiculo>(It.IsAny<VeiculoModel>()))
                .Returns(FakeVeiculo.ObtemVeiculoDefault());

            //setup
            _mockRepository.Setup(x => x.Atualizar(It.IsAny<Veiculo>()));

            //application           
            var application = new VeiculoApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.AtualizarAsync(It.IsAny<VeiculoModel>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

        [Fact]
        public async Task ExcluirrAsync_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.Excluir(It.IsAny<Guid>()));

            //application           
            var application = new VeiculoApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ExcluirAsync(It.IsAny<Guid>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

        [Fact]
        public async Task ObterClientePorId_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.ObterVeiculoPorId(It.IsAny<Guid>()))
                .ReturnsAsync(FakeVeiculo.ObtemVeiculoDefault());

            //application           
            var application = new VeiculoApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ObterVeiculoPorIdAsync(Guid.NewGuid().ToString());

            Assert.IsType<Result<Veiculo>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task ObterVeiculosPorCategoriaAsync_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.ObterListaPorCategoria(It.IsAny<int>()))
                .ReturnsAsync(new List<Veiculo>() { FakeVeiculo.ObtemVeiculoDefault() });

            //application           
            var application = new VeiculoApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ObterVeiculosPorCategoriaAsync(It.IsAny<int>());

            Assert.IsType<Result<IList<Veiculo>>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

    }
}
