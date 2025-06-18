using Customer.API.Abstractions.Registrations;
using Microsoft.AspNetCore.Http.Json;
using OPS.Infrastructure;

namespace Customer.API.Registrations
{
    public class SystemRegistration : IRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JsonOptions>(config => config.SerializerOptions.PropertyNamingPolicy = null);

            services.AddInfrastructure(configuration);
        }
    }
}
