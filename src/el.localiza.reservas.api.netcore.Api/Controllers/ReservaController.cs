using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace el.localiza.reservas.api.netcore.Api.Controllers
{
    [Route("reservas")]
    [ApiController]
    public class ReservaController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IReservaApplication _reservaApplication;

        public ReservaController(IMapper mapper, IReservaApplication reservaApplication)
        {
            _mapper = mapper;
            _reservaApplication = reservaApplication;
        }

        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(ReservaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarReserva([FromBody] ReservaModelRequest reservaModel)
        {
            try
            {
                var result = await _reservaApplication.SalvarReservaAsync(reservaModel);

                if (result.Success)
                    return Created($"/reservas/{result.Object.Id}", _mapper.Map<Reserva, ReservaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ReservaController > CriarReserva - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("checklist/criar")]
        [ProducesResponseType(typeof(ChecklistModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarCheckListVeiculo([FromBody] ChecklistModel checkListModel)
        {
            try
            {
                var result = await _reservaApplication.SalvarChecklistAsync(checkListModel);

                if (result.Success)
                    return Created($"/reservas/checklist/{result.Object.Id}", _mapper.Map<Checklist, ChecklistModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ReservaController > CriarCheckListVeiculo - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }
    }
}
