using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    [ExcludeFromCodeCoverage]
    public class MarcaModel
    {
        public Guid MarcaId { get; set; }        
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
