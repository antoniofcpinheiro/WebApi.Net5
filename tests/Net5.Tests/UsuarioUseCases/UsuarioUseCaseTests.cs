using Moq;
using Net5.Application.Interfaces;
using Net5.Application.UsuarioUseCases.Request;

using Xunit;

namespace Net5.Tests.UsuarioUseCases
{
    public class UsuarioUseCaseTests
    {
        private MockRepository _mockRepository;

        private Mock<IJwtTokenService> _mockJwtTokenService;
        private Mock<IUsuarioValidator> _mockUsuarioValidator;
        private Mock<IGeradorDeSenhas> _mockGeradorDeSenhas;

        public UsuarioUseCaseTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);
            _mockJwtTokenService = _mockRepository.Create<IJwtTokenService>();
            _mockUsuarioValidator = _mockRepository.Create<IUsuarioValidator>();
            _mockGeradorDeSenhas = _mockRepository.Create<IGeradorDeSenhas>();

            
        }

        private IUsuarioUseCase CreateUsuarioUseCase()
        {
            return new Application.UsuarioUseCases.UsuarioUseCase(
                _mockJwtTokenService.Object,
                _mockUsuarioValidator.Object,
                _mockGeradorDeSenhas.Object);
        }

        [Fact]
        public void DeveValidarSenhaGeradaUseCase()
        {
            // Arrange
            var senhaCorreta = "1234567890@aA_*";

            _mockGeradorDeSenhas
                .Setup(s => s.GerarSenha())
                .Returns(senhaCorreta);

            var usuarioUseCase = this.CreateUsuarioUseCase();


            // Act
            var result = usuarioUseCase
                .GerarSenha();

            // Assert
            Assert.True(result.Equals("1234567890@aA_*"));
            this._mockRepository.Verify();
        }

        [Fact]
        public void DeveValidarTokenGeradoUseCase()
        {
            // Arrange
            var senhaCorreta = "1234567890@aA_*";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFudG9uaW8iLCJuYmYiOjE2Mjc0MzgxODQsImV4cCI6MTYyNzQzODQ4NCwiaWF0IjoxNjI3NDM4MTg0fQ.LclO_2yK3KRbLragHrbCRH_kbvulratbMKu1WLFka2I";

            var usuarioRequest = new UsuarioRequest
            {
                Usuario = "APINHEIRO",
                Senha = senhaCorreta
            };

            _mockJwtTokenService
                .Setup(s => s.GenerateToken(usuarioRequest))
                .Returns(token);

            _mockUsuarioValidator
                .Setup(s => s.Validar(usuarioRequest))
                .Returns(true);

            var usuarioUseCase = this
                .CreateUsuarioUseCase();

            // Act
            var result = usuarioUseCase
                .GerarToken(usuarioRequest);

            // Assert
            Assert.True(result.Token.Equals(token),
                        "Token inválido");

            Assert.True(result.Token.Equals(token) && result.Autenticado,
                        "Não deve gerar token para não autenticados");

            this._mockRepository.Verify();
        }


        [Fact]
        public void NaoDeveValidarTokenGeradoSenhaInvalidaUseCase()
        {
            // Arrange
            var senha = "1";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFudG9uaW8iLCJuYmYiOjE2Mjc0MzgxODQsImV4cCI6MTYyNzQzODQ4NCwiaWF0IjoxNjI3NDM4MTg0fQ.LclO_2yK3KRbLragHrbCRH_kbvulratbMKu1WLFka2I";

            var usuarioRequest = new UsuarioRequest
            {
                Usuario = "APINHEIRO",
                Senha = senha
            };

            _mockJwtTokenService
                .Setup(s => s.GenerateToken(usuarioRequest))
                .Returns(token);

            _mockUsuarioValidator
                .Setup(s => s.Validar(usuarioRequest))
                .Returns(false);

            var usuarioUseCase = this
                .CreateUsuarioUseCase();

            // Act
            var result = usuarioUseCase
                .GerarToken(usuarioRequest);

            // Assert
            Assert.True(string.IsNullOrEmpty(result.Token), "Não deveria ter gerado Token");

            Assert.True(string.IsNullOrEmpty(result.Token) && !result.Autenticado, "Não deve gerar token para não autenticados");

            this._mockRepository.Verify();
        }

    }
}
