using Customer.API.Registrations;
using FastEndpoints;

namespace Customer.API
{
    public static class RegisterExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var registrations = typeof(Program).Assembly.ExportedTypes
                .Where(t => typeof(IRegistration).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IRegistration>()
                .ToList();

            registrations.ForEach(registration =>
            {
                registration.RegisterServices(services, configuration);
            });
        }

        public static void ConfigureRequestPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseFastEndpoints();
        }
    }
}
