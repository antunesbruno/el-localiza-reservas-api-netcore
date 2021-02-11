using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application
{
   public class ReservaApplication : IReservaApplication
    {
        private readonly IMapper _mapper;
        private readonly IReservaRepository _reservaRepository;
        private readonly IChecklistRepository _checklistRepository;

        public ReservaApplication(IMapper mapper, IReservaRepository reservaRepository, IChecklistRepository checklistRepository)
        {
            _mapper = mapper;
            _reservaRepository = reservaRepository;
            _checklistRepository = checklistRepository;
        }

        /// <summary>
        /// Obtem a lista de checklists pelo id da reserva
        /// </summary>
        /// <param name="reservaId"></param>
        /// <returns></returns>
        public async Task<Result<IList<Checklist>>> ObterListaChecklistPorReservaId(Guid reservaId)
        {
            var checklists = await _checklistRepository.ObterListaChecklistPorReserva(reservaId);

            if (checklists != null && checklists.Any())
                return Result<IList<Checklist>>.Ok(checklists.ToList());

            return Result<IList<Checklist>>.Ok(null);
        }

        /// <summary>
        /// Salva as informações de checklist
        /// </summary>
        /// <param name="checklistModel"></param>
        /// <returns></returns>    
        public async Task<Result<Checklist>> SalvarChecklistAsync(ChecklistModel checklistModel)
        {
            var checklist = _mapper.Map<ChecklistModel, Checklist>(checklistModel);

            if (checklist.Valid)
            {
                checklist.DataCriacao = DateTime.Now;

                await _checklistRepository.Incluir(checklist);
                return Result<Checklist>.Ok(checklist);
            }

            return Result<Checklist>.Error(checklist.Notifications);
        }

        /// <summary>
        /// Salva uma lista de itens do checklist
        /// </summary>
        /// <param name="checklistModel"></param>
        /// <returns></returns>
        public async Task<Result<List<Checklist>>> SalvarListaCheckListAsync(List<ChecklistModel> checklistModel)
        {
            var retorno = new List<Checklist>();

            foreach (var item in checklistModel)
            {
                var checklist = _mapper.Map<ChecklistModel, Checklist>(item);
                if (checklist.Valid)
                {
                    checklist.DataCriacao = DateTime.Now;
                    await _checklistRepository.Incluir(checklist);                    
                    retorno.Add(checklist);
                }
            }

            if (retorno.Count > 0)
                return Result<List<Checklist>>.Ok(retorno);

            var errorChecklist = new Checklist();
            errorChecklist.AddNotification("404", "Erro ao incluir a lista !");
            return Result<List<Checklist>>.Error(errorChecklist.Notifications);
        }

        /// <summary>
        /// Salva as informações da reserva
        /// </summary>
        /// <param name="reservaModel"></param>
        /// <returns></returns>    
        public async Task<Result<Reserva>> SalvarReservaAsync(ReservaModelRequest reservaModel)
        {
            var reserva = _mapper.Map<ReservaModelRequest, Reserva>(reservaModel);

            if (reserva.Valid)
            {
                reserva.DataCriacao = DateTime.Now;

                await _reservaRepository.Incluir(reserva);
                return Result<Reserva>.Ok(reserva);
            }

            return Result<Reserva>.Error(reserva.Notifications);
        }

        /// <summary>
        /// Obtem as reservas pelo o id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<Result<IList<Reserva>>> ObtemListaReservasIdCliente(string idCliente)
        {
            var reservas = await _reservaRepository.ObtemListaReservasIdCliente(Guid.Parse(idCliente));

            if (reservas != null && reservas.Any())
                return Result<IList<Reserva>>.Ok(reservas.ToList());

            return Result<IList<Reserva>>.Ok(null);
        }
    }
}

