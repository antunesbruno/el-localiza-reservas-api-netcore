using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Infrastructure.Database.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Infrastructure.Database
{
    [ExcludeFromCodeCoverage]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(new ClienteDbMap().Configure);
            modelBuilder.Entity<Marca>(new MarcaDbMap().Configure);
            modelBuilder.Entity<Modelo>(new ModeloDbMap().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioDbMap().Configure);
            modelBuilder.Entity<Veiculo>(new VeiculoDbMap().Configure);

            modelBuilder.Ignore<Notification>();            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }        
    }
}
