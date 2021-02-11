using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;

namespace el.localiza.reservas.api.netcore.Application.Mapping
{
    public class ReservaMap : Profile
    {
        public ReservaMap()
        {
            CreateMap<Reserva, ReservaModel>()
              .ForMember(dest => dest.TotalHoras, m => m.MapFrom(src => src.TotalHoras))
              .ForMember(dest => dest.ValorTotalReserva, m => m.MapFrom(src => src.ValorTotalReserva))
              .ForMember(dest => dest.Simulacao, m => m.MapFrom(src => src.Simulacao))
              .ForMember(dest => dest.Efetivada, m => m.MapFrom(src => src.Efetivada))
              .ForMember(dest => dest.Agendamento, m => m.MapFrom(src => src.Agendamento))
              .ForMember(dest => dest.DataSimulacao, m => m.MapFrom(src => src.DataSimulacao))
              .ForMember(dest => dest.DataPrevisaoRetirada, m => m.MapFrom(src => src.DataPrevisaoRetirada))
              .ForMember(dest => dest.DataPrevisaoDevolucao, m => m.MapFrom(src => src.DataPrevisaoDevolucao))
              .ForMember(dest => dest.DataRetiradaReal, m => m.MapFrom(src => src.DataRetiradaReal))
              .ForMember(dest => dest.DataDevolucaoReal, m => m.MapFrom(src => src.DataDevolucaoReal))
              .ForMember(dest => dest.ValorTotalPosChecklist, m => m.MapFrom(src => src.ValorTotalPosChecklist));

            CreateMap<ReservaModelRequest, Reserva>()
                        .ConstructUsing(src =>
                            new Reserva(
                                src.IdCliente,
                                src.IdUsuario,
                                src.IdVeiculo,
                                src.TotalHoras,
                                src.ValorTotalReserva,
                                src.Simulacao,
                                src.Efetivada,
                                src.Agendamento,
                                src.DataSimulacao,
                                src.DataPrevisaoRetirada,
                                src.DataPrevisaoDevolucao,
                                src.DataRetiradaReal,
                                src.DataDevolucaoReal,
                                src.ValorTotalPosChecklist));

        }
    }
}
