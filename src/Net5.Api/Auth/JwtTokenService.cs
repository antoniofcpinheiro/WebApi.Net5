using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Net5.Application.Interfaces;
using Net5.Application.UsuarioUseCases.Request;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net5.Api.Auth
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UsuarioRequest request)
        {

            var secret = _configuration["ApiSettings:Secret"];
            var expires = Convert.ToInt32(_configuration["ApiSettings:Expires"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, request.Usuario)
                }),
                Expires = DateTime.UtcNow.AddMinutes(expires),
                SigningCredentials = new SigningCredentials(
                     new SymmetricSecurityKey(key),
                     SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
