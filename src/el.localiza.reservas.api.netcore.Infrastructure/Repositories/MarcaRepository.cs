using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Infrastructure.Repositories
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        protected readonly DatabaseContext _context;

        public MarcaRepository(DatabaseContext context)
           : base(context)
        {
            _context = context;
        }
    }
}
