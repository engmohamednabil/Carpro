using Carpro.Application.Vehicles.DTOs;
using Carpro.Application.Vehicles.Queries.GetVehicleByRegNum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carpro.Api.Controllers;

/// <summary>
/// Controller for vehicle-related endpoints
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<VehiclesController> _logger;

    public VehiclesController(IMediator mediator, ILogger<VehiclesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Gets a vehicle by its registration number
    /// </summary>
    /// <param name="regNum">The registration number to search for</param>
    /// <returns>The vehicle if found</returns>
    [HttpGet("{regNum}")]
    [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VehicleDto>> GetVehicleByRegNum(int regNum)
    {
        _logger.LogInformation("Getting vehicle with registration number {RegNum}", regNum);

        var query = new GetVehicleByRegNumQuery { RegNum = regNum };
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}

