using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Incluir(T obj);

        Task Atualizar(T obj);

        Task Excluir(Guid id);

        Task<T> ListarPorId(Guid id);

        Task<IList<T>> Listar();
    }
}
