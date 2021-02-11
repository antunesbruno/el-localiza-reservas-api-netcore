using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
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
            return await _context.Set<Veiculo>().Where(x => ((int)x.Categoria) == categoria)
                .Include(x => x.Marca)
                .Include(x => x.Modelo)
                .ToListAsync();
        }

        public async Task<Veiculo> ObterVeiculoPorId(Guid veiculoId)
        {
            return await _context.Set<Veiculo>()
                .Include(x => x.Marca)
                .Include(x => x.Modelo)
                .FirstOrDefaultAsync(x => x.Id.Equals(veiculoId));
        }
    }
}
