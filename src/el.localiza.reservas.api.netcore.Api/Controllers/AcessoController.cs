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
    [Route("acesso")]
    public class AcessoController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAcessoApplication _acessoApplication;

        public AcessoController(IMapper mapper, IAcessoApplication acessoApplication)
        {
            _mapper = mapper;
            _acessoApplication = acessoApplication;         
        }

        /// <summary>
        /// Valida os dados de acesso do Usuario
        /// </summary>
        /// <param name="loginModel">Modelo contendo o login e a senha</param>
        /// <returns>Se OK, retorna os dados do usuário, senão retorna as notificações</returns>
        [HttpPost]
        [ProducesResponseType(typeof(LoginModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ValidaAcessoUsuario([FromBody] LoginModel loginModel)
        {
            try
            {
                //valida os dados de acesso
                var dadosValidos = await _acessoApplication.ValidarDadosAcesso(loginModel);

                if (dadosValidos.Success)
                    return Ok(_mapper.Map<Usuario, UsuarioModel>(dadosValidos.Object));

                //StatusCode-404
                return NotFound(dadosValidos.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "AcessoController > ValidaAcessoUsuario - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }
    }
}
