using System;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    public class UsuarioModel
    {
        public Guid UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Perfil { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
