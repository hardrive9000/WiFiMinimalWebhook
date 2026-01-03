namespace MinimalWebhook.Application.DTOs;

public record WebhookResponseDto(
    bool IsSuccess,
    string Message,
    DateTime Timestamp,
    int BodyLength);
