using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class MarcaDbMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("el_veiculo_marca");

            builder.Property(c => c.Id)
                 .IsRequired()
                 .HasColumnName("id_marca");

            builder.Property(c => c.Nome)
                .HasColumnName("nom_marca");

            builder.Property(c => c.DataCriacao)
                .HasColumnName("dt_criacao");

            builder.Ignore(p => p.Notifications);
            builder.Ignore(p => p.Invalid);
            builder.Ignore(p => p.Valid);
        }
    }
}
