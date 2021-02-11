using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace el.localiza.reservas.api.netcore.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ModeloRepository : BaseRepository<Modelo>, IModeloRepository
    {
        protected readonly DatabaseContext _context;

        public ModeloRepository(DatabaseContext context)
           : base(context)
        {
            _context = context;
        }
    }
}
