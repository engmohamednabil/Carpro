using Carpro.Application.Vehicles.DTOs;
using MediatR;

namespace Carpro.Application.Vehicles.Queries.GetVehicleByRegNum;

/// <summary>
/// Query to get a vehicle by its registration number
/// </summary>
public class GetVehicleByRegNumQuery : IRequest<VehicleDto>
{
    /// <summary>
    /// Gets or sets the registration number to search for
    /// </summary>
    public int RegNum { get; set; }
}

