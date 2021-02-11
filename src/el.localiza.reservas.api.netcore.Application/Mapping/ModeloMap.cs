using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;

namespace el.localiza.reservas.api.netcore.Application.Mapping
{
    public class ModeloMap : Profile
    {
        public ModeloMap()
        {
            CreateMap<Modelo, ModeloModel>()
              .ForMember(dest => dest.ModeloId, m => m.MapFrom(src => src.Id))
              .ForMember(dest => dest.MarcaId, m => m.MapFrom(src => src.MarcaId))
              .ForMember(dest => dest.DataCriacao, m => m.MapFrom(src => src.DataCriacao))
              .ForMember(dest => dest.ImagePath, m => m.MapFrom(src => src.ImagePath))
              .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome));

            CreateMap<ModeloModel, Modelo>()
                    .ConstructUsing(src =>
                        new Modelo(
                            src.Nome,
                            src.MarcaId.ToString(),
                            src.ImagePath)); 
        }
    }
}
