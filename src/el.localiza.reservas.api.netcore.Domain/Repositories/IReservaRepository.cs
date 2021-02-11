using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Domain.Repositories
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        Task<IList<Reserva>> ObtemListaReservasIdCliente(Guid clienteId);
    }
}
