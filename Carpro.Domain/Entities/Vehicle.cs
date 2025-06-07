using Carpro.Domain.Exceptions;

namespace Carpro.Domain.Entities;

/// <summary>
/// Represents a vehicle entity in the domain
/// </summary>
public class Vehicle
{
    // Constants for validation
    private const int MinRegNum = 1;
    private const int MaxRegNum = 100000;
    private const int MinModelLength = 1;
    private const int MaxModelLength = 50;
    private const int MinProdYearLength = 4;
    private const int MaxProdYearLength = 4;

    // Private backing fields
    private int _vehicleRegNum;
    private string _vehicleModel = string.Empty;
    private string _vehicleProdYear = string.Empty;

    // Private constructor for EF Core
    private Vehicle()
    {
    }

    /// <summary>
    /// Creates a new Vehicle instance
    /// </summary>
    /// <param name="vehicleRegNum">The vehicle registration number</param>
    /// <param name="vehicleModel">The vehicle model</param>
    /// <param name="vehicleProdYear">The vehicle production year</param>
    public Vehicle(int vehicleRegNum, string vehicleModel, string vehicleProdYear)
    {
        SetVehicleRegNum(vehicleRegNum);
        SetVehicleModel(vehicleModel);
        SetVehicleProdYear(vehicleProdYear);
    }

    /// <summary>
    /// Gets the vehicle registration number
    /// </summary>
    public int VehicleRegNum => _vehicleRegNum;

    /// <summary>
    /// Gets the vehicle model
    /// </summary>
    public string VehicleModel => _vehicleModel;

    /// <summary>
    /// Gets the vehicle production year
    /// </summary>
    public string VehicleProdYear => _vehicleProdYear;

    /// <summary>
    /// Sets the vehicle registration number with validation
    /// </summary>
    /// <param name="regNum">The registration number to set</param>
    /// <exception cref="InvalidVehicleRegistrationException">Thrown when the registration number is invalid</exception>
    public void SetVehicleRegNum(int regNum)
    {
        if (regNum < MinRegNum || regNum > MaxRegNum)
        {
            throw new InvalidVehicleRegistrationException(regNum);
        }

        _vehicleRegNum = regNum;
    }

    /// <summary>
    /// Sets the vehicle model with validation
    /// </summary>
    /// <param name="model">The model to set</param>
    /// <exception cref="ArgumentException">Thrown when the model is invalid</exception>
    public void SetVehicleModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model) || model.Length < MinModelLength || model.Length > MaxModelLength)
        {
            throw new ArgumentException($"Vehicle model must be between {MinModelLength} and {MaxModelLength} characters", nameof(model));
        }

        _vehicleModel = model;
    }

    /// <summary>
    /// Sets the vehicle production year with validation
    /// </summary>
    /// <param name="prodYear">The production year to set</param>
    /// <exception cref="ArgumentException">Thrown when the production year is invalid</exception>
    public void SetVehicleProdYear(string prodYear)
    {
        if (string.IsNullOrWhiteSpace(prodYear) || prodYear.Length != 4 || !int.TryParse(prodYear, out _))
        {
            throw new ArgumentException("Vehicle production year must be a 4-digit year", nameof(prodYear));
        }

        _vehicleProdYear = prodYear;
    }

    /// <summary>
    /// Validates if the vehicle is of a specific model
    /// </summary>
    /// <param name="model">The model to check</param>
    /// <returns>True if the vehicle is of the specified model, false otherwise</returns>
    public bool IsModel(string model)
    {
        return string.Equals(_vehicleModel, model, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Validates if the vehicle was produced in a specific year
    /// </summary>
    /// <param name="year">The year to check</param>
    /// <returns>True if the vehicle was produced in the specified year, false otherwise</returns>
    public bool IsProducedInYear(string year)
    {
        return string.Equals(_vehicleProdYear, year, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Validates if the vehicle was produced after a specific year
    /// </summary>
    /// <param name="year">The year to check</param>
    /// <returns>True if the vehicle was produced after the specified year, false otherwise</returns>
    public bool IsProducedAfterYear(string year)
    {
        if (int.TryParse(_vehicleProdYear, out int prodYear) && int.TryParse(year, out int compareYear))
        {
            return prodYear > compareYear;
        }

        return false;
    }

    /// <summary>
    /// Validates if the vehicle was produced before a specific year
    /// </summary>
    /// <param name="year">The year to check</param>
    /// <returns>True if the vehicle was produced before the specified year, false otherwise</returns>
    public bool IsProducedBeforeYear(string year)
    {
        if (int.TryParse(_vehicleProdYear, out int prodYear) && int.TryParse(year, out int compareYear))
        {
            return prodYear < compareYear;
        }

        return false;
    }

    /// <summary>
    /// Creates a string representation of the vehicle
    /// </summary>
    /// <returns>A string representation of the vehicle</returns>
    public override string ToString()
    {
        return $"{_vehicleModel} ({_vehicleProdYear}) - Reg# {_vehicleRegNum}";
    }
}

