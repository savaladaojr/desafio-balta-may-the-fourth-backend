using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Vehicles.Queries.GetById;

public class VehicleGetByIdQuery : BaseGetByIdQuery, IRequest<VehicleDTO?>
{
}
