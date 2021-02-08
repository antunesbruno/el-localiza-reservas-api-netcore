using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using el.localiza.reservas.api.netcore.Domain.Enums;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;
using Flunt.Validations;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Usuario()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Login, nameof(Login), "Usuario não encontrado !"));
        }

        public Usuario(string login, string senha, Nome nome, CPF cpf, Email email, PerfilUsuarioEnum perfil)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Perfil = perfil;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Login, nameof(Login), "Login não pode ser nulo")
                .IsNotNullOrWhiteSpace(Senha, nameof(Senha), "Senha não pode ser nulo"));

            if (Nome != null)
                AddNotifications(Nome);

            if (Cpf != null)
                AddNotifications(Cpf);

            if (Email != null)
                AddNotifications(Email);
        }

        public Usuario(string login, string senha, Nome nome, string matricula, Email email, PerfilUsuarioEnum perfil)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            Matricula = matricula;
            Email = email;
            Perfil = perfil;
            Matricula = matricula;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Login, nameof(Login), "Login não pode ser nulo")
                .IsNotNullOrWhiteSpace(Senha, nameof(Senha), "Senha não pode ser nulo")
                .HasLen(Matricula, 6, nameof(Matricula), "Matrícula inválida")
                .IsDigit(Matricula, nameof(Matricula), "Matricula deve conter apenas números"));

            if (Nome != null)
                AddNotifications(Nome);

            if (Email != null)
                AddNotifications(Email);
        }

        public string Login { get; private set; }
        public string Senha { get; set; }
        public CPF Cpf { get; private set; }
        public string Matricula { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public PerfilUsuarioEnum Perfil { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
