using System.ComponentModel.DataAnnotations;

namespace MinimalWebhook.Domain.Entities;

public class WiFiCredentialEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(32)]
    public string NetworkName { get; set; } = string.Empty;

    [Required]
    [MaxLength(63)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    public string? IpAddress { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
