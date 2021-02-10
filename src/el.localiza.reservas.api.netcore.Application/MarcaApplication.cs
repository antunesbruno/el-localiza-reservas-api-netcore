using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
