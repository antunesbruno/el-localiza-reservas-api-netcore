using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;

namespace el.localiza.reservas.api.netcore.Application.Mapping
{
    public class ClienteMap : Profile
    {
        public ClienteMap()
        {
            CreateMap<Cliente, ClienteModel>()
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome.PrimeiroNome))
                .ForMember(dest => dest.Sobrenome, m => m.MapFrom(src => src.Nome.Sobrenome))
                .ForMember(dest => dest.Cpf, m => m.MapFrom(src => src.Cpf.ToString()))
                .ForMember(dest => dest.Ddd, m => m.MapFrom(src => src.Telefone.Ddd))
                .ForMember(dest => dest.Telefone, m => m.MapFrom(src => src.Telefone.Numero))
                .ForMember(dest => dest.Email, m => m.MapFrom(src => src.Email.ToString()))
                .ForMember(dest => dest.DataNascimento, m => m.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Logradouro, m => m.MapFrom(src => src.Endereco.Logradouro))
                .ForMember(dest => dest.Numero, m => m.MapFrom(src => src.Endereco.Numero))
                .ForMember(dest => dest.Complemento, m => m.MapFrom(src => src.Endereco.Complemento))
                .ForMember(dest => dest.Cidade, m => m.MapFrom(src => src.Endereco.Cidade))
                .ForMember(dest => dest.Estado, m => m.MapFrom(src => src.Endereco.Estado))
                .ForMember(dest => dest.Cep, m => m.MapFrom(src => src.Endereco.Cep));

            CreateMap<ClienteModel, Cliente>()
                .ForMember(dest => dest.Nome, m => m.Ignore())
                .ForMember(dest => dest.Cpf, m => m.Ignore())
                .ForMember(dest => dest.Email, m => m.Ignore())
                .ForMember(dest => dest.Telefone, m => m.Ignore())
                .ForMember(dest => dest.Endereco, m => m.Ignore())
                .ConstructUsing(src =>
                    new Cliente(
                        new Nome(src.Nome, src.Sobrenome),
                        new CPF(src.Cpf),
                        new Email(src.Email),
                        new Telefone(src.Ddd, src.Telefone),
                        src.DataNascimento,
                        new Endereco(src.Logradouro, src.Numero, src.Complemento, src.Cidade, src.Estado, src.Cep))
                    );
        }
    }
}

