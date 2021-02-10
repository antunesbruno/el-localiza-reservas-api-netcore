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
    [Route("marcas")]
    [ApiController]
    public class MarcaController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMarcaApplication _marcaApplication;

        public MarcaController(IMapper mapper, IMarcaApplication marcaApplication)
        {
            _mapper = mapper;
            _marcaApplication = marcaApplication;
        }

        /// <summary>
        /// Cria uma nova marca
        /// </summary>
        /// <param name="marcaModel">Modelo de Marcas de veiculo</param>
        /// <returns></returns>
        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(MarcaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarMarcaVeiculo([FromBody] MarcaModel marcaModel)
        {
            try
            {
                var result = await _marcaApplication.SalvarAsync(marcaModel);

                if (result.Success)
                    return Created($"/marcas/{result.Object.Id}", _mapper.Map<Marca, MarcaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "MarcaController > CriarMarcaVeiculo - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }
    }
}
