﻿using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class VeiculoDbMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("el_veiculo");

            builder.Property(c => c.Id)
                 .IsRequired()
                 .HasColumnName("id_veiculo");

            builder.Property(c => c.Placa)
                .HasColumnName("cd_placa");

            builder.Property(c => c.MarcaId)
                .HasColumnName("id_marca");

            builder.Property(c => c.ModeloId)
                .HasColumnName("id_modelo");

            builder.Property(c => c.Ano)
                .HasColumnName("num_ano");

            builder.Property(c => c.ValorHora)
                .HasColumnName("vlr_hora");

            builder.Property(c => c.Combustivel)
                .HasColumnName("idc_combustivel");

            builder.Property(c => c.Categoria)
                .HasColumnName("idc_categoria");

            builder.Property(c => c.LimitePortaMalas)
                .HasColumnName("num_limite_pm");

            builder.Property(c => c.DataCriacao)
                .HasColumnName("dt_criacao");

            builder.Ignore(p => p.Notifications);
            builder.Ignore(p => p.Invalid);
            builder.Ignore(p => p.Valid);
        }
    }
}

