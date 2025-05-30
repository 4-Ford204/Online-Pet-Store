using Microsoft.EntityFrameworkCore;
using OPS.Infrastructure.MSSQL;
using OPS.Infrastructure.MSSQL.DataSeeding;

namespace Customer.API.Registrations
{
    public class DatabaseRegistration : IRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

            Seeding.InitializeAsync(dbContext).GetAwaiter().GetResult();
        }
    }
}
