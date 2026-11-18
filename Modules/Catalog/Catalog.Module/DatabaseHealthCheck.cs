using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Catalog.Module;

internal sealed class DatabaseHealthCheck(IOptions<DatabaseOptions> options) : IHealthCheck
{
    private readonly string _connectionString =
        options.Value.ConnectionString;

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);

            await using var command = connection.CreateCommand();

            command.CommandText = "SELECT 1";

            await command.ExecuteScalarAsync(cancellationToken);

            return HealthCheckResult.Healthy("Database healthy");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy("Database is unhealthy", e);
        }
    }
}