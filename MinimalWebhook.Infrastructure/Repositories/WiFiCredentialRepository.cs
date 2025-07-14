using Microsoft.Data.Sqlite;
using MinimalWebhook.Domain.Entities;
using MinimalWebhook.Domain.Interfaces;
using MinimalWebhook.Infrastructure.Data;

namespace MinimalWebhook.Infrastructure.Repositories;

public class WiFiCredentialRepository(ApplicationDbContext context, ILoggingService loggingService) : IWiFiCredentialRepository
{
    public async Task<List<WiFiCredentialEntity>> SaveAsync(List<WiFiCredentialEntity> wiFiCredentialEntities, string? ipAddress)
    {
		try
		{
			context.WiFiCredentials.AddRange(wiFiCredentialEntities);
			await context.SaveChangesAsync();

			return wiFiCredentialEntities;
		}
		catch (SqliteException ex)
		{
            await loggingService.LogErrorAsync("SQLite error while saving Wi-Fi credentials", ex);
            throw new InvalidOperationException("Failed to save Wi-Fi credentials due to SQLite error", ex);
        }
        catch (Exception ex)
        {
            await loggingService.LogErrorAsync("Unexpected error while saving Wi-Fi credentials", ex);
            throw;
        }
    }
}
