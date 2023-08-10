using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Caching
{
    public interface ICacheService
    {
        Task ClearAsync(CancellationToken cancellationToken = default);
        Task<TItem?> GetAsync<TItem>(string key, CancellationToken cancellationToken = default);
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
        Task RemoveAsync(Func<string, bool> filter, CancellationToken cancellationToken = default);
        Task SetAsync<TItem>(string key, TItem value, TimeSpan? slidingExpiration = null, CancellationToken cancellationToken = default);
    }
}
