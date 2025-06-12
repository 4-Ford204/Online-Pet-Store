using OPS.UseCases.Interfaces.ExternalServices;

namespace OPS.Infrastructure.Implementations.ExternalServices.Caching
{
    public class NoCacheService : ICacheService
    {
        public Task<string?> GetAsync(string key) => Task.FromResult<string?>(null);

        public Task SetAsync(string key, object value, TimeSpan? expiration = null) => Task.CompletedTask;

        public Task<bool> RemoveAsync(string key) => Task.FromResult(true);

        public Task<bool> RemovePatternAsync(string pattern) => Task.FromResult(true);
    }
}
