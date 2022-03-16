using ApiGateway;
using Microsoft.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
           .UseKestrel()
           .UseContentRoot(Directory.GetCurrentDirectory())
           .ConfigureAppConfiguration((hostingContext, config) =>
           {
               config
                   .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                   .AddJsonFile("appsettings.json", true, true)
                   .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                   .AddJsonFile("ocelot.json", true, true)
                   .AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                   .AddEnvironmentVariables();
           })
           .ConfigureLogging((hostingContext, logging) =>
           {
               logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
               logging.AddConsole();
           })
           .UseStartup<APIStartup>();
}