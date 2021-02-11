using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class ChecklistDbMap : IEntityTypeConfiguration<Checklist>
    {
        public void Configure(EntityTypeBuilder<Checklist> builder)
        {
            builder.ToTable("el_checklist");

            builder.Property(c => c.Id)
                 .IsRequired()
                 .HasColumnName("id_checklist");

            builder.Property(c => c.IdReserva)
                .HasColumnName("id_reserva");

            builder.Property(c => c.IdItemChecklist)
                .HasColumnName("id_checklist_item");

            builder.Property(c => c.Observacao)
                .HasColumnName("desc_observacao");

            builder.Property(c => c.ItemOk)
                .HasColumnName("idc_itemOk");

            builder.Property(c => c.DataCheckList)
                .HasColumnName("dt_checklist");

            builder.Property(c => c.DataCriacao)
                .HasColumnName("dt_criacao");
        }
    }
}
