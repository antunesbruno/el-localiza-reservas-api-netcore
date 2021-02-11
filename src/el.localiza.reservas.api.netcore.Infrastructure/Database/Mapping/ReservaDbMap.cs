using el.localiza.reservas.api.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class ReservaDbMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("el_reserva");

            builder.Property(c => c.Id)
                 .IsRequired()
                 .HasColumnName("id_reserva");

            builder.Property(c => c.IdCliente)
                .HasColumnName("id_cliente");

            builder.Property(c => c.IdUsuario)
                .HasColumnName("id_usuario");

            builder.Property(c => c.IdVeiculo)
                .HasColumnName("id_veiculo");

            builder.Property(c => c.TotalHoras)
                .HasColumnName("num_total_horas");

            builder.Property(c => c.ValorTotalReserva)
                .HasColumnName("vlr_total_reserva");

            builder.Property(c => c.Simulacao)
                .HasColumnName("idc_simulacao");

            builder.Property(c => c.Efetivada)
                .HasColumnName("idc_efetivada");

            builder.Property(c => c.Agendamento)
                .HasColumnName("idc_agendamento");

            builder.Property(c => c.DataSimulacao)
                .HasColumnName("dt_simulacao");

            builder.Property(c => c.DataPrevisaoRetirada)
                .HasColumnName("dt_previsao_retirada");

            builder.Property(c => c.DataPrevisaoDevolucao)
                .HasColumnName("dt_previsao_devolucao");

            builder.Property(c => c.DataRetiradaReal)
                .HasColumnName("dt_retirada_real");

            builder.Property(c => c.DataDevolucaoReal)
                .HasColumnName("dt_devolucao_real");

            builder.Property(c => c.DataCriacao)
                .HasColumnName("dt_criacao");

            builder.Property(c => c.ValorTotalPosChecklist)
                .HasColumnName("vlr_total_pos_check");

            builder.Ignore(p => p.Notifications);
            builder.Ignore(p => p.Invalid);
            builder.Ignore(p => p.Valid);
        }
    }
}
