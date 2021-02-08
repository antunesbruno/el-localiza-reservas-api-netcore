using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;

namespace el.localiza.reservas.api.netcore.Application.Mapping
{
    public class UsuarioMap : Profile
    {
        public UsuarioMap()
        {
            CreateMap<Usuario, UsuarioModel>()
                .ForMember(dest => dest.UsuarioId, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, m => m.MapFrom(src => src.Login))
                .ForMember(dest => dest.Cpf, m => m.MapFrom(src => src.Cpf.ToString()))
                .ForMember(dest => dest.Matricula, m => m.MapFrom(src => src.Matricula))
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome.NomeCompleto))
                .ForMember(dest => dest.Email, m => m.MapFrom(src => src.Email.ToString()))
                .ForMember(dest => dest.DataCriacao, m => m.MapFrom(src => src.DataCriacao))
                .ForMember(dest => dest.Perfil, m => m.MapFrom(src => src.Perfil));

            CreateMap<UsuarioModel, Usuario>()
                .ForMember(dest => dest.Nome, m => m.Ignore())
                .ForMember(dest => dest.Cpf, m => m.Ignore())
                .ForMember(dest => dest.Email, m => m.Ignore())
                .ConstructUsing(src =>
                    new Usuario(
                        src.Login,
                        src.Senha,
                        new Nome(src.Nome),
                        new CPF(src.Cpf),
                        new Email(src.Email),
                        (PerfilUsuarioEnum)src.Perfil)
                    );
        }
    }
}
