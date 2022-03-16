using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace JR.P262605.API
{
    public class APIHost
    {
        public static Task RunAsync(CancellationToken stoppingToken)
        {
            return CreateHostBuilder().Build().RunAsync(stoppingToken);
        }

        public static IHostBuilder CreateHostBuilder()
        {
            IHostBuilder HostBuilder = Host.CreateDefaultBuilder();

            Microsoft.Extensions.Logging.ILogger Logger = new LoggerFactory()
                .AddSerilog(new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(Path.Combine(new FileInfo(AppDomain.CurrentDomain.BaseDirectory).Directory.Parent.FullName, "Logs\\API-LOG-.txt"),
                    rollingInterval: RollingInterval.Hour,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
                .CreateLogger()).CreateLogger("API");

            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("apiConfig.json", true).Build();

            HostBuilder.ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService(serviceProvider =>
                {
                    return new APIService(Logger, Configuration);
                });
            });

            HostBuilder.ConfigureAppConfiguration(app =>
            {
                app.AddJsonFile("config.json", true);
            });

            return HostBuilder;
        }
    }
}
