using FastEndpoints;
using FastEndpoints.Swagger;

namespace Customer.API.Registrations
{
    public class FastEndpointsRegistration : IRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddFastEndpoints()
                .SwaggerDocument(config =>
                {
                    config.DocumentSettings = settings =>
                    {
                        settings.Title = "Customer API";
                        settings.Version = "v1";
                    };
                });
        }
    }
}
