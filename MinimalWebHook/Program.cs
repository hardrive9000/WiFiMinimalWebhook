using Microsoft.EntityFrameworkCore;
using MinimalWebhook.Application.Interfaces;
using MinimalWebhook.Application.Services;
using MinimalWebhook.Domain.Interfaces;
using MinimalWebhook.Infrastructure.Data;
using MinimalWebhook.Infrastructure.Logging;
using MinimalWebhook.Infrastructure.Repositories;
using MinimalWebhook.Infrastructure.Services;
using System.Text.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register application services
builder.Services.AddScoped<IWiFiCredentialRepository, WiFiCredentialRepository>();
builder.Services.AddScoped<IWiFiCredentialService, WiFiCredentialService>();
builder.Services.AddScoped<IWebhookService, WebhookService>();
builder.Services.AddScoped<ILoggingService, ConsoleLoggingService>();
builder.Services.AddScoped<IWiFiCredentialExtractor, WiFiCredentialExtractor>();

// Configure JSON options
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
});

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await context.Database.EnsureCreatedAsync();
}

app.UseRouting();
app.MapControllers();

app.Run();
