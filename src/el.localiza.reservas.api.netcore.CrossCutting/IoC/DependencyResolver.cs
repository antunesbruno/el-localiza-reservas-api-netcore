using Microsoft.Extensions.DependencyInjection;
using el.localiza.reservas.api.netcore.Application;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using el.localiza.reservas.api.netcore.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IAcessoApplication, AcessoApplication>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IVeiculoApplication, VeiculoApplication>();
            services.AddScoped<IMarcaApplication, MarcaApplication>();
            services.AddScoped<IModeloApplication, ModeloApplication>();
            services.AddScoped<IClienteApplication, ClienteApplication>();            
            services.AddScoped<IReservaApplication, ReservaApplication>();

        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IChecklistRepository, ChecklistRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
        }
    }
}