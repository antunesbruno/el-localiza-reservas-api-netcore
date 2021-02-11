using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application.Interfaces
{
    public interface IModeloApplication
    {
        Task<Result<Modelo>> SalvarAsync(ModeloModel modeloModel);
        Task<bool> AtualizarAsync(ModeloModel modeloModel);
        Task<bool> ExcluirAsync(Guid modeloId);
    }
}
