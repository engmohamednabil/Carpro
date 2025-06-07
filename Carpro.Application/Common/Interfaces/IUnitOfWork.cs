using Carpro.Domain.Entities;

namespace Carpro.Application.Common.Interfaces;

/// <summary>
/// Interface for the unit of work pattern
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the repository for the Vehicle entity
    /// </summary>
    IVehicleRepository Vehicles { get; }

    /// <summary>
    /// Saves all changes made in this context to the database
    /// </summary>
    /// <returns>The number of state entries written to the database</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Generic repository interface
/// </summary>
/// <typeparam name="T">The entity type</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Gets all entities
    /// </summary>
    /// <returns>A collection of all entities</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Gets an entity by its id
    /// </summary>
    /// <param name="id">The id to search for</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<T?> GetByIdAsync(object id);

    /// <summary>
    /// Adds a new entity
    /// </summary>
    /// <param name="entity">The entity to add</param>
    Task AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity
    /// </summary>
    /// <param name="entity">The entity to update</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an entity
    /// </summary>
    /// <param name="entity">The entity to delete</param>
    void Delete(T entity);
}

/// <summary>
/// Repository interface for Vehicle entity
/// </summary>
public interface IVehicleRepository : IRepository<Vehicle>
{
    /// <summary>
    /// Gets a vehicle by its registration number
    /// </summary>
    /// <param name="regNum">The registration number to search for</param>
    /// <returns>The vehicle if found, null otherwise</returns>
    Task<Vehicle?> GetByRegNumAsync(int regNum);
}

