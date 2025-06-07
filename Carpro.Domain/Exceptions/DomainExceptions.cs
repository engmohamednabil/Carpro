namespace Carpro.Domain.Exceptions;

/// <summary>
/// Base exception for domain exceptions in the application
/// </summary>
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message)
    {
    }
}

/// <summary>
/// Exception thrown when a vehicle is not found
/// </summary>
public class VehicleNotFoundException : DomainException
{
    public VehicleNotFoundException(int regNum)
        : base($"Vehicle with registration number {regNum} was not found.")
    {
        RegNum = regNum;
    }

    public int RegNum { get; }
}

/// <summary>
/// Exception thrown when a vehicle registration number is invalid
/// </summary>
public class InvalidVehicleRegistrationException : DomainException
{
    public InvalidVehicleRegistrationException(int regNum)
        : base($"Vehicle registration number {regNum} is invalid.")
    {
        RegNum = regNum;
    }

    public int RegNum { get; }
}

