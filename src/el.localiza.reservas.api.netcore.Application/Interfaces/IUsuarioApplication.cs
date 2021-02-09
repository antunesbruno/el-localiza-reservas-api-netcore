using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<Result<IList<Usuario>>> ObterListaPorPerfilAsync(PerfilUsuarioEnum perfil);
        Task<Result<Usuario>> Salvar(UsuarioModel usuarioModel);
        Task<bool> Atualizar(UsuarioModel usuarioModel);
        Task<bool> Excluir(Guid usuarioId);
    }
}
