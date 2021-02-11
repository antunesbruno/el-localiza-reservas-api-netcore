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
    public class ReservaApplicationTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IReservaRepository> _mockRepository;
        private readonly Mock<IChecklistRepository> _mockChRepository;

        public ReservaApplicationTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IReservaRepository>();
            _mockChRepository = new Mock<IChecklistRepository>();
        }

        [Fact]
        public async Task SalvarReservaAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<ReservaModelRequest, Reserva>(It.IsAny<ReservaModelRequest>()))
                .Returns(FakeReserva.ObtemReservaDefault());

            //setup
            _mockRepository.Setup(x => x.Incluir(It.IsAny<Reserva>()));

            //application           
            var application = new ReservaApplication(_mockMapper.Object, _mockRepository.Object, _mockChRepository.Object);
            var response = await application.SalvarReservaAsync(It.IsAny<ReservaModelRequest>());

            Assert.IsType<Result<Reserva>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task SalvarChecklistAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<ChecklistModel, Checklist>(It.IsAny<ChecklistModel>()))
                .Returns(FakeChecklist.ObtemChecklistDefault());

            //setup
            _mockChRepository.Setup(x => x.Incluir(It.IsAny<Checklist>()));

            //application           
            var application = new ReservaApplication(_mockMapper.Object, _mockRepository.Object, _mockChRepository.Object);
            var response = await application.SalvarChecklistAsync(It.IsAny<ChecklistModel>());

            Assert.IsType<Result<Checklist>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task SalvarListaCheckListAsync_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<ChecklistModel, Checklist>(It.IsAny<ChecklistModel>()))
                .Returns(FakeChecklist.ObtemChecklistDefault());

            //setup
            _mockChRepository.Setup(x => x.Incluir(It.IsAny<Checklist>()));

            //application           
            var application = new ReservaApplication(_mockMapper.Object, _mockRepository.Object, _mockChRepository.Object);
            var response = await application.SalvarListaCheckListAsync(new List<ChecklistModel>() { FakeChecklist.ObtemChecklistModelDefault() });

            Assert.IsType<Result<List<Checklist>>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task ObtemListaReservasIdCliente_Sucesso()
        {
            //setup
            _mockRepository.Setup(x => x.ObtemListaReservasIdCliente(It.IsAny<Guid>()))
                .ReturnsAsync(new List<Reserva>() { FakeReserva.ObtemReservaDefault() });

            //application           
            var application = new ReservaApplication(_mockMapper.Object, _mockRepository.Object, _mockChRepository.Object);
            var response = await application.ObtemListaReservasIdCliente(Guid.NewGuid().ToString());

            Assert.IsType<Result<IList<Reserva>>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }

        [Fact]
        public async Task ObterListaChecklistPorReservaId_Sucesso()
        {
            //setup
            _mockChRepository.Setup(x => x.ObterListaChecklistPorReserva(It.IsAny<Guid>()))
                .ReturnsAsync(new List<Checklist>() { FakeChecklist.ObtemChecklistDefault() });

            //application           
            var application = new ReservaApplication(_mockMapper.Object, _mockRepository.Object, _mockChRepository.Object);
            var response = await application.ObterListaChecklistPorReservaId(Guid.NewGuid());

            Assert.IsType<Result<IList<Checklist>>>(response);
            Assert.True(response.Valid);
            Assert.NotNull(response.Object);
        }
    }
}
