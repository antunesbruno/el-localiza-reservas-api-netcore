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
            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IAcessoApplication, AcessoApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            //services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}