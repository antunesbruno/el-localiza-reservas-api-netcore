using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace el.localiza.reservas.api.netcore.Api.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UsuarioController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IMapper mapper, IUsuarioApplication usuarioApplication)
        {
            _mapper = mapper;
            _usuarioApplication = usuarioApplication;
        }

        /// <summary>
        /// Obtem os usuários de acordo com o Perfil
        /// </summary>
        /// <param name="perfil">0 - Cliente / 1 - Operador</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UsuarioModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosUsuariosPorPerfil(PerfilUsuarioEnum perfil)
        {
            try
            {
                var usuarios = await _usuarioApplication.ObterListaPorPerfilAsync(perfil);

                if (usuarios.Success)
                    return Ok(_mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioModel>>(usuarios.Object));

                return NotFound("Usuários não encontrados para o Perfil !");
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "UsuarioController > ObterTodosUsuariosPorPerfil - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="usuarioModel">Modelo de Usuario</param>
        /// <returns></returns>
        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(UsuarioModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                var result = await _usuarioApplication.Salvar(usuarioModel);

                if (result.Success)
                    return Created($"/usuario/{result.Object.Id}", _mapper.Map<Usuario, UsuarioModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "UsuarioController > CriarUsuario - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="usuarioModel">Modelo do usuário</param>
        /// <returns></returns>
        [HttpPost]
        [Route("atualizar")]
        [ProducesResponseType(typeof(UsuarioModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                var resultOk = await _usuarioApplication.Atualizar(usuarioModel);

                if (resultOk)
                    return Ok(usuarioModel);

                return BadRequest("Ocorreu um erro na atualização do Usuário ! ");
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "UsuarioController > AtualizarUsuario - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

        /// <summary>
        /// Exclui um usuário pelo Identificador
        /// </summary>
        /// <param name="usuarioId">Identificador do usuário</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExcluirUsuario(Guid usuarioId)
        {
            try
            {
                var resultOk = await _usuarioApplication.Excluir(usuarioId);

                if (resultOk)
                    return Ok($"O usuário com o Identificador: {usuarioId} foi excluído com sucesso !");

                return BadRequest("Ocorreu um erro na exclusão do Usuário ! ");
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "UsuarioController > ExcluirUsuario - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }
    }
}
