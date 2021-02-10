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
    public class ModeloApplication : IModeloApplication
    {
        private readonly IMapper _mapper;
        private readonly IModeloRepository _modeloRepository;

        public ModeloApplication(IMapper mapper, IModeloRepository modeloRepository)
        {
            _mapper = mapper;
            _modeloRepository = modeloRepository;
        }

        /// <summary>
        /// Salva um novo Modelo
        /// </summary>
        /// <param name="modeloModel"></param>
        /// <returns></returns>
        public async Task<Result<Modelo>> SalvarAsync(ModeloModel modeloModel)
        {
            var modelo = _mapper.Map<ModeloModel, Modelo>(modeloModel);

            if (modelo.Valid)
            {
                await _modeloRepository.Incluir(modelo);
                return Result<Modelo>.Ok(modelo);
            }

            return Result<Modelo>.Error(modelo.Notifications);
        }

        /// <summary>
        /// Atualiza um modelo existente
        /// </summary>
        /// <param name="modeloModel"></param>
        /// <returns></returns>
        public async Task<bool> AtualizarAsync(ModeloModel modeloModel)
        {
            var modelo = _mapper.Map<ModeloModel, Modelo>(modeloModel);

            if (modelo.Valid)
            {
                await _modeloRepository.Atualizar(modelo);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Exclui um modelo existente
        /// </summary>
        /// <param name="modeloId"></param>
        /// <returns></returns>
        public async Task<bool> ExcluirAsync(Guid modeloId)
        {
            await _modeloRepository.Excluir(modeloId);

            //verifica a exclusao
            var modelo = await _modeloRepository.ListarPorId(modeloId);

            if (modelo == null)
                return true;

            return false;
        }
    }
}
    

