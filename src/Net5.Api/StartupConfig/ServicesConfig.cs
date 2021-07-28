using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Net5.Api.StartupConfig
{
    public static class ServicesConfig
    {
        public static IServiceCollection ConfigureServices( this IServiceCollection services)
        {

            services.AddControllers();

            return services;
        }
    }
}
