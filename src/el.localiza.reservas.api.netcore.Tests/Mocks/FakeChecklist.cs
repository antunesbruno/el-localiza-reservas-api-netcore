using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public static class FakeChecklist
    {
        public static ChecklistModel ObtemChecklistModelDefault()
        {
            return new ChecklistModel() {
                IdChecklist = Guid.NewGuid().ToString(),
                IdReserva = Guid.NewGuid().ToString(),
                IdItemChecklist = Guid.NewGuid().ToString(),
                DataCheckList = DateTime.Now,
                Observacao = "Não teve ocorrencias",
                ItemOk = true,
                DataCriacao = DateTime.Now
            };
        }

        public static Checklist ObtemChecklistDefault()
        {            
            return new Checklist(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now, "", true) ;            
        }
    }
}
