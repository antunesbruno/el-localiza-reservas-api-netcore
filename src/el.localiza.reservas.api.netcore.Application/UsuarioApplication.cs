using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplication(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Result<IList<Usuario>>> ObterListaPorPerfilAsync(PerfilUsuarioEnum perfil)
        {
            var usuarios = await _usuarioRepository.ObterListaPorPerfil(perfil);

            if (usuarios != null && usuarios.Any())
                return Result<IList<Usuario>>.Ok(usuarios.ToList());

            return Result<IList<Usuario>>.Ok(null);
        }

        public async Task<Result<Usuario>> Salvar(UsuarioModel usuarioModel)
        {
            var usuario = _mapper.Map<UsuarioModel, Usuario>(usuarioModel);

            if (usuario.Valid)
            {
                await _usuarioRepository.Incluir(usuario);
                return Result<Usuario>.Ok(usuario);
            }

            return Result<Usuario>.Error(usuario.Notifications);
        }

        public async Task<bool> Atualizar(UsuarioModel usuarioModel)
        {
            var usuario = _mapper.Map<UsuarioModel, Usuario>(usuarioModel);

            if (usuario.Valid)
            {
                await _usuarioRepository.Atualizar(usuario);
                return true;
            }

            return false;
        }

        public async Task<bool> Excluir(Guid usuarioId)
        {
            await _usuarioRepository.Excluir(usuarioId);

            //verifica a exclusao
            var usuario = await _usuarioRepository.ListarPorId(usuarioId);

            if (usuario == null)
                return true;

            return false;
        }
    }
}
