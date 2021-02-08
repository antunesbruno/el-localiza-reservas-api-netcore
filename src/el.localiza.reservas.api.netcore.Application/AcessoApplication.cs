using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Interfaces;
using el.localiza.reservas.api.netcore.Application.Models;
using el.localiza.reservas.api.netcore.Domain.Entities;
using el.localiza.reservas.api.netcore.Domain.Extensions;
using el.localiza.reservas.api.netcore.Domain.Repositories;
using System.Threading.Tasks;

namespace el.localiza.reservas.api.netcore.Application
{
    public class AcessoApplication : IAcessoApplication
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public AcessoApplication(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Result<Usuario>> ValidarDadosAcesso(LoginModel loginModel)
        {
            //valida os dados de acesso
            var usuario = await _usuarioRepository.ObterPorLogin(loginModel.Usuario);

            if (usuario != null)
            {
                //valida a senha
                var usuarioValido = CriptografiaService.Validate(loginModel.Senha, Salt.SALT_DEFAULT, usuario.Senha);

                if (usuarioValido)
                {
                    //reseta a senha
                    usuario.Senha = string.Empty;

                    //retorna o usuario
                    return Result<Usuario>.Ok(usuario);
                }             
            }

            //adiciona a notificacao
            var usuarioErro = new Usuario();
            usuarioErro.AddNotification("404", "Login inválido - Verifique se foi informado o Login e Senha corretos !");
            return Result<Usuario>.Error(usuarioErro.Notifications);
        }
    }
}
