using Catalog.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.DbConfiguration;

public class CatalogDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Venue> Venues { get; set; }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }
}