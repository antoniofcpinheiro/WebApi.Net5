using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Net5.Api.StartupConfig
{
    public static class SwaggerConfig
    {

        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net5.Api", Version = "v1" });
            });

            return services;
        }

    }
}
