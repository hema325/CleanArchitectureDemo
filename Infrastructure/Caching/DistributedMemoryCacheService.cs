using Application.Common.Interfaces.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Caching
{
    internal class DistributedMemoryCacheService : ICacheService
    {
        private static readonly HashSet<string> _cachedKeys = new();
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<DistributedMemoryCacheService> _logger;

        public DistributedMemoryCacheService(IDistributedCache distributedCache, ILogger<DistributedMemoryCacheService> logger)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public async Task<TItem?> GetAsync<TItem>(string key, CancellationToken cancellationToken = default) 
        {
            var bytes = await _distributedCache.GetAsync(key,cancellationToken);
            if (bytes != null)
                return JsonSerializer.Deserialize<TItem>(Encoding.UTF8.GetString(bytes!))!;

            return default(TItem);
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync(key,cancellationToken);
            _logger.LogInformation("Key {key} is removed from the cache", key);

            _cachedKeys.Remove(key);
        }

        public async Task SetAsync<TItem>(string key, TItem value, TimeSpan? slidingExpiration = null, CancellationToken cancellationToken = default)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));
            await _distributedCache.SetAsync(key, bytes, new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            },cancellationToken);
            _logger.LogInformation("Key {key} is added to the cache", key);

            _cachedKeys.Add(key);
        }

        public async Task ClearAsync(CancellationToken cancellationToken = default)
        {
            var tasks = _cachedKeys.Select(key => _distributedCache.RemoveAsync(key, cancellationToken));

            await Task.WhenAll(tasks);

            _logger.LogInformation("Cache is cleared");
        }

        public async Task RemoveAsync(Func<string,bool> filter,CancellationToken cancellationToken = default)
        {
            var tasks = _cachedKeys.Where(filter).Select(key => _distributedCache.RemoveAsync(key, cancellationToken));

            await Task.WhenAll(tasks);
        }
    }
}
