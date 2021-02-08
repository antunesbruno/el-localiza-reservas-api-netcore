using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        protected readonly DatabaseContext _context;

        public UsuarioRepository(DatabaseContext context)
           : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorLogin(string login)
        {
            return await _context.Set<Usuario>().FirstOrDefaultAsync(x => x.Login.Equals(login));
        }
    }
}
