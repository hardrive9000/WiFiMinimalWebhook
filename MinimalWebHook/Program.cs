using MinimalWebhook.Application.Interfaces;
using MinimalWebhook.Application.Services;
using MinimalWebhook.Domain.Interfaces;
using MinimalWebhook.Infrastructure.Logging;
using MinimalWebhook.Infrastructure.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register application services
builder.Services.AddScoped<IWebhookService, WebhookService>();
builder.Services.AddScoped<ILoggingService, ConsoleLoggingService>();
builder.Services.AddScoped<IWiFiCredentialExtractor, WiFiCredentialExtractor>();

// Configure JSON options
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
