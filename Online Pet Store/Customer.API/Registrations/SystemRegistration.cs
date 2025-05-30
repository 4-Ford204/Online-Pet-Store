using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http.Json;
using OPS.Infrastructure;

namespace Customer.API.Registrations
{
    public class SystemRegistration : IRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JsonOptions>(config => config.SerializerOptions.PropertyNamingPolicy = null);

            services.AddFastEndpoints();
            services.SwaggerDocument(config =>
            {
                config.DocumentSettings = settings =>
                {
                    settings.Title = "Customer API";
                    settings.Version = "v1";
                };
            });

            services.AddInfrastructure();
        }
    }
}
