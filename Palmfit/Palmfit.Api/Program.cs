using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Palmfit.Api.Extensions;
using Palmfit.Data.AppDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextAndConfigurations(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Add appsettings.json configuration
var config = app.Services.GetRequiredService<IConfiguration>();
var env = app.Environment;
var configBuilder = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables();
config = configBuilder.Build();

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