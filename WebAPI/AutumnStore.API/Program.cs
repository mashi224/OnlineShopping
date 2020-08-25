using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace AutumnStore.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            // .WriteTo.File(new RenderedCompactJsonFormatter(), "/logs/log.ndjson")
                            // .WriteTo.Seq("http://localhost:5341")
                            // Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341")
                            .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
                            .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
