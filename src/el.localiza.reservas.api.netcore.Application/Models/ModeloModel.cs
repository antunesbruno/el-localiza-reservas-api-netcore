using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    public class ModeloModel
    {
        public Guid ModeloId { get; set; }
        public string Nome { get; set; }
        public Guid MarcaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ImagePath { get; set; }
        public MarcaModel Marca { get; set; }
    }
}
