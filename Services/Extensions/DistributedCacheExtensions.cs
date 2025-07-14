using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Services.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache ,
                                              string recordId ,
                                              T data ,
                                              TimeSpan? absoluteExpireTime = null ,
                                              TimeSpan? unusedExpiredTime = null)
        {
            var cacheOptions = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.Add(absoluteExpireTime ?? TimeSpan.FromSeconds(60)) ,
                SlidingExpiration = unusedExpiredTime
            };

            var jsonData = JsonSerializer.Serialize(data);

            await cache.SetStringAsync(recordId , jsonData , cacheOptions);
        }

        public static async Task<T> GetRecoredAsync<T>(this IDistributedCache cache , string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);
            if (jsonData is null)
            {
                return default;
            }

            T value = JsonSerializer.Deserialize<T>(jsonData);
            return value;
        }
    }
}
