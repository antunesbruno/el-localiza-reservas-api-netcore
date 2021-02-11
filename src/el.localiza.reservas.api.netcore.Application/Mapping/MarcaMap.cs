using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;

namespace el.localiza.reservas.api.netcore.Application.Mapping
{
    public class MarcaMap : Profile
    {
        public MarcaMap()
        {
            CreateMap<Marca, MarcaModel>()
               .ForMember(dest => dest.MarcaId, m => m.MapFrom(src => src.Id))
               .ForMember(dest => dest.DataCriacao, m => m.MapFrom(src => src.DataCriacao))
               .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome));

            CreateMap<MarcaModel, Marca>()
                .ConstructUsing(src =>
                    new Marca(src.Nome));
        }
    }
}
