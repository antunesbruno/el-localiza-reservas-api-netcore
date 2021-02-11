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
using System.Threading.Tasks;
using Xunit;

namespace el.localiza.reservas.api.netcore.Tests.Controllers
{
    [Collection("Mapper")]
    public class ReservaControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly Mock<IReservaApplication> _entidadeApplication;
        private readonly Mock<IReservaRepository> _entidadeRepository;
        private readonly Mock<IMapper> _mockMapper;

        public ReservaControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _mockMapper = new Mock<IMapper>();
            _entidadeApplication = new Mock<IReservaApplication>();
            _entidadeRepository = new Mock<IReservaRepository>();
        }

        [Fact]
        public async Task CriarReserva_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Reserva>(It.IsAny<ModeloModel>()))
                .Returns(FakeReserva.ObtemReservaDefault());

            _entidadeApplication.Setup(x => x.SalvarReservaAsync(It.IsAny<ReservaModelRequest>()))
                .ReturnsAsync(Result<Reserva>.Ok(FakeReserva.ObtemReservaDefault()));

            var controller = new ReservaController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.CriarReserva(It.IsAny<ReservaModelRequest>());

            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task CriarChecklist_Sucesso()
        {
            //mapping
            _mockMapper.Setup(m => m.Map<Checklist>(It.IsAny<ChecklistModel>()))
                .Returns(FakeChecklist.ObtemChecklistDefault());

            _entidadeApplication.Setup(x => x.SalvarChecklistAsync(It.IsAny<ChecklistModel>()))
                .ReturnsAsync(Result<Checklist>.Ok(FakeChecklist.ObtemChecklistDefault()));

            var controller = new ReservaController(_mockMapper.Object, _entidadeApplication.Object);
            var response = await controller.CriarCheckListVeiculo(It.IsAny<ChecklistModel>());

            Assert.IsType<CreatedResult>(response);
        }
    }
}
