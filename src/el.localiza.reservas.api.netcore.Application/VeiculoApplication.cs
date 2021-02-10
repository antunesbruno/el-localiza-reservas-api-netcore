using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
