using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace BackgroundWorkerInAppService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(builder => 
                {
                    builder.AddApplicationInsights();
                    builder.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);

                })
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
