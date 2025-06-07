using System.Net;
using System.Text.Json;
using Carpro.Application.Common.Exceptions;
using Carpro.Domain.Exceptions;

namespace Carpro.Api.Middleware;

/// <summary>
/// Middleware for handling exceptions globally
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (exception)
        {
            case Application.Common.Exceptions.ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new
                {
                    title = "Validation Error",
                    status = (int)statusCode,
                    errors = validationException.Errors
                });
                break;

            case Application.Common.Exceptions.NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new
                {
                    title = "Resource Not Found",
                    status = (int)statusCode,
                    detail = exception.Message
                });
                break;

            case InvalidVehicleRegistrationException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new
                {
                    title = "Invalid Registration Number",
                    status = (int)statusCode,
                    detail = exception.Message
                });
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                result = JsonSerializer.Serialize(new
                {
                    title = "Server Error",
                    status = (int)statusCode,
                    detail = _environment.IsDevelopment() ? exception.Message : "An error occurred while processing your request."
                });
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(result);
    }
}

