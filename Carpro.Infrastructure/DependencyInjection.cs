using Carpro.Application.Common.Interfaces;
using Carpro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carpro.Infrastructure;

/// <summary>
/// Extension methods for setting up infrastructure services in an IServiceCollection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds infrastructure services to the specified IServiceCollection
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to</param>
    /// <param name="configuration">The configuration instance</param>
    /// <returns>The IServiceCollection so that additional calls can be chained</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<CarproDbContext>(options =>
            options.UseInMemoryDatabase("CarproDB"));

        // Add repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

