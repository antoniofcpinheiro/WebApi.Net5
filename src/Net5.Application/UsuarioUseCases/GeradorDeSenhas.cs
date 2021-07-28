using Net5.Application.Interfaces;
using Net5.Application.UsuarioUseCases.Validations;
using System;
using System.Linq;

namespace Net5.Application.UsuarioUseCases
{
    public class GeradorDeSenhas : IGeradorDeSenhas
    {
        const string CARACTERES_ESPECIAIS = "#?!@$%^&*-_";
        const string CARACTERES_MINUSCULOS = "abcdefghijklmnopqrstuvwxyz";
        const string CARACTERES_MAIUSCULOS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string CARACTERES_GERAIS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789#?!@$%^&*-_";
        public string GerarSenha()
        {
            var senhaGerada = GerarSequencia();

            while (!SenhaValidator.Validar(senhaGerada))
                senhaGerada = GerarSequencia();

            return senhaGerada;
        }

        private static string GerarSequencia()
        {
            return string.Format("{0}{1}{2}{3}",
                Ramdomizar(CARACTERES_ESPECIAIS, 1),
                Ramdomizar(CARACTERES_MINUSCULOS, 1),
                Ramdomizar(CARACTERES_MAIUSCULOS, 1),
                Ramdomizar(CARACTERES_GERAIS, 12));
        }

        private static string Ramdomizar(string caracteres, int tamanho)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(caracteres, tamanho)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
