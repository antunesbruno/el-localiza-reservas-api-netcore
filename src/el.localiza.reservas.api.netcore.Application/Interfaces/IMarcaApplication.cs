using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application.Interfaces
{
    public interface IMarcaApplication
    {
        Task<Result<Marca>> SalvarAsync(MarcaModel marcaModel);
        Task<bool> AtualizarAsync(MarcaModel marcaModel);
        Task<bool> ExcluirAsync(Guid marcaId);
    }
}
