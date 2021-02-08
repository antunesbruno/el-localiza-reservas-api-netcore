using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Api.Controllers
{
    [ApiController]
    [Route("acesso")]
    public class AcessoController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAcessoApplication _acessoApplication;
        private readonly IAcessoRepository _acessoRepository;

        public AcessoController(IMapper mapper, IAcessoApplication acessoApplication, IAcessoRepository acessoRepository)
        {
            _mapper = mapper;
            _acessoApplication = acessoApplication;
            _acessoRepository = acessoRepository;
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(LoginModel), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> ValidaAcessoUsuario([FromBody] LoginModel loginModel)
        //{
        //    //TODO: validar os dados de acesso
        //    var dadosValidos = _acessoApplication.ValidarDadosAcesso(loginModel);

        //    if(dadosValidos.Success)
        //    {
        //        //TODO: verifica na base o usuário e senha

        //        //StatusCode-404
        //        return NotFound(dadosValidos.Notifications);
        //    }

        //    //var result = _clienteApplication.Salvar(clienteModel);

        //    //if (result.Success)
        //    //    return Created($"/clientes/{result.Object.Id}", _mapper.Map<Cliente, LoginModel>(result.Object));

        //    return BadRequest(dadosValidos.Notifications);
        //}
    }
}
