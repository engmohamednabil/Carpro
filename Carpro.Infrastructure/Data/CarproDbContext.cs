using Carpro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carpro.Infrastructure.Data;

/// <summary>
/// The database context for the application
/// </summary>
public class CarproDbContext : DbContext
{
    public CarproDbContext(DbContextOptions<CarproDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the vehicles DbSet
    /// </summary>
    public DbSet<Vehicle> Vehicles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarproDbContext).Assembly);

    }
}

