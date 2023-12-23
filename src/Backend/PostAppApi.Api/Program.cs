using Microsoft.EntityFrameworkCore;
using PostAppApi.Api.Configuration;
using PostAppApi.Application.Implementations;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Infrastructure;
using PostAppApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("MysqlConnection");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<PostAppApiContext>(
    options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddScoped<DbContext, PostAppApiContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.UseAutoMapperConfiguration();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
