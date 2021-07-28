using System.Text.RegularExpressions;

namespace Net5.Application.UsuarioUseCases.Validations
{
    public static class SenhaValidator
    {
        public static bool Validar(this string senha)
        {
            return senha.TamanhoMinimo() &&
                   senha.MinimoLetraMaiuscula() &&
                   senha.MinimoLetraMinuscula() &&
                   senha.PossuirCaractererEspecial() &&
                   senha.CarectereEmSequencialPermitida();
        }
        public static bool TamanhoMinimo(this string senha)
        {
            return senha.Length >= 15;
        }
        public static bool MinimoLetraMaiuscula(this string senha)
        {
            return new Regex("(?=.*?[A-Z])").IsMatch(senha);
        }
        public static bool MinimoLetraMinuscula(this string senha)
        {
            return new Regex("(?=.*?[a-z])").IsMatch(senha);
        }
        public static bool PossuirCaractererEspecial(this string senha)
        {
            return new Regex("(?=.*?[#?!@$%^&*\\-,_])").IsMatch(senha);
        }
        public static bool CarectereEmSequencialPermitida(this string senha)
        {
            return !new Regex(@"(.)\1{1}").IsMatch(senha);
        }
    }
}
