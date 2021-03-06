using System;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace API
{
    public class Program
    {
        /*public static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(
            new ConfigurationOptions{
                EndPoints = {"localhost:6379"}                
            });*/

        public static async Task Main(string[] args)
        {   
            /*var db = redis.GetDatabase();
            var pong = await db.PingAsync();
            Console.WriteLine(pong);*/

            var host = CreateHostBuilder(args).Build();

            // Create database base on Migration
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                { 
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory); // Seed data to database from Json files
                }
                catch(Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration.");
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
