using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using el.localiza.reservas.api.netcore.Application.Models;
using System.Collections.Generic;
using System.Net;

namespace el.localiza.reservas.api.netcore.Api.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        protected BadRequestObjectResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            return new BadRequestObjectResult(new ErrorModel(notifications));
        }

        protected NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ErrorModel(message));
        }

        protected IActionResult InternalServerError()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro interno. Não foi possivel comunicar com o servidor.");
        }
    }
}