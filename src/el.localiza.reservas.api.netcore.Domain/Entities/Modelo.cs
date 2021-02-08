using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using Flunt.Validations;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Modelo : Entity, IAggregateRoot
    {
        public Modelo(string nome, Marca marca)
        {
            Nome = nome;
            Marca = marca;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Nome, nameof(Nome), "Nome do Modelo não pode ser nulo"));

            if (Marca != null)
                AddNotifications(Marca);
        }

        public string Nome { get; private set; }
        public Guid MarcaId { get; private set; }        
        public DateTime DataCriacao { get; private set; }

        public Marca Marca { get; private set; }
    }
}
