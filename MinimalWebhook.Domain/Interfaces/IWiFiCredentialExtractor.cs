using MinimalWebhook.Domain.Models;

namespace MinimalWebhook.Domain.Interfaces;

public interface IWiFiCredentialExtractor
{
    Task<List<WiFiCredential>> ExtractCredentialsAsync(string content);
}
