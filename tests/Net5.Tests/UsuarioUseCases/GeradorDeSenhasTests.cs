using Net5.Application.UsuarioUseCases;
using Net5.Application.UsuarioUseCases.Validations;
using Xunit;

namespace Net5.Tests.UsuarioUseCase
{
    public class GeradorDeSenhasTests
    {
        [Fact]
        public void DeveValidarSenhaGerada()
        {
            // Arrange
            var geradorDeSenhas = new GeradorDeSenhas();

            // Act
            var senha = geradorDeSenhas
                .GerarSenha();

            // Assert
            Assert.True(SenhaValidator.Validar(senha));
        }
    }
}
