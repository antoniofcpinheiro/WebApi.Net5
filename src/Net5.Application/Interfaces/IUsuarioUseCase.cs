using Net5.Application.UsuarioUseCases.Request;
using Net5.Application.UsuarioUseCases.Response;

namespace Net5.Application.Interfaces
{
    public interface IUsuarioUseCase
    {
        UsuarioResponse GerarToken(UsuarioRequest request);
        SenhaResponse ValidarSenha(string senha);
        string GerarSenha();
    }
}
