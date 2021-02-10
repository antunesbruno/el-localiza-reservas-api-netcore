using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Api.Controllers
{
    [Route("modelos")]
    [ApiController]
    public class ModeloController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IModeloApplication _modeloApplication;

        public ModeloController(IMapper mapper, IModeloApplication modeloApplication)
        {
            _mapper = mapper;
            _modeloApplication = modeloApplication;
        }

        /// <summary>
        /// Cria um novo modelo de veiculo
        /// </summary>
        /// <param name="modeloModel">Modelo de veiculo</param>
        /// <returns></returns>
        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(ModeloModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarModeloVeiculo([FromBody] ModeloModel modeloModel)
        {
            try
            {
                var result = await _modeloApplication.SalvarAsync(modeloModel);

                if (result.Success)
                    return Created($"/modelos/{result.Object.Id}", _mapper.Map<Modelo, ModeloModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "ModeloController > CriarModeloVeiculo - Erro Interno");

                //StatusCode-500
                return InternalServerError();
            }
        }

    }
}
