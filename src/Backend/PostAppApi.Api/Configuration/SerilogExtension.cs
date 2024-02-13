using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace PostAppApi.Api.Configuration
{
    public static class SerilogExtension
    {
        public static void AddSerilogApi(this IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithMachineName()
                .Enrich.WithExceptionDetails()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
