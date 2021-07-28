using Microsoft.Extensions.DependencyInjection;
using Net5.Api.Auth;
using Net5.Application.Interfaces;
using Net5.Application.UsuarioUseCases;
using Net5.Application.UsuarioUseCases.Validations;

namespace Net5.Api.StartupConfig
{
    public static class DependencyIinjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IGeradorDeSenhas, GeradorDeSenhas>();
            services.AddScoped<IUsuarioValidator, UsuarioValidator>();
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();

            return services;
        }
    }
}
