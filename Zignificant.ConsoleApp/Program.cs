using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Zignificant.Data;
using Zignificant.Repository;

namespace Zignificant.ConsoleApp
{
    class Program
    {
        private static IConfiguration Configuration;

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var worker = ActivatorUtilities.CreateInstance<Worker>(host.Services);
            worker.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context,configuration) =>
                {
                    configuration.Sources.Clear();
                    var env = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");
                    configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    Configuration = configuration.Build();
                })
                .ConfigureServices((context,services)=>
                {
                    string connString = Configuration.GetConnectionString("DefaultConnection"); 
                    services.AddScoped<IBirthdateRepository, BirthdateRepository>();
                    services.AddScoped<IBirthdates, Birthdates>((IServiceProvider serviceProvider) => new Birthdates(connString));
                });
        }
    }
}
