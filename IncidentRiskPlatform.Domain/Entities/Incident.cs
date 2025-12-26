namespace IncidentRiskPlatform.Domain.Entities;

public sealed class Incident
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public DateTimeOffset OccurredAt { get; private set; }
    public string SourceSystem { get; private set; } = default!;
    public string Category { get; private set; } = default!;
    public int Severity { get; private set; } // 1..5
    public string? LocationCode { get; private set; }

    private Incident() { } // EF Core needs this

    public Incident(DateTimeOffset occurredAt, string sourceSystem, string category, int severity, string? locationCode)
    {
        if (string.IsNullOrWhiteSpace(sourceSystem)) throw new ArgumentException("SourceSystem is required.");
        if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException("Category is required.");
        if (severity is < 1 or > 5) throw new ArgumentOutOfRangeException(nameof(severity), "Severity must be 1..5.");

        OccurredAt = occurredAt;
        SourceSystem = sourceSystem.Trim();
        Category = category.Trim();
        Severity = severity;
        LocationCode = string.IsNullOrWhiteSpace(locationCode) ? null : locationCode.Trim();
    }
}
