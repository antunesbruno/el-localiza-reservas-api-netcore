using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Obtem os usuarios pelo Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<Usuario> ObterPorLogin(string login)
        {
            return await _context.Set<Usuario>().FirstOrDefaultAsync(x => x.Login.Equals(login));
        }

        /// <summary>
        /// Obtem todos os usuários pelo Perfil
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Usuario>> ObterListaPorPerfil(PerfilUsuarioEnum perfil)
        {
            return await _context.Set<Usuario>().Where(x => x.Perfil.Equals((int)perfil)).ToListAsync();
        }
    }
}
