using System;

namespace el.localiza.reservas.api.netcore.Application.Models
{
    public class UsuarioModel
    {
        public Guid UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; private set; }
        public string Matricula { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public int Perfil { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
