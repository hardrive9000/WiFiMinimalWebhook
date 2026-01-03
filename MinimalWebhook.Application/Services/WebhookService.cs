using MinimalWebhook.Application.DTOs;
using MinimalWebhook.Application.Interfaces;
using MinimalWebhook.Domain.Interfaces;
using MinimalWebhook.Domain.Models;

namespace MinimalWebhook.Application.Services;

public class WebhookService(IWiFiCredentialExtractor credentialExtractor, IWiFiCredentialService credentialService, ILoggingService loggingService) : IWebhookService
{
    public async Task<WebhookResponseDto> ProcessWebhookAsync(string body, string? ipAddress)
    {
        try
        {
            await loggingService.LogInfoAsync(body);

            List<WiFiCredential> credentials = await credentialExtractor.ExtractCredentialsAsync(body);
            await loggingService.LogCredentialsExtractedAsync(credentials);
            await credentialService.SaveCredentialsAsync(credentials, ipAddress);

            return new WebhookResponseDto(
                IsSuccess: true,
                Message: "ack",
                Timestamp: DateTime.Now,
                BodyLength: body.Length
            );
        }
        catch (Exception ex)
        {
            await loggingService.LogErrorAsync($"Error processing webhook: {ex.Message}", ex);

            return new WebhookResponseDto(
                IsSuccess: false,
                Message: ex.Message,
                Timestamp: DateTime.Now,
                BodyLength: 0
            );
        }
    }
}
