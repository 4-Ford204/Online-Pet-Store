namespace OPS.UseCases.Interfaces.ExternalServices
{
    public interface ICacheService
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, object value, TimeSpan? expiration = null);
        Task<bool> RemoveAsync(string key);
        Task<bool> RemovePatternAsync(string pattern);
    }
}
