using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterPorLogin(string login);
        Task<IEnumerable<Usuario>> ObterListaPorPerfil(PerfilUsuarioEnum perfil);
    }
}
