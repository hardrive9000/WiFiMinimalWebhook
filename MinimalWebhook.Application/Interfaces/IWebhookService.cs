using MinimalWebhook.Application.DTOs;

namespace MinimalWebhook.Application.Interfaces;

public interface IWebhookService
{
    Task<WebhookResponseDto> ProcessWebhookAsync(string body, string? ipAddress);
}
