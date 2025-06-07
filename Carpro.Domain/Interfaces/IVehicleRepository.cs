using Carpro.Domain.Entities;

namespace Carpro.Domain.Interfaces;

/// <summary>
/// Repository interface for Vehicle entity
/// </summary>
public interface IVehicleRepository
{
    /// <summary>
    /// Gets a vehicle by its registration number
    /// </summary>
    /// <param name="regNum">The registration number to search for</param>
    /// <returns>The vehicle if found, null otherwise</returns>
    Task<Vehicle?> GetByRegNumAsync(int regNum);

    /// <summary>
    /// Gets all vehicles
    /// </summary>
    /// <returns>A collection of all vehicles</returns>
    Task<IEnumerable<Vehicle>> GetAllAsync();

    /// <summary>
    /// Adds a new vehicle
    /// </summary>
    /// <param name="vehicle">The vehicle to add</param>
    Task AddAsync(Vehicle vehicle);

    /// <summary>
    /// Updates an existing vehicle
    /// </summary>
    /// <param name="vehicle">The vehicle to update</param>
    Task UpdateAsync(Vehicle vehicle);

    /// <summary>
    /// Deletes a vehicle by its registration number
    /// </summary>
    /// <param name="regNum">The registration number of the vehicle to delete</param>
    Task DeleteAsync(int regNum);
}

