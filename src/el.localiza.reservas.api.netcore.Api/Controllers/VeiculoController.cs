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
    [Route("veiculos")]
    [ApiController]
    public class VeiculoController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoApplication _veiculoApplication;

        public VeiculoController(IMapper mapper, IVeiculoApplication veiculoApplication)
        {
            _mapper = mapper;
            _veiculoApplication = veiculoApplication;
        }

        /// <summary>
        /// Obtem os veiculos por Categoria ( Basico = 0, Completo = 1, Luxo = 2)
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<VeiculoModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterVeiculosPorCategoria(int categoria)
        {
            try
            {
                var veiculos = await _veiculoApplication.ObterVeiculosPorCategoriaAsync(categoria);

                if (veiculos.Success)
                    return Ok(_mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoModel>>(veiculos.Object));

                return NotFound("Veiculos não encontrados para a Categoria !");
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "VeiculoController > ObterVeiculosPorCategoria - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{idVeiculo}")]
        [ProducesResponseType(typeof(VeiculoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterVeiculoPorId(string idVeiculo)
        {
            try
            {
                var veiculo = await _veiculoApplication.ObterVeiculoPorIdAsync(idVeiculo);

                if (veiculo.Success)
                    return Ok(_mapper.Map<Veiculo, VeiculoModel>(veiculo.Object));

                return NotFound("Veiculos não encontrado !");
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "VeiculoController > ObterVeiculoPorId - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

        /// <summary>
        /// Cria um novo veiculo
        /// </summary>
        /// <param name="veiculoModel">Modelo de Veiculos</param>
        /// <returns></returns>
        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(VeiculoModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarVeiculo([FromBody] VeiculoModelRequest veiculoModel)
        {
            try
            {
                var result = await _veiculoApplication.SalvarAsync(veiculoModel);

                if (result.Success)
                    return Created($"/veiculo/{result.Object.Id}", _mapper.Map<Veiculo, VeiculoModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "VeiculoController > CriarVeiculo - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }
    }
}
