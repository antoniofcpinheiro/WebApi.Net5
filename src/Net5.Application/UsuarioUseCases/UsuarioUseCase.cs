using Net5.Application.Interfaces;
using Net5.Application.UsuarioUseCases.Request;
using Net5.Application.UsuarioUseCases.Response;
using Net5.Application.UsuarioUseCases.Validations;
using System;

namespace Net5.Application.UsuarioUseCases
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IJwtTokenService _jwtService;
        private readonly IUsuarioValidator _validator;
        private readonly IGeradorDeSenhas _geradorDeSenhas;

        public UsuarioUseCase(IJwtTokenService jwtService,
                              IUsuarioValidator validator,
                              IGeradorDeSenhas geradorDeSenhas)
        {
            _jwtService = jwtService;
            _validator = validator;
            _geradorDeSenhas = geradorDeSenhas;
        }

        public string GerarSenha() => _geradorDeSenhas.GerarSenha();
        public bool ValidarSenha(string senha) => senha.Validar();

        public UsuarioResponse GerarToken(UsuarioRequest request)
        {
            if (!_validator.Validar(request))
                return new UsuarioResponse(request.Usuario);

            return new UsuarioResponse
            {
                Usuario = request.Usuario,
                Token = _jwtService.GenerateToken(request),
                ExpiraEm = DateTime.UtcNow.AddMinutes(5),
                Autenticado = true
            };
        }


    }
}
