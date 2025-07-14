using MinimalWebhook.Application.Interfaces;
using MinimalWebhook.Domain.Entities;
using MinimalWebhook.Domain.Interfaces;
using MinimalWebhook.Domain.Models;

namespace MinimalWebhook.Application.Services;

public class WiFiCredentialService(IWiFiCredentialRepository repository, ILoggingService loggingService) : IWiFiCredentialService
{
    public async Task<List<WiFiCredentialEntity>> SaveCredentialsAsync(List<WiFiCredential> wiFiCredentials, string? ipAddress)
    {
        try
        {
            DateTime timestamp = DateTime.UtcNow;

            List<WiFiCredentialEntity> wiFiCredentialEntities = [.. wiFiCredentials.Select(wfc => new WiFiCredentialEntity
            {
                NetworkName = wfc.NetworkName,
                Password = wfc.Password,
                CreatedAt = timestamp,
                IpAddress = ipAddress
            })];

            return await repository.SaveAsync(wiFiCredentialEntities, ipAddress);
        }
        catch (Exception ex)
        {
            await loggingService.LogErrorAsync("Unexpected error processing Wi-Fi credentials", ex);
            throw;
        }
    }
}
