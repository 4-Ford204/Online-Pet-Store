using Microsoft.Extensions.DependencyInjection;

namespace OPS.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddServices();
        }
    }
}
