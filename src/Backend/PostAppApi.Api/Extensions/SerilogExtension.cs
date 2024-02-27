using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace PostAppApi.Api.Extensions
{
    public static class SerilogExtension
    {
        public static void AddSerilogApi(this IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithMachineName()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
