using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application.Interfaces
{
    public interface IVeiculoApplication
    {
        Task<Result<IList<Veiculo>>> ObterVeiculosPorCategoriaAsync(int categoria);
        Task<Result<Veiculo>> SalvarAsync(VeiculoModel veiculoModel);
        Task<bool> AtualizarAsync(VeiculoModel veiculoModel);
        Task<bool> ExcluirAsync(Guid veiculoId);
    }
}
