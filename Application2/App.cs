using Microsoft.Extensions.Caching.Distributed;
using Services.Extensions;
using Services.Models;

namespace Application2
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
            Console.WriteLine("Application2: Hibernate thread...");
            Thread.Sleep(5000); // Simulate some delay to ensure Application1 has set the data
            Console.WriteLine("Application2: Thread active");

            Console.WriteLine("Application2: Reading cache data");
            var data = await _distributedCache.GetRecoredAsync<DataModel>("Application1Data");

            Console.WriteLine(data.ToString());

            Console.ReadKey();
        }
    }
}
