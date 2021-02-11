using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using Flunt.Validations;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Modelo : Entity, IAggregateRoot
    {
        public Modelo()
        {

        }

        public Modelo(string nome, string marca, string imagePath)
        {
            Nome = nome;
            MarcaId = Guid.Parse(marca);
            ImagePath = imagePath;
            DataCriacao = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Nome, nameof(Nome), "Nome do Modelo não pode ser nulo"));

            if (Marca != null)
                AddNotifications(Marca);
        }

        public string Nome { get; private set; }
        public Guid MarcaId { get; private set; }        
        public DateTime DataCriacao { get; set; }
        public string ImagePath { get; set; }

        public Marca Marca { get; private set; }
    }
}
