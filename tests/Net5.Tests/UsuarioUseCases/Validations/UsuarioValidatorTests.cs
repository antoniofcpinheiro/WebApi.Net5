using Net5.Application.UsuarioUseCases.Request;
using Net5.Application.UsuarioUseCases.Validations;
using Xunit;

namespace Net5.Tests.UsuarioUseCase.Validations
{
    public class UsuarioValidatorTests
    {

        [Fact]
        public void DeveValidarUsuarioESenhaCorreto()
        {
            // Arrange
            var usuarioValidator = new UsuarioValidator();
            var usuario = new UsuarioRequest
              { 
                Senha = "Aa123@123012345", 
                Usuario = "APINHEIRO" 
            };

            // Act
            var result = usuarioValidator
                .Validar(usuario);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void NaoDeveValidarUsuarioVazio()
        {
            // Arrange
            var usuarioValidator = new UsuarioValidator();
            var usuario = new UsuarioRequest { Senha = "Aa123@123012345" };

            // Act
            var result = usuarioValidator
                .Validar(usuario);

            // Assert
            Assert.False(result);
        }

    }
}
