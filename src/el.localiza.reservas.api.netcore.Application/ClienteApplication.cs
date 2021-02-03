using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Repositories;

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

        public Result<Cliente> Salvar(ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<ClienteModel, Cliente>(clienteModel);

            if (cliente.Valid)
            {
                _clienteRepository.Incluir(cliente);
                return Result<Cliente>.Ok(cliente);
            }

            return Result<Cliente>.Error(cliente.Notifications);
        }
    }
}
