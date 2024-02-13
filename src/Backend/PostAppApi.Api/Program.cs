using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PostAppApi.Api.Configuration;
using PostAppApi.Infrastructure;
using System.Text;
using System.Text.Json.Serialization;
using Serilog;
using PostAppApi.Api.Middlewares;

try
{
    var builder = WebApplication.CreateBuilder(args);

    SerilogExtension.AddSerilogApi(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);

    var AllowOrigin = "AllowOrigin";
    var origins = builder.Configuration["AllowedHosts"];
    var connection = builder.Configuration.GetConnectionString("MysqlConnection");
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:Secret"]);

    builder.Services.AddControllers().AddJsonOptions(
        x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().
         AllowAnyHeader());
    });

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddDbContext<PostAppApiContext>(
        options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));


    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

    builder.Services.AddScoped<DbContext, PostAppApiContext>();

    builder.Services.UseDependecyInjectionConfiguration();

    builder.Services.UseAutoMapperConfiguration();

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseMiddleware<ErrorHandlingMiddleware>();
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
    }

    app.UseCors("AllowOrigin");

    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    app.UseAuthentication();

    app.MapGet("/", () => $"Post App Api em {builder.Configuration["env"]}");

    app.UseAuthorization();

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