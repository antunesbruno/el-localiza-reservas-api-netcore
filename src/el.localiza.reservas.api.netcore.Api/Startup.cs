using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using el.localiza.reservas.api.netcore.Api.Filters;
using el.localiza.reservas.api.netcore.Api.Logging;
using el.localiza.reservas.api.netcore.CrossCutting.Assemblies;
using el.localiza.reservas.api.netcore.CrossCutting.IoC;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace el.localiza.reservas.api.netcore.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            services.AddMvc(options => options.Filters.Add(new DefaultExceptionFilterAttribute()));

            services.AddLoggingSerilog();

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            services.AddDependencyResolver();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "el.localiza.reservas.api.netcore",
                    Description = "API - el.localiza.reservas.api.netcore",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "el.localiza.reservas.api.netcore.Api.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "el.localiza.reservas.api.netcore.Application.xml");

                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(applicationPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/el.localiza.reservas.api.netcore");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/el.localiza.reservas.api.netcore/swagger/v1/swagger.json", "API el.localiza.reservas.api.netcore");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
