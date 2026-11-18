using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Catalog.Module;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<DatabaseOptions>()
            .Bind(configuration.GetSection("Database"))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddHealthChecks()
            .AddCheck<DatabaseHealthCheck>("catalog-database");
        return services;
    }
}