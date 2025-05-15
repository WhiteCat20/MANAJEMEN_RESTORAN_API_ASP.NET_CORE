using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Resto.Domain;
using Resto.Infrastructure.Configuration;

namespace Resto.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<DatabaseContext, SqlDatabaseContext>(options =>
            options.UseNpgsql(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(
                        typeof(ServiceRegistration).Assembly.FullName);
                })
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );
        services.AddDomain();
        return services;
    }
}