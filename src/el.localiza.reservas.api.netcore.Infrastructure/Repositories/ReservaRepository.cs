using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ReservaRepository : BaseRepository<Reserva>, IReservaRepository
    {
        protected readonly DatabaseContext _context;

        public ReservaRepository(DatabaseContext context)
           : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem a lista de reservas pelo id do cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public async Task<IList<Reserva>> ObtemListaReservasIdCliente(Guid clienteId)
        {
            return await _context.Reserva.Where(s => s.IdCliente.Equals(clienteId)).ToListAsync();
        }

        
    }
}
