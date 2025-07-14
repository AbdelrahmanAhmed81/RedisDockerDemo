using Application2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace RedisDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection servicesCollection = ConfigureServices();
            var servicesBuilder = servicesCollection.BuildServiceProvider();
            await servicesBuilder.GetService<App>().RunAsync(args);
        }

        static IServiceCollection ConfigureServices()
        {
            var configuration = LoadConfiguration();

            IServiceCollection services = new ServiceCollection();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "RedisDemo_";
            });

            return services;
        }

        static IConfiguration LoadConfiguration()
        {
            //var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json" , optional: false , reloadOnChange: true);
            //.AddJsonFile($"appsettings.{environmentName}.json" , false , true);

            return builder.Build();
        }
    }
}
