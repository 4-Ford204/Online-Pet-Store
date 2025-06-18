using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OPS.Infrastructure.Implementations.ExternalServices.Caching;
using OPS.Infrastructure.Implementations.ExternalServices.Messaging;

namespace OPS.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCacheService(configuration);

            services.AddMassTransitService(configuration);

            services.AddServices();
        }
    }
}
