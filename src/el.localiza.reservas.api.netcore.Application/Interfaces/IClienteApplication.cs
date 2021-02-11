using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application.Interfaces
{
    public interface IClienteApplication
    {
        Task<Result<Cliente>> SalvarAsync(ClienteModel clienteModel);
        Task<Result<Cliente>> ObterClientePorId(Guid clienteId);
        Task<bool> AtualizarAsync(ClienteModel clienteModel);
        Task<bool> ExcluirAsync(Guid clienteId);     
    }
}