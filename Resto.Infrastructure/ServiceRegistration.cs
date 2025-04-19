using Microsoft.Extensions.DependencyInjection;
using Resto.Domain;

namespace Resto.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDomain();
        return services;
    }
}