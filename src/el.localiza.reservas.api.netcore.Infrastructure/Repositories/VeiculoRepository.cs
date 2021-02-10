using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Infrastructure.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        protected readonly DatabaseContext _context;

        public VeiculoRepository(DatabaseContext context)
           : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem a lista dos veiculos por categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Veiculo>> ObterListaPorCategoria(int categoria)
        {
            return await _context.Set<Veiculo>().Where(x => x.Categoria.Equals(categoria)).ToListAsync();
        }
    }
}
