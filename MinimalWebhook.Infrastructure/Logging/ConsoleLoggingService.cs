using MinimalWebhook.Domain.Interfaces;
using MinimalWebhook.Domain.Models;

namespace MinimalWebhook.Infrastructure.Logging;

public class ConsoleLoggingService : ILoggingService
{
    public async Task LogInfoAsync(string info)
    {
        await Task.Run(() =>
        {
            Console.WriteLine($"Date/Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"INFO: {info}");
        });
    }

    public async Task LogCredentialsExtractedAsync(List<WiFiCredential> credentials)
    {
        await Task.Run(() =>
        {
            foreach (WiFiCredential credential in credentials)
            {
                Console.WriteLine($"SSID: '{credential.NetworkName}' - Password: '{credential.Password}'");
            }
        });
    }

    public async Task LogErrorAsync(string message, Exception? exception = null)
    {
        await Task.Run(() =>
        {
            Console.WriteLine($"ERROR: {message}");
            if (exception != null)
            {
                Console.WriteLine($"Description: {exception.Message}");
            }
        });
    }
}
