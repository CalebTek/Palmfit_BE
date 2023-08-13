using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Palmfit.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
//    .AddEnvironmentVariables()
//    .Build();

var maxUserWatches = builder.Configuration.GetValue<int>("MaxUserWatches");
if (maxUserWatches > 0)
{
    var fileSystemWatcher = new FileSystemWatcher("/")
    {
        EnableRaisingEvents = true
    };
    var maxFiles = maxUserWatches / 2;
    fileSystemWatcher.InternalBufferSize = maxFiles * 4096;
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextAndConfigurations(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Seeder.SeedData(app).Wait();

app.UseAuthorization();

app.MapControllers();


app.Run();