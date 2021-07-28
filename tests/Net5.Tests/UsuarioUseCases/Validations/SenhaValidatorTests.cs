using Net5.Application.UsuarioUseCases.Validations;
using Xunit;

namespace Net5.Tests.UsuarioUseCases.Validations
{
    public class SenhaValidatorTests
    {

        [Theory]
        [InlineData("Aa123@123012345")]
        [InlineData("Aa123_123012345")]
        [InlineData("Aa123#123012345")]
        [InlineData("Aa123%123012345")]
        [InlineData("Aa123&123012345")]
        [InlineData("Aa123!123012345")]
        [InlineData("Aa123^123012345")]
        [InlineData("Aa123-123012345")]
        [InlineData("Aa123?123012345")]
        [InlineData("Aa123?123012345?123012345?123012345?123012345?123012345?123012345")]
        public void DeveValidarSenhaCorreta(string senha)
        {
            // Arrange                        

            // Act
            var result = SenhaValidator.Validar(senha);

            // Assert
            Assert.True(result, $"Não validou senha: {senha}");

        }


        [Theory]
        [InlineData("AX123@123012345")]
        [InlineData("AX123_123012345")]
        [InlineData("AX123#123012345")]
        [InlineData("AX123%123012345")]
        [InlineData("AX123&123012345")]
        [InlineData("AX123!123012345")]
        [InlineData("AX123^123012345")]
        [InlineData("AX123-123012345")]
        [InlineData("AX123?123012345")]
        public void NaoDeveValidarSemCaracterMinusculo(string senha)
        {
            // Arrange            


            // Act
            var result = SenhaValidator.Validar(senha);

            // Assert
            Assert.False(result);

        }


        [Theory]
        [InlineData("AA123@123012345")]
        [InlineData("A1123_123012345")]
        [InlineData("AX12##123012345")]
        [InlineData("111123%113012345")]
        [InlineData("AX123&1230&&345")]
        [InlineData("AX123!123012345")]
        [InlineData("AX123^1230123^^")]
        [InlineData("AX123-1230123bb")]
        [InlineData("aa123?123012345")]
        public void NaoDeveValidarCaracterRepetidoEmSequencia(string senha)
        {


            // Act
            var result = SenhaValidator.Validar(senha);

            // Assert
            Assert.False(result);

        }





        [Fact]
        public void NaoDeveValidarAusenciaDeCaracterEspecial()
        {
            // Arrange            
            string senha = "AB1938123012345";

            // Act
            var result = SenhaValidator.Validar(senha);

            // Assert
            Assert.False(result);

        }


        [Fact]
        public void NaoDeveValidarSenhaMenorQue15Caracteres()
        {
            // Arrange            
            string senha = "AB19381230";

            // Act
            var result = SenhaValidator.Validar(senha);

            // Assert
            Assert.False(result);

        }


    }
}
