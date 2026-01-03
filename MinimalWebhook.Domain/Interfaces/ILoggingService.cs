using MinimalWebhook.Domain.Models;

namespace MinimalWebhook.Domain.Interfaces;

public interface ILoggingService
{
    Task LogInfoAsync(string info);
    Task LogCredentialsExtractedAsync(List<WiFiCredential> credentials);
    Task LogErrorAsync(string message, Exception? exception = null);
}