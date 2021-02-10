using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application
{
    public class MarcaApplication : IMarcaApplication
    {
        private readonly IMapper _mapper;
        private readonly IMarcaRepository _marcaRepository;

        public MarcaApplication(IMapper mapper, IMarcaRepository marcaRepository)
        {
            _mapper = mapper;
            _marcaRepository = marcaRepository;
        }

        /// <summary>
        /// Salva um novo Marca
        /// </summary>
        /// <param name="marcaModel"></param>
        /// <returns></returns>
        public async Task<Result<Marca>> SalvarAsync(MarcaModel marcaModel)
        {
            var marca = _mapper.Map<MarcaModel, Marca>(marcaModel);

            if (marca.Valid)
            {
                await _marcaRepository.Incluir(marca);
                return Result<Marca>.Ok(marca);
            }

            return Result<Marca>.Error(marca.Notifications);
        }

        /// <summary>
        /// Atualiza um Marca existente
        /// </summary>
        /// <param name="marcaModel"></param>
        /// <returns></returns>
        public async Task<bool> AtualizarAsync(MarcaModel marcaModel)
        {
            var marca = _mapper.Map<MarcaModel, Marca>(marcaModel);

            if (marca.Valid)
            {
                await _marcaRepository.Atualizar(marca);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Exclui um Marca existente
        /// </summary>
        /// <param name="marcaId"></param>
        /// <returns></returns>
        public async Task<bool> ExcluirAsync(Guid marcaId)
        {
            await _marcaRepository.Excluir(marcaId);

            //verifica a exclusao
            var Marca = await _marcaRepository.ListarPorId(marcaId);

            if (Marca == null)
                return true;

            return false;
        }

    }
}
