using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;

namespace el.localiza.reservas.api.netcore.Application.Mapping
{
    public class VeiculoMap : Profile
    {
        public VeiculoMap()
        {
            CreateMap<Veiculo, VeiculoModel>()
              .ForMember(dest => dest.IdVeiculo, m => m.MapFrom(src => src.Id))
              .ForMember(dest => dest.Placa, m => m.MapFrom(src => src.Placa))
              .ForMember(dest => dest.Ano, m => m.MapFrom(src => src.Ano))
              .ForMember(dest => dest.ValorHora, m => m.MapFrom(src => src.ValorHora))
              .ForMember(dest => dest.CodigoCombustivel, m => m.MapFrom(src => src.Combustivel))
              .ForMember(dest => dest.DescricaoCombustivel, m => m.MapFrom(src => ConverteCombustivelEnum((int)src.Combustivel)))
              .ForMember(dest => dest.LimitePortaMalas, m => m.MapFrom(src => src.LimitePortaMalas))
              .ForMember(dest => dest.CodigoCategoria, m => m.MapFrom(src => src.Categoria))
              .ForMember(dest => dest.DescricaoCategoria, m => m.MapFrom(src => ConverteCategoriaEnum((int)src.Categoria)))
              .ForMember(dest => dest.Marca, m => m.MapFrom(src => src.Marca))
              .ForMember(dest => dest.Modelo, m => m.MapFrom(src => src.Modelo))
              .ForMember(dest => dest.DataCriacao, m => m.MapFrom(src => src.DataCriacao));

            CreateMap<VeiculoModel, Veiculo>()
                .ConstructUsing(src =>
                    new Veiculo(
                        src.Placa,
                        src.MarcaId,
                        src.ModeloId,
                        src.Ano,
                        src.ValorHora,
                        (CombustivelEnum)src.CodigoCombustivel,
                        src.LimitePortaMalas,
                        (CategoriaEnum)src.CodigoCategoria));

            CreateMap<VeiculoModelRequest, Veiculo>()
               .ConstructUsing(src =>
                   new Veiculo(
                       src.Placa,
                       src.MarcaId,
                       src.ModeloId,
                       src.Ano,
                       src.ValorHora,
                       (CombustivelEnum)src.CodigoCombustivel,
                       src.LimitePortaMalas,
                       (CategoriaEnum)src.CodigoCategoria));
        }

        private string ConverteCombustivelEnum(int codigo)
        {
            switch (codigo)
            {
                case (int)CombustivelEnum.Gasolina:
                    { return "Gasolina"; }
                case (int)CombustivelEnum.Etanol:
                    { return "Etanol"; }
                case (int)CombustivelEnum.Diesel:
                    { return "Diesel"; }
                case (int)CombustivelEnum.GNV:
                    { return "GNV"; }
                case (int)CombustivelEnum.Flex:
                    { return "Flex (Gasolina / Etanol)"; }
            }

            return string.Empty;
        }

        private string ConverteCategoriaEnum(int codigo)
        {
            switch (codigo)
            {
                case (int)CategoriaEnum.Basico:
                    { return "Basico"; }
                case (int)CategoriaEnum.Completo:
                    { return "Completo"; }
                case (int)CategoriaEnum.Luxo:
                    { return "Luxo"; }
            }

            return string.Empty;
        }
    }
}
