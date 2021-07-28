using Net5.Application.UsuarioUseCases.Request;

namespace Net5.Application.Interfaces
{
    public interface IUsuarioValidator
    {
        bool Validar(UsuarioRequest usuario);
    }
}
