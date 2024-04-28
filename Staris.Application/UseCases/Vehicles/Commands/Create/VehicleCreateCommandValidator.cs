using FluentValidation;
using Staris.Application.UseCases.Films.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Application.UseCases.Vehicles.Commands.Create;

public sealed class VehicleCreateCommandValidator : AbstractValidator<VehicleCreateCommand>
{
	public VehicleCreateCommandValidator()
	{


	}

}
