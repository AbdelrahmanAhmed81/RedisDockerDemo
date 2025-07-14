using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecord<T>(this IDistributedCache cache ,
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
        }
    }
}
