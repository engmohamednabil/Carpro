using FluentValidation;

namespace Carpro.Application.Vehicles.Queries.GetVehicleByRegNum;

/// <summary>
/// Validator for the GetVehicleByRegNum query
/// </summary>
public class GetVehicleByRegNumQueryValidator : AbstractValidator<GetVehicleByRegNumQuery>
{
    public GetVehicleByRegNumQueryValidator()
    {
        RuleFor(v => v.RegNum)
            .NotEmpty().WithMessage("Registration number is required.")
            .GreaterThan(0).WithMessage("Registration number must be greater than 0.")
            .LessThan(100000).WithMessage("Registration number must be less than 100000.");
    }
}

