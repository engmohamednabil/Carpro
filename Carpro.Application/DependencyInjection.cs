using System.Reflection;
using Carpro.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Carpro.Application;

/// <summary>
/// Extension methods for setting up application services in an IServiceCollection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds application services to the specified IServiceCollection
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to</param>
    /// <returns>The IServiceCollection so that additional calls can be chained</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        });
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}

