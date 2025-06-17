using Microsoft.EntityFrameworkCore;
using OPS.Infrastructure;
using OPS.Infrastructure.MSSQL;
using OPS.UseCases;
using System.Reflection;

namespace Pet.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            #region SERVICES

            services.AddControllers();

            services.AddOpenApi();

            var assemblies = new[] { Assembly.GetAssembly(typeof(UseCasesRegistration)) };
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies!));

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });

            services.AddInfrastructure(configuration);

            #endregion

            var app = builder.Build();

            #region APP

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
