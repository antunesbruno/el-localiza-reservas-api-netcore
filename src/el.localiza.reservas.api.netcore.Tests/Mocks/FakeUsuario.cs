using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public static class FakeUsuario
    {
        public static UsuarioModel ObtemUsuarioModelDefault()
        {
            return new UsuarioModel() {
                UsuarioId = Guid.NewGuid().ToString(),
                Login = "01122233344",
                Senha = "12346",
                Cpf = "01122233344",
                Matricula = "",
                Nome = "Jose da Silva",
                Email = "jose@gmail.com",
                Perfil = 0,
                DataCriacao = DateTime.Now
            };
        }

        public static Usuario ObtemUsuarioCpfDefault()
        {            
            return new Usuario("01122233344", "1234", new Nome("Jose", "Da Silva"), new CPF("01122233344"), new Email("jose@gmail.com"), netcore.Domain.Enums.PerfilUsuarioEnum.Cliente);
        }

        public static Usuario ObtemUsuarioMatriculaDefault()
        {
            //Usuario(string login, string senha, Nome nome, string matricula, Email email, PerfilUsuarioEnum perfil)
            return new Usuario("131313", "1234", new Nome("Jose", "Da Silva"), "131313", new Email("jose@gmail.com"), netcore.Domain.Enums.PerfilUsuarioEnum.Operador);
        }
    }
}

        
    
    