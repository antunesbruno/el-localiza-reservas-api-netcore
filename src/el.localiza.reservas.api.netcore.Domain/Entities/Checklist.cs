using el.localiza.reservas.api.netcore.Domain.Core.Entities;
using System;

namespace el.localiza.reservas.api.netcore.Domain.Entities
{
    public class Checklist : Entity, IAggregateRoot
    {
        public Checklist() { }

        public Checklist(string idChecklist, string idReserva, string idItemChecklist, DateTime dataCheckList, string observacao, bool itemOk)
        {
            IdChecklist = idChecklist;
            IdReserva = idReserva;
            IdItemChecklist = idItemChecklist;
            DataCheckList = dataCheckList;
            Observacao = observacao;
            ItemOk = itemOk;            
            DataCriacao = DateTime.Now;
        }

        public string IdChecklist { get; set; }
        public string IdReserva { get; set; }
        public string IdItemChecklist { get; set; }
        public DateTime DataCheckList { get; set; }
        public string Observacao { get; set; }
        public bool ItemOk { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
