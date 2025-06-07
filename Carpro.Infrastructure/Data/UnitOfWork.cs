using Carpro.Application.Common.Interfaces;
using Carpro.Infrastructure.Data.Repositories;

namespace Carpro.Infrastructure.Data;

/// <summary>
/// Implementation of the unit of work pattern
/// </summary>
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly CarproDbContext _context;
    private IVehicleRepository? _vehicleRepository;
    private bool _disposed;

    public UnitOfWork(CarproDbContext context)
    {
        _context = context;

        EnsureDatabaseSeeded();
    }

    private void EnsureDatabaseSeeded()
    {
        try
        {
            // Check if database is empty
            if (!_context.Vehicles.Any())
            {
                // Add seed data directly
                var vehicles = new[]
                {
                    new Domain.Entities.Vehicle(23432, "Toyota", "2020"),
                    new Domain.Entities.Vehicle(45634, "Honda", "2019"),
                    new Domain.Entities.Vehicle(36436, "Ford", "2021"),
                    new Domain.Entities.Vehicle(36774, "Chevrolet", "2018"),
                    new Domain.Entities.Vehicle(55775, "Dodge", "2022"),
                    new Domain.Entities.Vehicle(74757, "Nissan", "2020"),
                    new Domain.Entities.Vehicle(75747, "Jeep", "2023"),
                    new Domain.Entities.Vehicle(97964, "Subaru", "2017"),
                    new Domain.Entities.Vehicle(66832, "Mazda", "2021")
                };

                _context.Vehicles.AddRange(vehicles);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
        }
    }

    public IVehicleRepository Vehicles => _vehicleRepository ??= new VehicleRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}

