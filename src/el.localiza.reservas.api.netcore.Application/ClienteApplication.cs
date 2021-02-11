using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns></returns>
        public async Task<Result<Cliente>> SalvarAsync(ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<ClienteModel, Cliente>(clienteModel);

            if (cliente.Valid)
            {
                cliente.DataCriacao = DateTime.Now;

                await _clienteRepository.Incluir(cliente);
                return Result<Cliente>.Ok(cliente);
            }

            return Result<Cliente>.Error(cliente.Notifications);
        }

        /// <summary>
        /// Obtem o cliente pelo id
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public async Task<Result<Cliente>> ObterClientePorId(Guid clienteId)
        {
            var cliente = await _clienteRepository.ListarPorId(clienteId);

            if (cliente != null)
                return Result<Cliente>.Ok(cliente);

            return Result<Cliente>.Ok(null);
        }

        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns></returns>
        public async Task<bool> AtualizarAsync(ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<ClienteModel, Cliente>(clienteModel);

            if (cliente.Valid)
            {
                await _clienteRepository.Atualizar(cliente);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Exclui um cliente existente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public async Task<bool> ExcluirAsync(Guid clienteId)
        {
            await _clienteRepository.Excluir(clienteId);

            //verifica a exclusao
            var modelo = await _clienteRepository.ListarPorId(clienteId);

            if (modelo == null)
                return true;

            return false;
        }

    }
}
