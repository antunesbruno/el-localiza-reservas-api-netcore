using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Collections.Generic;

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

        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        //public IActionResult Get(Guid id)
        //{
        //    var cliente = _clienteRepository.ObterPorId(id);

        //    if (cliente == null)
        //        return NotFound("Cliente não encontrado");

        //    return Ok(_mapper.Map<Cliente, ClienteModel>(cliente));
        //}

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<ClienteModel>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        //public IActionResult List()
        //{
        //    var cliente = _clienteRepository.ListarTodos();

        //    return Ok(_mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(cliente));
        //}       

        [HttpPost]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Post(ClienteModel clienteModel)
        {
            var result = _clienteApplication.Salvar(clienteModel);

            if (result.Success)
                return Created($"/clientes/{result.Object.Id}", _mapper.Map<Cliente, ClienteModel>(result.Object));

            return BadRequest(result.Notifications);
        }
    }
}
