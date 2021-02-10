using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
    

