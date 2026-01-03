using MinimalWebhook.Domain.Entities;
using MinimalWebhook.Domain.Models;

namespace MinimalWebhook.Application.Interfaces;

public interface IWiFiCredentialService
{
    Task<List<WiFiCredentialEntity>> SaveCredentialsAsync(List<WiFiCredential> wiFiCredentials, string? ipAddress);
}
