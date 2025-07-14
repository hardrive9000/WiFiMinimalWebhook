using MinimalWebhook.Domain.Exceptions;
using MinimalWebhook.Domain.Interfaces;
using MinimalWebhook.Domain.Models;
using System.Text.RegularExpressions;

namespace MinimalWebhook.Infrastructure.Services;

public class WiFiCredentialExtractor(ILoggingService loggingService) : IWiFiCredentialExtractor
{
    public async Task<List<WiFiCredential>> ExtractCredentialsAsync(string content)
    {
        List<WiFiCredential> credentials = [];
        if (string.IsNullOrWhiteSpace(content))
        {
            return credentials;
        }
        
        try
        {
            return await Task.Run(() =>
            {
                string pattern = @"Wi-Fi-([^:]+\.xml):.*?<keyMaterial>([^<]+)</keyMaterial>";
                MatchCollection matches = Regex.Matches(content, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                
                foreach (Match match in matches)
                {
                    if (match.Success && match.Groups.Count >= 3)
                    {
                        string networkName = match.Groups[1].Value.Trim();
                        string password = match.Groups[2].Value.Trim();
                        credentials.Add(new WiFiCredential(networkName[..^4], password));
                    }
                }
                
                return credentials;
            });
        }
        catch (Exception ex)
        {
            await loggingService.LogErrorAsync($"Error extracting Wi-Fi credentials: {ex.Message}", ex);
            throw new WiFiCredentialExtractionException($"Failed extracting Wi-Fi credentials: {ex.Message}", ex);
        }
    }
}
