using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Domain.Repositories
{
    public interface IChecklistRepository : IRepository<Checklist>
    {
        Task<IList<Checklist>> ObterListaChecklistPorReserva(Guid reservaId);
    }
}
