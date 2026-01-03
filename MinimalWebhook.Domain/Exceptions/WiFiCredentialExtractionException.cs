namespace MinimalWebhook.Domain.Exceptions;

public class WiFiCredentialExtractionException : Exception
{
    public WiFiCredentialExtractionException(string message) : base(message) { }
    public WiFiCredentialExtractionException(string message, Exception innerException) : base(message, innerException) { }
}
