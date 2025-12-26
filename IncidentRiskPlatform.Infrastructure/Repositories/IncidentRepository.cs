using IncidentRiskPlatform.Application.Interfaces;
using IncidentRiskPlatform.Domain.Entities;
using IncidentRiskPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IncidentRiskPlatform.Infrastructure.Repositories;

public sealed class IncidentRepository : IIncidentRepository
{
    private readonly AppDbContext _db;

    public IncidentRepository(AppDbContext db) => _db = db;

    public async Task<Incident> AddAsync(Incident incident, CancellationToken ct)
    {
        _db.Incidents.Add(incident);
        await _db.SaveChangesAsync(ct);
        return incident;
    }

    public Task<Incident?> GetByIdAsync(Guid id, CancellationToken ct) =>
        _db.Incidents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<List<Incident>> QueryAsync(
        DateTimeOffset? from,
        DateTimeOffset? to,
        int? severityMin,
        int? severityMax,
        string? sourceSystem,
        string? category,
        string? locationCode,
        int page,
        int pageSize,
        CancellationToken ct)
    {
        var q = _db.Incidents.AsNoTracking().AsQueryable();

        if (from is not null) q = q.Where(x => x.OccurredAt >= from.Value.ToUniversalTime());
        if (to is not null) q = q.Where(x => x.OccurredAt <= to.Value.ToUniversalTime());

        if (severityMin is not null) q = q.Where(x => x.Severity >= severityMin);
        if (severityMax is not null) q = q.Where(x => x.Severity <= severityMax);

        if (!string.IsNullOrWhiteSpace(sourceSystem)) q = q.Where(x => x.SourceSystem == sourceSystem);
        if (!string.IsNullOrWhiteSpace(category)) q = q.Where(x => x.Category == category);
        if (!string.IsNullOrWhiteSpace(locationCode)) q = q.Where(x => x.LocationCode == locationCode);

        page = page < 1 ? 1 : page;
        pageSize = pageSize is < 1 or > 200 ? 50 : pageSize;

        return await q.OrderByDescending(x => x.OccurredAt)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize)
                      .ToListAsync(ct);
    }
}
