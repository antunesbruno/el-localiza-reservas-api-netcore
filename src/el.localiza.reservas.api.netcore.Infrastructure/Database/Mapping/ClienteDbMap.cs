using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping
{    
    [ExcludeFromCodeCoverage]
    public class ClienteDbMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {          
            builder.ToTable("el_cliente");

            builder.HasKey(c => c.Id)
                .HasName("pk_el_cliente");

            builder.Property(c => c.Id)
                 .IsRequired()
                 .HasColumnName("id_cliente");

            builder.OwnsOne(m => m.Nome, a =>
            {
                a.Property(p => p.PrimeiroNome)
                    .HasColumnName("nom_cliente")
                    .HasDefaultValue(null);

                a.Property(p => p.Sobrenome)
                    .HasColumnName("nom_sobrenome_cliente")
                    .HasDefaultValue(null);

                a.Ignore(p => p.Notifications);
                a.Ignore(p => p.Invalid);
                a.Ignore(p => p.Valid);
            });

            builder.OwnsOne(m => m.Cpf, a =>
            {
                a.Property(p => p.Numero)
                    .HasColumnName("cd_cpf_cliente")
                    .HasDefaultValue(null);

                a.Ignore(p => p.Notifications);
                a.Ignore(p => p.Invalid);
                a.Ignore(p => p.Valid);
            });

            builder.OwnsOne(m => m.Email, a =>
            {
                a.Property(p => p.Endereco)
                    .HasColumnName("email_cliente")
                    .HasDefaultValue(null);

                a.Ignore(p => p.Notifications);
                a.Ignore(p => p.Invalid);
                a.Ignore(p => p.Valid);
            });

            builder.OwnsOne(m => m.Endereco, a =>
            {
                a.Property(p => p.Logradouro)
                    .HasColumnName("desc_logradouro")
                    .HasDefaultValue(null);

                a.Property(p => p.Numero)
                    .HasColumnName("num_residencia")
                    .HasDefaultValue(null);

                a.Property(p => p.Complemento)
                    .HasColumnName("desc_complemento")
                    .HasDefaultValue(null);

                a.Property(p => p.Cidade)
                    .HasColumnName("desc_cidade")
                    .HasDefaultValue(null);

                a.Property(p => p.Estado)
                    .HasColumnName("sigla_estado")
                    .HasDefaultValue(null);

                a.Property(p => p.Cep)
                  .HasColumnName("num_cep")
                  .HasDefaultValue(null);

                a.Ignore(p => p.Notifications);
                a.Ignore(p => p.Invalid);
                a.Ignore(p => p.Valid);
            });

            builder.Property(c => c.DataCriacao)
                .HasColumnName("dt_criacao");

            builder.Property(c => c.DataNascimento)
                .HasColumnName("dt_nascimento");

            builder.Ignore(p => p.Notifications);
            builder.Ignore(p => p.Invalid);
            builder.Ignore(p => p.Valid);
        }
    }
}