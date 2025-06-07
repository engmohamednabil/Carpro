using Carpro.Application.Common.Interfaces;
using Carpro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carpro.Infrastructure.Data.Repositories;

/// <summary>
/// Repository implementation for Vehicle entity
/// </summary>
public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(CarproDbContext context) : base(context)
    {
    }

    /*public async Task<Vehicle?> GetByRegNumAsync(int regNum)
    {
        return await _dbSet.FirstOrDefaultAsync(v => v.VehicleRegNum == regNum);
    }*/
    public async Task<Vehicle?> GetByRegNumAsync(int regNum)
    {
        // Add this line to check all vehicles in the database
        var allVehicles = await _dbSet.ToListAsync();
        Console.WriteLine($"Found {allVehicles.Count} vehicles in the database");
        foreach (var vehicle in allVehicles)
        {
            Console.WriteLine($"Vehicle: {vehicle.VehicleRegNum}, {vehicle.VehicleModel}, {vehicle.VehicleProdYear}");
        }

        return await _dbSet.FirstOrDefaultAsync(v => v.VehicleRegNum == regNum);
    }

}

