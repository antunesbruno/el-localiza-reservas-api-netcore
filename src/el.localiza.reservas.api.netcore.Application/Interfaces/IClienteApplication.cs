using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;

namespace el.localiza.reservas.api.netcore.Application.Interfaces
{
    public interface IClienteApplication
    {
        Result<Cliente> Salvar(ClienteModel clienteModel);
    }
}