using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IClienteApplication _clienteApplication;

        public ClienteController(IMapper mapper, IClienteApplication clienteApplication)
        {
            _mapper = mapper;
            _clienteApplication = clienteApplication;
        }

        /// <summary>
        /// Obtem um cliente pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterClientePorId(Guid id)
        {
            try
            {
                var cliente = await _clienteApplication.ObterClientePorId(id);

                if (cliente == null)
                    return NotFound("Cliente não encontrado");

                return Ok(_mapper.Map<Cliente, ClienteModel>(cliente.Object));
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ClienteController > ObterClientePorId - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

        /// <summary>
        /// Insere um novo cliente 
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarClientes(ClienteModel clienteModel)
        {
            try
            {
                var result = await _clienteApplication.SalvarAsync(clienteModel);

                if (result.Success)
                    return Created($"/clientes/{result.Object.Id}", _mapper.Map<Cliente, ClienteModel>(result.Object));

                return BadRequest(result.Notifications);
            }

            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ClienteController > CriarClientes - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }
    }
}
    
