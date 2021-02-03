using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace el.localiza.reservas.api.netcore.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {            
            return new Assembly[]
            {
                Assembly.Load("el.localiza.reservas.api.netcore.Api"),
                Assembly.Load("el.localiza.reservas.api.netcore.Application"),
                Assembly.Load("el.localiza.reservas.api.netcore.Domain"),
                Assembly.Load("el.localiza.reservas.api.netcore.Domain.Core"),
                Assembly.Load("el.localiza.reservas.api.netcore.Infrastructure"),
                Assembly.Load("el.localiza.reservas.api.netcore.CrossCutting")
            };
        }
    }
}
