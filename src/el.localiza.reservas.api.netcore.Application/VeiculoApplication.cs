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
    public class VeiculoApplication : IVeiculoApplication
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoApplication(IMapper mapper, IVeiculoRepository veiculoRepository)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;
        }

        /// <summary>
        /// Obtem os veiculos por Categoria
        /// </summary>
        /// <param name="categoria">Codigo da categoria</param>
        /// <returns></returns>

        public async Task<Result<IList<Veiculo>>> ObterVeiculosPorCategoriaAsync(int categoria)
        {
            var veiculos = await _veiculoRepository.ObterListaPorCategoria(categoria);

            if (veiculos != null && veiculos.Any())
                return Result<IList<Veiculo>>.Ok(veiculos.ToList());

            return Result<IList<Veiculo>>.Ok(null);
        }

        /// <summary>
        /// Obter o veiculo pelo ID
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <returns></returns>
        public async Task<Result<Veiculo>> ObterVeiculoPorIdAsync(string idVeiculo)
        {
            var veiculo = await _veiculoRepository.ObterVeiculoPorId(Guid.Parse(idVeiculo));

            if (veiculo != null)
                return Result<Veiculo>.Ok(veiculo);

            return Result<Veiculo>.Ok(null);
        }

        /// <summary>
        /// Salva um novo Veiculo
        /// </summary>
        /// <param name="veiculoModel"></param>
        /// <returns></returns>
        public async Task<Result<Veiculo>> SalvarAsync(VeiculoModelRequest veiculoModel)
        {
            var veiculo = _mapper.Map<VeiculoModelRequest, Veiculo>(veiculoModel);

            if (veiculo.Valid)
            {
                veiculo.DataCriacao = DateTime.Now;

                await _veiculoRepository.Incluir(veiculo);
                return Result<Veiculo>.Ok(veiculo);
            }

            return Result<Veiculo>.Error(veiculo.Notifications);
        }

        /// <summary>
        /// Atualiza um veiculo existente
        /// </summary>
        /// <param name="veiculoModel"></param>
        /// <returns></returns>
        public async Task<bool> AtualizarAsync(VeiculoModel veiculoModel)
        {
            var veiculo = _mapper.Map<VeiculoModel, Veiculo>(veiculoModel);

            if (veiculo.Valid)
            {
                await _veiculoRepository.Atualizar(veiculo);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Exclui um veiculo existente
        /// </summary>
        /// <param name="veiculoId"></param>
        /// <returns></returns>
        public async Task<bool> ExcluirAsync(Guid veiculoId)
        {
            await _veiculoRepository.Excluir(veiculoId);

            //verifica a exclusao
            var veiculo = await _veiculoRepository.ListarPorId(veiculoId);

            if (veiculo == null)
                return true;

            return false;
        }
    }
}
