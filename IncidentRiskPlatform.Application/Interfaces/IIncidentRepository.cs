using IncidentRiskPlatform.Domain.Entities;

namespace IncidentRiskPlatform.Application.Interfaces;

public interface IIncidentRepository
{
    Task<Incident> AddAsync(Incident incident, CancellationToken ct);
    Task<Incident?> GetByIdAsync(Guid id, CancellationToken ct);

    Task<List<Incident>> QueryAsync(
        DateTimeOffset? from,
        DateTimeOffset? to,
        int? severityMin,
        int? severityMax,
        string? sourceSystem,
        string? category,
        string? locationCode,
        int page,
        int pageSize,
        CancellationToken ct);
}
