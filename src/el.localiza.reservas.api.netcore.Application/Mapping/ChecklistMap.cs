using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;

namespace el.localiza.reservas.api.netcore.Application.Mapping
{
    public class ChecklistMap : Profile
    {
        public ChecklistMap()
        {
            CreateMap<Checklist, ChecklistModel>()
              .ForMember(dest => dest.IdChecklist, m => m.MapFrom(src => src.Id))
              .ForMember(dest => dest.IdReserva, m => m.MapFrom(src => src.IdReserva))
              .ForMember(dest => dest.IdItemChecklist, m => m.MapFrom(src => src.IdItemChecklist))
              .ForMember(dest => dest.DataCheckList, m => m.MapFrom(src => src.DataCheckList))
              .ForMember(dest => dest.Observacao, m => m.MapFrom(src => src.Observacao))
              .ForMember(dest => dest.ItemOk, m => m.MapFrom(src => src.ItemOk))
              .ForMember(dest => dest.DataCriacao, m => m.MapFrom(src => src.DataCriacao));


        CreateMap<ChecklistModel, Checklist>()
                .ConstructUsing(src =>
                    new Checklist(
                        src.IdChecklist,
                        src.IdReserva,
                        src.IdItemChecklist,
                        src.DataCheckList,
                        src.Observacao,
                        src.ItemOk));
         
        }
    }
}
