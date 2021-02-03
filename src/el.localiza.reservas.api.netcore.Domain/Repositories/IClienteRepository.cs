using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace el.localiza.reservas.api.netcore.Domain.Repositories
{
    public interface IClienteRepository
    {
        void Incluir(Cliente cliente);
        Cliente ObterPorId(Guid id);
        IEnumerable<Cliente> ListarTodos();
    }
}
