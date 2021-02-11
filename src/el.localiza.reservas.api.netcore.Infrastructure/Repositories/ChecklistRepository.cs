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
    public class ChecklistRepository : BaseRepository<Checklist>, IChecklistRepository
    {
        protected readonly DatabaseContext _context;

        public ChecklistRepository(DatabaseContext context)
           : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem a lista de checklists pelo id da reserva
        /// </summary>
        /// <param name="reservaId"></param>
        /// <returns></returns>
        public async Task<IList<Checklist>> ObterListaChecklistPorReserva(Guid reservaId)
        {
            return await _context.Checklist.Where(s => s.IdReserva.Equals(reservaId)).ToListAsync();
        }
    }
}
