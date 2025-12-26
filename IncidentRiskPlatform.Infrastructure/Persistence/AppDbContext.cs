using IncidentRiskPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncidentRiskPlatform.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public DbSet<Incident> Incidents => Set<Incident>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incident>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.OccurredAt).IsRequired();
            b.Property(x => x.SourceSystem).HasMaxLength(100).IsRequired();
            b.Property(x => x.Category).HasMaxLength(100).IsRequired();
            b.Property(x => x.Severity).IsRequired();
            b.Property(x => x.LocationCode).HasMaxLength(50);
            b.HasIndex(x => x.OccurredAt);
        });
    }
}
