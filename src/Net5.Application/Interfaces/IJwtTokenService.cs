using Net5.Application.UsuarioUseCases.Request;

namespace Net5.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(UsuarioRequest user);
    }
}
