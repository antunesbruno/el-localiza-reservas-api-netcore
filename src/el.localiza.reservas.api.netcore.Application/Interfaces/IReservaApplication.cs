using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application.Interfaces
{
    public interface IReservaApplication
    {
        #region Checklists        
        
        Task<Result<IList<Checklist>>> ObterListaChecklistPorReservaId(Guid reservaId);
        Task<Result<Checklist>> SalvarChecklistAsync(ChecklistModel checklistModel);        
        Task<Result<List<Checklist>>> SalvarListaCheckListAsync(List<ChecklistModel> checklistModel);

        #endregion

        #region Reserva

        Task<Result<Reserva>> SalvarReservaAsync(ReservaModelRequest reservaModel);
        Task<Result<IList<Reserva>>> ObtemListaReservasIdCliente(string idCliente);

        #endregion
    }
}
