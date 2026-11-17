using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Module;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services)
    {
        return services;
    }
}