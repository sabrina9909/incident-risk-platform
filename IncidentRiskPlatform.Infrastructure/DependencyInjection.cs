using IncidentRiskPlatform.Application.Interfaces;
using IncidentRiskPlatform.Application.Services;
using IncidentRiskPlatform.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentRiskPlatform.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIrpServices(this IServiceCollection services)
    {
        services.AddScoped<IIncidentRepository, IncidentRepository>();
        services.AddScoped<IncidentService>();
        return services;
    }
}
