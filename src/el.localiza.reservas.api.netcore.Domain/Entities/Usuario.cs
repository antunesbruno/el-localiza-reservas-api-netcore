using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;
using Flunt.Validations;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Usuario(string login, string senha, Nome nome, PerfilUsuarioEnum perfil)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            Perfil = perfil;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Login, nameof(Login), "Login não pode ser nulo")
                .IsNotNull(Senha, nameof(Senha), "Senha não pode ser nulo"));

            if (Nome != null)
                AddNotifications(Nome);
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
        public CPF Cpf { get; private set; }
        public string Matricula { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public PerfilUsuarioEnum Perfil { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
