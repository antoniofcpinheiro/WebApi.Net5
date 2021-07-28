using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net5.Application.Interfaces;
using Net5.Application.UsuarioUseCases.Request;
using Net5.Application.UsuarioUseCases.Response;

namespace Net5.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCase _useCase;
        public UsuarioController(IUsuarioUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        [Route(nameof(ValidarUsuario))]
        [AllowAnonymous]
        public UsuarioResponse ValidarUsuario([FromBody] UsuarioRequest request) =>
            _useCase.GerarToken(request);

        [HttpGet]
        [Route(nameof(GerarSenha))]
        [Authorize]
        public string GerarSenha() => 
            _useCase.GerarSenha();

        [HttpGet]
        [Route(nameof(ValidarSenha))]
        [Authorize]
        public SenhaResponse ValidarSenha(string senha) =>
            _useCase.ValidarSenha(senha);
    }
}
