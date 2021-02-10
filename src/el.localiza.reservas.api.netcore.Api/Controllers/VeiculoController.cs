using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Api.Controllers
{
    public class VeiculoController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoApplication _veiculoApplication;

        public VeiculoController(IMapper mapper, IVeiculoApplication veiculoApplication)
        {
            _mapper = mapper;
            _veiculoApplication = veiculoApplication;
        }
    }
}
