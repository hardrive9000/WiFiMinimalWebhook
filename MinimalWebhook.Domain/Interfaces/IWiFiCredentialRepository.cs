using MinimalWebhook.Domain.Entities;

namespace MinimalWebhook.Domain.Interfaces;

public interface IWiFiCredentialRepository
{
    Task<List<WiFiCredentialEntity>> SaveAsync(List<WiFiCredentialEntity> wiFiCredentialEntities, string? ipAddress);
}
