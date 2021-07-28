using Net5.Application.Interfaces;
using Net5.Application.UsuarioUseCases.Request;

namespace Net5.Application.UsuarioUseCases.Validations
{
    public class UsuarioValidator : IUsuarioValidator
    {
        public bool Validar(UsuarioRequest usuario)
        {
            if (string.IsNullOrEmpty(usuario.Usuario))
                return false;

            return usuario.Senha.TamanhoMinimo() &&
                   usuario.Senha.MinimoLetraMaiuscula() &&
                   usuario.Senha.MinimoLetraMinuscula() &&
                   usuario.Senha.PossuirCaractererEspecial() &&
                   usuario.Senha.CarectereEmSequencialPermitida();
        }
    }
}
