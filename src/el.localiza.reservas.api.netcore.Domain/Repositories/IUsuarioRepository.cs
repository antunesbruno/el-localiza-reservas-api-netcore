using el.localiza.reservas.api.netcore.Domain.Entities;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterPorLogin(string login);
    }
}
