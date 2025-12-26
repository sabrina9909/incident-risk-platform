using IncidentRiskPlatform.Application.Interfaces;
using IncidentRiskPlatform.Domain.Entities;

namespace IncidentRiskPlatform.Application.Services;

public sealed class IncidentService
{
    private readonly IIncidentRepository _repo;

    public IncidentService(IIncidentRepository repo) => _repo = repo;

    public Task<Incident> CreateAsync(Incident incident, CancellationToken ct) =>
        _repo.AddAsync(incident, ct);

    public Task<Incident?> GetByIdAsync(Guid id, CancellationToken ct) =>
        _repo.GetByIdAsync(id, ct);

    public Task<List<Incident>> QueryAsync(
        DateTimeOffset? from,
        DateTimeOffset? to,
        int? severityMin,
        int? severityMax,
        string? sourceSystem,
        string? category,
        string? locationCode,
        int page,
        int pageSize,
        CancellationToken ct) =>
        _repo.QueryAsync(from, to, severityMin, severityMax, sourceSystem, category, locationCode, page, pageSize, ct);
}
