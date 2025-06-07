using Carpro.Application.Common.Exceptions;
using Carpro.Application.Common.Interfaces;
using Carpro.Application.Vehicles.DTOs;
using MediatR;

namespace Carpro.Application.Vehicles.Queries.GetVehicleByRegNum;

/// <summary>
/// Handler for the GetVehicleByRegNum query
/// </summary>
public class GetVehicleByRegNumQueryHandler : IRequestHandler<GetVehicleByRegNumQuery, VehicleDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleByRegNumQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<VehicleDto> Handle(GetVehicleByRegNumQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _unitOfWork.Vehicles.GetByRegNumAsync(request.RegNum);

        if (vehicle == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Vehicle), request.RegNum);
        }

        return new VehicleDto
        {
            VehicleRegNum = vehicle.VehicleRegNum,
            VehicleModel = vehicle.VehicleModel,
            VehicleProdYear = vehicle.VehicleProdYear
        };
    }
}

