using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using Flunt.Validations;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Marca : Entity, IAggregateRoot
    {
        public Marca() { }

        public Marca(string nome)
        {
            Nome = nome;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Nome, nameof(Nome), "Nome da Marca não pode ser nulo"));
        }


        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
