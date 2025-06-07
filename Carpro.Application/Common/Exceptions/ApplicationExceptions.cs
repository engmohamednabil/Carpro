namespace Carpro.Application.Common.Exceptions;

/// <summary>
/// Base exception for application exceptions
/// </summary>
public abstract class ApplicationException : Exception
{
    protected ApplicationException(string message) : base(message)
    {
    }
}

/// <summary>
/// Exception thrown when validation fails
/// </summary>
public class ValidationException : ApplicationException
{
    public ValidationException(IReadOnlyDictionary<string, string[]> errors)
        : base("One or more validation failures have occurred.")
    {
        Errors = errors;
    }

    public IReadOnlyDictionary<string, string[]> Errors { get; }
}

/// <summary>
/// Exception thrown when a requested entity is not found
/// </summary>
public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}

