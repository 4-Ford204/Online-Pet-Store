using Customer.API.Abstractions.Registrations;
using OPS.UseCases;
using System.Reflection;

namespace Customer.API.Registrations
{
    public class MediatrRegistration : IRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = new[] { Assembly.GetAssembly(typeof(UseCasesRegistration)) };

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies!));
        }
    }
}
