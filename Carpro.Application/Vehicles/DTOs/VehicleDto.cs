namespace Carpro.Application.Vehicles.DTOs;

/// <summary>
/// Data Transfer Object for Vehicle entity
/// </summary>
public class VehicleDto
{
    /// <summary>
    /// Gets or sets the vehicle registration number
    /// </summary>
    public int VehicleRegNum { get; set; }

    /// <summary>
    /// Gets or sets the vehicle model
    /// </summary>
    public string VehicleModel { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the vehicle production year
    /// </summary>
    public string VehicleProdYear { get; set; } = string.Empty;
}

