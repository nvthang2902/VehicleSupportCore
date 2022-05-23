using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace VehicleSupport
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host= CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var sevices = scope.ServiceProvider;
                var loggerFactory = sevices.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = sevices.GetRequiredService<VehicleDBContext>();
                    await context.Database.MigrateAsync();
                    await VehicleDBContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (System.Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
