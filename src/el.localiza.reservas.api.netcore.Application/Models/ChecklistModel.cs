using System;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    [ExcludeFromCodeCoverage]
    public class ChecklistModel
    {
        public string IdChecklist { get; set; }
        public string IdReserva { get; set; }
        public string IdItemChecklist { get; set; }
        public DateTime DataCheckList { get; set; } 
        public string Observacao { get; set; }
        public bool ItemOk { get; set; }
        public DateTime DataCriacao { get; set; }
        
    }
}
