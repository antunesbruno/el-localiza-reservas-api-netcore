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
        Task<Result<Usuario>> SalvarAsync(UsuarioModel usuarioModel);
        Task<bool> AtualizarAsync(UsuarioModel usuarioModel);
        Task<bool> ExcluirAsync(Guid usuarioId);
    }
}
