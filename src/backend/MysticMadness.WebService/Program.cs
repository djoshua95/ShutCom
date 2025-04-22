using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MysticMadness.Model;
using MysticMadness.Service;
using MysticMadness.Service.Mapping;
using MysticMadness.WebService.Auth;
using MysticMadness.WebService.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MysticMadnessDB")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Invoke custom extension methods
builder.Services.AddServices();
builder.Services.AddMapping();

// Auth
builder.Services.AddAuth(builder.Configuration);

// Configure JSON loops handling
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Configure swagger in dev environments
List<string> devEnvironments = ["Development", "Docker"];
if (devEnvironments.Contains(builder.Environment.EnvironmentName))
{
    builder.Services.ConfigureSwagger(builder.Configuration);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (devEnvironments.Contains(app.Environment.EnvironmentName))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
