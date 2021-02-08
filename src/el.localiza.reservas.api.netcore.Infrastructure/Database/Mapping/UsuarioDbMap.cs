using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class UsuarioDbMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("el_usuario");

            builder.HasKey(c => c.Id)
                .HasName("pk_el_usuario");

            builder.Property(c => c.Id)
                 .IsRequired()
                 .HasColumnName("id_usuario");

            builder.Property(c => c.Login)
                .HasColumnName("cd_login");

            builder.Property(c => c.Senha)
                .HasColumnName("cd_senha");

            builder.Property(c => c.Matricula)
                .HasColumnName("cd_matricula");

            builder.OwnsOne(m => m.Cpf, a =>
            {
                a.Property(p => p.Numero)
                    .HasColumnName("cd_cpf_usuario")
                    .HasDefaultValue(null);

                a.Ignore(p => p.Notifications);
                a.Ignore(p => p.Invalid);
                a.Ignore(p => p.Valid);
            });

            builder.OwnsOne(m => m.Nome, a =>
            {
                a.Property(p => p.PrimeiroNome)
                    .HasColumnName("nom_usuario")
                    .HasDefaultValue(null);

                a.Property(p => p.Sobrenome)
                    .HasColumnName("nom_sobrenome_usuario")
                    .HasDefaultValue(null);

                a.Ignore(p => p.Notifications);
                a.Ignore(p => p.Invalid);
                a.Ignore(p => p.Valid);
            });

            builder.OwnsOne(m => m.Email, a =>
            {
                a.Property(p => p.Endereco)
                    .HasColumnName("email_usuario")
                    .HasDefaultValue(null);

                a.Ignore(p => p.Notifications);
                a.Ignore(p => p.Invalid);
                a.Ignore(p => p.Valid);
            });         

            builder.Property(c => c.DataCriacao)
                .HasColumnName("dt_criacao");

            builder.Ignore(p => p.Notifications);
            builder.Ignore(p => p.Invalid);
            builder.Ignore(p => p.Valid);
        }
    }
}
