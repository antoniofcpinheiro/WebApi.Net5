using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net5.Api.StartupConfig;

namespace Net5.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services) =>        
            services
                .ConfigureServices()
                .ResolveDependencies()
                .AddJwtConfig(Configuration)
                .AddSwaggerConfig();        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app.Configure(env);        
    }
}
