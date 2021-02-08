using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using Flunt.Validations;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Veiculo : Entity, IAggregateRoot
    {
        public Veiculo()
        {

        }
        public Veiculo(string placa, Guid marca, Guid modelo, int ano, double valorHora, CombustivelEnum combustivel, int limitePortaMalas, CategoriaEnum categoria)
        {
            Placa = placa;
            MarcaId = marca;
            ModeloId = modelo;
            Ano = ano;
            ValorHora = valorHora;
            Combustivel = combustivel;
            LimitePortaMalas = limitePortaMalas;
            Categoria = categoria;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Placa, nameof(Placa), "Placa não pode ser nulo")
                .IsNotNull(MarcaId, nameof(MarcaId), "Marca não pode ser nulo")
                .IsNotNull(ModeloId, nameof(ModeloId), "Modelo não pode ser nulo")
                .IsGreaterOrEqualsThan(Ano, DateTime.Now.AddYears(-6).Year, nameof(Ano), "Ano do veículo deve ser maior que " + DateTime.Now.AddYears(-6).Year)
                .IsGreaterOrEqualsThan(ValorHora, 1, nameof(ValorHora), "Valor/Hora do veículo deve ser maior que zero")
                .IsGreaterOrEqualsThan(LimitePortaMalas, 1, nameof(LimitePortaMalas), "Limite do Porta-Malas deve ser maior que zero"));
        }

        public string Placa { get; private set; }
        public Guid MarcaId { get; private set; }
        public Guid ModeloId { get; private set; }
        public int Ano { get; private set; }
        public double ValorHora { get; private set; }
        public CombustivelEnum Combustivel { get; private set; }
        public int LimitePortaMalas { get; private set; }
        public CategoriaEnum Categoria { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Marca Marca { get; private set; }
        public Modelo Modelo { get; private set; }
    }
}
