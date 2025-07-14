using Microsoft.Extensions.Caching.Distributed;
using Services.Extensions;
using Services.Models;

namespace Application1
{
    public class App
    {
        private readonly IDistributedCache _distributedCache;

        public App(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task RunAsync(string[] args)
        {
            var data = new DataModel
            {
                Id = 1 ,
                Name = "Application1" ,
                Description = "This is a sample application using Redis Cache" ,
                TimeStamp = DateTime.Now
            };
            Console.WriteLine("Application1: Setting cache data");
            await _distributedCache.SetRecordAsync("Application1Data" , data);
            Console.WriteLine("Application1: Cache data set");

            Console.ReadKey();
        }
    }
}
