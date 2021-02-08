using Flunt.Validations;
using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Cliente : Entity, IAggregateRoot
    {
        public Cliente(Nome nome, CPF cpf, Email email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataCriacao = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Nome, nameof(Nome), "Nome não pode ser nulo")
                .IsNotNull(Cpf, nameof(Cpf), "Cpf não pode ser nulo")
                .IsNotNull(Email, nameof(Email), "Email não pode ser nulo"));

            if (Nome != null)
                AddNotifications(Nome);

            if (Cpf != null)
                AddNotifications(Cpf);

            if (Email != null)
                AddNotifications(Email);
        }

        public Nome Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public Telefone Telefone { get; private set; }
        public Email Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Endereco Endereco { get; private set; }      
    }
}
