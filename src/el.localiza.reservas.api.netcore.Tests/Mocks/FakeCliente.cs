using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public static class FakeCliente
    {
        public static ClienteModel ObtemClienteModelDefault()
        {
            return new ClienteModel()
            {
                Id = Guid.NewGuid(),
                Nome = "João",
                Sobrenome = "Silva",
                Cpf = "12345678910",
                Ddd = 11,
                Telefone = "999009900",
                Email = "joao@gmail.com",
                DataNascimento = DateTime.Now,
                Logradouro = "Rua Bernardo Monteiro",
                Numero = 100,
                Complemento = "Casa de esquina",
                Cidade = "Belo Horizonte",
                Estado = "MG",
                Cep = "30111222"
            };
        }

        public static Cliente ObtemClienteDefault()
        {
            return new Cliente(
                new Nome("João", "Silva"),
                new CPF("12345678910"),
                new Email("joao@gmail.com"),
                new Telefone(11, "999009900"),
                DateTime.Now,
                new Endereco("Rua Bernardo Monteiro", 100, "Casa de esquina", "Belo Horizonte", "MG", "30111222"));            
        }
    }
}
