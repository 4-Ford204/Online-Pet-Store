using FastEndpoints;
using OPS.Infrastructure;
using OPS.UseCases;
using System.Reflection;

namespace Customer.API.Registrations
{
    public class SystemRegistration : IRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFastEndpoints();
            services.AddInfrastructure();

            var assemblies = new[] { Assembly.GetAssembly(typeof(UseCasesRegistration)) };

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies!));

        }
    }
}
