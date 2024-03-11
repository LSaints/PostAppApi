using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using PostAppApi.Api.Configuration;
using PostAppApi.Infrastructure;
using System.Text.Json.Serialization;
using Serilog;
using PostAppApi.Api.Middlewares;
using PostAppApi.Api.Extensions;
using PostAppApi.Api.Middlewares.ExceptionsMiddleware;

try
{
    var builder = WebApplication.CreateBuilder(args);

    SerilogExtension.AddSerilogApi(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);

    var origins = builder.Configuration["AllowedHosts"];
    var connection = builder.Configuration.GetConnectionString("MysqlConnection");
    

    builder.Services.AddControllers().AddJsonOptions(
        x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(origins, options => options.AllowAnyOrigin().AllowAnyMethod().
         AllowAnyHeader());
    });

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddDbContext<PostAppApiContext>(
        options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));


    builder.Services.UseJwtAuthentication(builder);

    builder.Services.AddScoped<DbContext, PostAppApiContext>();

    builder.Services.UseDependecyInjectionConfiguration();

    builder.Services.UseAutoMapperConfiguration();

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    app.UseMiddleware<RequestSerilLogMiddleware>();

    using var scope = app.Services.CreateScope();
    await using var dbContext = scope.ServiceProvider.GetRequiredService<PostAppApiContext>();
    await dbContext.Database.MigrateAsync();

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UsePrometheus();
    }

    app.UseCors(origins);

    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    app.UseAuthentication();

    app.MapGet("", () => $"Post App Api em {builder.Configuration["env"]}");

    app.UseAuthorization();

    app.UsePrometheus();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host foi encerrado inesperadamente");
}
finally
{
    Log.Information("Servidor desligando...");
    Log.CloseAndFlush();
}