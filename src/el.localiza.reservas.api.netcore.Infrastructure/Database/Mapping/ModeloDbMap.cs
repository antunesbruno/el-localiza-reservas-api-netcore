using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class ModeloDbMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("el_veiculo_modelo");

            builder.HasKey(c => c.Id)
                .HasName("pk_el_veiculo_modelo");

            builder.Property(c => c.Id)
                 .IsRequired()
                 .HasColumnName("id_veiculo_modelo");

            builder.Property(c => c.Nome)
                .HasColumnName("nom_modelo");

            builder.HasOne(x => x.Marca)
               .WithMany()
               .HasForeignKey(c => c.MarcaId)
               .HasConstraintName("fk_elveicmarca_elveicmodelo");

            builder.Property(c => c.DataCriacao)
                .HasColumnName("dt_criacao");

            builder.Ignore(p => p.Notifications);
            builder.Ignore(p => p.Invalid);
            builder.Ignore(p => p.Valid);
        }
    }
}
