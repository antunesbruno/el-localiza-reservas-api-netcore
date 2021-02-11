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
    public class ModeloApplicationTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IModeloRepository> _mockRepository;

        public ModeloApplicationTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IModeloRepository>();
        }

        [Fact]
        public async Task SalvarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<ModeloModel, Modelo>(It.IsAny<ModeloModel>()))
                .Returns(FakeModelo.ObtemModeloDefault());

            //setup
            _mockRepository.Setup(x => x.Incluir(It.IsAny<Modelo>()));

            //application           
            var application = new ModeloApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.SalvarAsync(It.IsAny<ModeloModel>());

            Assert.IsType<Result<Modelo>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task AtualizarAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<ModeloModel, Modelo>(It.IsAny<ModeloModel>()))
                .Returns(FakeModelo.ObtemModeloDefault());

            //setup
            _mockRepository.Setup(x => x.Atualizar(It.IsAny<Modelo>()));

            //application           
            var application = new ModeloApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.AtualizarAsync(It.IsAny<ModeloModel>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }

        [Fact]
        public async Task ExcluirrAsync_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.Excluir(It.IsAny<Guid>()));

            //application           
            var application = new ModeloApplication(_mockMapper.Object, _mockRepository.Object);
            var response = await application.ExcluirAsync(It.IsAny<Guid>());

            Assert.IsType<bool>(response);
            Assert.True(response);
        }
    }
}
