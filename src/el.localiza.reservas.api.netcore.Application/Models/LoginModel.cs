using System.Diagnostics.CodeAnalysis;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    [ExcludeFromCodeCoverage]
    public class LoginModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
