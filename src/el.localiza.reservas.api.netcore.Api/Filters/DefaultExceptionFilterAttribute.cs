using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using el.localiza.reservas.api.netcore.Application.Models;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace el.localiza.reservas.api.netcore.Api.Filters
{
    [ExcludeFromCodeCoverage]
    public class DefaultExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string DEFAULT_EXCEPTION = "Ocorreu um erro inesperado.";

        public override void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message);

            context.Result = new ObjectResult(new ErrorModel(DEFAULT_EXCEPTION))
            {
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
