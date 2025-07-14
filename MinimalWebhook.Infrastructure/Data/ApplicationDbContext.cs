using MinimalWebhook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MinimalWebhook.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<WiFiCredentialEntity> WiFiCredentials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WiFiCredentialEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.NetworkName).IsRequired().HasMaxLength(32);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(63);
            entity.Property(e => e.IpAddress).HasMaxLength(15);
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
