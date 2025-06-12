using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OPS.UseCases.Interfaces.ExternalServices;
using StackExchange.Redis;

namespace OPS.Infrastructure.Implementations.ExternalServices.Caching
{
    public static class CacheRegistration
    {
        public static void AddCacheService(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("CacheConfiguration");

            if (section.Exists())
            {
                var enabled = section.GetValue<bool>("Enabled");

                if (enabled)
                {
                    var provider = section.GetValue<string>("Provider");

                    switch (provider)
                    {
                        case "Redis":
                            var redis = section.GetSection("Redis");
                            var connectionString = redis.GetValue<string>("ConnectionString");

                            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(connectionString!));
                            services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);
                            services.AddSingleton<ICacheService, RedisCacheService>();

                            return;
                        default:
                            break;
                    }
                }
            }

            services.AddSingleton<ICacheService, NoCacheService>();
        }
    }
}
